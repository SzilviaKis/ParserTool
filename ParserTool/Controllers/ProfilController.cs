using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParserTool;
using System.Data.Entity.Validation;
using ParserTool.Models;
using System.IO;
using Newtonsoft.Json;
using Rotativa;
using ClosedXML.Excel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParserTool.Controllers
{
    public class ProfilController : Controller
    {
        // create the instantiation of database entity class
        private ParserToolDatabaseEntities database = new ParserToolDatabaseEntities();

        // fill the table with files from the pathway
        public ActionResult Table(PathViewModel path)
        {
            List<PathViewModel> model = new List<PathViewModel>();

            try
            {
                var userId = (int)Session["userId"];
                var signed = model.Where(m => m.UserId == userId);

                if (signed != null)
                {
                    FillMyModel(model);
                    return View(model.OrderByDescending(a => a.Date));
                }
            }
            catch (Exception)
            {
                RedirectToAction("UploadFiles", "Browse");
            }
            return View(model);
        }


        // make ratings from database by pathway id
        public ActionResult Rating(int Id)
        {
            try
            {
                SelectFromDatabase(Id);
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("UploadFiles", "Browse");
            }
        }
              

        // export data to pdf format       
        public ActionResult ExportToPDF()
        {
            var report = new ActionAsPdf("Table");
            return report;
        }

        public ActionResult PrintPartialViewToPdf(PathViewModel path)
        {
            List<PathViewModel> model = new List<PathViewModel>();

            try
            {
                var userId = (int)Session["userId"];

                var signed = model.Where(m => m.UserId == userId);

                if (signed != null)
                {
                    FillMyModel(model);
                    var orderedModel = model.OrderByDescending(a => a.Date);
                    var report = new PartialViewAsPdf("~/Views/Profil/ExportToPDF.cshtml", orderedModel);
                    return report;
                }
                return ViewBag.Message("Not success to print");
            }
            catch (Exception)
            {
                RedirectToAction("Table", "Profil");
                return ViewBag.Message("Not success to print");
            }
        }

        // export data to excel format
        public ActionResult ExportToExcel()
        {
            try
            {
                List<PathViewModel> model = new List<PathViewModel>();
                FillMyModel(model);
                var gv = new GridView();
                gv.DataSource = model;
                gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();
                return View("ExportToExcel");
            }
            catch (Exception)
            {
                return ViewBag.Message("Export is NOT successful! Try again!");
            }
        }


        // fill up the PathViewModel list by iterating through the database
        private void FillMyModel(List<PathViewModel> model)
        {
            try
            {
                foreach (var item in database.FolderFile)
                {
                    model.Add(new PathViewModel()
                    {
                        Id = item.Id,
                        JsFile = item.JsFile,
                        JsLine = item.JsLine,
                        SqlFile = item.SqlFile,
                        SqlLine = item.SqlLine,
                        CsFile = item.CsFile,
                        CsLine = item.CsLine,
                        HtmlFile = item.HtmlFile,
                        HtmlLine = item.HtmlLine,
                        Date = item.Date,
                    });
                }
            }
            catch
            {
                View();
            }
        }

        // select the pathway id from database
        private void SelectFromDatabase(int Id)
        {
            FolderFile item = database.FolderFile.Find(Id);

            if (item != null)
            {

                PathViewModel model = new PathViewModel()
                {
                    JsFile = item.JsFile,
                    JsLine = item.JsLine,
                    SqlFile = item.SqlFile,
                    SqlLine = item.SqlLine,
                    CsFile = item.CsFile,
                    CsLine = item.CsLine,
                    HtmlFile = item.HtmlFile,
                    HtmlLine = item.HtmlLine,
                    Date = item.Date,
                };
                View(model);
            }
        }
    }
}
