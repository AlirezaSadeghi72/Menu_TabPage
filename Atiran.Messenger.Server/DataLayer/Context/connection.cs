using System;
using System.Collections.Generic;
using System.Data.Entity;
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

                //foreach (MessageNotRed notRed in ListOfData)
                //{
                //    if (ctx.Entry(notRed).State == EntityState.Detached)
                //        ctx.MessageNotRed.Attach(notRed);
                //}

                ctx.MessageNotRed.RemoveRange(ListOfData);
                ctx.SaveChanges();

            }
        }

        public static void DeleteCuntact(int UserIdFrom, int UserIdTo, bool forContact)
        {
            using (var ctx = new DBMessengerEntities())
            {
                var result = ctx.Contacts.AsNoTracking()
                    .Where(w => w.UserID == UserIdFrom && w.ContactUserID == UserIdTo).ToList();

                result.Select(s =>
                {
                    s.ContactDelete = true;
                    return s;
                }).ToList();

                var resultMessage = ctx.Messages.Where(w => (w.FromTocen == UserIdFrom && w.ToTocen == UserIdTo)).ToList();

                resultMessage.Select(s =>
                {
                    s.MessageDeleteFrom = true;
                    return s;
                }).ToList();

                if (forContact)
                {
                    var result1 = ctx.Contacts.AsNoTracking()
                        .Where(w => w.UserID == UserIdTo && w.ContactUserID == UserIdFrom).ToList();

                    result1.Select(s =>
                    {
                        s.ContactDelete = true;
                        return s;
                    }).ToList();

                    resultMessage.Select(s =>
                    {
                        s.MessageDeleteTo = true;
                        return s;
                    }).ToList();


                    if (result1 != null)
                    {
                        // اينجا بودي
                    }
                }

                if (result != null)
                {

                }

                if (resultMessage != null)
                {

                }


                ctx.SaveChanges();
            }
        }

        public static void DeleteMessage(int UserIdFrom, int UserIdTo, Int64 MessageID, bool forContact)
        {
            using (var ctx = new DBMessengerEntities())
            {
                var result = ctx.Messages.AsNoTracking().FirstOrDefault(w =>
                    w.FromTocen == UserIdFrom && w.ToTocen == UserIdTo && w.MessageID == MessageID);
                if (result != null)
                {
                    result.MessageDeleteFrom = true;

                    if (forContact)
                    {
                        result.MessageDeleteTo = true;
                    }

                    ctx.Entry(result).State = EntityState.Modified;
                    ctx.SaveChanges();
                }

            }
        }

        public static void EditeMessage(int UserIdFrom, int UserIdTo, string Text, Int64 MessageID)
        {
            using (var ctx = new DBMessengerEntities())
            {
                var result = ctx.Messages.AsNoTracking().FirstOrDefault(w =>
                    w.FromTocen == UserIdFrom && w.ToTocen == UserIdTo && w.MessageID == MessageID);
                if (result != null)
                {
                    result.Text = Text;
                    ctx.Entry(result).State = EntityState.Modified;
                    ctx.SaveChanges();
                }

            }
            //اينجا رو تكميل كن
        }

    }
}
