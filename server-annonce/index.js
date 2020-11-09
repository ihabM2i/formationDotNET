const http =require("http");
const fs = require("fs");
let annonces = [];
let compteur = 0;

const express = require("express");

const app = express()

const updateAnnonces = () => {
    fs.writeFile("sv/data.json", JSON.stringify(annonces))
}

const getAnnonces = () => {
    fs.readFile("sv/data.json",(err,data) => {
        annonces = JSON.parse(data)
    })
}

app.use(express.json());
getAnnonces();
//Ajouter un middelware pour les cross origin
app.use((req, res, next) => {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers","Content-Type")
    res.header("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE")
    next();
})



//route en get  pour récuperer la liste des annonces
app.get('/annonces', (req,res) => {
    res.json({
        error : false,
        annonces : annonces
    })
})


//route en get pour récuperer une seule annonce
app.get('/annonce/:id', (req,res) => {
    const id = req.params.id
    const annonce = annonces.find(a => a.id == id)
    if(annonce != undefined) {
        res.json({
            error : false,
            annonce : annonce
        })
    }
    else {
        res.json({
            error : true,
            message : "Annonce not found"
        })
    }
})

//route pour ajouter une annonce
app.post('/annonce', (req,res) => {
    let annonce = {...req.body};
    annonce.id = ++compteur;
    annonces.push(annonce);
    updateAnnonces();
    res.json({
        error:false,
        id : annonce.id
    })
})

//route pour effectuer une recherche
app.get('/annonces/:filter', (req, res) => {
    const filter = req.params.filter
    const tmpAnnonces = annonces.filter(a => a.titre.includes(filter) || a.description.includes(filter))
    res.json({
        error : false,
        annonces : tmpAnnonces
    })
})
const webServer = http.createServer(app);

webServer.listen(3020)