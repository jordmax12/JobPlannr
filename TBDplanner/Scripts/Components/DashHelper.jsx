class Contributor extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            loading: false
        };
    }

    render() {
        return (
            <div className="container-fluid pad-top-10"> 
              <div className="row">
                <div className="col-sm-4">
                    <div className="contributerImage"></div>
                </div>
                <div className="col-sm-4">
                    One of three columns
                </div>
                <div className="col-sm-4">
                    One of three columns
                </div>
              </div>
            </div>
        );
    };
}