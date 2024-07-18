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
    function loadDropdownData(url, choicesInstance) {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                const choices = data.map(item => ({
                    value: item.id,
                    label: item.name
                }));
                choicesInstance.setChoices(choices, 'value', 'label', true);
            });
    }

    loadDropdownData('/Books/Languages/GetActiveLanguagePreviews', languageChoices);
    loadDropdownData('/Location/Rooms/GetActiveRooms', roomChoices);
    loadDropdownData('/Books/Publishers/GetActivePublishers', publisherChoices);
});