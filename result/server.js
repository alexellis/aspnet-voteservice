var express = require('express'),
    async = require('async'),
    cookieParser = require('cookie-parser'),
    bodyParser = require('body-parser'),
    methodOverride = require('method-override'),
    app = express(),
    server = require('http').Server(app),
    io = require('socket.io')(server),
    request = require('request');

io.set('transports', ['polling']);

var port = process.env.PORT || 4000;

io.sockets.on('connection', function (socket) {

  socket.emit('message', { text : 'Welcome!' });

  socket.on('subscribe', function (data) {
    socket.join(data.channel);
  });
});

function getVotes() {
   console.log("Getting votes");

   var options = {
      uri: process.env.VOTE_SERVICE_URL,
      json: true
    };

    request.get(options, function(err, res, body) {
      if (err) {
        console.error("Waiting for db");
        console.log(body);  
      }else {
        var votes = collectVotesFromResult(body);
        io.sockets.emit("scores", JSON.stringify(votes));
      }
      setTimeout(function() {getVotes() }, 1000);
    });
}

function collectVotesFromResult(result) {
  var votes = {a: result.VoteA, b: result.VoteB};
  return votes;
}

app.use(cookieParser());
app.use(bodyParser());
app.use(methodOverride('X-HTTP-Method-Override'));
app.use(function(req, res, next) {
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
  res.header("Access-Control-Allow-Methods", "PUT, GET, POST, DELETE, OPTIONS");
  next();
});

app.use(express.static(__dirname + '/views'));

app.get('/', function (req, res) {
  res.sendFile(path.resolve(__dirname + '/views/index.html'));
});

server.listen(port, function () {
  var port = server.address().port;
  console.log('App running on port ' + port);
});


getVotes();