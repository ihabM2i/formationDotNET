import React, { Component } from 'react';
import CompletedTodos from './CompletedTodos';
import FormulaireTodo from './FormulaireTodo';
import Todos from './Todos';
import { TodoType } from './interfaces/TodoType';
export interface ContainerTodoProps {

}

export interface ContainerTodoState {
    todos : TodoType[],
    completedTodos : TodoType[],
    compteurTodo : number
}
class ContainerTodo extends Component<ContainerTodoProps,ContainerTodoState> {
    constructor(props: ContainerTodoProps) {
        super(props);
        this.state = {
            todos: [],
            completedTodos: [],
            compteurTodo: 0
        }
    }

    addTodo = (task:String) : void => {
        let id = this.state.compteurTodo + 1

        let todo = {
            id: id,
            task: task
        }

        let tmpTodos = [todo, ...this.state.todos]

        this.setState({
            todos: tmpTodos,
            compteurTodo: id
        })
    }

    deleteTodo = (id:number, type:String) :void => {
        switch (type) {
            case "todos":
                const tmpTodos = this.state.todos.filter(t => t.id != id)
                this.setState({
                    todos: tmpTodos
                })
                break;
            case "completedTodos":
                const tmpCompletedTodos = this.state.completedTodos.filter(t => t.id != id)
                this.setState({
                    completedTodos: tmpCompletedTodos
                })
                break;
        }
    }

    changeTodoState = (id:number) : void => {
        const tmpTodo = this.state.todos.find(t => t.id == id)
        if(tmpTodo != undefined) {
            const tmpCompletedTodos = [tmpTodo, ...this.state.completedTodos]
            const tmpTodos = this.state.todos.filter(t => t.id != id)
            this.setState({
                completedTodos : tmpCompletedTodos,
                todos : tmpTodos
            })
        }
    }
    render() {
        return (
            <div className="container">
                <FormulaireTodo addTodo={this.addTodo} />
                <Todos changeTodoState={this.changeTodoState} deleteTodo={this.deleteTodo} todos={this.state.todos} />
                <CompletedTodos deleteTodo={this.deleteTodo} todos={this.state.completedTodos} />
            </div>
        );
    }
}

export default ContainerTodo;