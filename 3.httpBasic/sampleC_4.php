<?php
//オリジナル関数(ユーザー定義関数)
//連想配列のキーと値をクエリ文字に変換する
function array_queryString(array $variable) : string
{
    $data =[];
    foreach($variable as $key => $value)
    {
        $data[] = "{$key}={$value}";
    }
    //クエリ文字を作る
    $queryString = implode("&",$data);
    return $queryString;
}
?>

<?php
//保存する連想配列の作成
$gamedata = ["name" => "マッキー","age"=>19,"avatar"=>"blue_snake","level"=>"a02wr215"];
//連想配列をクエリ文字列にする
$dataQueryString = array_queryString($gamedata);
//クッキーに保存
$result = setcookie("gamedata",$dataQueryString,time()+60*5);
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
            if(isset($_COOKIE["gamedata"]))
            {
                //クッキーから値を取り出す
                $dataQueryString = $_COOKIE["gamedata"];
                //クエリ文字から連想配列を作る
                parse_str($dataQueryString,$gamedata);
                //連想配列の値を表示
                foreach($gamedata as $key => $value)
                {
                    echo "{$key}:{$value},<br>";
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