import React, { Component } from 'react';
import { PersonneComponent } from './PersonneComponent';

export interface HelloWorldProps {
    
}
 
export interface HelloWorldState {
    
}
 
// class HelloWorld extends React.Component<HelloWorldProps, HelloWorldState> {
//     constructor(props: HelloWorldProps) {
//         super(props);
//         this.state = { :  };
//     }
//     render() { 
//         return ( <div></div> );
//     }
// }
 

class HelloWorld extends Component {
    
    constructor(props:any) {
        super(props)
    }
    renderHello = (nom:String) : JSX.Element => {
        const hello : String = "Bonjour tout le monde "+ nom
        return(
            <div>{hello}</div>
        )
    }

    ajouter = (nom:String, prenom: String) :void =>{
        console.log(nom + " "+ prenom)
    }
    render() : JSX.Element {
        return(
            <div>
                {this.renderHello("abadi")}
                <PersonneComponent ajouter={this.ajouter}></PersonneComponent>
            </div>
        )
    }
}
export default HelloWorld;