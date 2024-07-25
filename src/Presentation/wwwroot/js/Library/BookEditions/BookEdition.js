document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/${bookId}/BookEditions/${userAction}/${id}`;
    var afterFetchPath = `/Books/${bookId}/BookEditions`;

    performAction(fetchPath, afterFetchPath);
});


document.addEventListener('DOMContentLoaded', (event) => {
    const avaliableCopiesInput = document.getElementById('AvaliableCopiesCount');
    const totalCopiesInput = document.getElementById('TotalCopiesCount');

    if (avaliableCopiesInput && totalCopiesInput) {
        const initialTotalCopies = parseInt(totalCopiesInput.value, 10);
        const initialAvaliableCopies = parseInt(avaliableCopiesInput.value, 10);
        const initialDifference = initialTotalCopies - initialAvaliableCopies;

        avaliableCopiesInput.addEventListener('input', () => {
            const currentAvaliableCopies = parseInt(avaliableCopiesInput.value, 10) || 0;
            totalCopiesInput.value = currentAvaliableCopies + initialDifference;
        });
    }
});
