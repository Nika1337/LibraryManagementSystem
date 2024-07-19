document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/${bookId}/BookEditions/${userAction}/${id}`;
    var afterFetchPath = `/Books/${bookId}/BookEditions`;

    performAction(fetchPath, afterFetchPath);
});

document.addEventListener('DOMContentLoaded', function () {
    // Initialize Choices.js
    const languageChoices = new Choices('#LanguageId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select a language',
    });

    const publisherChoices = new Choices('#PublisherId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select publisher',
    });

    const roomChoices = new Choices('#RoomId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select room',
    });

    // Load data for dropdowns and set preselected values
    function loadDropdownData(url, choicesInstance, preselectedValue) {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                const choices = data.map(item => ({
                    value: item.id,
                    label: item.name,
                    selected: preselectedValue === item.id
                }));
                choicesInstance.setChoices(choices, 'value', 'label', true);
            });
    }

    loadDropdownData('/Languages/GetActiveLanguagePreviews', languageChoices, preselectedLanguage);
    loadDropdownData('/Rooms/GetActiveRooms', roomChoices, preselectedRoom);
    loadDropdownData('/Publishers/GetActivePublishers', publisherChoices, preselectedPublisher);
});