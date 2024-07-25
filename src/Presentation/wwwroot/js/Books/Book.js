document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/${userAction}/${id}`;
    var afterFetchPath = `/Books`;

    performAction(fetchPath, afterFetchPath);
});
