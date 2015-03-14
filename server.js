var http = require("http");
http.createServer(function(req,res){
	res.write("<h1>Welcome to Node.js</h1>");
	res.end();
}).listen(9090);
