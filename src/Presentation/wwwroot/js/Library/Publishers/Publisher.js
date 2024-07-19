document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Publishers/${userAction}/${id}`;
    var afterFetchPath = `/Publishers`;

    performAction(fetchPath, afterFetchPath);
});