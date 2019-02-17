var selectedTeams = [];
var selectedTeamsName = [];
var _tagEditor = $('#selectedTeamMatches').tagEditor({

    forceLowercase: false,
    beforeTagSave: function (field, editor, tags, tag, val) {
        //_selectedPersons.push(_selectedPersonId);
    },
});
$("#match-teams-list li").click(function (data) {
    var selectedTeam = data.currentTarget.getAttribute('data-team-id');
    var selectedTeamName = data.currentTarget.innerText;
    data.currentTarget.style.background = "red";
    if (selectedTeams.length < 2) {
        $.toast({
            heading: 'Information',
            text: 'First team selected',
            icon: 'info',
            loader: true,        // Change it to false to disable loader
            loaderBg: '#9EC600' , // To change the background
            position: 'top-right',
        });
        selectedTeams.push(selectedTeam);
        $('#selectedTeamMatches').tagEditor('addTag', selectedTeamName);
    }
    else {
        $.toast({
            heading: 'Error',
            text: 'Too many team selected',
            showHideTransition: 'fade',
            icon: 'error',
            position: 'top-right',
        });
    }

});
