﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Messenger.Server.DataLayer.Model;

namespace Atiran.Messenger.Server.DataLayer.Context
{
    public static class connection
    {
        
        public static List<Users> AllUsers
        {
            get
            {
                using (var ctx = new DBMessengerEntities())
                {
                    return ctx.Users.AsNoTracking().ToList();
                }
            }
        }

        public static void SituationUser(string UserNsme, bool situation, string DateTime = null)
        {
            using (var ctx = new DBMessengerEntities())
            {
                Users user = ctx.Users.FirstOrDefault(w => w.UserName == UserNsme);
                if (user != null)
                {
                    user.situation = situation;
                    if (!situation && DateTime != null)
                    {
                        user.LastSeenReserve = DateTime;
                    }
                    else
                    {
                        user.LastSeenReserve = null;
                    }
                    ctx.SaveChanges();
                }
            }
        }

        public static void SendMessage_temp(Message_Temp message)
        {
            using (var ctx = new DBMessengerEntities())
            {
                ctx.Message_Temp.Add(message);
                ctx.SaveChanges();
            }
        }
        public static void SendMessage(Message_Temp message)
        {
            var msg = new Messages()
            {
                Text = message.Text,
                FromTocen = message.FromTocen,
                ToTocen = message.ToTocen,
                MessageID = message.MessageID,
                MessageDeleteTo = message.MessageDeleteTo,
                MessageDeleteFrom = message.MessageDeleteFrom,
                DateTimeSend = message.DateTimeSend
            };
            using (var ctx = new DBMessengerEntities())
            {
                ctx.Messages.Add(msg);
                ctx.SaveChanges();
            }
        }

        public static void RedMessage(int UserIdTo, int UserIdFrom)
        {
            using (var ctx = new DBMessengerEntities())
            {
                //باگ داره ازديتابيس پاك نميكنه اطلاعات مورد نظر
                //var result = ctx.MessageNotRed.AsNoTracking()
                //    .Where(w => w.FromTocen == UserIdFrom && w.ToTocen == UserIdTo).ToList();
                ////var ali = (from messageNotRed in ctx.MessageNotRed
                ////    where messageNotRed.FromTocen == UserIdFrom && messageNotRed.ToTocen == UserIdTo
                ////    select messageNotRed).ToList();
                //ctx.MessageNotRed.RemoveRange(result);

                var ListOfData = (from a in ctx.MessageNotRed
                        where a.FromTocen == UserIdFrom && a.ToTocen == UserIdTo
                        select a)
                    .ToList();

                ctx.MessageNotRed.RemoveRange(ListOfData);
                ctx.SaveChanges();

            }
        }


    }
}
