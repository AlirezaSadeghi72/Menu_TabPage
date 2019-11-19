using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Messenger.Class
{
    public static class ServiceServer
    {
        public static string serverIP { get; set; }
        public static string serverPort { get; set; }
        public static Socket T { get; set; }

    }
}
