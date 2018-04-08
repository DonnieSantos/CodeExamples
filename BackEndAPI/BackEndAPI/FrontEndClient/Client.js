$(document).ready(function () {

    $(".student-name").focusin(function () {
        $(".student-name").val("");
    });

    $(".student-name").focusout(function () {
        if ($(".student-name").val().length == 0) {
            $(".student-name").val(" [ Student Name ]");
        }
    });

    $(".student-id").focusin(function () {
        $(".student-id").val("");
    });

    $(".student-id").focusout(function () {
        if ($(".student-id").val().length == 0) {
            $(".student-id").val(" [ Student ID ]");
        }
    });

    $(".student-post").click(function () {

        var payloadJsonObject = [
            {
                "name": $(".student-name").val(),
                "id": parseInt($(".student-id").val())
            }
        ];

        var payloadJsonString = JSON.stringify(payloadJsonObject);

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'type': 'POST',
            'url': "http://localhost:53402/api/students",
            'data': payloadJsonString,
            'dataType': 'json',
            'success': function () {
                alert("Post Response: " + response);
            }
        });
    });
});