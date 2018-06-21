using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ParserTool.Models
{
    public class ChartModel
    {
        public int x { get; set; }
        public Nullable<int> y { get; set; }

        public int Id { get; set; }
        public List<int> GraphList { get; set; }


        [Display(Name = "js")]
        public Nullable<int> JsFile { get; set; }
        [Display(Name = "jsLine")]
        public Nullable<int> JsLine { get; set; }
        [Display(Name = "html")]
        public Nullable<int> HtmlFile { get; set; }
        [Display(Name = "htmlLine")]
        public Nullable<int> HtmlLine { get; set; }
        [Display(Name = "cs")]
        public Nullable<int> CsFile { get; set; }
        [Display(Name = "csLines")]
        public Nullable<int> CsLine { get; set; }
        [Display(Name = "sql")]
        public Nullable<int> SqlFile { get; set; }
        [Display(Name = "sqlLines")]
        public Nullable<int> SqlLine { get; set; }


       

    }

    public partial class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }


    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, Nullable<int> y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}