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

    // Load data for dropdowns
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
    loadDropdownData('/Books/Genres/GetActiveGenrePreviews', genreChoices);
    loadDropdownData('/Books/Authors/GetActiveAuthorPreviews', authorChoices);
});