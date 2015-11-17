$(document).ready(function ($) {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });

    $('.nav-tabs').on('click', '#joinRequestsTab', function () {
        if (!$(this).hasClass('active')) {
            $(this).addClass('active');
            $(this).siblings('#meetingRequestsTab').removeClass('active');
            $('#meetingRequests').addClass('invisible');
            $('#joinRequests').removeClass('invisible');
        }

    });

    $('.nav-tabs').on('click', '#meetingRequestsTab', function () {
        if (!$(this).hasClass('active')) {
            $(this).addClass('active');
            $(this).siblings('#joinRequestsTab').removeClass('active');
            $('#joinRequests').addClass('invisible');
            $('#meetingRequests').removeClass('invisible');
        }
    });
});

$(document).ready(function ($) {
    $('#joinRequests').on('click', "input[name='check']", function () {
        refreshJoinRequestTab();
    });

    $('#joinRequests').on('click', '#selectAll', function () {

        var joinRequests = $('#joinRequests');

        joinRequests.find("input[name='check']").each(function (ind, node) {
            $(node).prop('checked', true);
        });

        refreshJoinRequestTab();
    });

    $('#joinRequests').on('click', '#unselectAll', function () {

        var joinRequests = $('#joinRequests');

        joinRequests.find("input[name='check']").each(function (ind, node) {
            $(node).prop('checked', false);
        });

        refreshJoinRequestTab();
    });

    $('#joinRequests').on('click', '#selectAllUnprocessed', function () {

        var joinRequests = $('#joinRequests');

        joinRequests.find("input[name='check']").each(function (ind, node) {
            var jnode = $(node);
            var readed = jnode.parent().parent().find('#readed');
            if (readed.prop('value') == '0') {
                jnode.prop('checked', true);
            }
            else {
                jnode.prop('checked', false);
            }
        });

        refreshJoinRequestTab();
    });

    $('#joinRequests').on('click', '#selectAllProcessed', function () {

        var joinRequests = $('#joinRequests');

        joinRequests.find("input[name='check']").each(function (ind, node) {
            var jnode = $(node);
            var readed = jnode.parent().parent().find('#readed');
            if (readed.prop('value') == '1') {
                jnode.prop('checked', true);
            }
            else {
                jnode.prop('checked', false);
            }
        });
        refreshJoinRequestTab();
    });

    $('#joinRequests').on('click', '#acceptBtn', function () {

        var msg = $(this).parent().parent();
        processJoinRequest(msg, 'Yes');
    });

    $('#joinRequests').on('click', '#rejectBtn', function () {

        var msg = $(this).parent().parent();
        processJoinRequest(msg, 'No');
    });

    $('#joinRequests').on('click', '#undoBtn', function () {
        var msg = $(this).parent().parent();
        processJoinRequest(msg, 'Pending');
    });

    $('#joinRequests').on('click', '#acceptAllBtn', function () {

        $('#joinRequests').find("input[name='check']:checked").each(function (ind, node) {
            var jnode = $(node);
            var msg = jnode.parent().parent();
            processJoinRequest(msg, 'Yes');
        });


    });

    $('#joinRequests').on('click', '#rejectAllBtn', function () {

        $('#joinRequests').find("input[name='check']:checked").each(function (ind, node) {
            var jnode = $(node);
            var msg = jnode.parent().parent();
            processJoinRequest(msg, 'No');
        });

    });

    $('#joinRequests').on('click', '#undoAllBtn', function () {

        $('#joinRequests').find("input[name='check']:checked").each(function (ind, node) {
            var jnode = $(node);
            var msg = jnode.parent().parent();
            processJoinRequest(msg, 'Pending');
        });


    });

});

