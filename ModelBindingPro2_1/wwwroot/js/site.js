// Write your JavaScript code.
$(document).ready(
    function saveImage() {
        $.post("https://localhost:44307/api/JsonInput", { base64Data: "Test" });
});
