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
        return sum > mostCals ? sum : mostCals
    }, 0);
    console.log("Most cals is ", most)
  });
}


var http = require('https');
http.request(options, callback).end();