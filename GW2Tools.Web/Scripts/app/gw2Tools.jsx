var Gw2Tools = React.createClass({
    render: function () {
        return (
            <div className="gw2-tools">
                <ApiKeyForm />
            </div>
    );
  }
});

var ApiKeyForm = React.createClass({
    render: function () {
        return (
            <div className="api-key-form">
                <label for="api-key">GW2 Api Key</label>
                <input type="text" name="api-key" id="api-key" />
            </div>  
        );
    }
});

ReactDOM.render(
    <Gw2Tools />,
    document.getElementById('content')
);