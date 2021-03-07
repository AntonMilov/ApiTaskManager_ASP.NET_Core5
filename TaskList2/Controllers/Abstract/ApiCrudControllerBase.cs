using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Controllers.Abstract;
using TaskList2.Entities;
using TaskList2.Models;
using TaskList2.Repositories.Abstract;

namespace TaskList2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCrudControllerBase<T, A> : ApiGetController<T, A>
        where T : class, IEntityBase, new()
      where A : class, IModel, new()
    {
        public ApiCrudControllerBase(IMapper mapper) : base(mapper)
        {
        }
        [HttpPost]
        public Guid Post(A value)
        {
            var model = _mapper.Map<T>(value);
            return rep.Create(model);
        }
        //[Authorize]
        [HttpPatch]
        public IActionResult UpdateById(Guid Id, A value)
        {
            var model = _mapper.Map<T>(value);
            rep.UpdateById(Id, model);
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            rep.DeleteById(Id);
            return Ok();

        }
    }
}
