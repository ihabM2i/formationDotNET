import React, { Component } from 'react';
import { ProductType } from './interfaces/ProductType';

export interface ProductProps {
    product:  ProductType
    addToCart(product:ProductType) : void
}
class Product extends Component<ProductProps, any> {
    constructor(props : ProductProps) {
        super(props);
    }
    render() { 
        return ( 
            <div className="row m-1 justify-content-center align-items-center">
                <div className="col-2">
                    <img className="imgProduct" src={this.props.product.image.toString()} />
                </div>
                <div className="col">
                    {this.props.product.title}
                </div>
                <div className="col-2">
                    {this.props.product.price} €
                </div>
                <div className="col-2">
                    <button onClick={()=> {
                        this.props.addToCart(this.props.product)
                    }} className="btn btn-info">Add To Cart</button>
                </div>
            </div>
         );
    }
}
 
export default Product;