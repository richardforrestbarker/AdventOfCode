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
    var mostCals = [0,0,0], indexOfMostCals = [0,0,0];
    str.split("\n\n").forEach(function (element, i, arr){
      console.log("elf ", i, "has ", element, " cals");
        var sum = element.split("\n").map(function(n) { return new Number(n);}).reduce(function (prev, curr, i, arr) {
            return prev + curr;
        });
        if(sum > mostCals[0]) {
          var temp = {cals: mostCals[0], index: indexOfMostCals[0]}
          var temp2 = {cals: mostCals[1], index: indexOfMostCals[1]}
          mostCals[0] = sum;
          indexOfMostCals[0] = i;
          
          mostCals[1] = temp.cals;
          indexOfMostCals[1] = temp.index;
          
          mostCals[2] = temp2.cals;
          indexOfMostCals[2] = temp2.index;
        }
        else if(sum > mostCals[1]) {
          var temp = {cals: mostCals[1], index: indexOfMostCals[1]}
          mostCals[1] = sum;
          indexOfMostCals[1] = i;
          
          mostCals[2] = temp.cals;
          indexOfMostCals[2] = temp.index;
        } else if(sum > mostCals[2]) {
          mostCals[2] = sum;
          indexOfMostCals[2] = i;
        }
    });
    console.log("Most cals is ", mostCals[0], " at elf ", indexOfMostCals[0]+1)
    console.log("Total of top 3 cals is ", mostCals.reduce(function(n,n1) { return n + n1;}), " at elves ", indexOfMostCals.join(", "))
  });
}


var http = require('https');
http.request(options, callback).end();