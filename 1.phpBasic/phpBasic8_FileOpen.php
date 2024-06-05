<?php
/*ファイルの読み込み */

//ファイル名
$filename = "test.txt";
//ファイルの存在を確認
$result = file_exists($filename);
//ファイルが存在していればtrueが返る
if($result)
{
    //ファイル読み込み
    $readdata = file_get_contents($filename);
    //ブラウザに表示
    echo $readdata;
}
else
{
    echo "正常に読み込めませんでした。";
}
?>