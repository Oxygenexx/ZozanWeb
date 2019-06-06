using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZozanWeb.Controllers
{
    public class StreamController : Controller
    {
        const string ContentTypeMpd = "application/dash+xml";
        const string ContentTypeMp4 = "video/mp4";
        const string FolderVod = "~/vod/";
        const string FolderLive = "~/live/";
        const string ManifestLive = "live.mpd";
        // GET: Stream
        public ActionResult Vod(string p, string f)
        {
            if (string.IsNullOrEmpty(f))
                throw new Exception("Stream.Vod : Aucun nom de fichier demandé");

            if (string.IsNullOrEmpty(p))
                throw new Exception("Stream.Vod : Aucun nom de programme demandé");

            string cType = f.EndsWith("mpd") ? ContentTypeMpd : ContentTypeMp4;

            string _filepath = FolderVod + p + '/' + f;
            try
            {
                return File(_filepath, cType);
            }
            catch (Exception _ex)
            {
                if (Request.IsLocal())
                    return Content(string.Format("Erreur lors de la préparation du fichier de résultat : {0}{1}", _ex.Message, _ex.InnerException != null ? "; InnerException: " + _ex.InnerException.Message : ""));
                else
                    throw new Exception(_ex.Message, _ex.InnerException);
            }
        }

        public ActionResult Live(string f)
        {
            if (string.IsNullOrEmpty(f))
                throw new Exception("Stream.Live : Aucun nom de fichier demandé");

            string cType = f.EndsWith(".mpd") ? ContentTypeMpd : ContentTypeMp4;

            //try
            //{
            return File(FolderLive + f, cType);
            //}
            //catch (Exception _ex)
            //{
            //    if (Request.IsLocal())
            //        return Content(string.Format("Erreur lors de la préparation du fichier de résultat : {0}{1}", _ex.Message, _ex.InnerException != null ? "; InnerException: " + _ex.InnerException.Message : ""));
            //    else
            //        throw new Exception(_ex.Message, _ex.InnerException);
            //}
        }

        public IActionResult TimeSync()
        {
            return Content(string.Concat(DateTime.UtcNow.ToString("s"), "Z"));
        }
    }
}