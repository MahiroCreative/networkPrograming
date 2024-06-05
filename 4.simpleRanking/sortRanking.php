<?php

/*データベースの作成と接続*/
//(既にある場合は接続のみ)
$db = new PDO('sqlite:ranking.db');

/*テーブルのデータを取得*/
$que ="SELECT * From Ranking";
//連想配列にする
$value = $db->query($que)->fetchAll();

/*２要素の配列にする*/
$arr = [];
foreach($value as $temp)
{
    $arr[$temp['name']] = $temp['score'];
}

/*ソート*/
arsort($arr);

/*テーブルデータの書き直し*/
$cout =1;
foreach($arr as $key => $temp)
{
    $que ="INSERT OR REPLACE INTO Ranking VALUES ({$cout},'{$key}',{$temp})";
    echo $que."\n";
    $db->query($que);
    $cout++;
}


?>