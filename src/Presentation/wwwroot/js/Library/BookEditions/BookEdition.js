$(function () {
    $('#confirmAction').on('click', function () {

        var fetchPath = `/Books/${bookId}/BookEditions/${userAction}/${id}`;
        var afterFetchPath = `/Books/${bookId}/BookEditions`;

        performAction(fetchPath, afterFetchPath);
    });
});


$(function () {
    const $avaliableCopiesInput = $('#AvaliableCopiesCount');
    const $totalCopiesInput = $('#TotalCopiesCount');

    if ($avaliableCopiesInput.length && $totalCopiesInput.length) {
        const initialTotalCopies = parseInt($totalCopiesInput.val(), 10);
        const initialAvaliableCopies = parseInt($avaliableCopiesInput.val(), 10);
        const initialDifference = initialTotalCopies - initialAvaliableCopies;

        $avaliableCopiesInput.on('input', () => {
            const currentAvaliableCopies = parseInt($avaliableCopiesInput.val(), 10) || 0;
            $totalCopiesInput.val(currentAvaliableCopies + initialDifference);
        });
    }
});
