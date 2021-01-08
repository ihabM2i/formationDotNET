import React, { Component } from 'react';

class Product extends Component {
    constructor(props) {
        super(props);
        this.state = {  }
    }
    render() { 
        return ( 
            <div className="row m-1 justify-content-center align-items-center">

                <div className="col-2">
                    <img className="imgProduct" src={this.props.product.images[0].url} />
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