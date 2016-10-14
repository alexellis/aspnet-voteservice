FROM stefanscherer/node-windows:4.6

MAINTAINER alexellis2@gmail.com


WORKDIR /app

RUN npm install -g nodemon
ADD package.json /app/package.json
RUN npm config set registry http://registry.npmjs.org
RUN npm install
RUN mv /app/node_modules /node_modules

ADD . /app

ENV PORT 4000
EXPOSE 4000

CMD ["node", "server.js"]
