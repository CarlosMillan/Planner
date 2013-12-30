using System;

namespace General.DTOs.Structs
{
    public struct LoggedUser
    {
        private string _userid;
        private string _name;
        private string _rol;

        #region Propierties
        public string UserId
        {
            get { return _userid; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Rol
        {
            get { return _rol; }
        }
        #endregion

        public LoggedUser(string userid, string name, string rol)
        {
            _userid = userid;
            _name = name;
            _rol = rol;
        }        
    }
}
