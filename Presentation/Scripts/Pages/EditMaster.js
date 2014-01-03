EditMaster = {
    Initializer: function () {
        $('#BtnLogOut').click(function () {
            Master.PreparePage('Orders');
            Master.SetAction("LogOut");
            Master.Submit();
        });
    }
}

$(document).ready(function () {
    EditMaster.Initializer();
});