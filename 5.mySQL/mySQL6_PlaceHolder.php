<?php
/*プレースホルダー*/
//SQL文に後から任意の値を組み込めるのが
//プレースホルダー

/*データベース接続設定*/
//ユーザ作成
$user = 'testuser';
$password = 'pw4testuser';
//利用するデータベース
$dbName = 'testdb';
//MySQLサーバ
$host = 'localhost:3306';
//MySQLのDSN文字列
$dsn = "mysql:host={$host};dbname={$dbName};charset=utf8";

/*MySQLデータベースに接続する*/
try {
    
    /*初期接続*/
    $pdo = new PDO($dsn, $user, $password);
    // プリペアドステートメントのエミュレーションを無効にする
    $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
    // 例外がスローされる設定にする
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "データベース{$dbName}に接続しました。", "<br>";

    /*プレースホルダーの例*/
    //SQLの作成
    $sql = "DELETE FROM member WHERE sex = :sex AND age >= :age";
    //プリアドステートメント作成
    $stm = $pdo->prepare($sql);
    //プレースホルダーの追加
    $stm->bindValue(':sex','女',PDO::PARAM_STR);
    $stm->bindValue(':age',40,PDO::PARAM_INT);
    //SQL文実行
    $stm->execute();

    /*結果確認*/
    $sql = "SELECT * FROM member";
    $stm = $pdo->prepare($sql);
    $stm->execute();
    $result = $stm->fetchAll(PDO::FETCH_ASSOC);
    foreach ($result as $row){
      // １行ずつテーブルに入れる
      echo $row['id'];
      echo ",". $row['name'];
      echo ",". $row['age'];
      echo ",". $row['sex'];
      echo "</br>";
    }
  } catch (Exception $e) {
    echo "エラーがありました.<br>";
    echo $e->getMessage();
    exit();
  }
  ?>