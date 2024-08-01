$(function () {
    const $availableCopiesInput = $('#AvaliableCopiesCount');
    const $totalCopiesInput = $('#TotalCopiesCount');
    const $editAvailableCopiesBtn = $('#editAvailableCopies');
    const $editAvailableCopiesModal = $('#editAvailableCopiesModal');
    const $newAvailableCopiesInput = $('#newAvailableCopies');
    const $changeReasonInput = $('#changeReasonInput');
    const $saveAvailableCopiesBtn = $('#saveAvailableCopies');
    const $copiesChangeReasonMessage = $('#CopiesChangeReasonMessage');
    const $confirmActionBtn = $('#confirmAction');
    let initialTotalCopies;
    let initialAvailableCopies;
    let initialDifference;

    if ($availableCopiesInput.length && $totalCopiesInput.length) {
        initialTotalCopies = parseInt($totalCopiesInput.val(), 10);
        initialAvailableCopies = parseInt($availableCopiesInput.val(), 10);
        initialDifference = initialTotalCopies - initialAvailableCopies;
    }

    $editAvailableCopiesBtn.on('click', function () {
        $newAvailableCopiesInput.val($availableCopiesInput.val());
        $changeReasonInput.val('');
        $editAvailableCopiesModal.modal('show');
    });

    $saveAvailableCopiesBtn.on('click', function () {
        const newAvailableCopies = parseInt($newAvailableCopiesInput.val(), 10);
        const changeReason = $changeReasonInput.val().trim();

        if (isNaN(newAvailableCopies) || newAvailableCopies < 0 || !changeReason) {
            alert('Please enter a valid number of copies and a reason for the change.');
            return;
        }

        $availableCopiesInput.val(newAvailableCopies);
        $totalCopiesInput.val(newAvailableCopies + initialDifference);
        $copiesChangeReasonMessage.val(changeReason);
        $editAvailableCopiesModal.modal('hide');
    });

    $editAvailableCopiesModal.on('hidden.bs.modal', function () {
        if (!$copiesChangeReasonMessage.val()) {
            $availableCopiesInput.val(initialAvailableCopies);
            $totalCopiesInput.val(initialTotalCopies);
        }
    });

    if ($confirmActionBtn.length) {
        $confirmActionBtn.on('click', function () {
            var fetchPath = `/Books/${bookId}/BookEditions/${userAction}/${id}`;
            var afterFetchPath = `/Books/${bookId}/BookEditions`;
            performAction(fetchPath, afterFetchPath);
        });
    }
});