import React, { Component, useState } from 'react';
import { ajouterAnnonce, isLogged } from '../services/DataService';

class FormAnnonce extends Component {
    constructor(props) {
        super(props);
        if(!isLogged) {
            this.props.history.push("/login/addAnnonce")
        }
        this.state = { 
            nombreImages : 1,
            annonce : {
                titre : '',
                prix : 0,
                description : '',
                images : []
            } 
        }
    }

    changeField = (e) => {
        let tmpAnnonce = {...this.state.annonce}
        tmpAnnonce[e.target.getAttribute("name")] = e.target.value
        this.setState({
            annonce : {...tmpAnnonce}
        })
    }
    changeImage = (e, index) => {
        let tmpAnnonce = {...this.state.annonce}
        tmpAnnonce.images[index] = e.target.value
        this.setState({
            annonce : tmpAnnonce
        })
    }
    renderImagesField = () => {
        const imagesField = []
        for(let i= 1 ; i <= this.state.nombreImages; i++) {
            imagesField.push(<input key={i} onChange={(e) => {this.changeImage(e,i-1)}} className="col-12 m-1 form-control" placeholder="Url image" />)
        }
        return imagesField
    }

    ajouterImage = () => {
        const tmpNombreImages = this.state.nombreImages + 1
        this.setState({
            nombreImages : tmpNombreImages
        })
    }
    validForm = (e) => {
        e.preventDefault()
        ajouterAnnonce(this.state.annonce)
        this.props.history.push('/')
    }
    render() { 
        return ( 
            <form className="container" onSubmit={this.validForm}>
                <div className="row m-1">
                    <input type="text" onChange={this.changeField} name="titre" className="form-control col" placeholder="Titre de l'annonce" />
                </div>
                <div className="row m-1">
                    <input type="text" name="prix" onChange={this.changeField} className="form-control col" placeholder="Prix de l'annonce" />
                </div>
                <div className="row m-1">
                    <textarea className="col form-control" onChange={this.changeField} placeholder="La description de l'annonce" name="description">

                    </textarea>
                </div>
                <div className="row m-1">
                    <div className="col">
                        <div className="row m-1">
                            {this.renderImagesField()}
                        </div>
                    </div>
                    <a className="btn col-2 btn-info" onClick={this.ajouterImage}>Ajouter une image</a>
                </div>
                <div className="row m-1">
                    <button type="submit" className="btn col btn-success">Valider</button>
                </div>
            </form>
        );
    }
}


// const FormAnnonce = (props) => {

//     const [nombreImages ,setNombreImages] = useState(1)
//     const [annonce, setAnnonce] = useState({
//         titre : '',
//         prix : 0,
//         description : '',
//         images : []    
//     } )

//     const changeField = (e) => {
//         let tmpAnnonce = {...annonce}
//         tmpAnnonce[e.target.getAttribute("name")] = e.target.value
//         setAnnonce(tmpAnnonce)
//     }
//     const changeImage = (e, index) => {
//         let tmpAnnonce = {...annonce}
//         tmpAnnonce.images[index] = e.target.value
//         setAnnonce(tmpAnnonce)
//     }
//     const renderImagesField = () => {
//         const imagesField = []
//         for(let i= 1 ; i <= nombreImages; i++) {
//             imagesField.push(<input key={i} onChange={(e) => {changeImage(e,i-1)}} className="col-12 m-1 form-control" placeholder="Url image" />)
//         }
//         return imagesField
//     }

//     const ajouterImage = () => {
//         const tmpNombreImages = nombreImages + 1
//         setNombreImages(tmpNombreImages)
//     }
//     const validForm = (e) => {
//         e.preventDefault()
//         ajouterAnnonce(annonce).then(res => {
//             if(!res.data.error) {
//                 props.history.push('/detail/'+res.data.id)
//             }
//         })
         
//     }
//     return(
//         <form className="container" onSubmit={validForm}>
//                 <div className="row m-1">
//                     <input type="text" onChange={changeField} name="titre" className="form-control col" placeholder="Titre de l'annonce" />
//                 </div>
//                 <div className="row m-1">
//                     <input type="text" name="prix" onChange={changeField} className="form-control col" placeholder="Prix de l'annonce" />
//                 </div>
//                 <div className="row m-1">
//                     <textarea className="col form-control" onChange={changeField} placeholder="La description de l'annonce" name="description">

//                     </textarea>
//                 </div>
//                 <div className="row m-1">
//                     <div className="col">
//                         <div className="row m-1">
//                             {renderImagesField()}
//                         </div>
//                     </div>
//                     <a className="btn col-2 btn-info" onClick={ajouterImage}>Ajouter une image</a>
//                 </div>
//                 <div className="row m-1">
//                     <button type="submit" className="btn col btn-success">Valider</button>
//                 </div>
//             </form>
//     )
// }
export default FormAnnonce;