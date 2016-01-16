var http = require('http');
var url = require('url');
var querystring = require('querystring');

var time1 = new Date().getTime();

var body = "<!DOCTYPE html>" +
"<html>" +
 "<head>" +
  "<meta charset='utf-8'>" +
  "<title>Круговая диаграмма</title>" +
  "<script src='https://www.google.com/jsapi'></script>" +
  "<script>" +
   "google.load('visualization', '1', {packages:['corechart']});" +
   "google.setOnLoadCallback(drawChart);" +
   "function drawChart() {" +
    "var data = google.visualization.arrayToDataTable([" +
     "['Газ', 'Объём']," +
     "['Азот',     78.09]," +
     "['Кислород', 20.95]," +
     "['Аргон',    0.93]," +
     "['Углекислый газ', 0.03]" +
    "]);" +
    "var options = {" +
     "title: 'Состав воздуха'," +
     "is3D: true," +
     "pieResidueSliceLabel: 'Остальное'" +
    "};" +
    "var chart = new google.visualization.PieChart(document.getElementById('air'));" +
     "chart.draw(data, options);" +
   "}" +
  "</script>" +
 "</head>" +
 "<body>" +
  "<div id='air' style='width: 500px; height: 400px;'></div>" +
 "</body>" +
"</html>" ;

function accept(req, res) {

  res.writeHead(200, {
    'Content-Type': 'text/plain',
    'Cache-Control': 'no-cache'
  });
  var time2 = new Date().getTime();
  console.log( time2 - time1 );
  time1 = time2;

  //sleep(3000);
  res.end(body);
}

function sleep(delay) {
    var start = new Date().getTime();
    while (new Date().getTime() < start + delay);
}




http.createServer(accept).listen(8080);



