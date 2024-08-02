

$(function () {
    // Initialize Choices.js
    const languageChoices = new Choices('#OriginalLanguageId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select a language',
    });

    const genreChoices = new Choices('#GenreIds', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select genres',
    });

    const authorChoices = new Choices('#AuthorIds', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select authors',
    });

    loadDropdownData('/Languages/GetActiveLanguages', languageChoices, [preselectedLanguage]);
    loadDropdownData('/Genres/GetActiveGenres', genreChoices, preselectedGenres);
    loadDropdownData('/Authors/GetActiveAuthors', authorChoices, preselectedAuthors);
});