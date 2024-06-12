document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/Languages/${userAction}Language/${id}`;
    var afterFetchPath = `/Books/Languages`;

    performAction(fetchPath, afterFetchPath);
});