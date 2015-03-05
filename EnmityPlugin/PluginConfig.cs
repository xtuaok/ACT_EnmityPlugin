using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tamagawa.EnmityPlugin
{
    [Serializable]
    public class PluginConfig
    {
        [XmlElement("EnmityOverlay")]
        public EnmityOverlayConfig EnmityOverlay { get; set; }

        [XmlElement("FollowLatestLog")]
        public bool FollowLatestLog { get; set; }

        [XmlElement("Version")]
        public Version Version { get; set; }

        [XmlIgnore]
        public bool IsFirstLaunch { get; set; }

        public PluginConfig()
        {
            this.EnmityOverlay = new EnmityOverlayConfig();
            this.EnmityOverlay.Position = new Point(320, 20);
            this.EnmityOverlay.Size = new Size(300, 500);
            this.EnmityOverlay.IsVisible = false;
            this.FollowLatestLog = false;
            this.IsFirstLaunch = true;
        }

        public void SaveXml(string path)
        {
            this.Version = typeof(PluginMain).Assembly.GetName().Version;

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PluginConfig));
                serializer.Serialize(stream, this);
            }
        }

        public static PluginConfig LoadXml(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Specified file is not exists.", path);
            }

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PluginConfig));
                var result = (PluginConfig)serializer.Deserialize(stream);

                result.IsFirstLaunch = false;

                return result;
            }
        }

    }
}
