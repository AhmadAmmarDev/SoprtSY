var selectedTeams = [];
var selectedTeamsName = [];
var selectedActivity = null;
var selectedPlace = null;
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
            loaderBg: '#9EC600', // To change the background
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
$('#matchActivitDropdownMenu a').on('click', function (data) {
     selectedActivity = data.currentTarget.getAttribute('value');
    data.currentTarget.style.background = '#5555';
});
$('#placeMatchDropdownMenu a').on('click', function (data) {
     selectedPlace = data.currentTarget.getAttribute('value');
    data.currentTarget.style.background = '#5555';
});
$('#mathcRequestButton').click(function () {
    var matchDate = $('#matchDatePicker').val().toString();
    var activityId;
    var placeId;
    if (selectedActivity !== null);
    activityId = selectedActivity;
    if (selectedPlace !== null)
        placeId = selectedPlace;
    var note = $('#matchNoteTextbox').val();
    var urlData = {
        'selectedTeams': selectedTeams,
        'matchDate': matchDate,
        'activityId': activityId,
        'placeId': placeId,
        'note': note
    };
    if (urlData.selectedTeams !== null && urlData.selectedTeams !== undefined && urlData.selectedTeams.length > 0) {
        url = '/match/create';
        $.post(url, urlData, function () {
            location.reload();
            $.toast({
                heading: 'Success',
                text: 'New match where orderd',
                showHideTransition: 'slide',
                icon: 'success'
            });
        });
    }
    else {
        $.toast({
            heading: 'Error',
            text: 'Check your selected data',
            showHideTransition: 'fade',
            icon: 'error',
            position: 'top-right',
        });
    }

});
