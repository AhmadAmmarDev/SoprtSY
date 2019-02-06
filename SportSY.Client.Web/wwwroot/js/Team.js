var _selectedPersons = [];
var _selectedPersonId;
var _tagEditor = $('#selectedTeamMembers').tagEditor({
 
    forceLowercase: false,
    beforeTagSave: function (field, editor, tags, tag, val) {
        _selectedPersons.push(_selectedPersonId);
    },
});
$("#playersList li").click(function (data) {
    var perosnName = data.currentTarget.getAttribute('data-person-name');
    _selectedPersonId = data.currentTarget.getAttribute('data-person-id');

    $('#selectedTeamMembers').tagEditor('addTag', perosnName);

});


$("#submitTeamButton").click(function () {
    var url = "/Team/Create";
    var teamArabicName = $("#arabicNametext").val();
    var teamEnglishName= $("#englishNametext").val();
    var parsedObject = {
        playersList: _selectedPersons,
        teamArabicName: teamArabicName,
        teamEnglishName :teamEnglishName
    };
    if (_selectedPersons !== null) {
        $.post(url, parsedObject, function () { },'json');

    }
});