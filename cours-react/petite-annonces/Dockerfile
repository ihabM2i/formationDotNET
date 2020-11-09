FROM ubuntu

RUN apt-get update -y
RUN apt-get upgrade -y
RUN apt-get install -q -y nodejs 
RUN apt-get install -q -y npm

WORKDIR /app

COPY . .

RUN npm install
ENTRYPOINT ["npm", "start"]