$(function () {
    $('#confirmAction').on('click', function () {

        var fetchPath = `/Publishers/${userAction}/${id}`;
        var afterFetchPath = `/Publishers`;

        performAction(fetchPath, afterFetchPath);
    });
});
