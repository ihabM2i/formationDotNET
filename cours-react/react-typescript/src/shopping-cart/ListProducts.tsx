import React, { Component } from 'react';
import Product from './Product';
import { ProductType } from './interfaces/ProductType';

export interface ListProductsProps {
    products : ProductType[],
    addToCart(product:ProductType) : void
}
class ListProducts extends Component<ListProductsProps, any> {
    constructor(props : ListProductsProps) {
        super(props);
        
    }
    render() { 
        return ( 
        <div className="col-8">
            <h1 className="row m-1">Liste des produits</h1>
             {this.props.products.map(product => (
                 <Product addToCart={this.props.addToCart} key={product.id} product={product}></Product>
             ))}
        </div> );
    }
}
 
export default ListProducts;