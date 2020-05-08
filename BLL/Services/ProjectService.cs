using BLL.Services.Base;
using DAL.Base;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ProjectService : BaseService
    {
        public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
