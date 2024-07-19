document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Genres/${userAction}/${id}`;
    var afterFetchPath = `/Genres`;

    performAction(fetchPath, afterFetchPath);
});