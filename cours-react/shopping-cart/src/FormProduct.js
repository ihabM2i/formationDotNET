import React, { PureComponent } from 'react'
import axios from "axios"
class FormProduct extends PureComponent {
    

    constructor(props) {
        super(props)
        this.state = {
            product : {
                title : '',
                description : '',
                price : 0
            },
            images : []
        }
    }

    fieldChanged = (e) => {
        const tmpProduct = {...this.state.product}
        tmpProduct[e.target.name] = (e.target.name == 'price') ? parseFloat(e.target.value) : e.target.value
        this.setState({ product: {...tmpProduct} });
    }

    imageChanged = (e) => {
        this.setState({ images: e.target.files });
    }

    submitForm = async (e) => {
        e.preventDefault()
        const response = await axios.post("http://localhost:53751/api/v1/products", {...this.state.product})
        if(response != undefined) {
            for(let image of this.state.images) {
                let formData = new FormData()
                formData.append('image', image)
                const res = await axios.put(`http://localhost:53751/api/v1/products/${response.data.id}/images`, formData)
                if(res.data == undefined) {
                    console.log('Erreur upload image '+ image)
                }
            }
        }
        
    }
    render() { 
        return ( 
            <div className="container">
                <form onSubmit={this.submitForm}>
                    <div className="row m-1 justify-content-center">
                        <input onChange={this.fieldChanged} type="text" placeholder="Titre du produit" name="title" className="form-control col p-1" />
                    </div>
                    <div className="row m-1 justify-content-center">
                        <input type="text" onChange={this.fieldChanged} placeholder="Prix du produit" name="price" className="form-control col p-1" />
                    </div>
                    <div className="row m-1 justify-content-center">
                        <textarea type="text" onChange={this.fieldChanged} placeholder="Description du produit" name="description" className="form-control col p-1" ></textarea>
                    </div>
                    <div className="row m-1 justify-content-center">
                        <input type="file" onChange={this.imageChanged} name="image" multiple className="form-control col p-1"/>
                    </div>
                    <div className="row m-1 justify-content-center">
                        <button type="submit" className="col p-1 btn btn-primary">Valider</button>
                    </div>
                </form>
            </div>
         );
    }
}
 
export default FormProduct;