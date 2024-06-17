document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/${userAction}Book/${id}`;
    var afterFetchPath = `/Books`;

    performAction(fetchPath, afterFetchPath);
});