class Dashboard extends React.Component {
    constructor(props) {
        super(props);
    }

    handleClick() {
        //yay this works! now plugin logic
    }

    render() {
        return (
            <div className="application">
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
                                        <Tile onUserInput={this.handleClick} tileName="Summer 2016"></Tile>
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
