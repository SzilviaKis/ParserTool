using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParserTool.Models
{
    public class ParsingItem
    {

        public int JsF { get; set; }
        public int JsL { get; set; }
        public int SqlL{ get; set; }
        public int CsF { get; set; }
        public int CsL { get; set; }
        public int HtmlF { get; set; }
        public int HtmlL { get; set; }
        public int SqlF { get; set; }
    }
}