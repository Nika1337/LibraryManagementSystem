$(function () {
    $('#confirmAction').on('click', function () {
        var fetchPath = `/Employees/${userAction}Employee/${id}`;
        var afterFetchPath = `/Employees`;


        performAction(fetchPath, afterFetchPath);
    });
});