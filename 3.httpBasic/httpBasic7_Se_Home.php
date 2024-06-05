<?php
/*セッション*/
//セッションとはページ間を跨って変数を利用する仕組みです。
//例えば別ページでログインしてログインIDを発行し、
//別ページでログインIDを元に本人確認をして、ガチャを引くといったものです。
//セッションの開始
session_start();
//ログイン接続かセッション接続かの確認
if(isset($_POST["userID"]))//ログイン接続
{
    //ログイン処理
    $userID = $_POST["userID"];
    $userPass = $_POST["userPass"];
    //正しいユーザIDとパスの取得(本来はデータベースから取り出す)
    $userData["ID"] = "user2023";
    $userData["pass"] = "pass2023";
    //ログインが成立すればログインIDの作成
    if($userID == $userData["ID"] && $userPass == $userData["pass"])
    {
        //本来は乱数を作成して入れる
        $_SESSION["Login"] = "sesson2023";
        echo "正常にログインできました。<br>";
    }
    else{
        /*セッションの破棄*/
        $_SESSION = [];//nullを入れる
        //セッションクッキーの破棄
        if(isset($_COOKIE[session_name()]))
        {
            $params = session_get_cookie_params();
            setcookie(session_name(), '',time()-36000,$params['path']);
        }
        session_destroy();//セッションの破棄
        echo "不正なアクセスです(ID,Passが間違っています)。<br>";
    }
}
else{//セッション接続
    if(isset($_SESSION["Login"]))
    {
        echo "正常アクセス<br>";
    }
    else{
        echo "不正アクセス(セッションがありません)<br>";
    }
}
?>
<!DOCTYPE html>
<html lang="ja">
    <head>
        <meta charset="utf-8">
        <title>ホーム画面</title>
    </head>
    <body>
        <?php
        if(isset($_SESSION["Login"]))
        {
            //htmlの作成
            $Gacha = "<a href='httpBasic7_Se_Gacha.php'>ガチャ</a><br>";
            $Logout = "<a href='httpBasic7_Se_Login.php'>ログアウト</a><br>";
            //htmlの出力
            echo $Gacha;
            echo $Logout;
        }
        else{
            echo "<a href='httpBasic7_Se_Login.php'>ログイン画面に戻る</a><br>";
        }
        ?>     
    </body>
</html>