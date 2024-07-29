$(function () {
    $('#confirmAction').on('click', function () {

        var fetchPath = `/Rooms/${userAction}/${id}`;
        var afterFetchPath = `/Rooms`;

        performAction(fetchPath, afterFetchPath);
    });
});
