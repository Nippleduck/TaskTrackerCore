using AutoMapper;
using BLL.Services.Base;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    class UserService : BaseService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }
    }
}
