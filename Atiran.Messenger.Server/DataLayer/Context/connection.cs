using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Messenger.Server.DataLayer.Model;

namespace Atiran.Messenger.Server.DataLayer.Context
{
    public static class connection
    {
        private static List<Users> _allUsers;

        public static void RefreshUsers()
        {
            using (var ctx = new DBMessengerEntities())
            {
                _allUsers = ctx.Users.AsNoTracking().ToList();
            }
        }
        public static List<Users> AllUsers
        {
            get => _allUsers;
        }

        public static void loginUser(string UserNsme, bool situation)
        {
            using (var ctx = new DBMessengerEntities())
            {
                Users user = ctx.Users.FirstOrDefault(w => w.UserName == UserNsme);
                if (user != null)
                {
                    user.situation = situation;
                    ctx.SaveChanges();
                }
            }
        }

        public static void SendMessage(Message_Temp mes)
        {
            using (var ctx = new DBMessengerEntities())
            {
                //ctx.
            }
        }

        public static void RedMessage(int UserIdTo, int UserIdFrom)
        {
            using (var ctx = new DBMessengerEntities())
            {
                var result = ctx.MessageNotRed.AsNoTracking()
                    .Where(w => w.FromTocen == UserIdFrom && w.ToTocen == UserIdTo).ToList();
                result.Clear();
                ctx.SaveChanges();

            }
        }


    }
}
