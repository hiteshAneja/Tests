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
    this.startMark = function (name) {
        performance.clearMarks(name + START, name + END);
        performance.mark(name + START);
    };

    this.endMark = function (name) {
        performance.mark(name + END);
        performance.clearMeasures(name);
        performance.measure(name, (name + START), (name + END));
    };

    this.printMeasures = function (name) {
        var result = getEntries(name);

        if (result && result.length > 0) {
            result.forEach(function (item, index) { 
                console.log(item.name + ":  " + Math.round(item.duration * 100) / 100 + "ms") 
            });
        }
    };
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
