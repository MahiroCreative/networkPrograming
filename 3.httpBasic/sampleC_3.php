<?php
//保存したい配列の作成
$tempArr = ["りんご","みかん","レモン","バナナ"];
//値を連結した文字列にする
//"りんご&みかん&レモン&バナナ"
$valueString = implode("&",$tempArr); 
//クッキーに保存
$result = setcookie("fruits",$valueString);
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
            echo "クッキーを保存できました。<br>";
            //前回のクッキーの確認
            if(isset($_COOKIE["fruits"]))
            {
                //クッキーの取り出し
                $valueString = $_COOKIE["fruits"];
                //配列に戻す
                $fruits = explode("&",$valueString);
                //表示
                foreach($fruits as $temp)
                {
                    echo $temp ."<br>";
                }

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