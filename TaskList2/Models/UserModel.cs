using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList2.Models
{
    public class UserModel:IModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
