const http = require("http");
const express = require("express");

let todos = []
let compteurTodo = 0

const app = express();

app.use(express.json());

//Route pour récuperer la liste des todos
app.get('/todos', (req,res) => {
    res.json({
        todos : todos,
        error : false
    })
})

//Route pour récuperer un todo avec son id
app.get('/todo/:id', (req, res) => {
    const id = req.params.id
    const todo = todos.find(t => t.id == id)
    if(todo != undefined) {
        res.json({
            todo : todo,
            error : false
        })
    }
    else {
        res.json({
            error : true,
            message : "todo not found"
        })
    }
})

//Route pour ajouter un todo
app.post('/todo', (req, res) => {
    //On récupère les données à partir du body de la request
    let tmpTodo = {...req.body}
    tmpTodo.id = ++compteurTodo
    todos.push(tmpTodo)
    res.json({
        error : false,
        message : "Todo added with id "+ tmpTodo.id
    })
})

//Route pour supprimer un todo
app.delete('/todo/:id', (req,res) => {
    const id = req.params.id
    todos = todos.filter(t => t.id != id)
    res.json({error : false})
})

//Route pour modifier un todo
app.put('/todo/:id', (req, res) => {
    const id = req.params.id
    const todo = todos.find(t => t.id == id)
    if(todo != undefined) {
        todo.task = req.body.task
        res.json({
            error : false
        })
    }
    else {
        res.json({
            error : true,
            message : "todo not found"
        })
    }
})

const server = http.createServer(app)

server.listen(3010)
