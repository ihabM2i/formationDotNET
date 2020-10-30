const http = require("http");
const app = require("./app")
// const server = http.createServer((request, response) => {
//     response.end("Bonjour tout le monde")
// })

//On cree notre serveur http
const server = http.createServer(app)

// on ecoute le port 5001
server.listen(5001)