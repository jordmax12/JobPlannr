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
        //const videoSearch = _.debounce((term) => { this.videoSearch(term) }, 300);
        //return (
        //    <div>
        //        <SearchBar onSearchTermChange={videoSearch} />
        //        <VideoDetail video={this.state.selected} />
        //        <VideoList onVideoSelect={selected => this.setState({selected})} videos={this.state.videos} />
        //    </div>
        //);

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