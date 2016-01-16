
var arr = [];

//csvTo2DArray("../../report.csv");
//csvTo2DArray("../../report2.csv");
var file1 = "../../report.csv";
var file2 = "../../report2.csv";
var fs = require('fs');
//var file11 = fs.readFileSync(file1);
//console.log(file11);

//fs.readFile(file2, (err, data) => {
//  if (err) throw err;
//  console.log(data);
//});

fs.readFile('/etc/passwd', function(err, data) {
  if (err) throw err;
  console.log(data);
});

function csvTo2DArray(file)
{
    var csv = require('csv');
    var fs = require('fs');

    var input = fs.createReadStream(file);
    var parser = csv.parse({comment: '#'}, function(err, data){
            for (var i = 0 ; i < data.length; i++) {
                arr.push(data[i]);
            };
        //console.log(data);
        console.log(arr);
    });

    input.pipe(parser);
}