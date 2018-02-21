

function parse(){if(typeof require !== 'undefined') XLSX = require('xlsx');
var workbook = XLSX.readFile('LossOnReturns.xlsx');
return workbook
debugger
}
console.log(parse())