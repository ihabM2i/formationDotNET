const http = require("http");
const express = require("express");
const fs = require("fs");
const app = express();
app.use(express.json());

app.post("/data", (req, res) => {
    const nameFile = req.body.nameFile;
    const contentFile = req.body.contentFile;
    fs.writeFile("sv/"+nameFile,contentFile,(err) => {
        if(!err) {
            res.json({err : false})
        }
        else {
            res.json({err : err})
        }
    })
});

const server = http.createServer(app);

server.listen(4010);
