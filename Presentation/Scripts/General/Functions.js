Functions = {
    GetHost: function() {
        var VirtualPath = '';
        var UrlElements = window.location.pathname.split('/');

        $(UrlElements).each(function () {
            if (this.indexOf('.') !== -1) return false;
            VirtualPath += this + '/'
        });

        return window.location.protocol + '//' + window.location.host + VirtualPath;
    }
}