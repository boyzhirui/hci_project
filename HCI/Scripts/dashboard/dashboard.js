$(document).ready(function () {
    $("#EventList").on("click", "#link-event", function () {
        var id = $(this).prev("#eventID").text();
        var EventDetail = "#EventDetail" + id;
        $('.hide-all-event').hide();
        $('#cancelSeriesBtn').addClass("edit-input");
        $('#cancelBtn').addClass("edit-input");
        $(EventDetail).show();
        var eventOwner = '#eventOwner' + (Number(id) + 1);
        if ($(eventOwner).length > 0) {
            $('#cancelSeriesBtn').removeClass("edit-input");
            $('#cancelBtn').removeClass("edit-input");
        }
    })
})