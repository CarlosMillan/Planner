﻿ActiveOrders = {
    StopAnimation: false,
    FirstTime: true,
    TotalOrders: 0,
    Initialize: function () {
        $('#BtnStop').click(function () {
            if (!ActiveOrders.StopAnimation) {
                ActiveOrders.StopAnimation = true;
                $('#BtnStop').removeClass('cancel');
                //$('#BtnStop').addClass('waiting');
                $('#BtnStop div').text('REANUDAR');
            }
            else {
                ActiveOrders.StopAnimation = false;
                $('#BtnStop').addClass('cancel');
                $('#BtnStop div').text('DETENER');
            }
        });

        $(document).ajaxComplete(function (event, request, settings) {
            if (ActiveOrders.TotalOrders == 0) window.location('Default.aspx');
            else setTimeout(ActiveOrders.GetPage, Master.TimePagination);
        });

        ActiveOrders.GetPage();
    },
    GetPage: function () {
        Ajax.Call('ActiveOrders', 'GetPage', '{stop:' + ActiveOrders.StopAnimation + '}', function (response) {
            var Result = jQuery.parseJSON(response.d);

            if (!ActiveOrders.StopAnimation) {
                if (!ActiveOrders.FirstTime) {
                    $('div#DvTable table').fadeOut(1000, function () {
                        $('div#DvTable table tbody').html(Result.PageData);
                        $('div.pages').text(Result.CurrentPage + '/' + Result.TotalPages);
                        $('div.subtitle span').text(Result.TotalOrders);
                        $('div#DvTable table').fadeIn(1000);
                    });
                }
                else {
                    ActiveOrders.FirstTime = false;
                    $('div#DvTable table tbody').html(Result.PageData);
                    $('div.pages').text(Result.CurrentPage + '/' + Result.TotalPages);
                    $('div.subtitle span').text(Result.TotalOrders);
                }

                ActiveOrders.TotalOrders = Result.TotalOrders;
            }
        });
    }
}

$(document).ready(function () {
    ActiveOrders.Initialize();
});