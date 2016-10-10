class Tasks extends React.Component {
    
    constructor(props) {
        super(props);

        this.state = {
            editableTasks: [],
            tasks: [],
            subTasks: [],
            editableSubTasks: [], 
            plannerId: this.props.plannerId,
        };

        var state = this.state;

        
    }

    getIndex(value, arr) {
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

    AddSubTaskObject(taskId, newSubTaskId) {
        var data = this.state.tasks[taskId];
        //create new object
        var subTaskObject = {
            Id : newSubTaskId,
            Name :"Inject Me",
            Status : "",
            Level : 1,
            Subtasks : [],
            Created: '',
            Modified : '',
            TaskId : taskId
        };
        //grab the task object
        var taskObjectKey = this.state.tasks[taskId - 1];

        //add new object to task object
        taskObjectKey.SubTasks.push(subTaskObject);
        
        //update tasks
        this.state.tasks[taskId - 1] = taskObjectKey;
        this.forceUpdate();

    }

    AddSubTask(taskId) {
        //create subtask object
        var subTaskObject = {
            Name: 'Inject Name',
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
                console.log(data);
                //return the new subtask id back here
                this.AddSubTaskObject(taskId, data.ReturnObject.Id);
                //this.setState({ tasks: data.ReturnObject, loading: false });
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
        } else {
            var index = this.getIndex(indexedTask[0], this.state.editableTasks);
            //index should never be -1, but just in case..
            if(index != -1) {
                //remove from array
                this.setState({
                    editableTasks: this.state.editableTasks.filter((_, i) => i !== index)
                });
                //update task
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

    createTask(name) {
        //make api call to create planner here.

        var data = {
            Name: name,
            PlannerId: model.plannerId,
            Status: "Not Complete",
            Description: "",
            Affiliation: "",
            Footprint: "",
            Created: new Date(),
            Modified: null,
        };

        $.ajax({
            type: "POST",
            url: "/Task/Add",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                this.getTasks(model.plannerId);
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
        const tasks = this.state.tasks.map((task) => {
            var editable = this.state.editableTasks.filter(id => id === task.Id).length > 0;
            const subTaskComponents = task.SubTasks.map(subTask => <li key={subTask.Id} className="list-group-item" style={{border: 0, backgroundColor: 'rgba(127,191,63,.42)'}}>{subTask.Name}</li>);
            


            return (
               <li className="list-group-item"  key={task.Id} style={{minHeight: '50px'}}>
                   <div className="pull-left" style={{width: '50%'}}>
                       {editable ? <input type="text" /> : <span>{task.Name}</span>}
                   </div>
                   <div className="pull-right" style={{marginTop: '-5px', width: '50%'}}>
                       <div className="pull-right">
                            <button className="btn btn-default" onClick={() => {this.AddSubTask(task.Id)}}>+</button>
                            <button className="btn btn-default" onClick={() => { this.EditTask(task.Id)}}>{editable ? <i className="fa fa-check"></i> : <i className="fa fa-pencil-square-o"></i>}</button>
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