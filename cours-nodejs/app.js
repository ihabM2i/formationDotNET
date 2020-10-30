//Declaration d'un objet http pour créer un serveur utilisant le protocole http
//const http = require("http");
//Après installation de express, on importe le module express dans notre fichier
const express = require("express");
const produits = [
    {
        id : 1,
        title : "produit 1",
        price : 10
    },
    {
        id : 2,
        title : "produit 2",
        price : 10
    },
]

//On crée notre application en utilisant express
const app = express()

//On intercepte une requete en get sur la route /
app.get('/', (req,res) => {
    //La réponse de notre requete 
    res.end("Bonjour tout le monde")
})

//On intercepte une requete en get sur la route /produits
app.get('/produits', (req,res) => {
    //res.end("voici les produits")
    //Envoyer la réponse en json
    res.json(produits)
})

//Une route pour chercher un produit en fonction de son id
app.get('/produit/:id', (req,res) => {
    //on peut récupérer dans la requete le paramètre id
    const id = req.params.id
    const produit = produits.find(p => p.id == id)
    if(produit != undefined) {
        res.json({produit : produit , error : false})
    }
    else {
        res.json({message : "product not found", error : true})
    }

})


app.post('/produits', (req,res) => {
    res.json(produits)
})


// const server = http.createServer(app)

// server.listen(5003)

module.exports = app