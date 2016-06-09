var Tile = React.createClass({
    render: function () {
        var deletePlanner = null;
        var tile = null;

        if (this.props.canDelete == "true") {
            deletePlanner =
                <div className="square-box pull-left toggleDelete">
                    <a onClick={() => this.props.onDeleteClick(this.key)}>
                        <span className="glyphicon glyphicon-remove glyphicon-sm"></span>
                    </a>
                </div>;

            return (
                <div className="col-md-3 col-sm-4 col-xs-6">
                    <div className="dummy" />
                    <a href="#" className="thumbnail purple" onClick={() => this.props.onDetailClick(this.key) }>{this.props.tileName}</a>
                    {deletePlanner}
                </div>
            );

        } else {
            return (
                <div className="col-md-3 col-sm-4 col-xs-6 toggleTileDelete">
                    <div className="dummy" />
                    <a href="#" className="thumbnail purple" onClick={() => this.props.onDetailClick(this.key) }>{this.props.tileName}</a>
                </div>
            );
        }


    }
});

{/*var Tile = React.createClass({
    render: function () {
        var deletePlanner = null;
        if (this.props.canDelete == "true") {
            deletePlanner =             <div className="square-box pull-left">
                        <span className="glyphicon glyphicon-tags glyphicon-lg" />
            </div>
        }

        return (
                <div className="col-md-3 col-sm-4 col-xs-6">
                    
                    <a href="#" className="thumbnail purple" onClick={() => this.props.onDetailClick(this.key) }>{this.props.tileName}</a>
                </div>


      );
    }
});*/}