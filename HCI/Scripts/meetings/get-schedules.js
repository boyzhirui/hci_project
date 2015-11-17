var meetingPatt = /^meeting_/;

function getDateString(date) {
    var dd, mm, yyyy;

    if (date.getDate) {
        dd = date.getDate();
        mm = date.getMonth() + 1; //January is 0!
        yyyy = date.getYear();
    }
    else {
        dd = date.date();
        mm = date.month() + 1; //January is 0!
        yyyy = date.year();
    }

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    dateStr = yyyy + '-' + mm + '-' + dd;
    return dateStr;
}

$(document).ready(function () {

    var userName = $('#userName').text();
    //today = getDateString(new Date());
    var today = new moment(new Date());

    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        timeFormat: 'H:mm',
        defaultDate: today,
        editable: true,
        eventLimit: true, // allow "more" link when too many events
        events: function (start, end, timezone, callback) {
            var startStr = getDateString(start);
            var endStr = getDateString(end);
            $.ajax({
                url: '/HCI/api/EventList',
                dataType: 'json',
                data: {
                    start: startStr,
                    end: endStr,
                    userName: userName

                },
                success: function (data) {
                    var events = [];
                    var i = 0;
                    var color = "#9A9CFF";
                    var eventlist = $('#eventList');
                    eventlist.empty();

                    for (i = 0; i < data.length; i++) {
                        if (data[i].IsMeeting) {
                            color = "#59b953";
                        }
                        else {
                            color = "#9A9CFF";
                        }
                        events.push({
                            title: data[i].Title,
                            start: data[i].Start,
                            end: data[i].End,
                            color: color,
                            allDay: false,
                            id: data[i].UniqueID
                        });
                        var uid = data[i].UniqueID;
                        var eventDiv = $('<div id="' + uid + '"/>');
                        eventDiv.append($('<span id="location"/>').text(data[i].LocationAddress));
                        eventDiv.append($('<span id="description"/>').text(data[i].Description));
                        eventDiv.append($('<span id="peroidic"/>').text(data[i].IsPeriodic));
                        eventDiv.append($('<span id="eventID"/>').text(data[i].EventID));
                        eventDiv.append($('<span id="ownerName"/>').text(data[i].OwnerName));
                        eventDiv.appendTo(eventlist);
                    }
                    callback(events);
                }
            });
        },
        eventClick: function (calEvent, jsEvent, view) {
            if (meetingPatt.test(calEvent.id)) {
                var location = $('#eventList #' + calEvent.id + ' #location').text();
                var description = $('#eventList #' + calEvent.id + ' #description').text();
                var peroidic = $('#eventList #' + calEvent.id + ' #peroidic').text();
                var eventID = $('#eventList #' + calEvent.id + ' #eventID').text();
                var ownerName = $('#eventList #' + calEvent.id + ' #ownerName').text();

                var modalWin = $('#meetingModal');
                modalWin.find('#title').text(calEvent.title);

                var time = calEvent.start.format('YYYY-MM-DD HH:mm') + ' ~ ' + calEvent.end.format('HH:mm');
                modalWin.find('#time').text(time);

                modalWin.find('#location').text(location);
                modalWin.find('#description').text(description);
                modalWin.find('#peroidic').text(peroidic);
                modalWin.find('#eventID').text(eventID);
                modalWin.find('#uid').text(calEvent.id);

                modalWin.find('#cancelBtn').addClass('invisible');
                modalWin.find('#cancelSeriesBtn').addClass('invisible');

                if (ownerName == userName) {
                    if (peroidic == 'true') {
                        modalWin.find('#cancelSeriesBtn').removeClass('invisible');
                    }
                    modalWin.find('#cancelBtn').removeClass('invisible');
                }

                modalWin.modal('show');
            }


        },
        dayClick: function (date, jsEvent, view) {

            var scheduleMeetingModal = $('#scheduleMeetingModal');

            var meetingDate = date.format('YYYY-MM-DD');
            var title = scheduleMeetingModal.find('#title');
            title.text("Do you want to schedule a meeting on [" + meetingDate + "]?");
            var meetingDateInput = scheduleMeetingModal.find('#meetingDate');
            meetingDateInput.prop('value', meetingDate);
            scheduleMeetingModal.modal('show');
        }
    });

    $('#meetingModal').on('click', '#cancelBtn', function () {
        var uid = $('#meetingModal #uid').text();

        $('#calendar').fullCalendar('removeEvents', uid);
    });

    $('#meetingModal').on('click', '#cancelSeriesBtn', function () {
        var eventID = $('#meetingModal #eventID').text();

        $.ajax({
            url: '/HCI/api/MeetingWebAPI?eventID=' + eventID,
            dataType: 'json',
            type: 'DELETE',
            success: function (data) {
                $('#calendar').fullCalendar('refetchEvents');
            }
        });

    });
});