class Detail extends React.Component {
    constructor(props) {
        super(props);
        this.state = { name: model.name, created: model.created, plannerid: model.plannerId, loading: false, model: model };
    }

    auth() {
        //$.ajax({
        //    url: this.props.url,
        //    dataType: 'json',
        //    success: function (data) {
        //        this.setState(data);
        //    }.bind(this),
        //    error: function (xhr, status, err) {
        //        console.log(err);
        //    }
        //});
    }


    componentDidMount() {
        console.log('here')
        $('#loading').hide();
    }

    render() {
        return (
            <div>
                <Navbar></Navbar>
                <div className="application">
                    <div className="container-fluid">
                        <h1>{this.state['name']}</h1>
                        <h3>{this.state['created']}</h3>
                            <div className="row ignore">
                                <div className="col-sm-7">
                                    <Tasks plannerId={this.state.plannerid} rowClass="row header" rowName="Current Tasks"></Tasks>
                                </div>
                                <div className="col-sm-5">

                                </div>
                            </div>

                    </div>
                </div>
            </div>
                
        );
    }
};
ReactDOM.render(
  <Detail />,
  document.getElementById('content')
);
