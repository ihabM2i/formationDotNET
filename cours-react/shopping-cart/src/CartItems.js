import React, { Component } from 'react';
import Item from "./Item"
class CartItems extends Component {
    constructor(props) {
        super(props);
        this.state = {  }
    }
    render() { 
        return ( 
            <div className="col-12">
                <h1 className="row">Panier</h1>
                {this.props.carts.map(item=>(
                    <Item props updateQty={this.props.updateQty} deleteFromCart={this.props.deleteFromCart} key={item.product.id} item={item}></Item>
                ))}
            </div>
         );
    }
}
 
export default CartItems;