var Gw2Tools = React.createClass({
    getInitialState: function() {
        return {
            loading: false,
            apiKeyInput: null,
            apiKeyIsValid: false, 
            birthdayData: []
        };
    },
    
    validateApiKey: (apiKeyInput) => {
        var validLength = 72;
        if (apiKeyInput.length != validLength) {
            return false;
        }
        
        var tokens = apiKeyInput.split("-");
        if (tokens.length != 9) {
            return false;
        }
        
        // api keys look like this :)
        // just length and format validation for now
        return tokens[0].length == 8
            && tokens[1].length == 4
            && tokens[2].length == 4
            && tokens[3].length == 4
            && tokens[4].length == 20
            && tokens[5].length == 4
            && tokens[6].length == 4
            && tokens[7].length == 4
            && tokens[8].length == 12;
    },
    
    getBirthdays: function () {
        if(this.state.apiKeyIsValid) {
            var payload = { apiKey: this.state.apiKeyInput };
            this.setState({ loading: true });
            $.get('/Tools/Birthdays', payload, (result) => {
                console.log("got data", result);
                this.setState({ birthdayData: result, loading: false });
            }.bind(this));
        }
    },
    
    handleUserInput: function (apiKeyInput) {
        var validate = this.validateApiKey(apiKeyInput);
        this.setState({
            apiKeyInput: apiKeyInput,
            apiKeyIsValid: validate
        });  
    },
    
    render: function () {
        var birthdayTable = null;
        var loading = null;
        if(this.state.birthdayData.length > 0) {
            console.log("make table", this.state);
            birthdayTable = <BirthdayTable birthdays={this.state.birthdayData} />
        }
        if(this.state.loading) {
            loading = <LoadingIndicator />
        }
        console.log("birthdayTable:", birthdayTable)
        return (
            <div className="gw2-tools">
                <ApiKeyForm 
                    apiKeyInput={this.state.apiKeyInput}
                    onUserInput={this.handleUserInput}
                    onSubmit={this.getBirthdays}
                />
                {loading}
                {birthdayTable}
            </div>
        );
    }
});

var LoadingIndicator = React.createClass({
    render: function () {
        return (
            <div className="loading">
                <h1>Loading...</h1>
            </div>
        ); 
    }
});

var BirthdayTable = React.createClass({
    render: function() {
        console.log("this", this, "got props", this.props)
        var birthdayRows = [];
        this.props.birthdays.forEach(function(character) {
            birthdayRows.push(
                <BirthdayRow key={character.Name} name={character.Name} birthday={character.Birthday} daysToBirthday={character.DaysUntilBirthday} />
            );
        });
        return (
            <div className="character-birthdays">
                <h3>Character Birthdays</h3>
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>Days Until Bday</th>
                            <th>Name</th>
                            <th>Create Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {birthdayRows}
                    </tbody>
                </table>
            </div>
        );
    }
});

var BirthdayRow = React.createClass({
    render: function() {
        return (
            <tr>
                <td>{this.props.daysToBirthday}</td>
                <td>{this.props.name}</td>
                <td>{this.props.birthday}</td>
            </tr>
        );
    }
});

var ApiKeyForm = React.createClass({
    handleChange: function() {
        this.props.onUserInput(this.refs.apiKeyInput.value);
    },
    
    handleSubmit: function (event) {
        this.props.onSubmit(this.refs.apiKeyInput.value);
        event.preventDefault();
    },
    
    render: function () {
        return (
            <form ref="form" className="api-key-form" onSubmit={this.handleSubmit}>
                <div className="input-group">
                    <label style={{display: "none"}} htmlFor="api-key">GW2 Api Key</label>
                    <input 
                        value={this.props.apiKeyInput}
                        ref="apiKeyInput" 
                        className="form-control" id="api-key" 
                        placeholder="Enter GW2 API Key" 
                        type="text"
                        onChange={this.handleChange}
                    />
                    <span className="input-group-btn">
                        <button className="btn btn-primary" type="submit">
                            Enter
                        </button>
                    </span>                        
                </div>
            </form>  
        );
    }
});

// var InputField = React.createClass({
//     // // handling inputs
//     // componentDidMount: function() {
//     //     $(document.body).on('keydown', this.onEnter);
//     // },
//     // componentWillUnmount: function() {
//     //     $(document.body).off('keydown', this.onEnter);
//     // },
//     // getInitialState: function() {
//     //     return { value: '' };
//     // },
//     // handleChange: function() {
//     //     this.setState({value: event.target.value});
//     // },
//     // onEnter: function(event) {
//     //     if( event.keyCode == 13 ) {
//     //         DisplayAccount(event.target.value)
//     //     }
//     // },
//     render: function () {
//         var buttonText = this.props.button;
//         if(buttonText != null) {
//             button = <InputFieldButton type="primary" onClick={()=>DisplayAccount(this.state.value)}>{buttonText}</InputFieldButton>
//         }
//         var { id, type, placeholder, children, ...other } = this.props;
//         return (
// 
//         );
//     } 
// });
// 
// var InputFieldButton = React.createClass({
//     render: function () {
//         var { type, children, ...other } = this.props;
//         var classes = "btn btn-" + type;
//         return (
//             <span className="input-group-btn">
//                 <button className={classes} {...other}>
//                     {this.props.children}
//                 </button>
//             </span>
//         );       
//     }
// });
// 
// var CharacterBirthdays = React.createClass({
//     getInitialState: function() {
//         var empty = {data:[]};
//         return empty;
//     },
//     componentDidMount: function() {
//         var apiKey = this.props.apiKey;
//         var payload = { apiKey: apiKey };
//         console.log("birthdays has ", apiKey, payload)
//         $.get('/Tools/Birthdays', payload, (result) => {
//             console.log("got data", result);
//             this.setState({ data: result });
//         }.bind(this)); 
//     },
//     render: function() {
//         var birthdays = null;
//         if(this.state.data != []) {   
//             birthdays = this.state.data.map(function(character) {
//                 return (
//                     <CharacterBirthday key={character.Name} name={character.Name} birthday={character.Birthday} daysToBirthday={character.DaysUntilBirthday} />
//                 )
//             });
//         };
//         return (
//             <div className="birthdays">
//                 {birthdays}
//             </div>
//         );
//     }
// });
// 
// var CharacterBirthday = React.createClass({
//     render: function() {
//         return (
//             <div className="row">
//                 <div className='col-md-3'>
//                     Name: {this.props.name}
//                 </div>
//                 <div className='col-md-3'>
//                     Created: {this.props.birthday}
//                 </div>
//                 <div className='col-md-3'>
//                     Days Until: {this.props.daysToBirthday}
//                 </div>
//                 <div className='col-md-3'>
//                 </div>
//             </div>
//         );
//     }
// });
// 
// function DisplayAccount(apikey) {
//     console.log("attempting apikey:", apikey);
//     var characterBirthdays = <CharacterBirthdays apiKey={apikey} />
//     console.log("atetmpting to make", characterBirthdays)
//     ReactDOM.render(
//         characterBirthdays,
//         document.getElementById('birthdays')
//     );
// }

ReactDOM.render(
    <Gw2Tools />,
    document.getElementById('tools')
);