import React, { Component, PureComponent } from 'react';
import CompletedTodos from './CompletedTodos';
import FormulaireTodo from './FormulaireTodo';
import Todos from './Todos';
import axios from "axios"

class ContainerTodo extends PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            todos: [],
            completedTodos: [],
            compteurTodo: 0
        }
    }

    componentDidMount() {
        axios.get('http://localhost:3010/todos').then(res => {
            //Le resultat est stocké dans clé data
            if(res.data.error == false) {
                this.setState({
                    todos : res.data.todos
                })
            }
        })
    }

    shouldComponentUpdate(nextProps, nextState, nextContext) {
        return (nextProps != props || nextState != state)
    }

    addTodo = (task) => {
        // let id = this.state.compteurTodo + 1
        let todo = {
            task: task
        }
        axios.post('http://localhost:3010/todo', {...todo}).then(res => {
            if(res.data.error == false) {
                todo.id = res.data.id
                let tmpTodos = [todo, ...this.state.todos]
                this.setState({
                    todos: tmpTodos
                })
            }
        })
        
    }

    deleteTodo = (id, type) => {
        switch (type) {
            case "todos":
                axios.delete("http://localhost:3010/todo/"+id).then(res => {
                    if(res.data.error == false) {
                        const tmpTodos = this.state.todos.filter(t => t.id != id)
                        this.setState({
                            todos: tmpTodos
                        })
                    }
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

    changeTodoState = (id) => {
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