﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUow
{
    public interface IGenericUowService<T>
    {
        T TGetById(int id);
        void TInsert(T t);
        void TUpdate(T t);
        void TMultiUpdate(List<T> t);
    }
}
