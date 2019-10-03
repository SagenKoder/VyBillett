
// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

const URL = document.URL;

$(window).on('load', function () {
    let datalist_from = $('#datalist-from');
    datalist_from.empty();
    $.getJSON(URL + 'stations', function (data) {
        $.each(data, function (key, entry) {
            datalist_from.append($('<option></option>').attr('value', entry.id).text(entry.name));
        });
    });
});

const to_input_field = document.getElementById("date-input-to");
to_input_field.onfocus = function () {

    const from_input_field = document.getElementById("date-input-from");

    let datalist_to = $('#datalist-to');
    datalist_to.empty();

    $.getJSON(URL + 'stations/GetStations?name=' + encodeURI(from_input_field), function (data) {
        $.each(data, function (key, entry, linenumber) {
            datalist_to.append($('<option></option>').attr('value', entry.id).text(entry.name));
        });
    }).fail(console.log("Error"));
};