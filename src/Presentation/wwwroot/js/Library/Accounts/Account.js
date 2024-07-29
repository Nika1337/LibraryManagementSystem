$(function () {
    $('#confirmAction').on('click', function () {
        var fetchPath = `/Accounts/${userAction}/${id}`;
        var afterFetchPath = `/Accounts`;


        performAction(fetchPath, afterFetchPath);
    });
});