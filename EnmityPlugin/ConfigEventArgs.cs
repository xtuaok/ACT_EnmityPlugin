using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
}
