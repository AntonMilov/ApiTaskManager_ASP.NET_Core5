using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Context;
using TaskList2.Entities;
using TaskList2.Repositories.Abstract;

namespace TaskList2.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context)
             : base(context)
        {
        }
        public override void UpdateById(Guid Id, User userModel)
        {
            var user = context.Users.Where(p => p.Id == Id).FirstOrDefault();
            user.StatusActivated = userModel.StatusActivated;
            user.Name = userModel.Name;
            user.Email = userModel.Email;
            if (user.Email != userModel.Email)
            {
                user.StatusActivated = false;
            }
            SaveChange();
        }
    }
}
