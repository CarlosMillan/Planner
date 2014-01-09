EditOrder = {    
    Initialize: function () {
        $('#BtnSaveOrder').click(function () {
            Master.PreparePage('EditOrder');
            Master.Submit();
        });

        $('#BtnCancel').click(function () {
            window.location = $('#ReturnUrl').val();
        });
    }
}

$(document).ready(function () {
    EditOrder.Initialize();
});