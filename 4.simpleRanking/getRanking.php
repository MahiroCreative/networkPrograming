<?php
//データベースの作成と接続
//(既にある場合は接続のみ)
$db = new PDO('sqlite:ranking.db');

/*データの受け取り*/
$getName = $_GET['table'];

//テーブルのデータを確認
$que ="SELECT * From {$getName}";
$value = $db->query($que);
//連想配列として入ってるのでこれで出せる。
foreach($value as $temp)
{
    echo $temp['rank'].",";
    echo $temp['name'].",";
    echo $temp['score']."\n";
}
