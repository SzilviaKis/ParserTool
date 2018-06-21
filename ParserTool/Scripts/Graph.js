var
    dataset = [],
    graph = null,
    graphcontainer = null,
    height = 250,
    width = 600,
    xScale = null,
    yScale = null,
    cScale = null;

function init() {
    graphcontainer = d3.select(".graphcontainer");

    container_size = d3.select(".graphcontainer").node().getBoundingClientRect();

    width = container_size.width;

    graph = graphcontainer
        .append("svg")
        .attr("height", height)
        .attr("width", width);

    get_data();
    set_scales();
    draw_graph();
    bind_UI_actions();
}

function get_data() {
    // generate data
    new_dataset = [];
    n = Math.round(Math.random() * 30);
    for (var i = 0; i < n; i++) {
        new_dataset.push(Math.random() * 100);
    }
    dataset = new_dataset;
}

function set_scales() {
    // set scales
    xScale = d3.scale.ordinal()
        .domain(d3.range(dataset.length))
        .rangeRoundBands([0, width], 0.05);

    yScale = d3.scale.linear()
        .domain([0, d3.max(dataset)])
        .range([0, height]);

    cScale = d3.scale.linear()
        .domain([0, d3.max(dataset)])
        .range(["gainsboro", "orangered"]);
}

function draw_graph() {
    // bind data to the bars
    var bars = graph.selectAll("rect")
        .data(dataset);

    // remove any extraneous bars
    bars.exit()
        .transition()
        .duration(500)
        .attr("x", width)
        .remove();

    // add any new bars
    bars.enter()
        .append("rect")
        .attr("x", width)
        .attr("y", function (d) {
            return height - yScale(d);
        })
        .attr("width", xScale.rangeBand())
        .attr("height", function (d) {
            return yScale(d);
        })
        .attr("fill", function (d) {
            return cScale(d);
        });

    // update all the bars to reflect the dataset
    bars.transition()
        .duration(500)
        //.ease('bounce') // ridiculous bouncy easing
        //.ease('elastic') // elastic easing woo
        .attr("x", function (d, i) {
            return xScale(i);
        })
        .attr("y", function (d) {
            return height - yScale(d);
        })
        .attr("width", xScale.rangeBand())
        .attr("height", function (d) {
            return yScale(d);
        })
        .attr("fill", function (d) {
            return cScale(d);
        });
}

function bind_UI_actions() {
    d3.select("p")
        .on("click", function () {
            get_data();
            set_scales();
            draw_graph();
        });
}

init();

d3.select(window).on('resize', resize);

function resize() {
    container_size = d3.select(".graphcontainer").node().getBoundingClientRect();
    width = container_size.width;

    set_scales();
    draw_graph();
}