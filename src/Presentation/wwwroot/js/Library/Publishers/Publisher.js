document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/Publishers/${userAction}/${id}`;
    var afterFetchPath = `/Books/Publishers`;

    performAction(fetchPath, afterFetchPath);
});