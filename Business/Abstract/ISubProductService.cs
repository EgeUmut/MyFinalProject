﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubProductService
    {
        IDataResult<List<SubProduct>> GetAll();
        IResult Add(SubProduct subProduct);
        IDataResult<List<SubProduct>> GetById(int Id);
    }
}
