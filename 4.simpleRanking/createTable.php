<?php
/*データベースの作成と接続*/
//(既にある場合は接続のみ)
$db = new PDO('sqlite:ranking.db');

/*Post受信*/
$Table = $_POST['table'];
$Colum1 = $_POST['colum1'];
$Colum2 = $_POST['colum2'];
$Colum3 = $_POST['colum3'];

/*ランキング用のテーブルを削除(無ければ無視)*/
$que = "DROP TABLE IF EXISTS {$Table}";
$db->query($que);

/*ランキング用のテーブルの作成(既にあれば無視)*/
$que = "CREATE TABLE IF NOT EXISTS";
$que .= " {$Table}({$Colum1} integer primary key,{$Colum2} text,{$Colum3} integer)";
$db->query($que);

/*テーブルのテストデータを初期化*/
$db->query("INSERT OR REPLACE INTO {$Table} VALUES (1,'FirstUser',0)");
echo "INSERT OR REPLACE INTO {$Table} VALUES (1,'FirstUser',0)"."<br>";
?>