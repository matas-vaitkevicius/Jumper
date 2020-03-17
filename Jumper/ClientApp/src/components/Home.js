import React, { Component } from 'react';
window.ListToJump = [];
window.ListsInBatch = [];
window.ListsForDisplay = [];
export class Home extends Component {
    static displayName = Home.name;

    

    dialButtonClick(e) {
        e.preventDefault()

        var listToJumpElement = document.getElementById('listToJump');
  //      debugger;
        console.log(e);
        var val = e.target.innerText;
        var digit = parseInt(val);
        if (isNaN(digit)) {
            if (val === "Delete") {
                window.ListToJump.pop()
            }
            else {
                if (window.ListToJump.length > 0) {
                    window.ListsInBatch.push(window.ListToJump);
                }
                window.ListToJump = [];
             if (val === "Add to Batch") {

                    document.getElementById('listsInBatch').innerHTML = JSON.stringify(window.ListsInBatch);
                }
                else {
                    var solution = [];
                 if (localStorage.getItem(window.ListsInBatch)) {
                        solution = localStorage.getItem(window.ListsInBatch);
                    } else {
                        fetch("https://localhost:44330/jumper", {
                            method: "POST",
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },

                            body: JSON.stringify(window.ListsInBatch)
                        })
                            .then(res => {
                                //debugger;
                                return res.json();
                            })
                            .then(
                                (result) => {
                                    solution = result;
                                    localStorage.setItem(window.ListsInBatch, solution);
                                    console.log(result);
                                    window.ListsForDisplay = window.ListsInBatch.map((o, i) => { return { 'original': o, 'result': result[i] }; });
                                    window.ListsInBatch = [];
                                });
                    }
                }
            }
        } else {
            window.ListToJump.push(digit);
        }
        listToJumpElement.value = window.ListToJump.toString();
    }
    render() {
    return (
      <div>
            <h1>You need to point fetch API to correct port</h1>
            <div id="result"></div>
            <div>Lists ready for batch processing</div>
            <div id="listsInBatch"></div>
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
                <div className="dialButton" onClick={e => this.dialButtonClick(e)}>Add to Batch</div>
            </div>
            
        </div>
    );
  }
}
