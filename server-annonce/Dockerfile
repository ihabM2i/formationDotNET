FROM ubuntu

RUN apt-get update -y 
RUN apt-get upgrade -y 
RUN apt-get install nodejs -q -y
RUN apt-get install npm -q -y

WORKDIR /app

COPY . . 

RUN npm install

ENTRYPOINT [ "node", "index.js" ]