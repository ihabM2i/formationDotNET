import React, {Component} from "react"
import { Personne } from "./Personne"


export interface PersonneComponentProps {
    ajouter (nom:String, prenom:String):void
}

export interface PersonneComponentState {
    personne : Personne,
    compteur : 1
}

export class PersonneComponent extends Component<PersonneComponentProps,PersonneComponentState> {

    constructor(props : any) {
        super(props)
        const p : Personne = {
            nom : '',
            prenom : '',
        }
        this.state = {
            personne  : p,
            compteur : 1
        }
    }

    render() {
        return (
            <div>
                <div>
                    Nom : {this.state.personne.nom}
                </div>
                <div>
                    Prénom : {this.state.personne.prenom}
                </div>
            </div>
        )
    }
}