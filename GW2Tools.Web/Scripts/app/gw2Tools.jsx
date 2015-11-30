var Gw2Tools = React.createClass({
    getInitialState: function() {
        return {
            loading: 0,
            apiKeyInput: null,
            apiKeyIsValid: false, 
            birthdayData: [],
            accountInventory: [],
            filterItemName: null
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
            this.state.loading++;
            
            this.setState({ birthdayData: [] });
            var payload = { apiKey: this.state.apiKeyInput };
            $.get('/Tools/Birthdays', payload, (result) => {
                loading = this.state.loading - 1;
                this.setState({ birthdayData: result, loading: loading });
            });
        }
    },
    
    getAccountInventory: function () {
        if(this.state.apiKeyIsValid) {
            this.state.loading++;
            
            this.setState({ birthdayData: [] });
            var payload = { apiKey: this.state.apiKeyInput };
            $.get('/Tools/AccountInventory', payload, (result) => {
                loading = this.state.loading - 1;
                this.setState({ accountInventory: result, loading: loading });
            });
        }
    },
    
    handleUserInput: function (apiKeyInput) {
        var validate = this.validateApiKey(apiKeyInput);
        this.setState({
            apiKeyInput: apiKeyInput,
            apiKeyIsValid: validate
        });  
    },
    
    apiKeySubmit: function () {
        this.getBirthdays();
        this.getAccountInventory();
    },
    
    setItemFilter: function (filter) {
        this.setState({filterItemName: filter})
    },
    
    render: function () {
        var accountInventory = null;
        var birthdayTable = null;
        var loading = null;
        if(this.state.birthdayData.length > 0) {
            birthdayTable = <BirthdayTable birthdays={this.state.birthdayData} />
        }
        if(this.state.accountInventory.length > 0) {
            accountInventory = 
                <AccountInventory
                    inventory={this.state.accountInventory}
                    filterItemName={this.state.filterItemName}
                    onUserInput={this.setItemFilter} />
        }
        if(this.state.loading > 0) {
            loading = <LoadingIndicator />
        }
        return (
            <div className="gw2-tools">
                <ApiKeyForm 
                    apiKeyInput={this.state.apiKeyInput}
                    onUserInput={this.handleUserInput}
                    onSubmit={this.apiKeySubmit}
                />
                {loading}
                {accountInventory}
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

var AccountInventoryRow = React.createClass({
   render: function () {
       return (
           <tr>
                <td>{this.props.quantity}</td>
                <td>
                    <img className="small-icon" src={this.props.iconUrl} />
                    {this.props.name}
                </td>
           </tr>
       )
   }
});

var AccountInventory = React.createClass({
   render: function () {
        var filteredItemRows = [];
        var max = 30;
        var nameFilter = this.props.filterItemName;
        this.props.inventory.forEach(function(item) {
            if(((nameFilter != null && nameFilter != '') && item.Name.indexOf(nameFilter) === -1) || filteredItemRows.length >= max) {
                return;
            }
            filteredItemRows.push(
                <AccountInventoryRow key={item.Id} name={item.Name} quantity={item.Quantity} iconUrl={item.IconUrl} />
            );
        });
        return (
           <div>
                <h3>Account Inventory Summary</h3>
                <AccountInventoryFilter
                    filterItemName={this.props.filterItemName}
                    onUserInput={this.props.onUserInput} />
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>Quantity</th>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredItemRows}
                    </tbody>
                </table>
           </div>
       );
   }
});

var AccountInventoryFilter = React.createClass({
    handleChange: function() {
        this.props.onUserInput(this.refs.filterItemName.value);
    },
    
    handleSubmit: function(event) {
        event.preventDefault();
        return false;
    },
    
    render: function() {
        return (
            <form ref="form" className="item-filter-form" onSubmit={this.handleSubmit}>
                <div className="input-group">
                    <span className="input-group-addon" id="filter-name-label">
                        Search
                    </span>
                    <input 
                        value={this.props.filterItemName}
                        ref="filterItemName" 
                        className="form-control" id="filter-name" 
                        placeholder="Search by item name" 
                        type="text"
                        onChange={this.handleChange}
                        aria-describedby="filter-name-label"
                    />                       
                </div>
            </form>
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
        console.log("handlesubmit", event);
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

ReactDOM.render(
    <Gw2Tools />,
    document.getElementById('tools')
);