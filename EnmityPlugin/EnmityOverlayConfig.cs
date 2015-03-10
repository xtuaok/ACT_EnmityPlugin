using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RainbowMage.OverlayPlugin;

namespace Tamagawa.EnmityPlugin
{
    [Serializable]
    public class EnmityOverlayConfig : OverlayConfigBase
    {
        public event EventHandler<ScanIntervalChangedEventArgs> ScanIntervalChanged;

        public EnmityOverlayConfig(string name)
            : base(name)
        {
            this.scanInterval = 100;
            this.Url = new Uri(System.IO.Path.Combine(OverlayAddonMain.ResourcesDirectory, "enmity.html")).ToString();
        }

        private EnmityOverlayConfig()
            : base(null)
        {
        }

        public override Type OverlayType
        {
            get { return typeof(EnmityOverlay); }
        }

        private int scanInterval;
        [XmlElement("ScanInterval")]
        public int ScanInterval
        {
            get
            {
                return this.scanInterval;
            }
            set
            {
                if (this.scanInterval != value)
                {
                    this.scanInterval = value;
                    if (ScanIntervalChanged != null)
                    {
                        ScanIntervalChanged(this, new ScanIntervalChangedEventArgs(this.scanInterval));
                    }
                }
            }
        }


    }
}
