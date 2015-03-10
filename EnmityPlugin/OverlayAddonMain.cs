﻿using RainbowMage.OverlayPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tamagawa.EnmityPlugin
{
    public class OverlayAddonMain : IOverlayAddon
    {
        // OverlayPluginのリソースフォルダ
        public static string ResourcesDirectory = String.Empty;

        public OverlayAddonMain()
        {
            // OverlayPlugin.Coreを期待
            Assembly asm = System.Reflection.Assembly.GetCallingAssembly();
            if (asm.Location == null || asm.Location == "")
            {
                // 場所がわからないなら自分の場所にする
                asm = Assembly.GetExecutingAssembly();
            }
            ResourcesDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(asm.Location), "resources");
        }

        static OverlayAddonMain()
        {
            // static constructor should be called only once
            UpdateChecker.Check();
        }

        public string Name
        {
            get { return "Enmity"; }
        }

        public string Description
        {
            get { return "Show enmity values of current target."; }
        }

        public Type OverlayType
        {
            get { return typeof(EnmityOverlay); }
        }

        public Type OverlayConfigType
        {
            get { return typeof(EnmityOverlayConfig); }
        }

        public Type OverlayConfigControlType
        {
            get { return typeof(EnmityOverlayConfigPanel); }
        }

        public IOverlay CreateOverlayInstance(IOverlayConfig config)
        {
            return new EnmityOverlay((EnmityOverlayConfig)config);
        }

        public IOverlayConfig CreateOverlayConfigInstance(string name)
        {
            return new EnmityOverlayConfig(name);
        }

        public System.Windows.Forms.Control CreateOverlayConfigControlInstance(IOverlay overlay)
        {
            return new EnmityOverlayConfigPanel((EnmityOverlay)overlay);
        }

        public void Dispose()
        {

        }
    }
}