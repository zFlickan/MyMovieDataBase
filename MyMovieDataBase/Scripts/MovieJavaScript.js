$("#loginButton").click(function () {
    alert("Blä!")
    var username = $("#username").val()
    var password = $("#password").val()

    //if (!$.isNumeric(userIdInput)) {
    //    $("#error").html("Skriv in ett heltal.")
    //    return
    //}

    $("#response").html("")
    $("#error").html("")

    $.ajax({
        url: '/session/login',
        method: 'GET',
        data: {
            userNameInput: username,
            passwordInput: password
        }
    })
        .done(function (response) {
            $("#response").html(`Log in status: ${response}`);
            //Location
        })
        .fail(function (xhr, status, error) {
            console.log("Error", xhr, status, error)
            $("#error").html(`Error! ${xhr.responseJSON.Message}`);
        })

})