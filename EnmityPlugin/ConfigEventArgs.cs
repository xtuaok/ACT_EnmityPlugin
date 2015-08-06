using System;

namespace Tamagawa.EnmityPlugin
{
    public class ScanIntervalChangedEventArgs : EventArgs
    {
        public int NewScanInterval { get; private set; }
        public ScanIntervalChangedEventArgs(int newScanInterval)
        {
            this.NewScanInterval = newScanInterval;
        }
    }

    public class FollowFFXIVPluginChangedEventArgs : EventArgs
    {
        public bool NewFollowFFXIVPlugin { get; private set; }
        public FollowFFXIVPluginChangedEventArgs(bool newValue)
        {
            this.NewFollowFFXIVPlugin = newValue;
        }
    }

    public class DisableTargetChangedEventArgs : EventArgs
    {
        public bool NewDisableTarget { get; private set; }
        public DisableTargetChangedEventArgs(bool newValue)
        {
            this.NewDisableTarget = newValue;
        }
    }

    public class DisableAggroListChangedEventArgs : EventArgs
    {
        public bool NewDisableAggroList { get; private set; }
        public DisableAggroListChangedEventArgs(bool newValue)
        {
            this.NewDisableAggroList = newValue;
        }
    }

    public class DisableEnmityListChangedEventArgs : EventArgs
    {
        public bool NewDisableEnmityList { get; private set; }
        public DisableEnmityListChangedEventArgs(bool newValue)
        {
            this.NewDisableEnmityList = newValue;
        }
    }

    public class AggroListSortKeyChangedEventArgs : EventArgs
    {
        public string NewAggroListSortKey { get; private set; }
        public AggroListSortKeyChangedEventArgs(string newValue)
        {
            this.NewAggroListSortKey = newValue;
        }
    }

    public class AggroListSortDecendChangedEventArgs : EventArgs
    {
        public bool NewAggroListSortDecend { get; private set; }
        public AggroListSortDecendChangedEventArgs(bool newValue)
        {
            this.NewAggroListSortDecend = newValue;
        }
    }

}
