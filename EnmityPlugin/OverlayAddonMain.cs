﻿using RainbowMage.OverlayPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Advanced_Combat_Tracker;

namespace Tamagawa.EnmityPlugin
{
    public class OverlayAddonMain : IOverlayAddon
    {
        // OverlayPluginのリソースフォルダ
        public static string ResourcesDirectory;

        // IOverlayAddon を実装したクラスの静的コンストラクタの中で、オーバーレイの型を登録する
        static OverlayAddonMain()
        {
            Assembly asm = System.Reflection.Assembly.GetCallingAssembly();
            foreach (ActPluginData plugin in ActGlobals.oFormActMain.ActPlugins)
            {
                if(plugin.pluginFile.Name == asm.ManifestModule.ScopeName) {
                    ResourcesDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(plugin.pluginFile.FullName), "resources");
                    break;
                }
            }

            OverlayTypeManager.RegisterOverlayType<
                EnmityOverlay,
                EnmityOverlayConfig,
                EnmityOverlayConfigPanel>(
                "Enmity Overlay",
                (config) => new EnmityOverlay(config as EnmityOverlayConfig),
                (name) => new EnmityOverlayConfig(name),
                (overlay) => new EnmityOverlayConfigPanel(overlay as EnmityOverlay)
                );

            // 更新チェック
            UpdateChecker.Check();
        }
    }
}