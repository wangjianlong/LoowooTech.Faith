using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LoowooTech.Faith.Common
{
    public static class FileManager
    {
        private static string _folder { get; set; }
        private static string _dir { get; set; }
        static FileManager()
        {
            _folder = "UploadFiles";
            _dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _folder);
        }
        public static string Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength == 0) return string.Empty;
            if (!Directory.Exists(_dir))
            {
                Directory.CreateDirectory(_dir);
            }
            var newfileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName);
            var saveFileName = Path.Combine(_dir, newfileName);
            file.SaveAs(saveFileName);
            return saveFileName;
        }
    }
}