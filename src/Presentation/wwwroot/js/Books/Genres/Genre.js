document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/Genres/${userAction}/${id}`;
    var afterFetchPath = `/Books/Genres`;

    performAction(fetchPath, afterFetchPath);
});