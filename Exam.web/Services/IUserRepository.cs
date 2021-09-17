using Exam.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Services
{
    public interface IUserRepository  
    {
        public ApplicationUser GetUser(Guid userId);
        public ApplicationUser GetUser(string userName);
    }
}
