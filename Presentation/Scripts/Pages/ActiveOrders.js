ActiveOrders = {
    StopAnimation: false,
    FirstTime: true,
    TotalOrders: 0,
    ShowSummary: false,
    Pagination: 0,
    FirstSummary: true,
    TableHeight: 0,
    Initialize: function () {                
        $('#BtnStop').click(function () {
            if (!ActiveOrders.StopAnimation) {
                ActiveOrders.StopAnimation = true;
                $('#BtnStop').removeClass('cancel');
                $('#BtnStop div').text('REANUDAR');
            }
            else {
                ActiveOrders.StopAnimation = false;
                $('#BtnStop').addClass('cancel');
                $('#BtnStop div').text('DETENER');
            }
        });

        $(document).ajaxComplete(function (event, request, settings) {
            if (ActiveOrders.TotalOrders == 0) window.location = 'Default.aspx?NoDataFound=True';
            else if (ActiveOrders.ShowSummary) {
                setTimeout(ActiveOrders.GetSummary, Master.TimePagination);
            }
            else {
                setTimeout(ActiveOrders.GetPage, Master.TimePagination);
            }
        });

        ActiveOrders.GetPage();
    },
    GetPage: function () {
        $('#DvTable').height(ActiveOrders.TableHeight + 'px');

        Ajax.Call('ActiveOrders', 'GetPage', '{stop:' + ActiveOrders.StopAnimation + '}', function (response) {
            var Result = jQuery.parseJSON(response.d);

            if (!ActiveOrders.StopAnimation) {
                if (!ActiveOrders.FirstTime) {
                    $('div.summarypanel').fadeOut(500, function () {
                        $('#TbData').fadeOut(1000, function () {
                            $('div#DvTable table tbody').html(Result.PageData);
                            $('div.pages').text(Result.CurrentPage + '/' + Result.TotalPages);
                            $('div.subtitle span').text(Result.TotalOrders);
                            $('#TbData').fadeIn(1000);                            
                            $('#DvTable').height(ActiveOrders.TableHeight + 'px');
                        });
                    });
                }
                else {
                    ActiveOrders.FirstTime = false;
                    $('div#DvTable table tbody').html(Result.PageData);
                    $('div.pages').text(Result.CurrentPage + '/' + Result.TotalPages);
                    $('div.subtitle span').text(Result.TotalOrders);
                    ActiveOrders.TableHeight = ($('table#TbData tr').height() * $('table#TbData tr').length);
                    $('#DvTable').height(ActiveOrders.TableHeight + 'px');
                }

                ActiveOrders.TotalOrders = Result.TotalOrders;
                ActiveOrders.ShowSummary = Result.Summary;
            }
        });
    },
    GetSummary: function () {        
        Ajax.Call('ActiveOrders', 'GetSummary', '{stop:' + ActiveOrders.StopAnimation + '}', function (response) {
            var Result = jQuery.parseJSON(response.d);

            if (!ActiveOrders.StopAnimation) {
                $('#TbData').fadeOut(500, function () {
                    $('div.summarypanel').fadeOut(1000, function () {
                        $('div.pages').text(Result.CurrentPage + '/' + Result.TotalPages);
                        $('div.subtitle span').text(Result.TotalOrders);

                        if (ActiveOrders.FirstSummary) {
                            $('div.summarypanel table#TableSummary1').show();
                            $('div.summarypanel table#TableSummary2').show();
                            $('div.summarypanel #TitleSummary1').show();
                            $('div.summarypanel #TitleSummary2').show();
                            $('div.summarypanel table#TableSummary1 tbody').html(Result.SummaryData1);
                            $('div.summarypanel table#TableSummary2 tbody').html(Result.SummaryData2);
                            $('div.summarypanel table#TableSummary3').hide();
                            $('div.summarypanel table#TableSummary4').hide();
                            $('div.summarypanel #TitleSummary3').hide();
                            $('div.summarypanel #TitleSummary4').hide();
                        }
                        else {
                            $('div.summarypanel table#TableSummary3').show();
                            $('div.summarypanel table#TableSummary4').show();
                            $('div.summarypanel #TitleSummary3').show();
                            $('div.summarypanel #TitleSummary4').show();
                            $('div.summarypanel table#TableSummary3 tbody').html(Result.SummaryData1);
                            $('div.summarypanel table#TableSummary4 tbody').html(Result.SummaryData2);
                            $('div.summarypanel table#TableSummary1').hide();
                            $('div.summarypanel table#TableSummary2').hide();
                            $('div.summarypanel #TitleSummary1').hide();
                            $('div.summarypanel #TitleSummary2').hide();
                        }

                        ActiveOrders.FirstSummary = !ActiveOrders.FirstSummary;
                        $('div.summarypanel').fadeIn(1000);
                        $('#DvTable').height($('div.summarypanel').height() + 'px');
                    });
                });

                ActiveOrders.ShowSummary = Result.Summary;
            }
        });
    }
}

$(document).ready(function () {
    ActiveOrders.Initialize();
});