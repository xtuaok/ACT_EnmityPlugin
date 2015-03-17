# EnmityPlugin

現在のターゲットの敵視量、距離、HP等をオーバーレイ表示する、[OverlayPlugin](https://github.com/RainbowMage/OverlayPlugin) のアドオンです。 

![sample](https://raw.githubusercontent.com/xtuaok/ACT_EnmityPlugin/master/sample.png) 

OverlayPlugin (0.3.1.0以降)のアドオンとして動作するため、 OverlayPlugin の導入が必要です。

## ダウンロード

[リリースページ](https://github.com/xtuaok/ACT_EnmityPlugin/releases/latest)よりダウンロードできます。

## インストール

OverlayPlugin をインストールしたフォルダに `addons` というフォルダを作り、`EnmityOverlay.dll` を入れます。   
`ja-JP` の中身は `OverlayPlugin` の `ja-JP` フォルダにコピーします。  
同じように `resources` の中身は `OverlayPlugin` の `resources` フォルダにコピーします。  
たとえば `C:\Program Files\Advanced Combat Tracker\OverlayPlugin\` に OverlayPlugin をインストールした場合、下記のような構成になればよいです。
```
C:\Program Files\Advanced Combat Tracker\OverlayPlugin\
    ├addons
    │ └EnmityOverlay.dll
    ├ja-JP
    │ └EnmityOverlay.resources.dll
    ├resources
    │ └enmity.html
    └OverlayPlugin.dll, OverlayPlugin.Core.dll, OverlayPlugin.Common.dll ....
```

単純には配布されているZipの中身をそのままOverlayPluginのフォルダにコピーするだけでよいことになります。

## 使い方

OverlayPluginの設定で新しいオーバーレイとして`Enmity`タイプのオーバーレイを追加してください。  
![install](https://raw.githubusercontent.com/xtuaok/ACT_EnmityPlugin/master/install.png)

その他設定は miniparse や spelltimer オーバーレイとほぼ変わりません。  

見た目のカスタマイズは`resources\enmity.html`ファイルを編集することで可能です。  
その際ファイル名を変更しておけば、アップデートの時誤って上書きされることを防げます。  

## 表示する情報について

メモリに存在するカレントターゲットの敵視値を表示します。  
計算等で算出しているのものではないので、リアルな値として参考になります。   
メモリには上位16キャラ分存在するので最大で16キャラ分表示されます。  
名前の下に表示されているゲージはヘイト1位との相対的な敵視量のグラフで、色はロールアイコンに準じています。

さらに、ターゲットとの距離、HPパーセント、HP/HPMaxが表示可能です。  
その他表示できる項目については `resources\enmity.html` のサンプルJSON(ActXivDebug)を参考にしてください。  

将来 OverlayPlugin のインターフェースに大きな変更があった場合、正しく動かなくなる可能性があります。  
また、FFXIVプロセスのメモリを参照しているので、FFにパッチがあたるとデータを正しく参照できなくなる可能性があります。  

### 敵視情報

軽くメモリを検索した限りではカレントターゲットの敵視量しかメモリにありません。  
つまり、ターゲットしてない敵はもちろん、フォーカスターゲットやホバーターゲット、ターゲットのターゲットなどの敵視量は得ることができません。

標準UIの敵視リストの情報は有効に使えないような気がしています。  

### 距離情報

JSONに含まれるターゲットへの距離情報についてです。

* `Distance` は3次元距離なのでジャンプするだけでも数値が変わります。
* `HorizontalDistance` は高さを考慮していない座標の距離でジャンプしても変わりません。
* `EffectiveDistance` はスキルの有効範囲等に影響する距離で整数値でしか得ることができません。また、スキル対象になりえないオブジェクト(呼び鈴等)の距離は0になるようです。
