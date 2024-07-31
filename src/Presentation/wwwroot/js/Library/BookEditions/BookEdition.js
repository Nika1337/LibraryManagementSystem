
$(function () {
    const $availableCopiesInput = $('#AvaliableCopiesCount');
    const $totalCopiesInput = $('#TotalCopiesCount');
    const $changeReasonModal = $('#changeReasonModal');
    const $saveChangeReasonBtn = $('#saveChangeReason');
    const $cancelChangeReasonBtn = $('#cancelChangeReason');
    const $changeReasonInput = $('#changeReasonInput');
    const $copiesChangeReasonMessage = $('#CopiesChangeReasonMessage');
    const $confirmActionBtn = $('#confirmAction');

    let originalAvailableValue;
    let initialTotalCopies;
    let initialAvailableCopies;
    let initialDifference;

    if ($availableCopiesInput.length && $totalCopiesInput.length) {
        initialTotalCopies = parseInt($totalCopiesInput.val(), 10);
        initialAvailableCopies = parseInt($availableCopiesInput.val(), 10);
        initialDifference = initialTotalCopies - initialAvailableCopies;

        $availableCopiesInput.on('focus', function () {
            originalAvailableValue = $(this).val();
        });

        $availableCopiesInput.on('input', function () {
            const currentAvailableCopies = parseInt($(this).val(), 10) || 0;
            $totalCopiesInput.val(currentAvailableCopies + initialDifference);
        });

        $availableCopiesInput.on('change', function () {
            if ($(this).val() !== originalAvailableValue) {
                $changeReasonModal.modal('show');
            }
        });
    }

    $saveChangeReasonBtn.on('click', function () {
        const reason = $changeReasonInput.val().trim();
        if (reason) {
            $copiesChangeReasonMessage.val(reason);
            $changeReasonModal.modal('hide');
        } else {
            alert('Please enter a reason for the change.');
        }
    });

    function revertChanges() {
        $availableCopiesInput.val(originalAvailableValue);
        $totalCopiesInput.val(parseInt(originalAvailableValue, 10) + initialDifference);
        $copiesChangeReasonMessage.val('');
        $changeReasonInput.val('');
    }

    $cancelChangeReasonBtn.on('click', function () {
        revertChanges();
    });

    $changeReasonModal.on('hidden.bs.modal', function (event) {
        if (event.target === this && !$copiesChangeReasonMessage.val()) {
            revertChanges();
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