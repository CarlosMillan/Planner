Master = {
    TimePagination: 0,
    Host: null,
    Initialize: function () {
        Master.ClearAction();
        Master.Host = Functions.GetHost();
    },
    GetIdForm: function () {
        return $('Form').attr('id');
    },
    SetAction: function (methodname) {
        $('input[type=hidden]#Action').val(methodname);
    },
    ClearAction: function () {
        $('input[type=hidden]#Action').val('');
    },
    PreparePage: function (type) {
        $('#' + Master.GetIdForm()).attr('action', type + '.aspx');
        //Master.SelectedMenu(type);
    },
    Submit: function () {
        $('#' + Master.GetIdForm()).submit();
    }
}

$(document).ready(function () {
    Master.Initialize();
});