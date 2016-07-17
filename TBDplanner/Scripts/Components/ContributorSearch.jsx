class ContributorSearch extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            loading: false
        };
    }

    render() {
        return (
            <div className="modal fade" id="myModal"> 
                <div className="modal-dialog" role="document">
                  <div className="modal-content">
                    <div className="modal-header">
                      <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                      </button>
                      <h4 className="modal-title">Modal title</h4>
                    </div>
                    <div className="modal-body">
                      <p>One fine body…</p>
                    </div>
                    <div className="modal-footer">
                      <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                      <button type="button" className="btn btn-primary">Save changes</button>
                    </div>
                  </div>
                </div>
              </div>
        );
    };
}