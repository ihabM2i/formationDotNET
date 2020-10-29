import React, { Component } from 'react';
import { ItemType } from './interfaces/ItemType';

export interface ItemProps {
    item : ItemType,
    updateQty(id:number, value:String):void
    deleteFromCart(id:number) : void
}

export interface ItemState {
    qty : number
}
class Item extends Component<ItemProps, ItemState> {
    constructor(props : ItemProps) {
        super(props);
        this.state = { 
            qty : this.props.item.qty
         }
    }
    changeQty = (event:any) => {
        this.props.updateQty(this.props.item.product.id, event.target.value)
        this.setState({
            qty : event.target.value
        })
    }
    render() { 
        return ( 
            <div className="row">
                <div className="col-2">
                    <img style={{width:'100%'}} src={this.props.item.product.image.toString()} />
                </div>
                <div className="col-3">
                    {this.props.item.product.title}
                </div>
                <div className="col-2">
                    {this.props.item.product.price} €
                </div>
                <input className="col-2" min="1" max="100" type="number" onChange={this.changeQty} defaultValue={this.props.item.qty} />
                <div className="col-1">
                    {this.props.item.qty * this.props.item.product.price}
                </div>
                <div className="col-2">
                <i className="fas fa-trash" onClick={()=> {
                        this.props.deleteFromCart(this.props.item.product.id)
                    }}></i>
                </div>
            </div>
         );
    }
}
 
export default Item;