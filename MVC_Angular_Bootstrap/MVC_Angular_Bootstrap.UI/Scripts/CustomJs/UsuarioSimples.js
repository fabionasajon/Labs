$(document).ready(function () {
    $("#userForm").submit(function (a) {

        a.preventDefault();

        var dat = new FormData(this);

        var object = {};
        dat.forEach(function (value, key) {
            object[key] = value;
        });
        var json = JSON.stringify(object);

        $.ajax({
            url: "Edit",
            ContentType: 'application/x-www-form-urlencoded',
            data: {
                usuario: json
            },
            type: "POST",
            success: function(json) {
                alert(json);
            }
        })
    });
});