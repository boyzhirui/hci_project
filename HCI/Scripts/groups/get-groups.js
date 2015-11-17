$(document).ready(function ($) {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
});

function quitGroupPreparation(handle) {
    var groupId = jQuery(handle).parent('#quitGroupBtn').children("#groupId").text();
    var groupName = jQuery(handle).parents('#groupPanel').children("#groupName").text();
    jQuery("#modalGroupId").val(groupId);
    jQuery("#modalBody").text("You are going to leave the group [" + groupName + "]. Are you sure?");
}