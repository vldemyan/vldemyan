var parseString = require('xml2js').parseString;
var xmlFile = "1.xml";

var fs = require('fs');
var util = require('util');
var data = fs.readFileSync(xmlFile);

parseString(data, {explicitCharkey : true}, function (err, result) {
	console.log(util.inspect(result, false, null))
    //console.dir(result);
    parseXmlRecursive(result);


    console.log('Done');
});


function parseXmlRecursive(xmlObject) {
	//console.log("length " + Object.keys(xmlObject).length);
	//console.log("constructor " + xmlObject.constructor);

	//if (Object.keys(xmlObject).length === 1) {
	//	var key = Object.keys(xmlObject)[0];
	//	console.log("key " + key);
	//	console.log("value " + xmlObject[key]);
	//}
	
	if (xmlObject.constructor == String) {
		console.log(util.inspect(xmlObject, false, null));
	} else {
		for(var index in xmlObject) { 
			if (xmlObject.constructor == Object) {
				console.log("index " + index);
			}
			
	    	//console.log("call recursive");
		    parseXmlRecursive(xmlObject[index]); 
		}
	}

}