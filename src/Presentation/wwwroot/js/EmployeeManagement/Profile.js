

document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Employees/${userAction}Employee/${id}`;
    var afterFetchPath = `/Employees`;

    performAction(fetchPath, afterFetchPath);
});