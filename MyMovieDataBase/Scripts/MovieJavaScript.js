﻿
$("#loginButton").click(function () {
    //alert("Blä!")
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
            window.location.replace("/home/mymovies")
        })
        .fail(function (xhr, status, error) {
            console.log("Error", xhr, status, error)
            $("#error").html(`Error! ${xhr.responseJSON.Message}`);
        })

})

$("#username").focus(function () {
    //$("#response").html("focus username")
    $("#username").attr("placeholder", "").val("").focus().blur();

})
$("#username").focusout(function () {
    //$("#response").html("focus username")
    if ($("#username").val() === "") {
        $("#username").attr("placeholder", "Email").val("").focus().blur();
    }
})
$("#password").focus(function () {
    //$("#response").html("focus password")
    $("#password").attr("placeholder", "").val("").focus().blur();
})
$("#password").focusout(function () {
    //$("#response").html("focus username")
    if ($("#username").val() === "") {
        $("#password").attr("placeholder", "Password").val("").focus().blur();
    }
})