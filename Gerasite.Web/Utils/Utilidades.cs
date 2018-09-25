using Gerasite.Infra.Data.Context;
using System.IO;
using System.Web;

namespace Gerasite.Web.Utils
{
    public class Utilidades
    {
        private static GerasiteContext _context = new GerasiteContext();

        public static string UploadPhoto(HttpPostedFileBase file)
        {
            string path = string.Empty;
            string pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Fotos"), pic);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            return pic;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}