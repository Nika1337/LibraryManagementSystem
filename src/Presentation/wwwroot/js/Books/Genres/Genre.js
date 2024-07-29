$(function () {
    $('#confirmAction').on('click', function () {
        var fetchPath = `/Genres/${userAction}/${id}`;
        var afterFetchPath = `/Genres`;


        performAction(fetchPath, afterFetchPath);
    });
});
