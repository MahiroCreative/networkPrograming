<?php
/*ホーム画面*/
//セッションの開始
session_start();
//ログイン変数作成
$LoginBool = false;

/*クッキー*/
echo "//クッキーの確認<br>";
$sessionKey ="";
if(isset($_COOKIE["sessionKey"]))
{
    //クッキーからセッションキーを取り出す。
    $sessionKey = $_COOKIE["sessionKey"];
    //表示
    echo "sessinoKey:{$sessionKey}<br>";
}
else
{
    //表示
    echo "sessionKey:null<br>";
}

/*セッション*/
$sessionID ="";
$SessionBool =false;
//セッション変数があるか調べる
if(isset($_SESSION[$sessionKey]))
{
    //ログインIDを取り出す
    $sessionID = $_SESSION[$sessionKey];
    //正しいセッションIDかをデータベースから確認
    $sessionList = ["sesson2023","session2024","session2023","1234ABCD"];
    //セッションIDのチェック
    if(in_array($sessionID, $sessionList))
    {
        echo "正しいセッションIDです。<br>";
        $SessionBool = true;
    }
    else
    {
        echo "セッションIDが間違っています<br>";
    }
}
else
{
    echo "セッションがありません<br>";
}
?>
<!DOCTYPE html>
<html lang="ja">
    <head>
        <meta charset="utf-8">
        <title>ガチャ画面</title>
    </head>
    <body>
        <?php
        if($SessionBool)
        {
            //正常ログイン

            //ユーザのセッションからuserID取得してガチャテーブル取得
            //(省略)

            //ガチャする
            //(省略)

            //結果を出力
            echo "正常にガチャしました。<br>";
            echo "<a href='httpBasic8_Ck_Home.php'>ホーム画面に戻る</a><br>";
        }
        else
        {
            //不正アクセスの場合
            echo "<a href='httpBasic8_Ck_Login.php'>ログイン画面に戻る</a><br>";
        }
        ?>
    </body>
</html>