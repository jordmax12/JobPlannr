class DetailContainer extends React.Component {
    constructor(props) {
        super(props);

        this.state = { name : '', loading: false };
    }

   

    render() {
        return (
            <div className="application">
                <div className="container-fluid">
                </div>
            </div>
        );
    }
};
ReactDOM.render(
  <DetailContainer />,
  document.getElementById('content')
);