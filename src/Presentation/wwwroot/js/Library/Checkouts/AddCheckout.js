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

    // Load accounts and books
    loadDropdownData('/Accounts/GetActiveAccounts', accountChoices);
    loadDropdownData('/Books/GetAvaliableBooks', bookChoices);

    // Handle book selection and load book editions
    bookChoices.passedElement.element.addEventListener('change', function () {
        const bookId = this.value;
        if (bookId) {
            loadDropdownData(`/Books/${bookId}/BookEditions/GetAvaliableBookEditions`, bookEditionChoices);
        } else {
            bookEditionChoices.clearChoices();
        }
    });

    // Optional: Add input masking or validation for CopiesCount and SupposedReturnTime
    // You can use libraries like cleave.js for input masking if needed
});