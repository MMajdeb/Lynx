using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Access.DAL.Transaction
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
