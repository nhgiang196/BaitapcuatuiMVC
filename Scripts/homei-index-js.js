$(document).ready(function () {

})
function editGuest(id) {
    $.ajax({
        url: 'Home/GetById/' + id,
        type: 'POST',
        dataType: 'JSON',

    }).done(function (data) {
        alert(stringify(data));
    });

    //$('#myModal').show();

}
function Msg() {
    alert('aaaa');
}


