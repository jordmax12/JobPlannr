class Dashboard extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            planners: [],
            loading: false
        };
    }

    getPlanners() {
        this.setState({ planners: [], loading: true });
        $('#plannersLoading').show();
        $.ajax({
            type: "GET",
            url: "/Planner/Get",
            data: { id: userId },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                this.setState({ planners: data.ReturnObject, loading: false });
                $('#plannersLoading').hide();
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
                this.setState({ planners: data.ReturnObject, loading: false });
                $('#plannersLoading').hide();
            }
        });
    }

    componentDidMount() {
        $('#loading').hide();
        this.getPlanners();
    }

    addNewPlanner() {
        $('#plannerName').val('');
        $('#plannerForm').modal('toggle');
    }

    goToDetail(id) {
        console.log(id);
    }

    render() {
        const planners = this.state.planners.map((planner) => {
            return (
                <Tile tileName={planner.Name} onDetailClick={() => this.goToDetail(planner.Id)}  key={planner.Id}></Tile>
            );
        });
        return (
            <div className="application">
                <PlannerForm getPlanners={() => this.getPlanners()}></PlannerForm>
                <div className="container-fluid">
                    <div className="row">
                      <div className="col-sm-8">
                        <div id="plannersLoading" style={{}}>
                            <img id="planner-loading-image" src="../../Content/Images/loading.gif" alt="Loading..." />
                        </div>
                        <div className="chart-wrapper">
                          <div className="chart-title">
                              Your Planners 
                          </div>
                          <div className="chart-stage">
                            <div id="grid-1-1">
                                <div className="container" style={{ "width": "100%", "paddingRight": "30px" } }>
                                    <div className="row">
                                        {/*(() => {
                                        //        switch (this.state.loading) {
                                        //            case true: {
                                        //                $('#plannersLoading').show();
                                        //                return { planners };
                                        //            }
                                        //            case false: {
                                        //                $('#plannersLoading').hide();
                                        //                return null;
                                        //            }
                                        //            default: {
                                        //                return "#FFFFFF";
                                        //            }
                                        //        }
                                        //})()*/}
                                        {planners}
                                        <Tile onDetailClick={() => this.addNewPlanner(null)} tileName="Add New +"></Tile>
                                        
                                    </div>

                                </div>
	                        </div>
                          </div>
                          <div className="chart-notes">
                              Notes about this chart
                          </div>
                            </div>
                      </div>
                      <div className="col-sm-4">
                        <div className="chart-wrapper">
                          <div className="chart-title">
                              Cell Title
                          </div>
                          <div className="chart-stage">
                            <img data-src="holder.js/100%x240/white" />
                          </div>
                          <div className="chart-notes">
                              Notes about this chart
                          </div>
                        </div>
                      </div>
                    </div>
                    <div className="row">
                      <div className="col-sm-6 col-md-4">
                        <div className="chart-wrapper">
                          <div className="chart-title">
                              Cell Title
                          </div>
                          <div className="chart-stage">
                            <img data-src="holder.js/100%x120/white" />
                          </div>
                          <div className="chart-notes">
                              Notes about this chart
                          </div>
                        </div>
                      </div>
                      <div className="col-sm-6 col-md-4">
                        <div className="chart-wrapper">
                          <div className="chart-title">
                              Cell Title
                          </div>
                          <div className="chart-stage">
                            <img data-src="holder.js/100%x120/white" />
                          </div>
                          <div className="chart-notes">
                              Notes about this chart
                          </div>
                        </div>
                      </div>
                    </div>
                </div>
            </div>

        );
    };
}
