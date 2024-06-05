<?php
//クッキーに配列を保存
$re1 = setcookie("visitLog[Key1]","test1");
$re2 = setcookie("visitLog[Key2]","test2");
$re3 = setcookie("visitLog[Key3]","test3");
?>
<!DOCTYPE html>
<html lang="ja">
    <head>
        <meta charset="utf-8">
        <title>sampleC1</title>
    </head>
    <body>
        <?php
        if($re1 && $re2 && $re3)
        {
            echo "クッキーを保存できました。<br>";
            //前回のクッキーがあるか確認
            if(isset($_COOKIE["visitLog"]))
            {
                //配列を取り出す
                $arr = $_COOKIE["visitLog"];
                //配列の中身を表示
                echo $arr["Key1"]. "<br>";
                echo $arr["Key2"]. "<br>";
                echo $arr["Key3"]. "<br>";
            }
            else
            {
                echo "前回のクッキーがありません。<br>";
            }
        }
        else
        {
            echo "クッキーを保存できませんでした。";
        }
        ?>
    </body>
</html>