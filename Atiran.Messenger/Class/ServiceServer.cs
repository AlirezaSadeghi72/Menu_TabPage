using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Messenger.Class
{
    public static class ServiceServer
    {
        public static string serverIP { get; set; }
        public static string serverPort { get; set; }
        public static Socket socketSever { get; set; }

        #region Local

        public static string serverIPLocal
        {
            get => "13.72.06.20";
        }
        public static string serverPortLocal
        {
            get => "2006";
        }


        #endregion

        //public async static void ReceiveMessageServer(byte[] buffer, EndPoint serverEP, out int inLength)
        //{
        //    await Task.Run(() => inLength = ServiceServer.T.ReceiveFrom(buffer, ref serverEP));
        //}

    }
}
