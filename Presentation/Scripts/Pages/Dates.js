Dates = {
    Initialize: function () {
        Dates.AdjustClientsTable();
        Dates.AdjustSchedulesTable();
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
    }
}

$(document).ready(function () {
    Dates.Initialize();
});