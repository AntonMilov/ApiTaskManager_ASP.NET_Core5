using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Entities;
using TaskList2.Models;
using TaskList2.Repositories.Abstract;

namespace TaskList2.Controllers.Abstract
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase<T> : ControllerBase where T : class, IEntityBase, new() 
     
    {
        public IBaseRepository<T> rep;
        public  IMapper _mapper;
        public ApiControllerBase(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}
