using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNVSSV.Client.Features
{
    public class PagingLink
    {
        //text
        public string Text { get; set; }
        //page cua no
        public int Page { get; set; }
        //hien hay ko
        public bool Enabled { get; set; }

        //trag thai kich hoat
        public bool Active { get; set; }
        public PagingLink(int page, bool enabled, string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }
    }
}
