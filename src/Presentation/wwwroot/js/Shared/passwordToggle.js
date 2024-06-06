function togglePasswordVisibility(passwordInputId, toggleButtonId) {
    var passwordInput = document.getElementById(passwordInputId);
    var toggleButton = document.getElementById(toggleButtonId);

    toggleButton.addEventListener('click', function () {
        if (passwordInput.type === 'password') {
            passwordInput.type = 'text';
            toggleButton.textContent = 'Hide';
        } else {
            passwordInput.type = 'password';
            toggleButton.textContent = 'Show';
        }
    });
}