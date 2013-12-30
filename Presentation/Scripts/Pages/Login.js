Login = {
    Initialize: function () {
        $('#BtnLogIn').click(function () {
            Master.PreparePage('Login');        // Page name e.g. Login.aspx -> Login
            Master.SetAction('UserLogIn');          // Method in Login.aspx
            Master.Submit();
        });
    }
}

$(document).ready(function () {
    Login.Initialize();
});