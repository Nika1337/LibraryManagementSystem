document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/Books/Authors/${userAction}/${id}`;
    var afterFetchPath = `/Books/Authors`;

    performAction(fetchPath, afterFetchPath);
});