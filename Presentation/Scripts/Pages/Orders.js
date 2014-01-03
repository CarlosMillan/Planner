Orders = {
    Initialize: function () {
        $('input[type="button"]').click(Orders.Edit);        
    },
    Edit: function () {
        var Tr = $(this).closest('tr');
        $('input[name="OrderType"]').val($(Tr.children()[0]).text());
        $('input[name="OrderNum"]').val($(Tr.children()[1]).text());
        $('input[name="AdmissionDate"]').val($(Tr.children()[2]).text());
        $('input[name="PrimiseDate"]').val($(Tr.children()[3]).text());
        $('input[name="PrimiseDate2"]').val($(Tr.children()[4]).text());
        $('input[name="Vehicle"]').val($(Tr.children()[5]).text());
        $('input[name="Client"]').val($(Tr.children()[6]).text());        
        $('input[name="Plates"]').val($(Tr.children()[7]).text());
        $('input[name="StayDays"]').val($(Tr.children()[8]).text());
        $('input[name="Status"]').val($(Tr.children()[9]).text());
        $('input[name="DeliveryDate"]').val($(Tr.children()[10]).text());
        $('input[name="Asessor"]').val($(Tr.children()[11]).text());
        $('input[name="Cellphone"]').val($(Tr.children()[12]).text());
        $('form').submit();
    }
}

$(document).ready(function () {
    Orders.Initialize();
});