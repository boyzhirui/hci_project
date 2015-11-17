var editRepeat = false;
var modalOKclick = false;
var modalCancelclick = false;

function getNowTime() {
    var date = new Date();
    var hour = date.getHours();
    var min = date.getMinutes();

    if (hour < 10) {
        hour = '0' + hour;
    }

    if (min < 10) {
        min = '0' + min;
    }

    return hour + ':' + min;
}

function setModalError(id, msg) {
    var msgDiv = $('#' + id);

    msgDiv.text(msg);
}
function removeRepeatsOnError() {
    $('#repeatsOnGroup').removeClass('has-error');
    $('#modalWeeklyRepeatsErrorMsg').text("");
    $('#modalMonthlyRepeatsErrorMsg').text("");
}

function removeEndsOnDateError() {
    $('#endsOnDateGroup').removeClass('has-error');
    $('#modalEndsOnErrorMsg').text("");
}

function validateModal(displayErr, displaySummary) {
    $('#modalSummary').text('');

    var error = false;
    var intervalType = $('#repeatingType').children(':selected').prop('value');
    var occurDays = '';
    var firstDay = true;
    var neverEnds = $('#endsOnNeverRadio').prop('checked');
    var startDate = $('#startsOnText').prop('value');
    var endDate = '';

    if (intervalType == 'Weekly') {
        if ($('#sunCheck').prop('checked')) {
            if (firstDay) {
                firstDay = false;
            }
            else {
                occurDays += ',';
            }
            occurDays += 'Sun';
        }

        if ($('#monCheck').prop('checked')) {
            if (firstDay) {
                firstDay = false;
            }
            else {
                occurDays += ',';
            }
            occurDays += 'Mon';
        }

        if ($('#tueCheck').prop('checked')) {
            if (firstDay) {
                firstDay = false;
            }
            else {
                occurDays += ',';
            }
            occurDays += 'Tue';
        }

        if ($('#wedCheck').prop('checked')) {
            if (firstDay) {
                firstDay = false;
            }
            else {
                occurDays += ',';
            }
            occurDays += 'Wed';
        }

        if ($('#thuCheck').prop('checked')) {
            if (firstDay) {
                firstDay = false;
            }
            else {
                occurDays += ',';
            }
            occurDays += 'Thu';
        }

        if ($('#friCheck').prop('checked')) {
            if (firstDay) {
                firstDay = false;
            }
            else {
                occurDays += ',';
            }
            occurDays += 'Fri';
        }

        if ($('#satCheck').prop('checked')) {
            if (firstDay) {
                firstDay = false;
            }
            else {
                occurDays += ',';
            }
            occurDays += 'Sat';
        }
    }
    else if (intervalType == 'Monthly') {
        occurDays = $('#monthlyRepeatsOnText').prop('value');
    }

    if (intervalType != 'Daily' && typeof occurDays != 'undefined' && occurDays != '') {
        if (intervalType == 'Monthly') {
            var monthlyDaysPatt = /^((0?[1-9])|[1-2][0-9]|(30)|(31))(,((0?[1-9])|[1-2][0-9]|(30)|(31)))*$/;
            if (!monthlyDaysPatt.test(occurDays)) {
                error = true;
                if (displayErr) {
                    $('#repeatsOnGroup').addClass('has-error');
                    setModalError('modalMonthlyRepeatsErrorMsg', 'Only numbers between 01 and 31 and commas are valid.');
                }
            }
        }
    }
    else if (intervalType != 'Daily') {
        error = true;
        if (displayErr) {
            $('#repeatsOnGroup').addClass('has-error');
            if (intervalType == 'Weekly') {
                setModalError('modalWeeklyRepeatsErrorMsg', '"Repeats on" field is required.');
            } else if (intervalType == 'Monthly') {
                setModalError('modalMonthlyRepeatsErrorMsg', '"Repeats on" field is required.');
            }
        }
    }



    if (!neverEnds) {
        endDate = $('#endsOnDateText').prop('value');

        if (typeof endDate == 'undefined' || endDate == '') {
            error = true;
            if (displayErr) {
                $('#endsOnDateGroup').addClass('has-error');
                setModalError('modalEndsOnErrorMsg', '"Ends on" field is required.');
            }
        }
        else {
            if (startDate > endDate) {
                error = true;
                if (displayErr) {
                    $('#endsOnDateGroup').addClass('has-error');
                    setModalError('modalEndsOnErrorMsg', '"Ends on" field should not be earlier than "Starts on"');
                }
            }
        }
    }

    if (!error) {
        if (displaySummary) {
            var summaryMsg = '';
            summaryMsg = intervalType;

            if (intervalType == 'Weekly') {
                summaryMsg += ' on ' + occurDays;
            }
            else if (intervalType == 'Monthly') {
                summaryMsg += ' on day ' + occurDays;
            }

            if (!neverEnds) {
                summaryMsg += " until " + endDate;
            }

            $('#modalSummary').text('Summary: ' + summaryMsg);
        }

        $('#NeverEnd').prop('value', neverEnds);
        $('#OccurDays').prop('value', occurDays);
        $('#IntervalType').prop('value', intervalType);
        $('#EndDateForCycle').prop('value', endDate);
    }

    return { error: error, summary: summaryMsg };
}

