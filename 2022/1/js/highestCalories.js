const toHighestSum = ( highest, itemCals) => {
  const sumOfElfCals = itemCals.split("\n").reduce((sum, next) => sum + new Number(next), 0);
  return sumOfElfCals > highest ? sumOfElfCals : highest;
}
require('https').request({
  host: 'adventofcode.com',
  path: '/2022/day/1/input',
  headers: { 'Cookie': ""}
}, (response) => {
  let str = "";
  response.on('data', chunk => str += chunk);
  response.on('end', () => (str) => console.log("Most cals is ", str.split("\n\n").reduce(toHighestSum, 0)));
}).end();