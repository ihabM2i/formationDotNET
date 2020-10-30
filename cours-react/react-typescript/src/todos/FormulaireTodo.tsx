import React, { Component } from 'react';

export interface FormulaireTodoProps {
    addTodo(task:String): void
}

export interface FormulaireTodoState {
    task : String
}
class FormulaireTodo extends Component<FormulaireTodoProps, FormulaireTodoState> {
    constructor(props : FormulaireTodoProps) {
        super(props);
        this.state = {
            task : ''
        }
    }

    changeTaskField = (event:any) : void => {
        this.setState({
            task : event.target.value
        })
    }

    validClick = () :void => {
        this.props.addTodo(this.state.task)
        this.setState({
            task : ''
        })
    }

    render() {
        return (
            <div className="row m-1">
                <input type="text" value={this.state.task.toString()} onChange={this.changeTaskField} className="col form-control" placeholder="Merci de saisir la task à faire" />
                <button onClick={this.validClick} className="col-2 btn btn-primary">Valider</button>
            </div>
        );
    }
}

export default FormulaireTodo;