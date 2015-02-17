(function () {
    "use strict";

    if (jQuery && jQuery.validator) {
        jQuery.validator.setDefaults({
            ignore: "input[ignore]",
            highlight: function (element) {
                var parent = $(element.parentElement);
                parent.removeClass("has-success");
                parent.addClass("has-error");
            },
            unhighlight: function (element) {
                var parent = $(element.parentElement);
                parent.removeClass("has-error");
                parent.addClass("has-success");
            },
            errorPlacement: function (error, element) {
                error.addClass("control-label");
                element.parent().prepend(error);
            }
        });
    }
}());