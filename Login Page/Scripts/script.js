$(document).ready(function () {
    // Check for login status on page load
    checkLoginStatus();

    $("#login-btn").click(function () {
        var username = $("#username").val();
        var password = $("#password").val();

        // Simulate server-side validation (in a real scenario, use AJAX to communicate with the server)
        $.ajax({
            type: "POST",
            url: "/Home/Login",
            data: { username: username, password: password },
            success: function (response) {
                $("#login-message").text(response);

                // Check and display login status after successful login
                checkLoginStatus();
            }
        });
    });

    function checkLoginStatus() {
        // Query the server to check the login status
        $.ajax({
            type: "GET",
            url: "/Home/CheckLogin",
            success: function (response) {
                $("#login-message").text(response);
            }
        });
    }
});
