<?php
/*XSS対策をして受け取る*/
//phpは文字の表示を基本的にhtml形式で行います。
//そのため、受け取った文字データがhtml形式で書かれていると
//htmlとして実行されてしまいます。
//場合によってはhtmlに埋め込んだphpまで実行されます。
//そのような不正行為を防ぐため、XSS対策を行い、
//html形式を破壊する必要があります。
//ゲームの場合はユーザが直接入力するような際に使用します。
//(基本はクライアント側で入れれないようにしてください)

/*データの受け取り */
$first = $_POST["first"];
$second = $_POST["second"];
/*XSS対策 */
$first = htmlspecialchars(string:$first,flags:ENT_QUOTES,encoding:'UTF-8');
$second = htmlspecialchars(string:$second,flags:ENT_QUOTES,encoding:'UTF-8');
//表示
echo $first . "</br>";
echo $second . "</br>";
?>