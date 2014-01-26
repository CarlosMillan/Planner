Default = {
    Delay: 500,
    AssesorsMatrix: null,
    Initialize: function () {
        Default.HideServiceElements();
        $('#DvMessages').hide();
        Default.AssesorsMatrix = $('#SlcAsesors option[value!="0"]');
        $('#SlcAsesors option[value!="0"]').remove();

        $('#BtnSearch').click(function () {
            Master.PreparePage('Default');        // Page name e.g. Login.aspx -> Login
            Master.SetAction('Search');          // Method in Login.aspx

            if (Default.Validations()) Master.Submit();
            else $('#DvMessages').show(500).append('Debes seleccionar todos los filtros y/o llenar los campos.');
        });

        $('#SlcService').change(function () {
            if ($('#SlcAccess').is(':visible')) Default.HideServiceElements();

            $('#SlcAccess').closest('div.row').show(Default.Delay);
        });

        $('#SlcAccess').change(function () {
            switch (parseInt(this.value)) {
                case 1:
                    $('#SlcOrder').closest('div.row').show(Default.Delay);
                    Default.HideAccessElements('SlcOrder');
                    break;

                case 2:
                    if ($('#SlcService').val() == 1) $('#SlcAsesors').append(Default.AssesorsMatrix);

                    $('#SlcAsesors').closest('div.row').show(Default.Delay);
                    Default.HideAccessElements('SlcAsesors');
                    break;

                case 3:
                    $('#SlcStatus').closest('div.row').show(Default.Delay)
                    Default.HideAccessElements('SlcStatus');
                    break;

                case 4:
                    $('#TxtOrder_Client_Plates').closest('div.row').show(Default.Delay);
                    Default.HideAccessElements('TxtOrder_Client_Plates');
                    break;

                default:
                    Default.HideAccessElements();
                    break;
            }

            $('select:not(:visible)').val(0);
            $('input[type="text"]').val('');
        });
    },
    Validations: function () {
        var Valid = true;
        $('#DvMessages').text('');

        $.each($('select:visible').find(':selected'), function () {
            if (this.value == "0") {
                Valid = false;
            }
        });

        $.each($('input[type="text"]:visible'), function () {
            if (this.value.length == 0) {
                Valid = false;
            }
        });

        return Valid;
    },
    HideServiceElements: function () {
        $('#SlcAccess').closest('div.row').hide();
        $('#SlcOrder').closest('div.row').hide();
        $('#SlcStatus').closest('div.row').hide();
        $('#SlcAsesors').closest('div.row').hide();
        $('#TxtOrder_Client_Plates').closest('div.row').hide();
        $('#SlcAccess').val('0');
        $('#SlcOrder').val('0');
        $('#SlcStatus').val('0');
        $('#SlcAsesors').val('0');
        $('#TxtOrder_Client_Plates').val('');
    },
    HideAccessElements: function (nothide) {
        switch (nothide) {
            case 'SlcOrder':
                $('#SlcStatus').closest('div.row').hide();
                $('#TxtOrder_Client_Plates').closest('div.row').hide();
                $('#SlcAsesors').closest('div.row').hide();
                $('#SlcAsesors option[value!="0"]').remove();
                break;

            case 'SlcStatus':
                $('#SlcOrder').closest('div.row').hide();
                $('#TxtOrder_Client_Plates').closest('div.row').hide();
                $('#SlcAsesors').closest('div.row').hide();
                $('#SlcAsesors option[value!="0"]').remove();
                break;

            case 'TxtOrder_Client_Plates':
                $('#SlcOrder').closest('div.row').hide();
                $('#SlcStatus').closest('div.row').hide();
                $('#SlcAsesors').closest('div.row').hide();
                $('#SlcAsesors option[value!="0"]').remove();
                break;

            case 'SlcAsesors':
                $('#SlcOrder').closest('div.row').hide();
                $('#SlcStatus').closest('div.row').hide();
                $('#TxtOrder_Client_Plates').closest('div.row').hide();
                break;
        }
    }
}

$(document).ready(function () {
    Default.Initialize();
});