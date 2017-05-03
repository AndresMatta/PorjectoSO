using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace Proyecto_SO_I.Controllers
{
    public class HomeController : Controller
    {
        /** Estan todo los métodos de filtros, la imagen se puede pasar por parametro a este constructor,
                si se les complica cargan la imagen directamente desde los archivos de la pc con el path quemado **/
        private ImageHandler imageHandler = new ImageHandler();

        string path =  Environment.CurrentDirectory + "\\img\\imagen.jpg";

        public ActionResult Index()
        {
            MethodsToThread();
            return View();
        }


        public void MethodsToThread()
        {
            Thread newThread2 = new Thread(() => MethodC(this.path));
            newThread2.Start();
        }

        public void MethodA(string path)
        {
            
        }

        public void MethodB(string path)
        {
            
        }

        public void MethodC(string path)
        {
            var uri = new Uri(path, UriKind.Absolute);
            imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(path);
            imageHandler.BitmapPath = path;
            imageHandler.SetGamma(120, 120, 120);

            string newPath = path + "F";
            imageHandler.SaveBitmap(newPath);

        }
    }

}