$(document).ready(function ($) {
    $('#meetingRequests').on('click', "input[name='check']", function () {
        refreshMeetingRequestTab();
    });

    $('#meetingRequests').on('click', '#selectAll', function () {

        var meetingRequests = $('#meetingRequests');

        meetingRequests.find("input[name='check']").each(function (ind, node) {
            $(node).prop('checked', true);
        });

        refreshMeetingRequestTab();
    });

    $('#meetingRequests').on('click', '#unselectAll', function () {

        var meetingRequests = $('#meetingRequests');

        meetingRequests.find("input[name='check']").each(function (ind, node) {
            $(node).prop('checked', false);
        });

        refreshMeetingRequestTab();
    });

    $('#meetingRequests').on('click', '#selectAllUnprocessed', function () {

        var meetingRequests = $('#meetingRequests');

        meetingRequests.find("input[name='check']").each(function (ind, node) {
            var jnode = $(node);
            var readed = jnode.parent().parent().find('#readed');
            if (readed.prop('value') == '0') {
                jnode.prop('checked', true);
            }
            else {
                jnode.prop('checked', false);
            }
        });

        refreshMeetingRequestTab();
    });

    $('#meetingRequests').on('click', '#selectAllProcessed', function () {

        var meetingRequests = $('#meetingRequests');

        meetingRequests.find("input[name='check']").each(function (ind, node) {
            var jnode = $(node);
            var readed = jnode.parent().parent().find('#readed');
            if (readed.prop('value') == '1') {
                jnode.prop('checked', true);
            }
            else {
                jnode.prop('checked', false);
            }
        });
        refreshMeetingRequestTab();
    });

    $('#meetingRequests').on('click', '#markReadedBtn', function () {

        var msg = $(this).parent().parent();
        processMeetingRequest(msg, 'Yes');
    });

    $('#meetingRequests').on('click', '#markUnreadedBtn', function () {

        var msg = $(this).parent().parent();
        processMeetingRequest(msg, 'No');
    });


    $('#meetingRequests').on('click', '#markAllReadedBtn', function () {

        $('#meetingRequests').find("input[name='check']:checked").each(function (ind, node) {
            var jnode = $(node);
            var msg = jnode.parent().parent();
            processMeetingRequest(msg, 'Yes');
        });


    });

    $('#meetingRequests').on('click', '#markAllUnreadedBtn', function () {

        $('#meetingRequests').find("input[name='check']:checked").each(function (ind, node) {
            var jnode = $(node);
            var msg = jnode.parent().parent();
            processMeetingRequest(msg, 'No');
        });

    });

});

$(document).ready(
    function () {
        var joinRequestsTabBadge = $('#joinRequestsTabBadge');
        var meetingRequestsTabBadge = $('#meetingRequestsTabBadge');
        var userName = $('#userName').val();
        $.ajax({
            url: '/HCI/api/MailBoxWebAPI?userName=' + userName + "&type=JoinRequest",
            dataType: 'json',
            success: function (data) {

                if (Number(data) > 0) {
                    joinRequestsTabBadge.text(data);
                }
            }
        });

        $.ajax({
            url: '/HCI/api/MailBoxWebAPI?userName=' + userName + "&type=MeetingRequest",
            dataType: 'json',
            success: function (data) {

                if (Number(data) > 0) {
                    meetingRequestsTabBadge.text(data);
                }
            }
        });
    });

