// Write your JavaScript code.
$(document).ready(
    function saveImage() {
        $.post("http://localhost:50358/api/JsonInput", { base64Data: "Test" });
});
