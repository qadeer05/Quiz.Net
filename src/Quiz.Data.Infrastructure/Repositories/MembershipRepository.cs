using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.EntityFramework;

namespace Quiz.Data.Infrastructure.Repositories
{
    public class MembershipRepository
    {
        private UserDbContext _context;

        public MembershipRepository(UserDbContext context)
        {
            _context = context;
        }

        public string GetConfirmationToken(int userId)
        {
            string cmd = "select ConfirmationToken from webpages_Membership where UserId = " + userId.ToString();
            return _context.Database.SqlQuery<string>(cmd).FirstOrDefault();
        }
    }
}
