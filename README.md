# EnmityPlugin

[OverlayPlugin](https://github.com/RainbowMage/OverlayPlugin) の機能をつかって、現在のターゲットの敵視量、距離、HP等をオーバーレイ表示するプラグインです。 

![sample](https://raw.githubusercontent.com/xtuaok/ACT_EnmityPlugin/master/sample.png)  

表示部にOverlayPluginの機能を使用しているため、OverlayPluginの導入が必要です。   
(必ずしもOverlayPluginをACTでロードする必要はありませんが、適切な場所に配置されている必要があります。)

## インストール

OverlayPluginをインストールしたフォルダに、ZIPの中身をすべてコピーします。   
たとえば "C:\Program Files\Advanced Combat Tracker\OverlayPlugin\" にOverlayPluginをインストールした場合、  
このフォルダに EnmityPlugin.dll, resources, ja-JP をコピーすればよいです。  

## 使い方

OverlayPlugin と概ね変わりません。  
ACTのPluginListからEnmityPlugin.dllをロードすれば使えるようになります。 

## 表示する情報について

メモリに存在するカレントターゲットの敵視値を表示します。  
計算等で算出しているのものではないので、リアルな値として参考になります。   
メモリには上位16キャラ分存在するので最大で16キャラ分表示されます。  
名前の下に表示されているゲージはヘイト1位との相対的な敵視量のグラフで、色はロールアイコンに準じています。

さらに、ターゲットとの距離、HPパーセント、HP/HPMaxが表示可能です。  
その他表示できる項目については resources/enmity.html のサンプルJSONを参考にしてください。  

将来OverlayPluginに大きな変更があった場合、正しく動かなくなる可能性があります。  
また、FFXIVプロセスのメモリを参照しているので、FFにパッチがあたるとデータを
正しく参照できなくなる可能性があります。  

