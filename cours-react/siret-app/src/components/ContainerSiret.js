import React, { PureComponent } from 'react';
import Entreprise from './Entreprise';
import SearchSiret from './SearchSiret';
import axios from "axios"
class ContainerSiret extends PureComponent {
    constructor(props) {
        super(props);
        this.state = { 
            entreprise : undefined
         }
    }

    search = (siret) => {
        //On effectue la recherche en utilisant l'api
        axios.get("https://api.insee.fr/entreprises/sirene/V3/siret/"+siret, {headers : {'Authorization' : 'Bearer a6c6890b-4841-391a-9868-eaee68711678'}})
        .then(res => {
            if(res.data.header.statut == 200) {
                this.setState({
                    entreprise : res.data.etablissement
                })
            }
        }).catch(err => {
            console.log(err)
        })
    }
    render() { 
        return (
            <div className="container">
                <SearchSiret search={this.search}></SearchSiret>
                <Entreprise entreprise={this.state.entreprise}></Entreprise>
            </div>
         );
    }
}
 
export default ContainerSiret;