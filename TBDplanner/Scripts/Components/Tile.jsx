var Tile = React.createClass({
    render: function() {
        return (

          <div className="col-md-3 col-sm-4 col-xs-6">
            <div className="dummy" />
            <a href="#" className="thumbnail purple" onClick={() => this.props.onDetailClick(this.key) }>{this.props.tileName}</a>
          </div>
      );
    }
});