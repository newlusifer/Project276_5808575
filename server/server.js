var io = require('socket.io')(process.env.PORT || 666);

var playerCount = 0;



console.log("server started");

io.on("connection",function(socket){
    console.log("client connected");

    socket.broadcast.emit('Hello');
    playerCount++;

    for(i=0;i<playerCount;i++)
    {
        socket.emit("hello");
        console.log("say hello to player");
    }
  

    socket.on("disconnect",function(){
        console.log("client disconnect");
        playerCount--;
    });

    socket.on("say",function(socket){
        console.log("Hello from server");
    });

});