$(function () {
    $('#confirmAction').on('click', function () {
        var fetchPath = `/Languages/${userAction}/${id}`;
        var afterFetchPath = `/Languages`;


        performAction(fetchPath, afterFetchPath);
    });
});
