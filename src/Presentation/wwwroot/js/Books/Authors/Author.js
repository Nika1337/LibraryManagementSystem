$(function () {
    $('#confirmAction').on('click', function () {
        var fetchPath = `/Authors/${userAction}/${id}`;
        var afterFetchPath = `/Authors`;

        performAction(fetchPath, afterFetchPath);
    });
});
