using System;

namespace General.DTOs.Structs
{
    public struct LoggedUser
    {
        private string _userid;

        #region Propierties
        public string UserId
        {
            get { return _userid; }
        }
        #endregion

        public LoggedUser(string userid)
        {
            _userid = userid;
        }        
    }
}
