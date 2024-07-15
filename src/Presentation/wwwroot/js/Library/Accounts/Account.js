document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Accounts/${userAction}/${id}`;
    var afterFetchPath = `/Accounts`;

    performAction(fetchPath, afterFetchPath);
});