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
            DisplayAccount(event.target.value)
        }
    },
    render: function () {
        var buttonText = this.props.button;
        if(buttonText != null) {
            button = <InputFieldButton type="primary" onClick={()=>DisplayAccount(this.state.value)}>{buttonText}</InputFieldButton>
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

var CharacterBirthdays = React.createClass({
    getInitialState: function() {
        var empty = {data:[]};
        return empty;
    },
    componentDidMount: function() {
        var apiKey = this.props.apiKey;
        var payload = { apiKey: apiKey };
        console.log("birthdays has ", apiKey, payload)
        $.get('/Tools/Birthdays', payload, (result) => {
            console.log("got data", result);
            this.setState({ data: result });
        }.bind(this)); 
    },
    render: function() {
        var birthdays = null;
        if(this.state.data != []) {   
            birthdays = this.state.data.map(function(character) {
                return (
                    <CharacterBirthday key={character.Name} name={character.Name} birthday={character.Birthday} daysToBirthday={character.DaysUntilBirthday} />
                )
            });
        };
        return (
            <div className="birthdays">
                {birthdays}
            </div>
        );
    }
});

var CharacterBirthday = React.createClass({
    render: function() {
        return (
            <div className="row">
                <div className='col-md-3'>
                    Name: {this.props.name}
                </div>
                <div className='col-md-3'>
                    Created: {this.props.birthday}
                </div>
                <div className='col-md-3'>
                    Days Until: {this.props.daysToBirthday}
                </div>
                <div className='col-md-3'>
                </div>
            </div>
        );
    }
});

function DisplayAccount(apikey) {
    console.log("attempting apikey:", apikey);
    var characterBirthdays = <CharacterBirthdays apiKey={apikey} />
    console.log("atetmpting to make", characterBirthdays)
    ReactDOM.render(
        characterBirthdays,
        document.getElementById('birthdays')
    );
}

ReactDOM.render(
    <Gw2Tools />,
    document.getElementById('tools')
);