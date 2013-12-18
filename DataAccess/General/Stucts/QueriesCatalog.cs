using System;

namespace DataAccess.General.Stucts
{
    public struct QueriesCatalog
    {       
        #region Propierties
        public static string ValidateUser
        {
            get { return "SELECT [User_Id] FROM Users WHERE [User_Id] = '{0}' AND Rol_Id = '{1}' "; }
        }
        #endregion
    }
}
