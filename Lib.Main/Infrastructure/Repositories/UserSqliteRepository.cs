using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Main.Infrastructure.Repositories
{
    internal class UserSqliteRepository : IUserRepository
    {
        public void Add(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> Get()
        {
            throw new NotImplementedException();
        }

        public UserModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
