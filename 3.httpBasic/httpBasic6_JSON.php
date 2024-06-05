<pre>
<?php
/*PHPでのJSONの処理 */
//どの言語でも大して変わりません。
//参考サイト：https://syncer.jp/how-to-use-json

/*配列からJSOｎデータの作成 */
$arr = array(
    "ID" => 88,
    "value" => array(
        "name" => "Tanaka",
        "age" => 12,
    ),
);
var_dump($arr);//確認

/*配列からJSONへ */
$json = json_encode($arr);
var_dump($json);//確認

/*JSONからデータ型へ*/
$arr2 = json_decode($json);
var_dump($arr2);//確認

/*JSONから配列へ*/
//オプションで色んな形式指定が出来る
$arr2 = json_decode($json,true);
var_dump($arr2);//確認

?>
</pre>