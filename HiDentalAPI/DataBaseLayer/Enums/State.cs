using System;
namespace DatabaseLayer.Enums
{

    public enum State
    {
        Active,
        Removed,
        Blocked,

        #region For Movements
        Payment
        #endregion
    }

}
