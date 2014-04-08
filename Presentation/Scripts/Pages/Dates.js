Dates = {
    TotalDates: 0,
    Initialize: function () {
        Dates.AdjustClientsTable();
        Dates.AdjustSchedulesTable();

        $(document).ajaxComplete(function (event, request, settings) {
            //if (Dates.TotalDates == 0) window.location = 'Default.aspx?NoDataFound=True';

            setTimeout(Dates.GetPage, Master.TimePagination);
        });

        Dates.GetPage();
    },
    AdjustClientsTable: function () {
        var PictureHeight = $('div.picture').height()
        $('#DvTable').height(PictureHeight + 'px');
    },
    AdjustSchedulesTable: function () {
        var TableMorningHeight = $('div.schedules table#Morning').height();
        var TablesEveningHeight = $('div.schedules table#Evening').height()
        var padding = parseInt($('div.schedules').css('padding-top')) / 2;
        $('.schedules').height((parseInt(Functions.GetBiggestNumber(TableMorningHeight, TablesEveningHeight)) + parseInt(padding)) + 'px');
    },
    GetPage: function () {
        Ajax.Call('Dates', 'GetDatesPage', '{}', function (response) {
            
        });
    }
}

$(document).ready(function () {
    Dates.Initialize();
});