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
// SQL文を作る（全レコード）
$sql = "SELECT * FROM member";
//上から三行だけ取得
$sql2 = "SELECT * FROM member LIMIT 3";
//30再以上かつ女性
$sql3 = "SELECT * FROM member WHERE age >= 30 AND sex = '女'";
//20代を年齢順に取り出す
$sql4 = "SELECT * FROM member WHERE age >= 20 AND age <30 ORDER BY age";
//上記の別の書き方
$sql5 = "SELECT * FROM member WHERE age BETWEEN 20 AND 29 ORDER BY age";
//任意の文字が含まれているかどうか
$sql6 = "SELECT * FROM member WHERE name LIKE '%木%'";
try {
    //接続
    $pdo = new PDO($dsn, $user, $password);
    // プリペアドステートメントのエミュレーションを無効にする
    $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
    // 例外がスローされる設定にする
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "データベース{$dbName}に接続しました。", "<br>";
    // プリペアドステートメントを作る(queryを飛ばさずに準備)
    $stm = $pdo->prepare($sql6);
    // SQL文を実行する(DBにqueryを飛ばさず)
    $stm->execute();
    // 結果の取得（連想配列で返す）
    $result = $stm->fetchAll(PDO::FETCH_ASSOC);
    // 値を取り出して行に表示する
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