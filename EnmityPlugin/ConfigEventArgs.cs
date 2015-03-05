using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagawa.EnmityPlugin
{
    public class VisibleStateChangedEventArgs : EventArgs
    {
        public bool IsVisible { get; private set; }
        public VisibleStateChangedEventArgs(bool isVisible)
        {
            this.IsVisible = isVisible;
        }
    }

    public class ThruStateChangedEventArgs : EventArgs
    {
        public bool IsClickThru { get; private set; }
        public ThruStateChangedEventArgs(bool isClickThru)
        {
            this.IsClickThru = isClickThru;
        }
    }

    public class UrlChangedEventArgs : EventArgs
    {
        public string NewUrl { get; private set; }
        public UrlChangedEventArgs(string url)
        {
            this.NewUrl = url;
        }
    }

    public class MaxFrameRateChangedEventArgs : EventArgs
    {
        public int NewFrameRate { get; private set; }
        public MaxFrameRateChangedEventArgs(int frameRate)
        {
            this.NewFrameRate = frameRate;
        }
    }

    public class ScanIntervalChangedEventArgs : EventArgs
    {
        public int NewScanInterval { get; private set; }
        public ScanIntervalChangedEventArgs(int newScanInterval)
        {
            this.NewScanInterval = newScanInterval;
        }
    }

    public class GlobalHotkeyEnabledChangedEventArgs : EventArgs
    {
        public bool NewGlobalHotkeyEnabled { get; private set; }
        public GlobalHotkeyEnabledChangedEventArgs(bool globalHotkeyEnabled)
        {
            this.NewGlobalHotkeyEnabled = globalHotkeyEnabled;
        }
    }

    public class GlobalHotkeyChangedEventArgs : EventArgs
    {
        public Keys NewHotkey { get; private set; }
        public GlobalHotkeyChangedEventArgs(Keys hotkey)
        {
            this.NewHotkey = hotkey;
        }
    }

}
