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
                <InputField id="api-key" type="text" placeholder="Enter GW2 API Key" button="Enter">
                    GW2 API Key
                </InputField>
            </div>  
        );
    }
});
/*

                <label for="api-key">GW2 Api Key</label>
                <input type="text" name="api-key" id="api-key" />
*/
var InputField = React.createClass({
   render: function () {
       var buttonText = this.props.button;
       if(buttonText != null) {
           button = <InputFieldButton type="primary">{buttonText}</InputFieldButton>
       }
       return (
           <div className="input-group">
                <span className="input-group-addon" id={this.props.id}>
                    {this.props.children}
                </span>
                <input type={this.props.type} className="form-control" placeholder={this.props.placeholder} aria-describedby={this.props.id} />
                {button}
           </div>
       );
   } 
});

var InputFieldButton = React.createClass({
    render: function () {
        var buttonType = this.props.type != null ? this.props.type : "primary";
        
        var classes = "btn btn-" + buttonType;
        return (
            <span className="input-group-btn">
                <button className={classes} type>
                    {this.props.children}
                </button>
            </span>
        );       
    }
});

ReactDOM.render(
    <Gw2Tools />,
    document.getElementById('tools')
);