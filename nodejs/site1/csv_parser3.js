var dir = "../../";
//var file1 = "../../report.csv";
//var file2 = "../../report2.csv";
var fs = require('fs');

var columnNames = ['elapsed', 'bytes'];

var  regexp = new RegExp(/\.csv$/);
var files = fs.readdirSync(dir);
//console.log(files);
for (var i = 0; i < files.length; i++) {
    if (regexp.test(files[i])) {
        getSummaryFromCSV(dir + files[i]);
    }

};

process.exit(0);;

function getSummaryFromCSV(csvFile) {
    var data = fs.readFileSync(csvFile);

    var fullArray = CSVToArray(data);
    console.log(fullArray);
    var miniArray = getCertainColumnsFrom2DArray(fullArray, columnNames)
    console.log(miniArray);
    var totalsArray = get2DArrayTotals(miniArray);
    console.log(totalsArray);
}

function CSVToArray( strData, strDelimiter ){
    // Check to see if the delimiter is defined. If not,
    // then default to comma.
    strDelimiter = (strDelimiter || ",");

    // Create a regular expression to parse the CSV values.
    var objPattern = new RegExp(
        (
            // Delimiters.
            "(\\" + strDelimiter + "|\\r?\\n|\\r|^)" +

            // Quoted fields.
            "(?:\"([^\"]*(?:\"\"[^\"]*)*)\"|" +

            // Standard fields.
            "([^\"\\" + strDelimiter + "\\r\\n]*))"
        ),
        "gi"
        );


    // Create an array to hold our data. Give the array
    // a default empty first row.
    var arrData = [[]];

    // Create an array to hold our individual pattern
    // matching groups.
    var arrMatches = null;


    // Keep looping over the regular expression matches
    // until we can no longer find a match.
    while (arrMatches = objPattern.exec( strData )){

        // Get the delimiter that was found.
        var strMatchedDelimiter = arrMatches[ 1 ];

        // Check to see if the given delimiter has a length
        // (is not the start of string) and if it matches
        // field delimiter. If id does not, then we know
        // that this delimiter is a row delimiter.
        if (
            strMatchedDelimiter.length &&
            strMatchedDelimiter !== strDelimiter
            ){

            // Since we have reached a new row of data,
            // add an empty row to our data array.
            arrData.push( [] );

        }

        var strMatchedValue;

        // Now that we have our delimiter out of the way,
        // let's check to see which kind of value we
        // captured (quoted or unquoted).
        if (arrMatches[ 2 ]){

            // We found a quoted value. When we capture
            // this value, unescape any double quotes.
            strMatchedValue = arrMatches[ 2 ].replace(
                new RegExp( "\"\"", "g" ),
                "\""
                );

        } else {

            // We found a non-quoted value.
            strMatchedValue = arrMatches[ 3 ];

        }


        // Now that we have our value string, let's add
        // it to the data array.
        arrData[ arrData.length - 1 ].push( strMatchedValue );
    }

    // Return the parsed data.
    return( arrData );
}

function findHeaderIndexes(headersFull, headersToFind) {
    if (headersFull.length < 1 || headersToFind.length < 1) {
        throw new Error("Array is empty");
    }

    var indexesToFind = [];
    for (var i = 0; i < headersToFind.length; i++) {
        var tempIndex = -1;
        for (var j = 0; j < headersFull.length; j++) {
            if (headersFull[j] === headersToFind[i]){
                tempIndex = j;
            }
        };
        if (tempIndex > -1) {
            indexesToFind.push(tempIndex);
            continue;
        } else {
            util = require('util');
            var errorString = util.format("Header '%s' was not found in the 2D array", headersToFind[i]);
            throw new Error(errorString);
        }
    };
    return indexesToFind;
}

function getCertainColumnsFrom2DArray(arr, columnNames){
    if (arr.length < 1 || arr[0].length < 1) {
        throw new Error("Array is empty");
    }

    var indexesToFind = findHeaderIndexes(arr[0], columnNames) ;
    var resultArray = [];
    for (var i = 0; i < arr.length; i++) {
        resultArray.push( [] );
        for (var j = 0; j < indexesToFind.length; j++) {
            resultArray[ resultArray.length - 1 ].push( arr[i][indexesToFind[j]] );
        };
    };

    return resultArray;
}

function get2DArrayTotals(arr){
    if (arr.length < 1 || arr[0].length < 1) {
        throw new Error("Array is empty");
    }

    var arrayWithTotals = [ arr[0], [] ];
    for (var i = 0; i < arr[0].length; i++) {
        var sum = 0;
        var numberOfElements = 0;
        for (var j = 1; j < arr.length; j++) {
            sum += parseFloat(arr[j][i]);
            numberOfElements++;
        };
        var average = sum/numberOfElements;
        arrayWithTotals[1][i] = average;
    };

    return arrayWithTotals;
}