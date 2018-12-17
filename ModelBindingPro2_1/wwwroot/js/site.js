// Write your JavaScript code.
$(document).ready(
    //function saveImage() {
    //    $.post("https://localhost:44307/api/JsonInput", { base64Data: "Test" });
    //}
    function save() {
        //var encoder = new mxCodec();
        //var node = encoder.encode(graph.getModel());
        //var model = mxUtils.getPrettyXml(node);
        //mxUtils.popup(model, true);
        var model = "<mxGraphModel>\n  <root>\n    <mxCell id=\"0\"/>\n    <mxCell id=\"1\" parent=\"0\"/>\n  </root>\n</mxGraphModel>\n";
        $.ajax({
            url: "https://localhost:44307/api/JsonInput/Save",
            contentType:"application/json",
            data: JSON.stringify(model),
            type: "POST",
            success: function (result) {
                console.log(result);
            }
        });

    }
);

$(document).ready(function () {
    //var coordinate = evt.coordinate;


    var datapoints = new Array();
    var datapt = new Object();
    datapt.X = "123.456";
    datapt.Y = "123.654";
    datapoints.push(datapt);
    var datapt1 = new Object();
    datapt1.X = "1123.456";
    datapt1.Y = "1123.654";
    datapoints.push(datapt1);
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "api/JsonInput/AddPointsToDB", true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(datapoints));
});

