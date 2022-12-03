var options = {
  host: 'adventofcode.com',
  path: '/2022/day/1/input',
  headers: { 'Cookie': ""}
};
var callback = function(response) {
  var str = "";
  response.on('data', function (chunk) {
    str += chunk;
  });

  response.on('end', function () {
    var most = str.split("\n\n").reduce(function (mostCals, element, i, arr){
        var sum = element.split("\n").reduce(function (prev, curr, i, arr) {
            return prev + new Number(curr);
        }, 0);
        if(sum > mostCals[0]) return [sum, mostCals[0], mostCals[1]];
        else if(sum > mostCals[1]) return [mostCals[0], sum, mostCals[1]];
        else if(sum > mostCals[2]) return [mostCals[0], mostCals[1], sum];
        else return mostCals;
    }, [0,0,0]);
    console.log("Total of top 3 cals is ", most.reduce(function (c,n) { return c+n; }));
  });
}


var http = require('https');
http.request(options, callback).end();