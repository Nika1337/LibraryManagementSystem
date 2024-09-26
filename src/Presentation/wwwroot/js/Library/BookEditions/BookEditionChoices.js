$(function () {
    // Initialize Choices.js
    const languageChoices = new Choices('#LanguageId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: languagePlaceholder,
    });

    const publisherChoices = new Choices('#PublisherId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: publisherPlaceholder,
    });

    const roomChoices = new Choices('#RoomId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: roomPlaceholder,
    });

    loadDropdownData('/Languages/GetActiveLanguages', languageChoices, [preselectedLanguage]);
    loadDropdownData('/Rooms/GetActiveRooms', roomChoices, [preselectedRoom]);
    loadDropdownData('/Publishers/GetActivePublishers', publisherChoices, [preselectedPublisher]);
});