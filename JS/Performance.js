(function () {
    var self = this,
        START = "Start",
        END = "End";

    var getEntries = function (name) {
        var result;
        if (name) {
            result = self.getEntriesByName(name);
        } else {
            result = self.getEntriesByType('measure');
        }
        return result;
    };


    /* Extend the window's performance API class to have some extra functions for logging. */

    // Starts the mark and clears the previous mark with the same name.
    this.startMark = function (name) {
        if (self.mark && name) {
            self.clearMarks(name + START, name + END);
            self.mark(name + START);
        }
    };

    // Ends the mark and calculate the measure between this and the previous mark with the same name.
    this.endMark = function (name) {
        if (self.mark && name) {
            self.mark(name + END);
            self.clearMeasures(name);
            self.measure(name, (name + START), (name + END));
        }
    };
    
    // Gets all the measures in an easy to use JSON object { name, duration }.
    this.getMeasures = function (name) {
        if (self.mark) {
            var response = [],
                result = getEntries(name);

            if (result && result.length > 0) {
                result.forEach(function (item) {
                    response.push({
                        name: item.name,
                        duration: (Math.round(item.duration * 100) / 100)
                    });
                });
            }

            return response;
        }
        return {};
    };

    // Prints all the measures on the console.
    this.printMeasures = function (name) {
        return JSON.stringify(this.getMeasures(name));
    };

    // Get duration of one particular measure.
    this.duration = function (name) {
        if (self.mark && name) {
            var entries = this.getMeasures(name);
            if (entries && entries.length > 0) {
                return entries[0].duration;
            }
        }
    };

    // Measures the difference between two marks, store the measure and return the result.
    this.difference = function (name, from, to) {
        if (self.mark && from && to) {
            self.measure(name, from, to);
            return this.getMeasures(name);
        }
    };


}.apply(window.performance));


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
