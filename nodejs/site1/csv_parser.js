
var headers = [];
var body = [];

csvTo2DArray("../../report.csv");
csvTo2DArray("../../report2.csv");

console.log(headers);
console.log(body);

function csvTo2DArray(file)
{

    var csv = require("fast-csv");
    var fs = require('fs');
    var stream = fs.createReadStream(file);

    var csvStream = csv()
        //.fromPath(file, {headers: true})
        .on("data", function(data){
            //if (headers.length === 0) {
            //    headers = data;
            //    console.log("data");
            //} else {
            //    body.push(data);
            //    console.log("body");
            //}
                body.push(data);
                console.log("body");

            //console.log(data.length);
//            for (var i = data.length - 1; i >= 0; i--) {
//                for (var k = data.length - 1; k >= 0; k--) {
//                    console.log("k: " + data[k].length);
//                };
//                console.log("i: " + data[i].length);
//            };

        })
        .on("end", function(){
            dataToCSV(body, "../../report_sum.csv");
             console.log("done");
        });


    stream.pipe(csvStream);

}

function dataToCSV(data, file)
{
    var csv = require("fast-csv");
    csv
       .writeToPath(file, data, {headers: true})
       .on("finish", function(){
          console.log("done!");
       });
}