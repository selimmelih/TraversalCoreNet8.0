using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnifOfWork
{
    public interface IUnitOfWorkDal
    {
        void Save();
    }
}
