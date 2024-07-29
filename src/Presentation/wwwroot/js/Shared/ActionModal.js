(function () {
    'use strict';

    // Define performAction function with parameters
    window.performAction = function (fetchPath, afterFetchPath) {
        var token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: fetchPath,
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': token
            },
            success: function () {
                window.location.href = afterFetchPath;
            },
            error: function () {
                alert('An error occurred while trying to perform action.');
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error:', textStatus, errorThrown);
            alert('An error occurred while trying to perform action.');
        });
    };
})();
