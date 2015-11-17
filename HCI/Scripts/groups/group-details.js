$(document).ready(function ($) {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()

    })
});

$(document).ready(function () {
    $("#UserList").on("click", "#link-userName", function () {
        $.ajax({
            type: "GET",
            url: "/HCI/User/GetUserInfo",
            data: { userName: $(this).text() }
        })
        .done(function (partialViewResult) {
            $("#user-modalBody").html(partialViewResult);
        });
    });
});

$(document).ready(function () {
    $("#EventList").on("click", "#link-event", function () {
        var id = $(this).prev("#eventID").text();
        var EventDetail = "#EventDetail" + id;
        $('.hide-all-event').hide();
        $(EventDetail).show();

    })
})