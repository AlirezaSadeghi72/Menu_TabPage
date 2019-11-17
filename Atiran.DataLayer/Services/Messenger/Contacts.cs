using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.DataLayer.Services.Messenger
{
    public class contacts
    {
        public int ID { get; set; }
        public Bitmap Image { get; set; }
        public string UserName { get; set; }
        public bool situation { get; set; }

        public int MessageNotRed { get; set; }

    }
}
