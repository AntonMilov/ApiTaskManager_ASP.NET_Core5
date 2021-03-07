using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Entities;
using TaskList2.Models;
namespace TaskList2.Controllers.Abstract
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApiGetController<T, A> : ApiControllerBase<T> where T : class, IEntityBase, new()
        where A : class, IModel, new()
    {
        public ApiGetController(IMapper mapper) : base(mapper)
        {
        }
        [Authorize]
        [HttpGet("ById")]
        public T GetById(Guid Id)
        {
            return rep.GetSingle(Id);
        }
        [Authorize]
        [HttpGet("ByAllId")]
        public IEnumerable<T> GetByAllId(Guid Id)
        {
            return rep.GetAllById(Id);
        }
        [Authorize]
        [HttpGet("AllPagination")]
        public IEnumerable<T> Get(int Page,int sizePage)
        {
            return rep.GetAllPagination(Page, sizePage);
        }

    }
}
