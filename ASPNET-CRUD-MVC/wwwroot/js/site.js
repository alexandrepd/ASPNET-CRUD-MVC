$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

function matchPassword() {
    var pw1 = document.getElementById("password");
    var pw2 = document.getElementById("confirm_password");

    isEmpty(pw1);

    isEqual(pw1, pw2);

    return true;
}

function isEmpty(password) {
    if (password.value.length == 0) {
        alert("Password cannot be null");
        return false;
    }
    return true;
}

function isEqual(password, confirm_password) {
    if (password.value != confirm_password.value) {
        alert("Passwords did not match");
        return false;
    }
    return true;
}