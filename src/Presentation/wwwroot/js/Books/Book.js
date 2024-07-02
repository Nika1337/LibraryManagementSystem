document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/${userAction}Book/${id}`;
    var afterFetchPath = `/Books`;

    performAction(fetchPath, afterFetchPath);
});

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

    // Load data for dropdowns and set preselected values
    function loadDropdownData(url, choicesInstance, preselectedValues) {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                const choices = data.map(item => ({
                    value: item.id,
                    label: item.name,
                    selected: preselectedValues.includes(item.id)
                }));
                choicesInstance.setChoices(choices, 'value', 'label', true);
            });
    }

    loadDropdownData('/Books/Languages/GetActiveLanguagePreviews', languageChoices, [preselectedLanguage]);
    loadDropdownData('/Books/Genres/GetActiveGenrePreviews', genreChoices, preselectedGenres);
    loadDropdownData('/Books/Authors/GetActiveAuthorPreviews', authorChoices, preselectedAuthors);
});