<?php
//セッション開始
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
        //postされた値をセッション変数に渡す
        if(isset($_POST['name']))
        {
            $_SESSION['name'] = $_POST["name"];

            if($_SESSION['name'] != "")
            {
                echo "nameは". $_SESSION['name'] . "です<br>";
            }
            else
            {
                echo "nameがありません<br>";
            }
            
        }
        else
        {
            echo "不正アクセスです<br>";
        }
        if(isset($_POST['kotoba']))
        {
            $_SESSION['kotoba'] = $_POST["kotoba"];

            if($_SESSION['kotoba'] != "")
            {
                echo "kotobaは". $_SESSION['kotoba'] . "です<br>";
            }
            else
            {
                echo "kotobaがありません<br>";
            }
        }
        else
        {
            echo "不正アクセスです<br>";
        }
    ?>
    <a href="finish.php">完了ページへ</a>
    </body>
</html>
