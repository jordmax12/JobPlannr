//var Init = React.createClass({

//    getInitialState: function() {
//        return { name: '' };
//    },
//    componentDidMount: function () {
//        $.ajax({
//            url: this.props.url,
//            dataType: 'json',
//            success: function (data) {
//                console.log(data);
//                this.setState(data);
//            }.bind(this),
//            error: function (xhr, status, err) {
//                console.log(err);
//            }
//        });
//    },
//    render: function() {
//        return (
//          <div className="commentBox">
//            {this.state.name}
//          </div>
//      );
//    }
//});

class Init extends React.Component {
    constructor(props) {
        super(props);
        
        this.state = { name : '' };
        
        this.auth();
    }
    
    auth() {
        $.ajax({
            url: this.props.url,
            dataType: 'json',
            success: function (data) {
                this.setState(data);
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }
    
    render () {
        return (
          <div className="commentBox">
                {this.state.name}
          </div>
        );
    }
};
ReactDOM.render(
  <Init url="/home/getauth" />,
  document.getElementById('content')
);