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
    var mostCals = 0, indexOfMostCals = 0;
    str.split("\n\n").forEach(function (element, i, arr){
      console.log("elf ", i, "has ", element, " cals");
        var sum = element.split("\n").map(function(n) { return new Number(n);}).reduce(function (prev, curr, i, arr) {
            return prev + curr;
        });
        if(sum > mostCals) {
            mostCals = sum;
            indexOfMostCals = i;
        }
    });
    console.log("Most cals is ", mostCals, " at elf ", indexOfMostCals+1)
  });
}


var http = require('https');
http.request(options, callback).end();