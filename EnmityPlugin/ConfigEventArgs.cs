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
}
