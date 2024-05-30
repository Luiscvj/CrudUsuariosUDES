using AutoMapper;
using CrudUdes.Api.Services;
using CrudUdes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudUdes.Api.Controllers
{
    [ApiController]
    [Route("api/CrudUdes/[controller]")]
    public class BaseApiController :ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseApiController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
