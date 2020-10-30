import React, { Component } from 'react';
import { TodoType } from './interfaces/TodoType';
export interface TodoProps {
    type:String,
    todo : TodoType,
    changeTodoState?:  {(id:number) : void},
    deleteTodo(id:number, type:String):void
}
class Todo extends Component<TodoProps,any> {
    constructor(props : TodoProps) {
        super(props);
    }
    render() { 
        return ( 
            <div className="row m-1">
                {this.props.type == 'todos' 
                    ? (
                        <input type="checkbox" onChange={() => {
                            (this.props.changeTodoState != undefined) ? this.props.changeTodoState(this.props.todo.id) : null
                        }} className="col-1 form-control" />
                    ) 
                : null}
                <div className="col">
                    {this.props.todo.task}
                </div>
                <button onClick={() => {
                    this.props.deleteTodo(this.props.todo.id, this.props.type)
                    }} className="col-2 btn btn-danger">
                    Supprimer
                </button>
            </div>
         );
    }
}
 
export default Todo;