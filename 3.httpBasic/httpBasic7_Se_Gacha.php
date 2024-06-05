<?php
/*ホーム画面*/
//セッションの開始
session_start();
//ログイン変数作成
$LoginBool = false;
//セッション変数があるか調べる
if(isset($_SESSION["Login"]))
{
    //ログインIDを取り出す
    $Login = $_SESSION["Login"];
    //正しいクーポンコードの取得
    //(本来はデータベースから取り出してる)
    //ここで複数データにしているのは、ログイン人が一人とは限らないから。
    $LoginList = ["sesson2023","session2024","session2023"];
    //ログインIDのチェック
    if(in_array($Login, $LoginList))
    {
        echo "正しいログインIDです。<br>";
        $LoginBool = true;
    }
    else
    {
        echo "不正アクセス(ログインIDが違います)<br>";
    }
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
        //正常ログイン処理
        if($LoginBool)
        {
            //ユーザのセッションからuserID取得してガチャテーブル取得
            //(省略)

            //ガチャする
            //(省略)

            //結果を出力
            echo "正常にガチャしました。<br>";
            echo "<a href='httpBasic7_Se_Home.php'>ホーム画面に戻る</a><br>";
        }
        else{//不正アクセス処理
            echo "不正アクセス(セッションがありません)<br>";
            echo "<a href='httpBasic7_Se_Login.php'>ログイン画面に戻る</a><br>";
        }
        ?>
    </body>
</html>