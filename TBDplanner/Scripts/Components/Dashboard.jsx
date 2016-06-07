class Dashboard extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            planners: []
        };
    }

    getPlanners() {
        $.ajax({
            type: "GET",
            url: "/Planner/Get",
            data: { id: userId },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                this.setState({ planners: data.ReturnObject })
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }

    componentDidMount() {
        this.getPlanners();
    }

    handleClick() {
        $('#plannerForm').modal('show');
    }

    render() {
        const planners = this.state.planners.map((planner) => {
            return (
                <Tile tileName={planner.Name}></Tile>
            );
        });
        return (
            <div className="application">
                <PlannerForm></PlannerForm>
                <div className="container-fluid">
                    <div className="row">
                      <div className="col-sm-8">
                        <div className="chart-wrapper">
                          <div className="chart-title">
                              Cell Title
                          </div>
                          <div className="chart-stage">
                            <div id="grid-1-1">
                                <div className="container" style={{ "width": "100%", "paddingRight": "30px" } }>
                                    <div className="row">
                                        {planners}
                                        <Tile onUserInput={this.handleClick} tileName="Add New +"></Tile>
                                        
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
