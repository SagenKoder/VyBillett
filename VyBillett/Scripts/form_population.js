
// Example starter JavaScript for disabling form submissions if there are invalid fields

window.addEventListener('load', function () {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementById('form');
    console.log("first event happened");
    var adults = document.getElementById('adultNumber');
    var children = document.getElementById('childrenNumber');
    var students = document.getElementById('studentNumber');
    // Loop over them and prevent submission
    console.log("Entered this other thing");

    forms.addEventListener('submit', function (event) {

        console.log("Trykket submit");
        console.log("Rett før IF");
        if (adults.value == "0" && children.value == "0" && students.value == "0") {
            console.log("Sjekken var riktig");

            document.getElementById('ticketTypeError').innerHTML = "Du må velge minst en billettype";
            event.preventDefault();
            event.stopPropagation();
        } else {
            form.classList.add('was-validated');
        }
        
    }, false);



    //var validation = Array.prototype.filter.call(forms, function (form) {
    //    forms.addEventListener('submit', function (event) {

    //        if (form.checkValidity() === false) {

    //            event.preventDefault();
    //            event.stopPropagation();
    //        }

    //        form.classList.add('was-validated');

    //    }, false);



    //    }, false);
});
   



const URL = document.URL;

const to_input_field = document.getElementById("station-to");
const from_input_field = document.getElementById("station-from");

$(window).on('load', function () {
    let datalist_from = $('#datalist-from');
    datalist_from.empty();
    $.getJSON(URL + 'stations/', function (data) {
        $.each(data, function (key, entry) {
            console.log("Data -> " + data);
            datalist_from.append($('<option></option>').attr('value', entry.Name).text(entry.Name));
        });
    });

    to_input_field.onfocus = function () {
        const to_input_field = document.getElementById("station-to");
        const from_input_field = document.getElementById("station-from");
        console.log("from_input_field -> " + from_input_field);

        var u = URL + 'stations/GetDestinations?name=' + from_input_field.value;
        console.log(u);

        $.getJSON(u, function (data) {
            console.log("Printing all stations");
            let datalist_to = $('#datalist-to');
            console.log(datalist_to.innerHTML);
            datalist_to.empty();
            console.log(datalist_to.innerHTML);
            $.each(data, function (key, entry) {
                console.log(key + " - " + entry.Name);
                datalist_to.append($('<option></option>').attr('value', entry.Name).text(entry.Name));
            });
        });
    };
});


function handleFocusOut(event) {
    var opt = $('option[value="' + event.target.value + '"]');
    if (!opt.length) {
        event.target.value = "";
    }
}

$(window).on('load', function (event) {

    const to_input_field = document.getElementById("station-to");
    const from_input_field = document.getElementById("station-from");

    alert(to_input_field);
    alert(from_input_field);

    to_input_field.addEventListener("focusout", handleFocusOut);
    from_input_field.addEventListener("focusout", handleFocusOut);
});
