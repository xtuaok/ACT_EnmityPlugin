using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Tamagawa.EnmityPlugin
{
    public class ReleaseInfo
    {
        public string url;
        public string html_url;
        public int id;
        public string tag_name;
        public string name;
        public string body;
    }

    public class UpdateChecker
    {
        private const string EndPoint = @"https://api.github.com/repos/xtuaok/ACT_EnmityPlugin/releases/latest";
        public static string ProductName
        {
            get
            {
                var product = (AssemblyProductAttribute)Attribute.GetCustomAttribute(
                    Assembly.GetExecutingAssembly(),
                    typeof(AssemblyProductAttribute));
                return product.Product;
            }
        }
        public static string Check()
        {
            var release = string.Empty;
            try
            {
                var json = String.Empty;
                using (var wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", @"ACT EnmityPlugin UpdateChecker/1.0; using .NET WebClient/4.0.0");
                    using (var stream = wc.OpenRead(EndPoint))
                    using (var reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }
                }
                var serializer = new JavaScriptSerializer();
                ReleaseInfo ri = (ReleaseInfo)serializer.Deserialize(json, typeof(ReleaseInfo));
                string version = ri.tag_name.Replace("v", string.Empty);
                var latest = new Version(version);
                var current = Assembly.GetExecutingAssembly().GetName().Version;
                if (current >= latest)
                {
                    release = String.Format(Messages.UpdateNotFound, current.ToString());
                    return release;
                }
                var message = Messages.NewVersionIsAvailable + Environment.NewLine + Environment.NewLine;
                message += String.Format(Messages.Update, latest.ToString()) + Environment.NewLine;
                message += String.Format(Messages.Current, current.ToString()) + Environment.NewLine;
                message += Environment.NewLine;
                message +=Messages.OpenSiteNow;
                if (MessageBox.Show(message, ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return release;
                }
                Process.Start(ri.html_url);
            } catch (Exception ex)
            {
                release = String.Format("Update check error: {0}", ex.ToString());
            }
            return release;
        }
    }
}
