using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoesECommerce.Models
{
    public static class MemberDB
    {
        public static void AddNewMember(Member m)
        {
            var context = new CommerceDbContext();
            context.Members.Add(m);
            context.SaveChanges();
        }

        public static bool IsUserNameTaken(RegistrationViewModel Reg)
        {
            // check if username is in use
            var db = new CommerceDbContext();
            bool isNameTaken =
                (from mem in db.Members
                 where mem.Username == Reg.Username
                 select mem).Count() == 1;
            return isNameTaken;
        }

        internal static bool UserExists(LoginViewModel login)
        {
            var db = new CommerceDbContext();
            bool doesExist =
                (from member in db.Members
                where member.Username == login.Username
                    && member.Password == login.Password
                select member).Any();
            return doesExist;

        }
    }
}