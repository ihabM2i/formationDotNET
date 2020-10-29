import React, { Component } from 'react';
import Item from "./Item"
import { ItemType } from './interfaces/ItemType';

export interface CartItemsProps {
    carts : ItemType[] 
    updateQty(id:number, value:String):void
    deleteFromCart(id:number) : void
}


class CartItems extends Component<CartItemsProps, any> {
    constructor(props : CartItemsProps) {
        super(props);
       
    }
    render() { 
        return ( 
            <div className="col-12">
                <h1 className="row">Panier</h1>
                {this.props.carts.map((item)=>(
                    <Item updateQty={this.props.updateQty} deleteFromCart={this.props.deleteFromCart} key={item.product.id} item={item}></Item>
                ))}
            </div>
         );
    }
}
 
export default CartItems;