const http = require("http");
const express = require("express");

let todos = []
let compteurTodo = 0

const app = express();

app.use(express.json());

//Ajouter un middelware pour les cross origin
app.use((req, res, next) => {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers","Content-Type")
    res.header("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE")
    next();
})

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
        id : tmpTodo.id
    })
})

//Route pour ajouter des todos
app.post('/todos', (req, res) => {
    //On récupère les données à partir du body de la request
    for(let tmpTodo of req.body){
        tmpTodo.id = ++compteurTodo
        todos.push(tmpTodo)
    }
    res.json({
        error : false,
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

//Route pour effectuer une recherche sur le contenu du todo
app.get('/search/:filtre', (req, res) => {
    const filtre = req.params.filtre
    const result = todos.filter(t => t.task.includes(filtre))
    res.json(result)
})

const server = http.createServer(app)

server.listen(3010)
