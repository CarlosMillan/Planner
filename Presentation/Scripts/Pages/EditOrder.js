EditOrder = {
    MessageSMS: '',
    Initialize: function () {
        $('#BtnSendMessage').click(function () {
            Master.PreparePage('EditOrder');
            Master.SetAction('SendMessage');
            Master.Submit();
        });

        $('#BtnCancel').click(function () {
            window.location = $('#ReturnUrl').val();
        });

        if (EditOrder.MessageSMS != '') {
            alert(EditOrder.MessageSMS);
            $('#BtnCancel').click();
        }
    }
}

$(document).ready(function () {
    EditOrder.Initialize();
});