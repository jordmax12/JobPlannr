class SearchBar extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            loading: false
        };
    }

    render() {
        return (
            <div className="input-group">
                <input type="text" className="form-control" placeholder="Search" aria-describedby="basic-addon1" />
                <span className="input-group-btn">
                    <button className="btn btn-secondary ignore searchAssistant" type="button" data-toggle="modal" data-target="#contributorSearch">Go!</button>
                </span>
            </div>
        );
    };
}