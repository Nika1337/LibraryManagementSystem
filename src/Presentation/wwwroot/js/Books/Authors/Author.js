document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Authors/${userAction}/${id}`;
    var afterFetchPath = `/Authors`;

    performAction(fetchPath, afterFetchPath);
});