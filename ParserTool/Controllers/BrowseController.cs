using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParserTool.Models;
using System.IO;
using System.IO.Compression;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;

namespace ParserTool.Controllers
{
    public class BrowseController : Controller
    {
        public ParserToolDatabaseEntities db = new ParserToolDatabaseEntities();
        
        // view of the browsing page, upload from pathway
        public ActionResult UploadFiles()
        {
            PathViewModel model = new PathViewModel();

            var validUserId = User.Identity.GetUserId();

            model.UserId = db.User.FirstOrDefault().Id;
          
            return View(model);
        }

        // ZIP file manipulation
        [HttpPost]
        public ActionResult UploadZipFile(HttpPostedFileBase zip)
        {
            var model = new PathViewModel();

            try
            {
                if (zip == null)
                    return View(nameof(UploadFiles), model);

                // zip file uploading
                var uploads = Server.MapPath("~/App_Data/Uploads/");
                string newGuid = Guid.NewGuid().ToString();
                string guidUploadPath = Path.Combine(uploads, newGuid);
                 
                // zip file saving 
                if (!Directory.Exists(guidUploadPath))
                    Directory.CreateDirectory(guidUploadPath);

                var zipPath = Path.Combine(guidUploadPath, zip.FileName);

                zip.SaveAs(zipPath);

                // zip file extracting
                ZipFile.ExtractToDirectory(zipPath, guidUploadPath);

                // zip file sending to the parser method
                PathViewModel path = new PathViewModel();
                path.Pathway = guidUploadPath;                
                ProcessingAndCounting(path);                
                return RedirectToAction("Table", "Profil", path);
               
            }
            catch (Exception ex)
            {
                ViewBag.Message(ex);
                return View(nameof(UploadFiles), model);
            }
        }

        // iterates and counts along the route
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFilesFromTextBox(PathViewModel model)
        {
            try
            {
                if (Session["userId"] is int)
                {
                    ProcessingAndCounting(model);
                    return RedirectToAction("Table", "Profil");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
                return View(model);
            }
        }

        // parser method: save the path, check the extension, and save the datas for database
        private void ProcessingAndCounting(PathViewModel model)
        {
            try
            {
                FolderPath pathway = new FolderPath();
                pathway.Date = DateTime.Now;
                pathway.FolderPathway = model.Pathway;
                pathway.UserId = (int)Session["userId"];
                FolderFile files = new FolderFile();

                if (model.Pathway != null)
                {
                    ParsingItem items = new ParsingItem();

                    string searchPattern = "*.sql,*.cs,*.js,*.html";
                    string path = model.Pathway;

                    foreach (string file in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(s => searchPattern.Contains(Path.GetExtension(s).ToLower())))
                    {
                        string extension = Path.GetExtension(file);

                        if (!(file.Contains("bin") || file.Contains("Debug") || file.Contains("obj")))
                        {
                            if (extension == ".sql")
                                items.SqlF++;                           
                            else if (extension == ".js")
                                items.JsF++;
                            else if (extension == ".cs")
                                items.CsF++;
                            else if (extension == ".html")
                                items.HtmlF++;

                            ParseLines(items, file, extension);                           
                        } 
                    }

                    // mapping
                    files.SqlFile = items.SqlF;
                    files.SqlLine = items.SqlL;
                    files.CsFile = items.CsF;
                    files.CsLine = items.CsL;
                    files.JsFile = items.JsF;
                    files.JsLine = items.JsL;
                    files.HtmlFile = items.HtmlF;
                    files.HtmlLine = items.HtmlL;
                    files.Date = DateTime.Now;
                }

                files.FolderPath = pathway;
                db.FolderPath.Add(pathway);
                db.FolderFile.Add(files);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
            }
        }

        // check each file and count the lines
        private void ParseLines(ParsingItem item, string file, string extension)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var lineData = reader.ReadLine();

                    if (!String.IsNullOrEmpty(lineData))
                    {
                        if (extension == ".sql")
                            item.SqlL++;
                        else if (extension == ".js")
                            item.JsL++;
                        else if (extension == ".cs")
                            item.CsL++;
                        else if (extension == ".html")
                            item.HtmlL++;
                    }
                }
            }
        }
    }
}

