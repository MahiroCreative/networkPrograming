<?php
//クッキーに値を保存
$result = setcookie("message","1");
//クッキーの削除
//$result = setcookie("message","1",time() - 36000);
?>
<!DOCTYPE html>
<html lang="ja">
    <head>
        <meta charset="utf-8">
        <title>sampleC1</title>
    </head>
    <body>
        <?php
        if($result)
        {
            echo "クッキーを保存しました<br>";
            //前回のクッキーがあるかの確認
            if(isset($_COOKIE["message"]))
            {
                echo "前回のクッキーは".$_COOKIE["message"];
            }
            else
            {
                echo "前回のクッキーはありません。<br>";
            }
            
        }
        else
        {
            echo "クッキーの保存に失敗しました<br>";
        }
        ?>
    </body>
</html>