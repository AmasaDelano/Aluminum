using System.Linq;
using Aluminum.Data;
using Aluminum.Web.ViewModels;

namespace Aluminum.Web.Services
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

        public bool ChangePassword(string userName, ChangePasswordViewModel passwords)
        {
            if (passwords.NewPassword != passwords.ConfirmNewPassword)
            {
                return false;
            }

            var userEntity = _context.Users
                .SingleOrDefault(e => e.UserName.ToLower() == userName.ToLower());

            if (userEntity == null)
            {
                return false;
            }

            bool passwordsMatch = PasswordHash.ValidatePassword(passwords.CurrentPassword, userEntity.HashedPassword);

            if (!passwordsMatch)
            {
                return false;
            }

            userEntity.HashedPassword = PasswordHash.CreateHash(passwords.NewPassword);

            _context.SaveChanges();

            return true;
        }
    }
}