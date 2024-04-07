function SubmitLoginForm() {
    let validator = $("#LoginForm").validate();
    validator.form();

    if (validator.valid()) {

        let form = $("#LoginForm").get(0);
        $.ajax({
            url: '/Account/Login',
            type: 'POST',
            data: new FormData(form),
            processData: false,
            contentType: false,
            beforeSend: function () {

            },
            complete: function () {

            },
            success: function (response) {
                window.location.href = "/String/Index";
            },
            error: function (xhr) {

            },

        })
    }
}