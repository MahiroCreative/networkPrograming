<?php
/*セッションの初期化*/
//セッションの開始
session_start();
//nullを入れる
$_SESSION = [];
//セッションクッキーの破棄
if(isset($_COOKIE[session_name()]))
{
    $params = session_get_cookie_params();
    setcookie(session_name(), '',time()-36000,$params['path']);
}
session_destroy();//セッションの破棄
?>
<!DOCTYPE html>
<html lang="ja">
    <head>
        <meta charset="utf-8">
        <title>ログインフォーム</title>
    </head>
    <body>
        <p>ログインフォーム</p>
        <form method="post" action="httpBasic7_Se_Home.php">
        <li><label>ID：<input type="text" name="userID"></label></li>
        <li><label>Pass：<input type="text" name="userPass"></label></li>
        <li><input type="submit" value="ログイン"></label></li>
        </form>
    </body>
</html>