<?php
/*データベース接続設定*/
//ユーザ作成
$user = "testuser";
$password = "pw4testuser";
//利用するデータベース
$dbName = "testdb";
//MySQLサーバ
$host = "localhost:3306";
//MySQLのDSN文字列の作成
$dsn = "mysql:host={$host};dbname={$dbName};charset=utf8";

/*データベース接続*/
try{
    //接続
    $pdo = new PDO($dsn, $user, $password);
    //プリペアドステートメントのエミュレーションを無効
    $pdo->setAttribute(PDO::ATTR_AUTOCOMMIT, PDO::ERRMODE_EXCEPTION);
    echo "データベース{$dbName}に接続しました。";
    //接続を解除する
    $pdo = NULL;
}
catch(Exception $e){
    echo "エラーです。</br>";
    echo $e->getMessage();
}
?>