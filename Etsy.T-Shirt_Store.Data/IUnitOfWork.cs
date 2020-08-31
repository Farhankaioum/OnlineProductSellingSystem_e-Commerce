using System;
using System.Collections.Generic;
using System.Text;

namespace Etsy.T_Shirt_Store.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
