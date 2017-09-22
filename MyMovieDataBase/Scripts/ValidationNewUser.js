$("#createButton").click(function () {
    validate();
})

//$("#verifyPassword").focus(function () {
//    validate();    
//})

function ajax() {

    var newUsername = $("#newUsername").val()
    var newPassword = $("#newPassword").val()

    $.ajax({
        url: '/Session/CreateNewUser',
        method: 'POST',
        data: {
            Username: newUsername,
            Password: newPassword
        }
    })
        .done(function (response) {
            $("#response").html(`Status: ${response}`);
            window.location.replace(`/home/mymovies?username=${newUsername}`)
        })
        .fail(function (xhr, status, error) {
            console.log("Error", xhr, status, error)
            $("#error").html(`Error! ${xhr.responseJSON.Message}`);
        })
}

function validate() {

    $("#response").html("")
    $("#error").html("")

    if ($("#newPassword").val() === $("#verifyPassword").val()) {
        ajax();
    }
    else (
        $("#error").html("Password is NOT ok")
    )
}