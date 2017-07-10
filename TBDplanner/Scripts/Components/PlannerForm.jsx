class PlannerForm extends React.Component {
    constructor(props) {
        super(props);
    }

    createPlanner() {
        var name = $('#plannerName').val();
        //make api call to create planner here.

        var data = {
            Name: name,
            Created: new Date(),
            Modified: null,
            UserId: userId
        };

        $.ajax({
            type: "POST",
            url: "/Planner/Add",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#plannerForm').modal('toggle');
                this.props.getPlanners();
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }

    render() {
        return (
            <div className="modal fade" id="plannerForm" tabIndex={-1} role="dialog" aria-labelledby="Planner Form" aria-hidden="true">
               <div className="modal-dialog">
                  <div className="modal-content">
                    {/* Modal Header */}
                     <div className="modal-header">
                        <button type="button" className="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span className="sr-only">Close</span>
                        </button>
                        <h4 className="modal-title" id="myModalLabel">
                           New Planner
                        </h4>
                     </div>
                    {/* Modal Body */}
                    <div className="modal-body">
                       <form role="form">
                          <div className="form-group">
                             <label htmlFor="plannerName">Planner Name</label>
                             <input type="text" className="form-control" id="plannerName" placeholder="Summer 2016" />
                          </div>
                          {/* show this only if create */}
                           {/*<button type="submit" className="btn btn-primary">Create</button>*/}
                       </form>
                    </div>
                    {/* Modal Footer */}
                    <div className="modal-footer">
                       <button type="button" className="btn btn-default" data-dismiss="modal">
                       Close
                       </button>
                       <button type="button" className="btn btn-primary" onClick={() => this.createPlanner()}>
                       Create
                       </button>
                    </div>
                 </div>
              </div>
            </div>
        );
        
    };
}



