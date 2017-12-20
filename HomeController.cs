using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppJquery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult File()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveFile(String Name,float Price)
        {
            var uniquName = "";
            if (Request.Files["Image"]!=null)
            {
                var file = Request.Files["Image"];
                if (file.FileName!="")
                {
                    var ext = System.IO.Path.GetExtension(file.FileName);
                    uniquName = Guid.NewGuid().ToString() + ext;


                    var rootPath = Server.MapPath("~/FileUploads");
                    var fileSavePath = System.IO.Path.Combine(rootPath,uniquName);
                    file.SaveAs(fileSavePath);
                }
            }
            return View("File");
        }
        [HttpPost]
        public ActionResult FileUploadAjax(string DenemeFile, string DenemeName,float DenemePrice)
        {
            var uniquName = "";
            if (Request.Files["DenemeFile"] != null)
            {
                var file = Request.Files["DenemeFile"];
                if (file.FileName != "")
                {
                    var ext = System.IO.Path.GetExtension(file.FileName);
                    uniquName = Guid.NewGuid().ToString() + ext;


                    var rootPath = Server.MapPath("~/FileUploadsAjax");
                    var fileSavePath = System.IO.Path.Combine(rootPath, uniquName);
                    file.SaveAs(fileSavePath);
                }
            }
            return View("File");
        }
    }
}