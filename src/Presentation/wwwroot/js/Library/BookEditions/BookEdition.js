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

    // Initialize initial values for available and total copies
    if ($availableCopiesInput.length && $totalCopiesInput.length) {
        initialTotalCopies = parseInt($totalCopiesInput.val(), 10);
        initialAvailableCopies = parseInt($availableCopiesInput.val(), 10);
        initialDifference = initialTotalCopies - initialAvailableCopies;
    }

    // Event to show the modal and populate inputs with initial values
    $editAvailableCopiesBtn.on('click', function () {
        $newAvailableCopiesInput.val($availableCopiesInput.val());
        $changeReasonInput.val('');
        $editAvailableCopiesModal.modal('show');

        // Remove previous error styles
        $newAvailableCopiesInput.removeClass('input-error');
        $changeReasonInput.removeClass('input-error');
    });

    // Save button event
    $saveAvailableCopiesBtn.on('click', function () {
        const newAvailableCopies = parseInt($newAvailableCopiesInput.val(), 10);
        const changeReason = $changeReasonInput.val().trim();

        // Reset error styles before validation
        $newAvailableCopiesInput.removeClass('input-error');
        $changeReasonInput.removeClass('input-error');

        // Validation
        let valid = true;
        if (isNaN(newAvailableCopies) || newAvailableCopies < 0) {
            $newAvailableCopiesInput.addClass('input-error'); // Apply red border to invalid field
            valid = false;
        }

        if (!changeReason) {
            $changeReasonInput.addClass('input-error'); // Apply red border to empty reason field
            valid = false;
        }

        // If validation passes, proceed with updating values
        if (valid) {
            $availableCopiesInput.val(newAvailableCopies);
            $totalCopiesInput.val(newAvailableCopies + initialDifference);
            $copiesChangeReasonMessage.val(changeReason);
            $editAvailableCopiesModal.modal('hide');
        }
    });

    // Handle modal close action
    $editAvailableCopiesModal.on('hidden.bs.modal', function () {
        // Reset the input values if no reason was provided
        if (!$copiesChangeReasonMessage.val()) {
            $availableCopiesInput.val(initialAvailableCopies);
            $totalCopiesInput.val(initialTotalCopies);
        }
    });

    // Confirm action button event (if applicable)
    if ($confirmActionBtn.length) {
        $confirmActionBtn.on('click', function () {
            var fetchPath = `/Books/${bookId}/BookEditions/${userAction}/${id}`;
            var afterFetchPath = `/Books/${bookId}/BookEditions`;
            performAction(fetchPath, afterFetchPath);
        });
    }
});
