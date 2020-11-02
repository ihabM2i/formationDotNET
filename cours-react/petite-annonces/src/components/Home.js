import React, { Component } from 'react';
import { annonces, getAnnonces, search } from '../services/DataService';
import Annonces from './Annonces';
// import Search from './Search';

import {Spin, Input} from "antd"
const {Search} = Input
class Home extends Component {
    constructor(props) {
        super(props);
        this.state = { 
            loading : true,
            annonces : []
         }
    }

    componentDidMount() {
        getAnnonces().then((result) => {
            this.setState({
                loading : false,
                annonces : result.data.annonces
            })
        })
    }

    
    shouldComponentUpdate(nextProps, nextState, nextContext) {
        return this.state != nextState || this.props != nextProps
    }

    search = (text) => {
        this.setState({
            loading : true
        })
        search(text).then((result) => {
            this.setState({
                annonces : result.data.annonces,
                loading : false
            })
        }).catch(err=> {
            this.setState({
                loading : false
            })
        }) 
    }

    render() { 
        return ( 
            <div className="container">
                {/* <Search search={this.search}></Search> */}
                <Search onChange={(e) => {this.search(e.target.value)}} placeholder="Votre recherche" enterButton="Search" size="large" loading={this.state.loading} />
                {this.state.loading ? <div style={{textAlign: 'center'}}><Spin /></div> : <Annonces annonces={this.state.annonces}></Annonces>}
                
            </div>
         );
    }
}
 
export default Home;