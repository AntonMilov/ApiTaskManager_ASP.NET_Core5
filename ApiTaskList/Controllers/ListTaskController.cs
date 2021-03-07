using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskList2.Context;
using TaskList2.Entities;
using TaskList2.Models;
using TaskList2.Repositories;
using System.Collections;
using TaskList2.Repositories.Abstract;
using AutoMapper;
using TaskList2.Controllers.Abstract;

namespace TaskList2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListTaskController : ApiCrudControllerBase<ListTask,ListTaskModel>
    {
    
        public ListTaskController(IListTaskRepository rep, IMapper mapper) : base(mapper)
        {
            this.rep = rep;
        }
   

    }
}
