# EnmityPlugin

現在のターゲットの敵視量、距離、HP等をオーバーレイ表示する、[OverlayPlugin](https://github.com/RainbowMage/OverlayPlugin) のアドオンです。 

![sample](https://raw.githubusercontent.com/xtuaok/ACT_EnmityPlugin/master/sample.png) 

OverlayPlugin (0.3.0.0以降)のアドオンとして動作するため、OverlayPluginの導入が必要です。

## ダウンロード

[リリースページ](https://github.com/xtuaok/ACT_EnmityPlugin/releases/latest)よりダウンロードできます。

## インストール

OverlayPluginをインストールしたフォルダにaddonsというフォルダを作り、EnmityOverlay.dllを入れます。   
ja-JPの中身はOverlayPluginのja-JPフォルダにコピーします。  
同じようにresourcesの中身はOverlayPluginのresourcesフォルダにコピーします。  
たとえば "C:\Program Files\Advanced Combat Tracker\OverlayPlugin\" にOverlayPluginをインストールした場合、下記のような構成になればよいです。
```
C:\Program Files\Advanced Combat Tracker\OverlayPlugin\
    ├addons
    │ └EnmityOverlay.dll
    ├ja-JP
    │ └EnmityOverlay.resources.dll
    ├resources
    │ └enmity.html
    └OverlayPlugin.dll, HtmlRenderer.dll ....
```

## 使い方

OverlayPlugin と概ね変わりません。  

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

### 敵視情報

軽くメモリを検索した限りではカレントターゲットの敵視量しかメモリにありません。  
つまり、ターゲットしてない敵はもちろん、フォーカスターゲットやホバーターゲット、ターゲットのターゲットなどの敵視量は得ることができません。

標準UIの敵視リストの情報はメモリにないのかと言われれば、表示されている以上ありますが、有効な情報として利用可能な状態ではなさそうです。  
未確認ですが恐らく、例えば「大まかな1位との差」などといった、敵視を4段階のマークで表現するに必要な最低限の情報かと思われます。

### 距離情報

*Distance* は3次元距離なのでジャンプするだけでも数値が変わります。  
*HorizontalDistance* は高さを考慮していない座標の距離でジャンプしても変わりません。  
*EffectiveDistance* はスキルの有効範囲等に影響する距離で整数値でしか得ることができません。また、スキル対象になりえないオブジェクト(呼び鈴等)の距離は0になるようです。    
