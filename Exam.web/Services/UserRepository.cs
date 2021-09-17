using Exam.web.DBcontexts;
using Exam.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ExamAppContext _appContext;

        public UserRepository(ExamAppContext appContext)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }
        public ApplicationUser GetUser(Guid userId)
        {
            return _appContext.Users.FirstOrDefault(a => a.Id == userId.ToString());
        }
        public ApplicationUser GetUser(string userName)
        {
            return _appContext.Users.FirstOrDefault(a => a.UserName == userName);
        }
    }
}