$(document).ready(function ($) {


    $('tbody').on('click', '#sender', function () {
        var msg = $(this).parents('#message');
        var senderID = msg.find('#senderID').prop('value');

        $.ajax({
            url: '/HCI/api/UserWebAPI?userID=' + senderID,
            dataType: 'json',
            success: function (data) {
                var userModal = $('#userModal');
                userModal.find('#name').text(data.userName);
                userModal.find('#degree').text(data.degree);
                userModal.find('#email').text(data.email);
                userModal.find('#phone').text(data.phone);
                userModal.find('#major').text(data.major);

                userModal.modal('show');

            }
        });
    });

    $('tbody').on('click', '#group', function () {
        var msg = $(this).parents('#message');
        var groupID = msg.find('#groupID').prop('value');

        $.ajax({
            url: '/HCI/api/GroupWebAPI?groupID=' + groupID,
            dataType: 'json',
            success: function (data) {
                var groupModal = $('#groupModal');
                groupModal.find('#name').text(data.name);
                groupModal.find('#description').text(data.description);
                groupModal.find('#studyFields').text(data.studyFields);
                groupModal.find('#courseNo').text(data.courseNo);
                groupModal.find('#maxMemberNumber').text(data.maxMemberNumber);

                groupModal.modal('show');

            }
        });
    });

    $('tbody').on('click', '#meeting', function () {
        var msg = $(this).parents('#message');
        var groupID = msg.find('#meetingID').prop('value');

        $.ajax({
            url: '/HCI/api/MeetingWebAPI?meetingID=' + groupID,
            dataType: 'json',
            success: function (data) {
                var meetingModal = $('#meetingModal');
                meetingModal.find('#name').text(data.name);
                meetingModal.find('#description').text(data.description);
                meetingModal.find('#location').text(data.location);
                meetingModal.find('#time').text(data.time);

                meetingModal.modal('show');

            }
        });
    });
});

function processJoinRequest(msg, status) {
    var membershipID = msg.find('#membershipID').prop('value');

    var readed = msg.find("#readed");
    var acceptBtn = msg.find("#acceptBtn");
    var rejectBtn = msg.find('#rejectBtn');
    var undoBtn = msg.find('#undoBtn');
    var statusCell = msg.find('#status');
    var mailID = msg.find('#mailID').prop('value');
    var url1 = '/HCI/api/GroupApprovalWebAPI?' + 'membershipID=' + membershipID + '&status=' + status;
    var url2;

    if (status != 'Pending') {
        url2 = '/HCI/api/MailBoxWebAPI?' + 'mailID=' + mailID + '&readed=1';
    }
    else {
        url2 = '/HCI/api/MailBoxWebAPI?' + 'mailID=' + mailID + '&readed=0';
    }

    $.ajax({
        url: url1,
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            $.ajax({
                url: url2,
                dataType: 'json',
                type: 'POST',
                success: function (data) {



                    if (status != 'Pending') {
                        msg.removeClass('bold');
                        acceptBtn.addClass('invisible');
                        rejectBtn.addClass('invisible');
                        undoBtn.removeClass('invisible');
                        readed.prop('value', '1');

                        if (status == 'Yes') {
                            statusCell.text('Accepted');
                        }
                        else {
                            statusCell.text('Rejected');
                        }
                    }
                    else {
                        msg.addClass('bold');
                        acceptBtn.removeClass('invisible');
                        rejectBtn.removeClass('invisible');
                        undoBtn.addClass('invisible');
                        readed.prop('value', '0');

                        statusCell.text('Pending');
                    }

                    refreshJoinRequestTab();
                }
            });
        }
    });


}

function processMeetingRequest(msg, status) {
    var readed = msg.find("#readed");
    var markReadedBtn = msg.find("#markReadedBtn");
    var markUnreadedBtn = msg.find('#markUnreadedBtn');
    var mailID = msg.find('#mailID').prop('value');
    var url2;

    if (status == 'Yes') {
        url2 = '/HCI/api/MailBoxWebAPI?' + 'mailID=' + mailID + '&readed=1';
    }
    else {
        url2 = '/HCI/api/MailBoxWebAPI?' + 'mailID=' + mailID + '&readed=0';
    }

    $.ajax({
        url: url2,
        dataType: 'json',
        type: 'POST',
        success: function (data) {



            if (status == 'Yes') {
                msg.removeClass('bold');
                markReadedBtn.addClass('invisible');
                markUnreadedBtn.removeClass('invisible');
                readed.prop('value', '1');

            }
            else {
                msg.addClass('bold');
                markReadedBtn.removeClass('invisible');
                markUnreadedBtn.addClass('invisible');
                readed.prop('value', '0');

            }

            refreshMeetingRequestTab();
        }
    });
}

