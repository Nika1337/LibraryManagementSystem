document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Checkouts/${userAction}/${id}`;
    var afterFetchPath = `/Checkouts`;

    performAction(fetchPath, afterFetchPath);
});