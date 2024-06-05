<?php
//セッションの開始
session_start();
?>

<!DOCTYPE html>
<html lang="ja">
    <head>
        <meta charset="utf-8">
        <title>Sample1</title>
    </head>
    <body>
        このページから購入するとクーポンです。
        <a href="httpBasic7_Se_Sample2.php">移動</a>
        <?php
        //セッション変数に値を代入する
        $_SESSION["coupon"] = "ABC123";   
        ?>
    </body>
</html>