function getLocation() {
    var isRepeat = $('#Repeats').prop('checked');
    var startDate, endDate, startTime, endTime, intervalType, occurDays, neverEnds;
    var locationID = $('#LocationID');

    occurDays = '';
    intervalType = 'OneDay';
    startDate = $('#StartDate').prop('value');
    endDate = $('#EndDate').prop('value');
    startTime = $('#StartTime').prop('value');
    endTime = $('#EndTime').prop('value');

    if (isRepeat) {
        intervalType = $('#IntervalType').prop('value');
        occurDays = $('#OccurDays').prop('value');
        neverEnds = $('#NeverEnd').prop('value');
        endDate = endDate$('#EndDateForCycle').prop('value');
    }


    $.ajax({
        url: '/HCI/api/AvailableLocation?' + 'startDate=' + startDate + '&endDate=' + endDate + '&startTime=' + startTime + '&endTime=' + endTime + '&intervalType=' + intervalType + '&occurDays=' + occurDays + '&neverEnds=' + neverEnds,
        dataType: 'json',

        success: function (data) {

            locationID.empty();
            for (i = 0; i < data.length; i++) {
                $("<option>").prop('value', data[i].ID).text(data[i].Name).appendTo(locationID);
            }
        }
    });

    if (locationID.children("option").length == 0) {
        $('<option value="-1" selected>No Available Room</option>').appendTo(locationID);
    }
}

$(document).ready(function ($) {
    $(function () {
        $('#Title').focus();
    })
});

$(document).ready(function ($) {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
});

$(document).ready(function ($) {
    $(function () {
        $('.clockpicker').clockpicker({
            autoclose: true,
        });

        $('#StartTime').prop('value', getNowTime());

        $('#StartDate').datepicker({
            format: "yyyy-mm-dd",
            weekStart: 0,
            todayBtn: "linked",
            forceParse: false,
            autoclose: true,
            todayHighlight: true
        });

        $('#EndDate').datepicker({
            format: "yyyy-mm-dd",
            weekStart: 0,
            todayBtn: "linked",
            forceParse: false,
            autoclose: true,
            todayHighlight: true
        });

        $('#endsOnDateText').datepicker({
            format: "yyyy-mm-dd",
            weekStart: 0,
            todayBtn: "linked",
            forceParse: false,
            autoclose: true,
            todayHighlight: true
        });
    }
    )
});

$(document).ready(function ($) {
    $(function () {
        $('#Repeat').change(function (event) {
            editRepeat = false;

            if (this.checked) {
                var startDate = $('#StartDate').prop('value');
                $('#startsOnText').prop('value', startDate);
                $('#RepeatSetup').modal('show');
                $("#repeatText").prop('hidden', false);
            }
            else {
                $("#repeatText").prop('hidden', true);
            }
        });

        $('#repeatEdit').click(function (event) {
            editRepeat = true;
            var startDate = $('#StartDate').prop('value');
            $('#startsOnText').prop('value', startDate);
            $('#RepeatSetup').modal('show');
        });

        $('#endsOnDateRadio').change(function (event) {
            removeEndsOnDateError();
            if (this.checked) {
                $('#endsOnDateText').prop('disabled', false)
            }
            else {
                $('#endsOnDateText').prop('disabled', true)
            }
            validateModal(true, true);
        });

        $('#endsOnNeverRadio').change(function (event) {
            removeEndsOnDateError();
            if (this.checked) {
                $('#endsOnDateText').prop('disabled', true)
            }
            else {
                $('#endsOnDateText').prop('disabled', false)
            }
            validateModal(true, true);
        });

        $('#endsOnDateText').change(function (event) {
            removeEndsOnDateError();
            validateModal(true, true);
        });

        $('#repeatingType').change(function (event) {
            var selectedVal = $(this).children(':selected').prop('value');

            removeRepeatsOnError();

            if (selectedVal == 'Weekly') {
                $('#weeklyRepeatsOn').prop('hidden', false);
                $('#monthlyRepeatsOn').prop('hidden', true);
            }
            else if (selectedVal == 'Monthly') {
                $('#weeklyRepeatsOn').prop('hidden', true);
                $('#monthlyRepeatsOn').prop('hidden', false);
            }
            else {
                $('#weeklyRepeatsOn').prop('hidden', true);
                $('#monthlyRepeatsOn').prop('hidden', true);
            }

            validateModal(true, true);
        });

        $('#repeatsOnGroup').change(function (event) {
            removeRepeatsOnError();
            validateModal(true, true);
        });

        $('#modalOK').click(function (event) {
            modalOKclick = true;
            var result = validateModal(true, true);
            if (!result.error) {
                $('#repeatText').children("strong").text(result.summary);
                $('#RepeatSetup').modal('hide');
                getLocation();
            }
        });

        $('#modalCancel').click(function (event) {
            modalCancelclick = true;
            if (!editRepeat) {
                $('#Repeat').prop('checked', false);
                $("#repeatText").prop('hidden', true);
            }
            getLocation();
        });

        $('#RepeatSetup').on('shown.bs.modal', function (e) {
            modalCancelclick = false;
            modalOKclick = false;
        })

        $('#RepeatSetup').on('hidden.bs.modal', function (e) {
            if (!modalCancelclick && !modalOKclick && !editRepeat) {
                $('#Repeat').prop('checked', false);
                $("#repeatText").prop('hidden', true);
            }
        })

        $('#StartDate').change(function (event) {

            getLocation();
        });

        $('#EndDate').change(function (event) {

            getLocation();
        });

        $('#StartTime').change(function (event) {

            getLocation();
        });

        $('#EndTime').change(function (event) {
            getLocation();
        });

    })
});