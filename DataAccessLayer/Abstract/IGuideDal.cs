﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGuideDal:IGenericDal<Guide>
    {
        // crud islemleri interfacede yapılır

        void ChangeToTrueByGuide(int id);
        void ChangeToFalseByGuide(int id);

    }
}
