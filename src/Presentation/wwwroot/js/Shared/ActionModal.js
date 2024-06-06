(function () {
    'use strict';

    // Define performAction function with parameters
    window.performAction = function (fetchPath, afterFetchPath) {

        var token = document.querySelector('input[name="__RequestVerificationToken"]').value;

        fetch(`${fetchPath}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': token
            }
        }).then(response => {
            if (response.ok) {
                window.location.href = `${afterFetchPath}`;
            } else {
                alert(`An error occurred while trying to perform action.`);
            }
        }).catch(error => {
            console.error('Error:', error);
            alert(`An error occurred while trying to perform action.`);
        });
    };
})();
