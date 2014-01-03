EditOrder = {
    Initialize: function () {
        $('#BtnSaveOrder').click(function () {
            Master.PreparePage('EditOrder');
            Master.Submit();
        });
    }
}

$(document).ready(function () {
    EditOrder.Initialize();
});