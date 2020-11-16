import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import 'antd/dist/antd.css';
// import { Home } from './Home';
import { ListeContacts } from './contacts/ListeContacts';
import { Compteur } from './Compteur';
import { HelloWorld } from './HelloWorld';
import { PlusOuMoin } from './PlusOuMoin';
import { Pendu } from './Pendu';
import { ContainerPersonnes } from './Personnes/ContainerPersonnes';
import { Todos } from './Todos';
import { BrowserRouter, Link, Route, Switch } from "react-router-dom"
import Login from './Login';
import { ColorContext } from './ColorContext';
import Countries from './Countries';
import ContainerBook from './book/ContainerBook';

class App extends Component {
  constructor(props) {
    super(props)
    this.state = {
      hidden: false,
      colorText: 'red'
    }
  }

  componentDidMount() {
    // this.setState({
    //   appState : false
    // })
  }

  hide = () => {
    this.setState({
      hidden: true
    })
  }
  changeColor = (e) => {
    this.setState({
      colorText : e.target.value
    })
  }
  render() {
    return (
      <div className="App">
        <button onClick={this.hide}>Hide HelloWorld</button>
        <div>
          <select onChange={this.changeColor}>
            <option>red</option>
            <option>green</option>
            <option>blue</option>
          </select>
        </div>
        <ColorContext.Provider value={this.state.colorText}>
          {this.state.hidden ? null : <HelloWorld></HelloWorld>}
        </ColorContext.Provider>
        {/* <Countries ></Countries>
        <ContainerBook></ContainerBook> */}
      </div>
    );
  }
}

export default App;
