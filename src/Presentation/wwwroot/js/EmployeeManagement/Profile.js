

document.getElementById('confirmAction').addEventListener('click', function () {

    var fetchPath = `/EmployeeManagement/${userAction}Employee/${username}`;
    var afterFetchPath = `/EmployeeManagement/AllEmployees`;

    performAction(fetchPath, afterFetchPath);
});