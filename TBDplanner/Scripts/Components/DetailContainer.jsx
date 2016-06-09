class DetailContainer extends React.Component {
    constructor(props) {
        super(props);

        this.state = { name : this.props.plannerName, loading: false };
    }

   

    render() {
        return (
            <div className="application">
                <div className="container-fluid">
                    <h1>Test</h1> 
                </div>
            </div>
        );
    }
};
ReactDOM.render(
  <DetailContainer />,
  document.getElementById('content')
);