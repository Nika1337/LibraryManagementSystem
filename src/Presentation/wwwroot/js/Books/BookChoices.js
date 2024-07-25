document.addEventListener('DOMContentLoaded', function () {
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

    loadDropdownData('/Languages/GetActiveLanguagePreviews', languageChoices, [preselectedLanguage]);
    loadDropdownData('/Genres/GetActiveGenrePreviews', genreChoices, preselectedGenres);
    loadDropdownData('/Authors/GetActiveAuthorPreviews', authorChoices, preselectedAuthors);
});