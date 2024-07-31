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

    loadDropdownData('/Languages/GetActiveLanguagePreviews', languageChoices, [preselectedLanguage]);
    loadDropdownData('/Rooms/GetActiveRooms', roomChoices, [preselectedRoom]);
    loadDropdownData('/Publishers/GetActivePublishers', publisherChoices, [preselectedPublisher]);
});