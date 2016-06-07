var Tile = React.createClass({
    render: function() {
        return (

          <div className="col-md-3 col-sm-4 col-xs-6">
            <div className="dummy" />
            <a href="#x" className="thumbnail purple" onClick={this.props.onUserInput}>{this.props.tileName}</a>
          </div>
      );
    }
});