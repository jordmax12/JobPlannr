class DetailContainer extends React.Component {
    constructor(props) {
        super(props);
        var model = this.props.planner;
        this.state = { name: model.name, loading: false };
    }

   

    render() {
        return (
            <div className="application">
                <div className="container-fluid">
                    <h1>{this.state['name']}</h1> 
                </div>
            </div>
        );
    }
};
ReactDOM.render(
  <DetailContainer />,
  document.getElementById('content')
);