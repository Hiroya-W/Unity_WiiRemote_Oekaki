# 創造工学「魔法のステッキWiiリモコン」
## ~ UnityでWiiリモコンを使ったお絵かきアプリ ~
## 開発スケジュール
2018/4/10 ~ 2018/7/24  
発表日 2018/7/24

## Wiiリモコン
- WindowsとBluetooth接続できることを知って遊んでみたかった
- C# / Unity Wii Remote APIがあるので簡単に使える
- 今回はマウス代わりに使いたかったため、Windowsのタッチ操作をWiiリモコンでエミュレートできる「Touchmote」を利用した

## 準備
- お絵かきで遊ぶスクリーン、モノを出現させるスクリーンを分離しているため、遊ぶためにパソコンが2台以上必要
1. Wiiリモコンをペアリング
1. UNetを用いてホストPCとクライアントPCを接続
1. 準備用UIを閉じる

## 遊び方
1. 水色の本のボタンから、魔法語辞典を開く
1. 魔法語の組み合わせを調べる
1. 本を閉じて、その組み合わせ通りに絵を描く
    - 直前に見ていたページの組み合わせの下絵が表示される
    - 描いた絵がどれ程綺麗に描けているか採点し表示
    1. 1文字目は魔法陣を描く(自由な魔法陣を描いてOK)
    1. 2~4文字目までは下絵をなぞるように描く
1. 指定文字描くと表示が切り替わるので、魔法を唱えるようにWiiリモコンを振る
1. スクリーンにオブジェクトが出現する

## 他の機能
- カーソルカラーの変更
- ヘルパーモード
    - 絵が描きにくい人用の補正機能
- ヘルプ

## 課題
- Wii Remote APIだけで完結させたい(Touchmoteが使えないパソコンがあった)
- パソコンを2台使うこと
    - Unityで2枚のディスプレイに出力することはできるけど、マウス座標やオブジェクトの表示位置を調整しないといけない
    - 結果的に分離したほうが楽だった
- 複数人で遊べるようにしたい
    - 丁寧さ、描く速さを競えるようなゲーム性も追加したい
- ヘルパーモードの充実
- Wiiリモコンの機能を他にも使う(振動、サウンド)
- Wiiリモコンでの操作が難しい
    - Wiiリモコンで絵を描こうとしたのが間違いだったかもしれないけど、予想以上にブレがあって難しい
    - (Wiiで遊ぶときには気にならなかったんだけどな...。ソフトウェアで調整してるのかな？)
    - (加速度センサー使って補正してるとか話を聞いたことがある。画面外に出たときのトラッキングを加速度センサー使ってやってるとかやってないとか...。)

# 副産物
複数のディスプレイに出力したいがために、UNETを使ってゴリ押したわけだが。これによりAndroidなどにビルドするとAndroid端末でオブジェクトが出現する様子が見れるようになる。もちろんWiiリモコンを使って絵を描くのはWindowsじゃないと出来ない。
- Unityはマルチプラットフォームに対応してる。

これには驚いた。同じソースコードで出来ちゃうんですね。  
Androidや、iPadなどのタブレット端末用に遊べる機能を追加 + ビルド すれば色んな人に遊んでもらえるようなものになるかも。 

## スクリーンショット
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-6.png)
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-7.png)
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-8.png)
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-9.png)
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-10.png)
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-11.png)
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-12.png)
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-13.png)
![](https://github.com/Hiroya-W/Unity_WiiRemote_Oekaki/blob/imgs/SnapCrab_2018-12-27_14-26-14.png)
