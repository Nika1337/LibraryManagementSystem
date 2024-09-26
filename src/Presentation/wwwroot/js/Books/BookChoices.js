
$(function () {
    // Initialize Choices.js
    const languageChoices = new Choices('#OriginalLanguageId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: languagePlaceholder,
    });

    const genreChoices = new Choices('#GenreIds', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: genresPlaceholder,
    });

    const authorChoices = new Choices('#AuthorIds', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: authorsPlaceholder,
    });

    loadDropdownData('/Languages/GetActiveLanguages', languageChoices, [preselectedLanguage]);
    loadDropdownData('/Genres/GetActiveGenres', genreChoices, preselectedGenres);
    loadDropdownData('/Authors/GetActiveAuthors', authorChoices, preselectedAuthors);
});