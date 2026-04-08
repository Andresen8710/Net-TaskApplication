using App.Common.Classes.Base.Repository;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Priority;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Priority
{
	public class PriorityService : BaseService<PriorityModel, PriorityEntity>, IPriorityService
	{
		public PriorityService(IBaseRepository<PriorityEntity> repository, IConfiguration configuration, IMapper mapper) : base(repository, configuration, mapper)
		{
		}
	}
}
