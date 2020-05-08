using AutoMapper;
using BLL.Services.Base;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    class ProjectTaskService : BaseService
    {
        public ProjectTaskService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }
    }
}
