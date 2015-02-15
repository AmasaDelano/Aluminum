using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return true;
        }
    }
}