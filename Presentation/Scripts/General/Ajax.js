Ajax = {
    Initialize: function () {
        $.ajaxSetup({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            datatype: 'json',
            async: true
        });
    },
    Call: function (page, method, parameters, onsuccess) {
        $.ajax({
            url: Master.Host + page + '.aspx/' + method,
            data: parameters == null ? '{}' : parameters,
            success: onsuccess
//            ,error: function (xhr, ajaxOptions, thrownError) {
//                alert('¡Algo falló! - ' + xhr.responseText + ' e ' + thrownError);
//            }
        });
    }
}

$(document).ready(function () {
    Ajax.Initialize();
});