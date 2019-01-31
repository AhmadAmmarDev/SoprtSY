var _selectedPersons = [];
var _selectedPersonId;
var _tagEditor = $('#selectedTeamMembers').tagEditor({
    initialTags: ['Hello', 'World', 'Example', 'Tags'],
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

