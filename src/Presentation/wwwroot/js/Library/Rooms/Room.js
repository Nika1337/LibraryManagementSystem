document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Location/Rooms/${userAction}/${id}`;
    var afterFetchPath = `/Location/Rooms`;

    performAction(fetchPath, afterFetchPath);
});