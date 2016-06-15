class EntriesTable extends React.Component{
    constructor(props) {
        super(props);

        this.state = { };
    }

    render() {
        return (
          <div className="table-wrapper">
            <div className="table">
                <div className={this.props.rowClass }>

                  <div className="cell">
                      <div className="float-left">
                          {this.props.rowName}
                      </div>

                      <div className="float-right">
                                              <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-plus" aria-hidden="true" /> Add
                                              </button>
                      </div>
                      
                  </div>
                  <div className="cell">
                      
                  </div>
                  <div className="cell">
                      
                  </div>
                  <div className="cell">
                      
                  </div>
                </div>
                <div className="row clickable-row">
                  <div className="cell">
                      Luke Peters
                  </div>
                  <div className="cell">
                      25
                  </div>
                  <div className="cell">
                      Freelance Web Developer
                  </div>
                  <div className="cell">
                      Brookline, MA
                  </div>
                  <div className="cell">
                    <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-remove" aria-hidden="true" />
                    </button>

                    <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-edit" aria-hidden="true" />
                    </button>
                  </div>
                </div>
                <div className="row clickable-row">
                  <div className="cell">
                      Joseph Smith
                  </div>
                  <div className="cell">
                      27
                  </div>
                  <div className="cell">
                      Project Manager
                  </div>
                  <div className="cell">
                      Somerville, MA
                  </div>
                  <div className="cell">
                    <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-remove" aria-hidden="true" />
                    </button>

                    <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-edit" aria-hidden="true" />
                    </button>
                  </div>
                </div>
                <div className="row clickable-row">
                  <div className="cell">
                      Maxwell Johnson
                  </div>
                  <div className="cell">
                      26
                  </div>
                  <div className="cell">
                      UX Architect &amp; Designer
                  </div>
                  <div className="cell">
                      Arlington, MA
                  </div>
                  <div className="cell">
                    <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-remove" aria-hidden="true" />
                    </button>

                    <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-edit" aria-hidden="true" />
                    </button>
                  </div>
                </div>
                <div className="row clickable-row">
                  <div className="cell">
                      Harry Harrison
                  </div>
                  <div className="cell">
                      25
                  </div>
                  <div className="cell">
                      Front-End Developer
                  </div>
                  <div className="cell">
                      Boston, MA
                  </div>
                  <div className="cell">
                    <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-remove" aria-hidden="true" />
                    </button>

                    <button type="button" className="btn btn-default btn-sm">
                        <span className="glyphicon glyphicon-edit" aria-hidden="true" />
                    </button>
                  </div>
                </div>
            </div>
          </div>

      );
    }
};