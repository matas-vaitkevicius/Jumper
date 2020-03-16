import React, { Component } from 'react';
window.ListToJump = []
export class Home extends Component {
    static displayName = Home.name;

    dialButtonClick(e) {
        e.preventDefault()
        
        var listToJumpElement = document.getElementById('listToJump');
        debugger;
        console.log(e);
        var val = e.target.innerText;
        var digit = parseInt(val);
        if (isNaN(digit)) {
            if (val === "Delete") {
                window.ListToJump.pop()
            }
            else
            {
                fetch("https://localhost:44330/jumper", {
                    method: "POST",
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },

                    body: JSON.parse(JSON.stringify("[[" + window.ListToJump.toString() + "]]"))

                })
                    .then(res => {
                        //debugger;
                        return res.json();
                    })
                    .then(
                        (result) => {
                            console.log(result);
                        });
            }
        } else
        {
            window.ListToJump.push(digit);
        }
        listToJumpElement.value = window.ListToJump.toString();
    }
    render() {
    return (
      <div>
            <h1>Hello, world!</h1>
            <div className="result"></div>
            <input type="text" className="input" id="listToJump"></input>
            <div className="buttonPad">
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>1</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>2</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>3</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>4</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>5</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>6</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>7</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>8</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>9</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>Send</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>0</div>
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>Delete</div>
            </div>
            
        </div>
    );
  }
}
