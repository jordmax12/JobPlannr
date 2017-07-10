
class Tasks extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            editableTasks: [],
            editableSubTasks: [], 
            completedTasks: [],
            completedSubTasks: [],
            tasks: [],
            subTasks: [],            
            plannerId: this.props.plannerId,
        };
        this.focusTasks = [];
        this.focusSubTasks = [];
        var state = this.state;

        
    }

    getKey(value, arr) {
        for(var i = 0; i < arr.length; i++) {
            if(arr[i] === value) {
                return i;
            }
        }
        return -1; //to handle the case where the value doesn't exist
    }

    componentDidMount() {
        this.getTasks(this.state.plannerId);
        this.EditTask = this.EditTask.bind(this);
    }

    handleTaskChange(event, index) {
            var tasks = this.state.tasks.slice(); // Make a copy of the tasks first.
            tasks[index].Name = event.target.value; // Update it with the modified task.
            this.setState({tasks: tasks}); // Update the state.
    }

    handleSubTaskChange(event, index, parentIndex) {       
        //react is stupid and doesn't configure the params very well.
        //definitely a hack but...
        var _index = event;
        var _parentIndex = index;
        var _event = parentIndex;

        this.state.tasks[_parentIndex].SubTasks[index].Name = _event.target.value; // Update it with the modified subtask.
        this.setState({tasks: tasks}); // Update the state.
    }

    completeTask(taskId, taskIndex) {
        //grab the task object
        var taskObject = this.state.tasks[taskIndex];  

        //add new object to task object
        taskObject.Status = "Complete";

        //update tasks
        this.state.tasks[taskIndex] = taskObject;
        this.state.completedTasks.push(taskId);
        console.log(this.state.completedTasks);
        this.forceUpdate();
    }

    completeSubTask(subTaskId, taskId, subTaskIndex, taskIndex) {
        //grab the task object
        var taskObject = this.state.tasks[taskIndex];  

        //grab the subTask object
        var subTaskObject = taskObject.SubTasks[subTaskIndex];

        //add new object to task object
        subTaskObject.Status = "Complete";

        //update tasks
        this.state.tasks[taskIndex].SubTasks[subTaskIndex] = subTaskObject;
        this.state.tasks[taskIndex] = taskObject;
        this.state.completedSubTasks.push(subTaskId);
        this.forceUpdate();
    }

    AddSubTaskObject(taskId, newSubTaskId) {
        var _task = this.state.tasks.filter((_, i) => this.state.tasks[i].Id == taskId)[0];
        if(typeof _task !== 'undefined') {
            //create new object
            var subTaskObject = {
                Id : newSubTaskId,
                Name :"New SubTask",
                Status : "",
                Level : 1,
                Subtasks : [],
                Created: '',
                Modified : '',
                TaskId : taskId
            };

            var index = this.getKey(_task, this.state.tasks);

            if(index != -1) {
                //grab the task object
                var taskObject = this.state.tasks[index];  

                //add new object to task object
                taskObject.SubTasks.push(subTaskObject);
        
                //update tasks
                this.state.tasks[index] = taskObject;
                this.forceUpdate();
            } else {
                //error
            }
        }
    }

    AddSubTask(taskId) {
        //create subtask object
        var subTaskObject = {
            Name: 'New Subtask',
            Status: '',
            Level: 1,
            Subtasks: [],
            TaskId: taskId
        };

        //call subtask controller to add
        $.ajax({
            type: "POST",
            url: "/SubTask/Add",
            data: JSON.stringify(subTaskObject),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //return the new subtask id back here
                this.AddSubTaskObject(taskId, data.ReturnObject.Id);
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }

    EditTask(Id) {
        var nextState = this.state;
        //grab the task object, in case we need it
        var indexedTask = this.state.editableTasks.filter(id => id === Id);
        //check whether or not the task already exists
        var alreadyExists = indexedTask.length > 0;
        if(!alreadyExists) {

            //add to array
            nextState.editableTasks.push(Id);
            this.setState(nextState);

            var taskRef = 'task' + Id;
            setTimeout(function() {
                var el = $('input[id="' + taskRef +'"]');
                console.log(el);
                el.focus();
                el.selectionStart = el.selectionEnd = 0;
            }, 1);
        } else {
            var index = this.getKey(indexedTask[0], this.state.editableTasks);
            //index should never be -1, but just in case..
            if(index != -1) {
                var task = this.state.tasks.filter((_, i) => this.state.tasks[i].Id == Id)[0];
                //call subtask controller to add
                $.ajax({
                    type: "POST",
                    url: "/Task/Update",
                    data: JSON.stringify({id : Id, name : task.Name}),
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //return the new subtask id back here
                        //this.AddSubTaskObject(taskId, data.ReturnObject.Id);
                    }.bind(this),
                    error: function (xhr, status, err) {
                        console.log(err);
                    }
                });
                //remove from array
                this.setState({
                    editableTasks: this.state.editableTasks.filter((_, i) => i !== index)
                });
               
            }
        }
    }

    EditSubTask(taskId, subTaskId) {
        var nextState = this.state;
        //get the parent task key
        var _task = this.state.tasks.filter((_, i) => this.state.tasks[i].Id == taskId)[0];
        var index = this.getKey(_task, this.state.tasks);

        if(index != -1) {
            //grab the task object
            var taskObject = this.state.tasks[index];
            //get the subtask key
            var subTaskKey = this.getKey(subTaskId, taskObject.SubTasks);
             //get the subtask object
            var subTaskObject = taskObject.SubTasks[subTaskKey];
            //grab the task object, in case we need it
            var indexedSubTask = this.state.editableSubTasks.filter(id => id === subTaskId);
            //check whether or not the task already exists
            var alreadyExists = indexedSubTask.length > 0;
            var subTaskRef = 'subTask' + subTaskId;
            setTimeout(function() {
                var el = $('input[id="' + subTaskRef +'"]')
                el.focus();
                el.selectionStart = el.selectionEnd = 0;
            }, 1);
            if(!alreadyExists) {
                //add to array
                nextState.editableSubTasks.push(subTaskId);
                $('#' + subTaskRef).focus();
                this.setState(nextState);
            } else {
                //get the editableSubTask key
                var subTaskIndexFromEditable = this.getKey(subTaskId, this.state.editableSubTasks);
                //remove from array
                this.setState({
                    editableSubTasks: this.state.editableSubTasks.filter((_, i) => i !== subTaskIndexFromEditable )
                });

                
                
            }
        }
    }

    updateTask(id, name) {
        $.ajax({
            type: "GET",
            url: "/Task/Update",
            data: { id: id, name: name },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                //this.setState({ tasks: data.ReturnObject, loading: false });
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }

    createTask() {
        //make api call to create planner here.

        var data = {
            Name: "New Task",
            PlannerId: model.plannerId,
            Status: "Not Complete",
            Description: "",
            Affiliation: "",
            Footprint: "",
            Created: new Date(),
            Modified: null,
            SubTasks: []
        };

        $.ajax({
            type: "POST",
            url: "/Task/AddWithReturn",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                //not working correctly yet?
                //adding a subtask for a new task we create here
                //issue with subtasks
                this.state.tasks.push(data.ReturnObject);
                this.forceUpdate();
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }

    getTasks(id) {
        this.setState({ tasks: [], loading: true });
        $.ajax({
            type: "GET",
            url: "/Task/GetAll",
            data: { id: id },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                this.setState({ tasks: data, loading: false });
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }

    render() {
        const tasks = this.state.tasks.map((task, idx) => {
            var editable = this.state.editableTasks.filter(id => id === task.Id).length > 0;
            var editableSubTasks = this.state.editableSubTasks;
            var completedTasks = this.state.completedTasks;
            var completedSubTasks = this.state.completedSubTasks;
            const subTaskComponents = task.SubTasks.map((subTask, indx) => 
                <li key={subTask.Id} className="list-group-item }" style={{minHeight: '50px', border: 0, backgroundColor: (completedTasks.filter(id => id === task.Id).length > 0 || completedSubTasks.filter(id => id === subTask.Id).length > 0 ? 'rgba(204, 255, 204,.42)' : 'rgba(242, 242, 242,.42)')}}>
                        <div className="pull-left" style={{width: '50%'}}>
                            {editableSubTasks.filter(id => id === subTask.Id).length > 0 ? <input className="ui-input-text" type="text" ref={ (ref) => this.focusSubTasks[subTask.Id] = ref }  onChange={this.handleSubTaskChange.bind(this, indx, idx)} value={subTask.Name} id={ `subTask${subTask.Id}` } /> : <span>{subTask.Name}</span>}
                        </div>
                        <div className="pull-right" style={{marginTop: '-5px', width: '50%'}}>
                            <div className="pull-right">
                                <button className="btn btn-default ignore" onClick={() => { this.EditSubTask(task.Id, subTask.Id)}}>{editableSubTasks.filter(id => id === subTask.Id).length > 0  ? <i className="fa fa-floppy-o"></i> : <i className="fa fa-pencil-square-o"></i>}</button>
                                {editableSubTasks.filter(id => id === subTask.Id).length > 0  ?  <div style={{display: 'none' }}></div> : (completedTasks.filter(id => id === task.Id).length > 0 || completedSubTasks.filter(id => id === subTask.Id).length > 0 ? <div style={{display: 'none' }}></div> : <button className="btn btn-default ignore" onClick={() => {this.completeSubTask(subTask.Id, task.Id, indx, idx)}}><i className="fa fa-check"></i></button>)}
                            </div>
                        </div>
                </li>
            );
            return (
               <li className="list-group-item"  key={task.Id} style={{minHeight: '50px', backgroundColor: (completedTasks.filter(id => id === task.Id).length > 0 ? 'rgba(204, 255, 204,.42)' : 'rgba(255, 255, 255,.42)')}}>
                   <div className="pull-left" style={{width: '50%'}}>
                       {editable ? <input className="ui-input-text" type="text" onChange={this.handleTaskChange.bind(this, idx)} value={task.Name} id={ `task${task.Id}` }/> : <span>{task.Name}</span>}
                   </div>
                   <div className="pull-right" style={{marginTop: '-5px', width: '50%'}}>
                       <div className="pull-right">
                            <button className="btn btn-default ignore" onClick={() => {this.AddSubTask(task.Id)}}>+</button>
                            <button className="btn btn-default ignore" onClick={() => { this.EditTask(task.Id)}}>{editable ? <i className="fa fa-floppy-o "></i> : <i className="fa fa-pencil-square-o"></i>}</button>
                            {editable ? <div style={{display: 'none'}}></div> : (completedTasks.filter(id => id === task.Id).length > 0 ? <div style={{display: 'none' }}></div> : <button className="btn btn-default ignore" onClick={() => {this.completeTask(task.Id, idx)}}><i className="fa fa-check"></i></button>)}
                        </div>
                   </div>
                   <br />
                   <ul style={{padding: 0, paddingTop: '10px'}}>
                       {subTaskComponents}
                   </ul>
               </li>
            );
        });
        return (
          <div className="table-wrapper">
            <div className="task-container">
                <h3>{this.props.rowName}</h3>
            </div>
            <ul id="tasksContainer">
                {tasks}
                <li className="list-group-item list-group-item-last"><input type="button" value="Add Task" onClick={this.createTask.bind(this)} className="btn btn-success btn-override" /></li>
            </ul>
          </div>

      );
    }
};