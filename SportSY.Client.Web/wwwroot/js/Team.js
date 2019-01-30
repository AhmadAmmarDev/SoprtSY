$("#playersList li").click(function (data) {
    var perosnName = data;
    $('#selectedTeamMembers').tagEditor('addTag', perosnName);

});
$('#selectedTeamMembers').tagEditor();