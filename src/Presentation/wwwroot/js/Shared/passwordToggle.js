function togglePasswordVisibility(passwordInputId, toggleButtonId) {
    var $passwordInput = $('#' + passwordInputId);
    var $toggleButton = $('#' + toggleButtonId);

    $toggleButton.on('click', function () {
        if ($passwordInput.attr('type') === 'password') {
            $passwordInput.attr('type', 'text');
            $toggleButton.text('Hide');
        } else {
            $passwordInput.attr('type', 'password');
            $toggleButton.text('Show');
        }
    });
}