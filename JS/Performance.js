(function () {
    var START = "Start",
        END = "End";

    var getEntries = function (name) {
        var result;
        if (name) {
            result = performance.getEntriesByName(name);
        } else {
            result = performance.getEntriesByType('measure');
        }
        return result;
    };


    /* Extend the window's performance API class to have some extra functions for logging. */

    // Starts the mark and clears the previous mark with the same name.
    this.startMark = function (name) {
        performance.clearMarks(name + START, name + END);
        performance.mark(name + START);
    };

    // Ends the mark and calculate the measure between this and the previous mark with the same name.
    this.endMark = function (name) {
        performance.mark(name + END);
        performance.clearMeasures(name);
        performance.measure(name, (name + START), (name + END));
    };

    // Prints all the measures in the console.
    this.printMeasures = function (name) {
        var result = getEntries(name);

        if (result && result.length > 0) {
            result.forEach(function (item, index) { 
                console.log(item.name + ":  " + Math.round(item.duration * 100) / 100 + "ms") 
            });
        }
    };
    
    // Gets all the measures in an easy to use JSON object { name, duration }.
    this.getMeasures = function (name) {
        var response = [],
            result = getEntries(name);

        if (result && result.length > 0) {
            result.forEach(function (item, index) { 
                response.push({ 
                    name: item.name,
                    duration: (Math.round(item.duration * 100) / 100)
                });
            });
        }
        
        return response;
    };

}.call(window.performance));


/*
How to use:
function clickMe() {
    window.performance.startMark('clickMe');
    setTimeout(function () {
        clickMe2();
    }, 100);
}
function clickMe2 () {
    window.performance.startMark('clickMe2');
    setTimeout(function () {
        window.performance.endMark('clickMe');
        window.performance.endMark('clickMe2');
    }, 100);
}

function print () {
   // window.performance.print();
   window.performance.printMeasures('clickMe2');
}


Result #######################
clickMe:  101.72ms
clickMe2:  201.66ms

[{
    "name":"clickMe",
    "duration":101.51
 },
 {
    "name":"clickMe2",
    "duration":201.27
 }]
*/
