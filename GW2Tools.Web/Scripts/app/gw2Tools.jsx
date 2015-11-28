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

var InputField = React.createClass({
    // handling inputs
    componentDidMount: function() {
        $(document.body).on('keydown', this.onEnter);
    },
    componentWillUnmount: function() {
        $(document.body).off('keydown', this.onEnter);
    },
    getInitialState: function() {
        return { value: '' };
    },
    handleChange: function(event) {
        this.setState({value: event.target.value});
    },
    onEnter: function(event) {
        if( event.keyCode == 13 ) {
            doStuff(event.target.value)
        }
    },
    render: function () {
        var buttonText = this.props.button;
        if(buttonText != null) {
            button = <InputFieldButton type="primary" onClick={()=>doStuff(this.state.value)}>{buttonText}</InputFieldButton>
        }
        var { id, type, placeholder, children, ...other } = this.props;
        return (
            <div className="input-group">
                <span className="input-group-addon" id={id}>
                    {children}
                </span>
                <input type={type} className="form-control" placeholder={placeholder} aria-describedby={id} onChange={this.handleChange} />
                {button}
            </div>
        );
    } 
});

function doStuff(apikey) {
    console.log("you entered:", apikey);
}

var InputFieldButton = React.createClass({
    render: function () {
        var { type, children, ...other } = this.props;
        var classes = "btn btn-" + type;
        return (
            <span className="input-group-btn">
                <button className={classes} {...other}>
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