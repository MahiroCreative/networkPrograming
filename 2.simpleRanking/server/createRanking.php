<?php
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

/*テーブルのテストデータを初期化*/
$db->query("INSERT OR REPLACE INTO Ranking VALUES (1,'Taniguchi',80)");
echo "INSERT OR REPLACE INTO Ranking VALUES (1,'Taniguchi',80)"."<br>";
$db->query("INSERT OR REPLACE INTO Ranking VALUES (2,'Furukawa',98)");
echo "INSERT OR REPLACE INTO Ranking VALUES (2,'Furukawa',98)"."<br>";
$db->query("INSERT OR REPLACE INTO Ranking VALUES (3,'Izumi',48)");
echo "INSERT OR REPLACE INTO Ranking VALUES (3,'Izumi',48)"."<br>";
$db->query("INSERT OR REPLACE INTO Ranking VALUES (4,'Sakuka',50)");
echo "INSERT OR REPLACE INTO Ranking VALUES (4,'Sakuka',50)"."<br>";
$db->query("INSERT OR REPLACE INTO Ranking VALUES (5,'Naito',78)");
echo "INSERT OR REPLACE INTO Ranking VALUES (5,'Naito',78)"."<br>";
$db->query("INSERT OR REPLACE INTO Ranking VALUES (6,'Shitamichi',58)");
echo "INSERT OR REPLACE INTO Ranking VALUES (6,'Shitamichi',58)"."<br>";
$db->query("INSERT OR REPLACE INTO Ranking VALUES (7,'Ito',28)");
echo "INSERT OR REPLACE INTO Ranking VALUES (7,'Ito',28)"."<br>";
$db->query("INSERT OR REPLACE INTO Ranking VALUES (8,'Yasu',28)");
echo "INSERT OR REPLACE INTO Ranking VALUES (8,'Yasu',28)"."<br>";

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