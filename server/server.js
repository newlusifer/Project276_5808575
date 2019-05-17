var io=require('socket.io')(process.env.PORT||3000);

var playerCount = 1;

var min=1; 
var max=6;  
var NumberGuess =Math.floor(Math.random() * (+max - +min)) + +min;

var currentPlayer="player";
console.log();
console.log("*************************************************************************************************************");
console.log("server is started");


console.log("numberGuess is "+NumberGuess);

io.on("connection",function(socket){
    console.log();
    console.log("client is connected");
    
    playerCount++;
    socket.broadcast.emit("startRoll");
    for(i=1;i<playerCount;i++)
    {
        
        console.log("welcome player"+" : "+i);
        socket.emit("startRoll");
        socket.emit("name",{player:i});
    }    

    socket.on("disconnect",function(){
        console.log("client disconnect");
        playerCount--;
    })

    socket.on("name",function(e){
       currentPlayer=e;
             // console.log(currentPlayer);
    });
    

    socket.on("roll",function(e){
        console.log();
        console.log(currentPlayer);
         console.log(" = "+e);

        if (e>NumberGuess){
            socket.emit("wrong");
        }

        if (e<NumberGuess){
            socket.emit("wrong");
        }

        if (e==NumberGuess){
            console.log();
            console.log("the winner is....... ");
            console.log(currentPlayer);
           socket.broadcast.emit("winner",currentPlayer);
           for(i=1;i<playerCount;i++)
    {
        socket.emit("winner",currentPlayer);        
    }    

    console.log();
    NumberGuess =Math.floor(Math.random() * (+max - +min)) + +min;
    console.log("New numberGuess is "+NumberGuess);
        }
    });

    });
