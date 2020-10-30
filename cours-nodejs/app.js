//Declaration d'un objet http pour créer un serveur utilisant le protocole http
//const http = require("http");
//Après installation de express, on importe le module express dans notre fichier
const express = require("express");


//On crée notre application en utilisant express
const app = express()

//On intercepte une requete en get sur la route /
app.get('/', (req,res) => {
    //La réponse de notre requete 
    res.end("Bonjour tout le monde")
})

//On intercepte une requete en get sur la route /produits
app.get('/produits', (req,res) => {
    res.end("voici les produits")
})


// const server = http.createServer(app)

// server.listen(5003)

module.exports = app