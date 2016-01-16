var parseString = require('xml2js').parseString;
var xmlFile = "1.xml";

var fs = require('fs');
var util = require('util');
var data = fs.readFileSync(xmlFile);
var resultArray = [];
var requiredElements = ["day", "month"];

parseString(data, {explicitCharkey : true}, function (err, result) {
    console.log(util.inspect(result, false, null))
    //console.dir(result);
    parseXmlRecursive(result, requiredElements);
    console.log("resultArray " + util.inspect(resultArray, false, null));
    var table = objToHtmlTable(resultArray);
    console.log(table);

    console.log('Done');
});


function parseXmlRecursive(xmlObject, requiredElements) {

    for(var index in xmlObject) {
        if (xmlObject.constructor == Object) {
            if (requiredElements.indexOf(index) > -1 ) {
                resultArray.push({
                    key : xmlObject[index][0]["$"]["name"],
                    value : xmlObject[index][0]["_"]
                });
            }
        }

        if (xmlObject.constructor != String) {
            parseXmlRecursive(xmlObject[index], requiredElements);
        }
    }
}

function objToHtmlTable(obj) {

    var tbody = '<tbody id="tbody">';

    for (var i = 0; i < obj.length; i++) {
        var tr = "<tr>";
        tr += "<td>" + obj[i].key + "</td>" + "<td>" + obj[i].value.toString() + "</td></tr>";
        tbody += tr;
    }

    tbody += '</tbody>';
    return '<table>' + tbody + '</table>';
}