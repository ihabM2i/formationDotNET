import React, { Component } from "react"
import { Contact } from "./Contact"
import axios from "axios"
export class ListeContacts extends Component {
    constructor(props) {
        super(props)
        this.state = {
            contacts: [
                
            ]
        }
    }

    componentDidMount() {
        axios.get("http://localhost:53751/api/v1/contacts").then(res => {
            this.setState({
                contacts: res.data
            })
        })
    }

    addContact = () => {
        const contact = { nom: "n contact 1", prenom: 'p contact 1', telephone: '01010101010', mails: [{mail:'a@p.fr'}] }
        axios.post("http://localhost:53751/api/v1/contacts", contact).then(res => console.log(res.data))
        this.setState({
            contacts: [...this.state.contacts, contact]
        })
    }

    render() {
        return (
            <div className="container">
                <div className="row">
                    <button onClick={this.addContact}>Ajouter contact</button>
                </div>
                {this.state.contacts.map((contact, index) => (<Contact key={index} nom={contact.nom} prenom={contact.prenom} telephone={contact.telephone} />))}
            </div>
        )
    }
}