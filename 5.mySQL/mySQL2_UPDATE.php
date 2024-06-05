<?php
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

    /*値の更新*/
    // SQL文を作る（名前の変更）
    $sql = "UPDATE member SET name = '新倉立男' WHERE id = 5";
    //プリペアドステートメント
    $stm = $pdo->prepare($sql);
    //SQL実行
    $stm->execute();

    /*全員の年齢を+1*/
    // SQL文を作る（名前の変更）
    $sql = "UPDATE member SET age = age + 1";
    //プリペアドステートメント
    $stm = $pdo->prepare($sql);
    //SQL実行
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