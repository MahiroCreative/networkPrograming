<?php
/*SQL文に関して*/
//基本５命令以外は詳しくは教えないので自己学習してください。
//学習サイトは以下
//https://zenn.dev/umi_mori/books/331c0c9ef9e5f0/viewer/992632
//下記は典型例で、細かな機能の作り方などは『simpleRanking』の方で。

/*データベースの作成と接続*/
//(既にある場合は接続のみ)
$db = new PDO('sqlite:ranking.db');

/*ランキング用のテーブルを削除(無ければ無視)*/
$que = "DROP TABLE IF EXISTS Ranking";
$db->query($que);

/*ランキング用のテーブルの作成(既にあれば無視)*/
$que = 'CREATE TABLE IF NOT EXISTS';
$que .= ' Ranking(rank integer primary key,name text,score integer)';
$db->query($que);

/*データの挿入*/
$db->query("INSERT OR REPLACE INTO Ranking VALUES (1,'Taniguchi',80)");
$db->query("INSERT OR REPLACE INTO Ranking VALUES (2,'Furukawa',98)");
$db->query("INSERT OR REPLACE INTO Ranking VALUES (3,'Izumi',48)");

/*テーブルのデータを確認*/
echo "【作成されたテーブルのデータ】"."<br>";
$que ="SELECT * From Ranking";
$value = $db->query($que);
//連想配列として入ってるのでこれで出せる。
foreach($value as $temp)
{
    echo $temp['rank'].",";
    echo $temp['name'].",";
    echo $temp['score']."<br>";
}
?>