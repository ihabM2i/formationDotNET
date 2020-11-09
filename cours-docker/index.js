const http = require("http");

const server = http.createServer((req, res) => {
    res.end("Bonjour tout le monde");
});

server.listen(3050);