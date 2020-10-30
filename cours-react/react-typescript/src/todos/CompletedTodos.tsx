import React, { Component } from 'react';
import Todo from './Todo';
import { TodoType } from './interfaces/TodoType';
export interface CompletedTodosProps {
    todos : TodoType[],
    deleteTodo(id:number, type:String):void
}
class CompletedTodos extends Component<CompletedTodosProps> {
    constructor(props : CompletedTodosProps) {
        super(props);
    }
    render() { 
        return (
        <div className="row">
            <div className="col">
                <div className="row">
                    <h1 className="col">Liste des completed todos</h1>
                </div>
                {this.props.todos.map((t,index) => (
                    <Todo type='completedTodos' deleteTodo={this.props.deleteTodo} todo={t} key={t.id}></Todo>
                ))}
            </div>
        </div>
        );
    }
}
 
export default CompletedTodos;