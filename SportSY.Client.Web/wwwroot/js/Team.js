$(".personItem").click(function () {
    var perosnName = $('.personItem').data().personName;
    $('#selectedTeamMembers').tagEditor('addTag', perosnName);

});
$('#selectedTeamMembers').tagEditor();