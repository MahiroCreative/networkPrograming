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
        <?php
        //セッションがあるか調べる
        if(isset($_SESSION["coupon"]))
        {
            //クーポンコードを取り出す
            $coupon = $_SESSION["coupon"];
            //クーポンリスト(セッションIDリスト)を取り出す(本来はDBから取り出す)
            $couponList = ["ABC123","XYZ999"];
            //クーポンコードをチェックする
            if(in_array($coupon,$couponList))
            {
                echo "正しいクーポンです<br>";
            }
            else
            {
                echo "誤ったクーポンです<br>";
            }
        }
        else
        {
            echo "セッションエラー<br>";   
        }
        ?>
    </body>
</html>
