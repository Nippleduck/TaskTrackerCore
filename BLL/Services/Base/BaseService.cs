﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.Base;
using DAL.UnitOfWork;

namespace BLL.Services.Base
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;
    }
}
