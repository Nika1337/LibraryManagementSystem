$(function () {
    $('#confirmAction').on('click', function () {
        var fetchPath = `/Books/${userAction}/${id}`;
        var afterFetchPath = `/Books`;


        performAction(fetchPath, afterFetchPath);
    });
});
