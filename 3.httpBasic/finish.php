<?php
//セッション開始
session_start();
//セッションのチェック
if(!empty($_SESSION['name']) && !empty($_SESSION['kotoba']))
{
    //セッション変数から値を取り出す
    $name = $_SESSION['name'];
    $kotoba = $_SESSION['kotoba'];
}
//セッションの破棄
$_SESSION = [];//セッション配列を空にする。
if(isset($_COOKIE[session_name()]))
{
    $params = session_get_cookie_params();
    setcookie(session_name(),'',time() - 36000, $params['path']);
}
session_destroy();//セッションそのものを破棄
?>


<!DOCTYPE html>
<html lang="ja">
    <head>
        <meta charset="utf-8">
        <title>Sample1</title>
    </head>
    <body>
        <?php
        echo  $name . "<br>";
        echo  $kotoba . "<br>";
        ?>
    </body>
</html>
