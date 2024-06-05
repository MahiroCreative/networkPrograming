<?php
/*データベースの削除 */
//SQLiteの削除操作は単なるファイルの削除
$file = "ranking.db";
//ファイルの削除
if(unlink($file)){
    echo $file.'の削除に成功しました。';
}
else{
    echo $file.'の削除に失敗しました。';
}
?>