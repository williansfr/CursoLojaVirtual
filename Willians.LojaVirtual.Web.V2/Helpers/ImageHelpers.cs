using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Willians.LojaVirtual.Web.V2.Helpers
{
    public class ImageHelpers
    {
        private static AppSettingsReader _app;

        public static string CaminhoImagem()
        {
            _app = new AppSettingsReader();
            return _app.GetValue("Imagem", typeof(string)).ToString();
        }
    }
}