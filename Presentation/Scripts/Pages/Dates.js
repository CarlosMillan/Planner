Dates = {
    TotalDates: 0,
    FirsTime: true,
    Initialize: function () {
        Dates.AdjustClientsTable();
        Dates.AdjustSchedulesTable();

        $(document).ajaxComplete(function (event, request, settings) {
            //    if (Dates.TotalDates == 0) window.location = 'Default.aspx?NoDataFound=True';

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
            var Result = jQuery.parseJSON(response.d);

            if (!Dates.FirsTime) {                
                $('#DvTable').fadeOut(500, function () {
                    Dates.TotalDates = Result.TotalPages;
                    $('#DvTable #TbData tbody').html(Result.DatesTable);
                    $('.schedules #Morning tbody').html(Result.MorningTable);
                    $('.schedules #Evening tbody').html(Result.EveningTable);
                    $('.picturecontainer .pictitle.name').text(Result.AssessorName);
                    $('.picturecontainer .picture').attr('style', 'background-image:url(./AssesorsPictures/' + Result.AssessorId + '.png)');
                    Dates.AdjustSchedulesTable();
                    Dates.AdjustClientsTable();
                    $('#DvTable').fadeIn(1000);
                });
            }
            else {
                Dates.FirsTime = false;
                Dates.TotalDates = Result.TotalPages;
                $('#DvTable #TbData tbody').html(Result.DatesTable);
                $('.schedules #Morning tbody').html(Result.MorningTable);
                $('.schedules #Evening tbody').html(Result.EveningTable);
                $('.picturecontainer .pictitle.name').text(Result.AssessorName);
                $('.picturecontainer .picture').attr('style', 'background-image:url(./AssesorsPictures/' + Result.AssessorId + '.png)');
                Dates.AdjustSchedulesTable();
                Dates.AdjustClientsTable();                
            }
        });
    }
}

$(document).ready(function () {
    Dates.Initialize();
});