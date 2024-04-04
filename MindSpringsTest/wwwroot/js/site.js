// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AjaxErrorHandler(xhr) {
    if (xhr.status == 403) {
        ServerCalled();
        ErrorNotification(errorMessage)
    }
    if (xhr.status == 401) {
        ServerCalled();
        ErrorNotification(errorMessage)
    }
    else {
        ErrorNotification(xhr.responseText)
    }
}


function ErrorNotification(message) {
    Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Incorrect Name or Password!",
        
    });
}

function WarningNotification(message) {
    Swal.fire({
        icon: "warning",
        title: "Oops...",
        text: "Incorrect Name or Password!",
    });
}

function SuccessNotification(message) {
    swal("Successful!", message, "success");
}