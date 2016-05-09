var Init = React.createClass({
    render: function() {
        return (
          <div className="commentBox">
            Hello, React!
          </div>
      );
    }
});
ReactDOM.render(
  <Init />,
  document.getElementById('content')
);