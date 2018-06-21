using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParserTool.Models
{
    public class PathViewModel
    {
        // role for authentication and for identification
        public int UserId { get; set; }
        public int Id { get; set; }
        
        // path and datas of browsing for database
        public string Pathway { get; set; }
        [Display(Name = "JS File")]
        public Nullable<int> JsFile { get; set; }
        [Display(Name = "JS Line")]
        public Nullable<int> JsLine { get; set; }
        [Display(Name = "HTML File")]
        public Nullable<int> HtmlFile { get; set; }
        [Display(Name = "HTML Line")]
        public Nullable<int> HtmlLine { get; set; }
        [Display(Name = "CSS File")]
        public Nullable<int> CsFile { get; set; }
        [Display(Name = "CSS Line")]
        public Nullable<int> CsLine { get; set; }
        [Display(Name = "SQL File")]
        public Nullable<int> SqlFile { get; set; }
        [Display(Name = "SQL Line")]
        public Nullable<int> SqlLine { get; set; }
        [Display(Name = "Date of Browsing")]
        public Nullable<DateTime> Date { get; set; }    
    }
}