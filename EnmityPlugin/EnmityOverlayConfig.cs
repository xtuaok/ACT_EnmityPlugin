using System;
using System.Xml.Serialization;
using RainbowMage.OverlayPlugin;

namespace Tamagawa.EnmityPlugin
{
    [Serializable]
    public class EnmityOverlayConfig : OverlayConfigBase
    {
        public event EventHandler<ScanIntervalChangedEventArgs> ScanIntervalChanged;
        public event EventHandler<FollowFFXIVPluginChangedEventArgs> FollowFFXIVPluginChanged;
        public event EventHandler<DisableTargetChangedEventArgs> DisableTargetChanged;
        public event EventHandler<DisableAggroListChangedEventArgs> DisableAggroListChanged;
        public event EventHandler<DisableEnmityListChangedEventArgs> DisableEnmityListChanged;
        public event EventHandler<AggroListSortKeyChangedEventArgs> AggroListSortKeyChanged;
        public event EventHandler<AggroListSortDecendChangedEventArgs> AggroListSortDecendChanged;

        public EnmityOverlayConfig(string name)
            : base(name)
        {
            this._scanInterval = 100;
            this.Url = new Uri(System.IO.Path.Combine(OverlayAddonMain.ResourcesDirectory, "enmity.html")).ToString();
            this._followFFXIVPlugin = false;
            this._disableTarget = false;
            this._disableAggroList = false;
            this._disableEnmityList = false;
            this._aggroListSortKey = "none";
            this._aggroListSortDecend = false;
        }

        private EnmityOverlayConfig()
            : base(null)
        {
        }

        public override Type OverlayType => typeof(EnmityOverlay);

        private int _scanInterval;
        [XmlElement("ScanInterval")]
        public int ScanInterval
        {
            get
            {
                return this._scanInterval;
            }
            set
            {
                if (this._scanInterval != value)
                {
                    this._scanInterval = value;
                    ScanIntervalChanged?.Invoke(this, new ScanIntervalChangedEventArgs(this._scanInterval));
                }
            }
        }

        private bool _followFFXIVPlugin;
        [XmlElement("FollowFFXIVPlugin")]
        public bool FollowFFXIVPlugin
        {
            get
            {
                return this._followFFXIVPlugin;
            }
            set
            {
                if (this._followFFXIVPlugin != value)
                {
                    this._followFFXIVPlugin = value;
                    FollowFFXIVPluginChanged?.Invoke(this, new FollowFFXIVPluginChangedEventArgs(this._followFFXIVPlugin));
                }
            }
        }

        private bool _disableTarget;
        [XmlElement("DisableTarget")]
        public bool DisableTarget
        {
            get
            {
                return this._disableTarget;
            }
            set
            {
                if (this._disableTarget != value)
                {
                    this._disableTarget = value;
                    DisableTargetChanged?.Invoke(this, new DisableTargetChangedEventArgs(this._disableTarget));
                }
            }
        }

        private bool _disableAggroList;
        [XmlElement("DisableAggroList")]
        public bool DisableAggroList
        {
            get
            {
                return this._disableAggroList;
            }
            set
            {
                if (this._disableAggroList != value)
                {
                    this._disableAggroList = value;
                    DisableAggroListChanged?.Invoke(this, new DisableAggroListChangedEventArgs(this._disableAggroList));
                }
            }
        }

        private bool _disableEnmityList;
        [XmlElement("DisableEnmityList")]
        public bool DisableEnmityList
        {
            get
            {
                return this._disableEnmityList;
            }
            set
            {
                if (this._disableEnmityList != value)
                {
                    this._disableEnmityList = value;
                    DisableEnmityListChanged?.Invoke(this, new DisableEnmityListChangedEventArgs(this._disableEnmityList));
                }
            }
        }

        private string _aggroListSortKey;
        [XmlElement("AggroListSortKey")]
        public string AggroListSortKey
        {
            get
            {
                return this._aggroListSortKey;
            }
            set
            {
                if (this._aggroListSortKey != value)
                {
                    this._aggroListSortKey = value;
                    AggroListSortKeyChanged?.Invoke(this, new AggroListSortKeyChangedEventArgs(this._aggroListSortKey));
                }
            }
        }

        private bool _aggroListSortDecend;
        [XmlElement("AggroListSortDecend")]
        public bool AggroListSortDecend
        {
            get
            {
                return this._aggroListSortDecend;
            }
            set
            {
                if (this._aggroListSortDecend != value)
                {
                    this._aggroListSortDecend = value;
                    AggroListSortDecendChanged?.Invoke(this, new AggroListSortDecendChangedEventArgs(this._aggroListSortDecend));
                }
            }
        }
    }
}
