<?php
/*セッション*/
$sessionID="";
//セッションの開始
session_start();

/*クッキー*/
echo "//クッキーの確認<br>";
$backPage="";
$sessionKey="";
$isBackPage =false;
$isSessionKey =false;
//クッキーの取り出し
//backPage
if(isset($_COOKIE["backPage"]))
{
    //クッキーの値を取り出す
    $backPage = $_COOKIE["backPage"];
    //表示
    $isBackPage =true;
    echo "backPage:{$backPage}<br>";
}
else
{
    //表示
    $isBackPage =false;
    echo "backPage:null<br>";
}
//sessionKey
if(isset($_COOKIE["sessionKey"]))
{
    //クッキーの値を取り出す
    $sessionKey = $_COOKIE["sessionKey"];
    //表示
    $isSessionKey=true;
    echo "sessinoKey:{$sessionKey}<br>";
}
else
{
    //表示
    $isSessionKey =false;
    echo "sessionKey:null<br>";
}

/*ログイン接続*/
echo "//ログイン接続の確認<br>";
$succesLogin = false;
//ログイン接続かどうかの確認(ログインページ以外からは処理しない)
if(isset($_POST["userID"]) && $backPage ==="Login")//ログイン接続
{
    echo "ログイン処理を開始します。<br>";
    //ログイン処理
    $userID = $_POST["userID"];
    $userPass = $_POST["userPass"];
    //正しいユーザIDとパスの取得(本来はデータベースから取り出す)
    $userData["ID"] = "user2023";
    $userData["pass"] = "pass2023";
    //ログインが成立すればログインフラグ立てる。
    if($userID === $userData["ID"] && $userPass === $userData["pass"])
    {
        //ログインそのものは成功
        echo "正常にログインできました。<br>";
        //セッションKeyの作成(本来は乱数を代入)
        $tempKey = "ABCD1234";
        $result = setcookie("sessionKey", $tempKey);
        //クッキーの作成の確認
        if($result)
        {
            echo "セッションキーを作成します。<br>";
            //セッションIDの作成(本来は乱数を代入)
            $sessionKey = $tempKey;
            $_SESSION[$sessionKey] = "1234ABCD";
            //セッションキー作成成功(ログイン成功)
            $succesLogin = true;
        }
        else
        {
            //セッションキー作成失敗(ログイン失敗)
            $succesLogin = false;
            echo "セッションキーの作成に失敗しました。<br>";
        }
    }
    else//不正ログイン
    {
        /*セッションの破棄*/
        $_SESSION = [];//nullを入れる
        //セッションクッキーの破棄
        if(isset($_COOKIE[session_name()]))
        {
            $params = session_get_cookie_params();
            setcookie(session_name(), '',time()-36000,$params['path']);
        }
        session_destroy();//セッションの破棄
        $succesLogin = false;
        echo "不正なアクセスです(ID,Passが間違っています)。<br>";
    }
}
else
{
    echo "ログイン接続ではありません<br>";
}

/*セッション接続*/
echo "//セッション接続の確認<br>";
$succesSession = false;
//セッション接続かどうかの確認
if(!$succesLogin && $isBackPage && $isSessionKey)
{
    //クッキーからセッションKeyの取得
    $sessionKey = $_COOKIE["sessionKey"];
    echo "セッションKey：" .$sessionKey . "<br>";//DeBug用
    //セッションIDの取得
    $sessionID = $_SESSION[$sessionKey];
    echo "セッションID：" . $sessionID . "<br>";//DeBug用
    //セッションリストの作成(本来はデータベースから取り出す)
    $sessionList = ["1234ABCD","session2023","session2024","session2023"];
    //セッションIDのチェック
    if(in_array($sessionID, $sessionList))
    {
        echo "正常アクセス(正しいセッションID)です。<br>";
        $succesSession = true;
    }
    else
    {
        echo "不正アクセス(正しくないセッションID)です。<br>";
        $succesSession = false;
    }
}
else
{
    echo "セッション接続ではありません。<br>";
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
        if($succesLogin || $succesSession)
        {
            //htmlの作成
            $Gacha = "<a href='httpBasic8_Ck_Gacha.php'>ガチャ</a><br>";
            $Logout = "<a href='httpBasic8_Ck_Login.php'>ログアウト</a><br>";
            //htmlの出力
            echo $Gacha;
            echo $Logout;
        }
        else{
            echo "<a href='httpBasic8_Ck_Login.php'>ログイン画面に戻る</a><br>";
        }
        ?>     
    </body>
</html>