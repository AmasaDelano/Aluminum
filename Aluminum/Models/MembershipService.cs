using System.Linq;
using Aluminum.ViewModels;

namespace Aluminum.Models
{
    public class MembershipService
    {
        private readonly RoomOfRequirement _context;

        public MembershipService(RoomOfRequirement context)
        {
            _context = context;
        }

        public bool LogIn(UserViewModel user)
        {
            var userEntity = _context.Users
                .SingleOrDefault(e => e.UserName.ToLower() == user.UserName.ToLower());

            // User not found -- cannot log in.
            if (userEntity == null)
            {
                return false;
            }

            // User found -- log in successful if passwords match.
            bool passwordsMatch = PasswordHash.ValidatePassword(user.Password, userEntity.HashedPassword);

            return passwordsMatch;
        }
    }
}