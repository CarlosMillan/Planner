Default = {
    Initialize: function () {
        $('select#SlcAccess').closest('div.row').hide();
        $('select#SlcOrder').closest('div.row').hide();
        $('#DvMessages').hide();

        $('#BtnSearch').click(function () {
            Master.PreparePage('Default');        // Page name e.g. Login.aspx -> Login
            Master.SetAction('Search');          // Method in Login.aspx

            if (Default.Validations()) Master.Submit();
            else $('#DvMessages').show(500).append('Debes seleccionar los filtros correctos.');
        });

        $('select#SlcService').change(function () {
            if (this.value != 0) $('select#SlcAccess').closest('div.row').show(500);
            else {
                $('select#SlcAccess').closest('div.row').hide();
                $('select#SlcOrder').closest('div.row').hide();
            }
        });

        $('select#SlcAccess').change(function () {
            if (this.value != 0) $('select#SlcOrder').closest('div.row').show(500);
            else $('select#SlcOrder').closest('div.row').hide();
        });
    },
    Validations: function () {
        var Response = true;
        $('#DvMessages').text('');

        $.each($('select:visible').find(':selected'), function () {
            if (this.value == "0") {
                Response = false;                 
            }
        });

        return Response;
    }
}

$(document).ready(function () {
    Default.Initialize();
});