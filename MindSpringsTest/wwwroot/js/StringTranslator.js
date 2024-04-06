function SubmitStringForm()
{
    let validator = $("#SubmitString").validate();
    validator.form();

    if (validator.valid()) {

        let form = $("#SubmitString").get(0);
        $.ajax({
            url: '/String/Create',
            type: 'POST',
            data: new FormData(form),
            processData: false,
            contentType: false,
            beforeSend: function () {

            },
            complete: function () {

            },
            success: function (response) {
                if (response) {
                    // Redirect to a new controller action method with the translated text
                    window.location.href = "/String/GridList";
                } else {
                    // Handle empty or invalid response
                    console.error("Empty or invalid response received.");
                }
            },
            error: function (xhr) {
                console.error("Ajax error:", xhr);
            },

        })
    }
}