function refreshJoinRequestTab() {
    var acceptAllBtn = $('#joinRequests').find('#acceptAllBtn')
    acceptAllBtn.prop('disabled', true);

    var rejectAllBtn = $('#joinRequests').find('#rejectAllBtn');
    rejectAllBtn.prop('disabled', true);

    var undoAllBtn = $('#joinRequests').find('#undoAllBtn');
    undoAllBtn.prop('disabled', true);


    var mailBoxBadge = $('#badge');
    var joinRequestsTabBadge = $('#joinRequestsTabBadge');

    var unprocessedCnt = 0;
    $('#joinRequests').find("input[name='check']").each(function (ind, node) {


        var jnode = $(node);

        var msg = jnode.parent().parent();
        var readed = msg.find('#readed').prop('value');

        if (jnode.prop('checked')) {
            if (readed == '0') {
                acceptAllBtn.prop('disabled', false);
                rejectAllBtn.prop('disabled', false);
            }
            else {
                undoAllBtn.prop('disabled', false);
            }
        }
        if (readed == '0') {
            unprocessedCnt++;
        }
    });

    if (unprocessedCnt > 0) {
        joinRequestsTabBadge.text(unprocessedCnt);
    }
    else {
        joinRequestsTabBadge.text("");
    }

    refreshInboxBadge();
}

function refreshMeetingRequestTab() {
    var markAllReadedBtn = $('#meetingRequests').find('#markAllReadedBtn')
    markAllReadedBtn.prop('disabled', true);


    var markAllUnreadedBtn = $('#meetingRequests').find('#markAllUnreadedBtn');
    markAllUnreadedBtn.prop('disabled', true);


    var mailBoxBadge = $('#badge');
    var meetingRequestsTabBadge = $('#meetingRequestsTabBadge');

    var unprocessedCnt = 0;
    $('#meetingRequests').find("input[name='check']").each(function (ind, node) {


        var jnode = $(node);

        var msg = jnode.parent().parent();
        var readed = msg.find('#readed').prop('value');

        if (jnode.prop('checked')) {
            if (readed == '0') {
                markAllReadedBtn.prop('disabled', false);
            }
            else {
                markAllUnreadedBtn.prop('disabled', false);
            }
        }
        if (readed == '0') {
            unprocessedCnt++;
        }
    });

    if (unprocessedCnt > 0) {
        meetingRequestsTabBadge.text(unprocessedCnt);
    }
    else {
        meetingRequestsTabBadge.text("");
    }

    refreshInboxBadge();
}

function refreshInboxBadge() {
    var mailBoxBadge = $('#badge');
    var joinRequestsTabBadge = $('#joinRequestsTabBadge');
    var meetingRequestsTabBadge = $('#meetingRequestsTabBadge');

    var unprocessedJoinRequestCnt = joinRequestsTabBadge.text();

    if (typeof unprocessedJoinRequestCnt == 'undefined' || unprocessedJoinRequestCnt == "") {
        unprocessedJoinRequestCnt = 0;
    }
    else {
        unprocessedJoinRequestCnt = Number(unprocessedJoinRequestCnt);
    }

    var unprocessedMeetingRequestsCnt = meetingRequestsTabBadge.text();

    if (typeof unprocessedMeetingRequestsCnt == 'undefined' || unprocessedMeetingRequestsCnt == "") {
        unprocessedMeetingRequestsCnt = 0;
    }
    else {
        unprocessedMeetingRequestsCnt = Number(unprocessedMeetingRequestsCnt);
    }

    var totalUnreadedCnt = unprocessedJoinRequestCnt + unprocessedMeetingRequestsCnt;
    if (totalUnreadedCnt > 0) {
        mailBoxBadge.text(totalUnreadedCnt);
    }
    else {
        mailBoxBadge.text('');
    }
}