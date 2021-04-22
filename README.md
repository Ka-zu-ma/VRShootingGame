# VRShootingGame
 VRで遊べるシューティングゲーム

## ビルド環境
- Unity Version : 2020.3.4f1

## 課題点
- SnapOffsetを調整して銃を持った位置を調整してるが、SnapOffsetはNULLで掴みたいオブジェクトのレンダラーの座標や角度を調整する方法の方がベストプラクティスらしいのでそっちでやってみる

## 実装予定
- ゲームに制限時間を設ける
- ユーザーが弾が生成される時間間隔を設定できるようにする
- クロスヘア表示（銃を動かすと銃の向きにクロスヘアも動く）
- TextをTextMeshProに置き換え
- 弾の大きさをユーザーが設定できるようにする
- 弾同士が重なってしまわないようにする
- 弾が床にめりこんでしまわないようにする

## バグ
- 銃をもっていない状態で人差し指トリガーを引くだけで銃弾が発射されてしまう


