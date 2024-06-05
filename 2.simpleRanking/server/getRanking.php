<?php
//データベースの作成と接続
//(既にある場合は接続のみ)
$db = new PDO('sqlite:ranking.db');

//テーブルのデータを確認
$que ="SELECT * From Ranking";
$value = $db->query($que);
//連想配列として入ってるのでこれで出せる。
foreach($value as $temp)
{
    echo $temp['rank'].",";
    echo $temp['name'].",";
    echo $temp['score']."\n";
}
?>