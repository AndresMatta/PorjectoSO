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
            Thread newThread = new Thread(() => MethodA(this.path));
            newThread.Start();

            Thread newThread2 = new Thread(() => MethodB(this.path));
            newThread2.Start();

            Thread newThread3 = new Thread(() => MethodC(this.path));
            newThread3.Start();

            Thread newThread4 = new Thread(() => MethodD(this.path));
            newThread4.Start();

            Thread newThread5 = new Thread(() => MethodE(this.path));
            newThread5.Start();
        }

        public void MethodA(string path)
        {
            imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(path);
            imageHandler.BitmapPath = path;
            imageHandler.SetGrayScale();

            string newPath = path + "F";
            imageHandler.SaveBitmap(newPath);
        }

        public void MethodB(string path)
        {
             imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(path);
            imageHandler.BitmapPath = path;
            imageHandler.SetInvert();

            string newPath = path + "F";
            imageHandler.SaveBitmap(newPath);
        }

        public void MethodC(string path)
        {
            imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(path);
            imageHandler.BitmapPath = path;
            imageHandler.SetGamma(120, 120, 120);

            string newPath = path + "F";
            imageHandler.SaveBitmap(newPath);

        }

        public void MethodD(string path)
        {
            imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(path);
            imageHandler.BitmapPath = path;
            imageHandler.SetContrast(12);

            string newPath = path + "F";
            imageHandler.SaveBitmap(newPath);

        }

        public void MethodE(string path)
        {
            imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(path);
            imageHandler.BitmapPath = path;
            imageHandler.SetBrightness(120);

            string newPath = path + "F";
            imageHandler.SaveBitmap(newPath);

        }
    }

}