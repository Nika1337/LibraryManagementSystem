document.addEventListener('DOMContentLoaded', function () {
    // Initialize Choices.js
    const accountChoices = new Choices('#AccountId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select an account',
    });
    const bookChoices = new Choices('#BookId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select a book',
    });
    const bookEditionChoices = new Choices('#BookEditionId', {
        removeItemButton: true,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select a book edition',
    });

    // Load accounts and books
    loadDropdownData('/Accounts/GetActiveAccounts', accountChoices, [preselectedAccount]);
    loadDropdownData('/Books/GetAvaliableBooks', bookChoices, [preselectedBook]);

    if (preselectedBook != 0) {
        loadDropdownData(`/Books/${preselectedBook}/BookEditions/GetAvaliableBookEditions`, bookEditionChoices, [preselectedBookEdition]);
    }

    // Handle book selection and load book editions
    bookChoices.passedElement.element.addEventListener('change', function () {
        const bookId = this.value;

        // Clear book edition choices and reset the selection
        bookEditionChoices.clearStore();
        bookEditionChoices.setChoiceByValue('');

        if (bookId) {
            loadDropdownData(`/Books/${bookId}/BookEditions/GetAvaliableBookEditions`, bookEditionChoices, [preselectedBookEdition]);
        }
    });
});