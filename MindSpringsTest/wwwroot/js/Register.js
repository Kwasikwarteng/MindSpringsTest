function SubmitRegisterForm() {
    let validator = $("#RegisterForm").validate();
    validator.form();

    if (validator.valid()) {
        let form = $("#RegisterForm").get(0);
        $.ajax({
            url: '/Account/Register',
            type: 'POST',
            data: new FormData(form),
            processData: false,
            contentType: false,
            beforeSend: function () {

            },
            complete: function () {

            },
            success: function (response) {
                window.location.href = "/Account/Login";
            },
            error: function (xhr) {

            },
        })
    }
}