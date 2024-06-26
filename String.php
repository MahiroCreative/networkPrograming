<pre>
<?php
/*String*/
//ネットワーク通信とは、極論を言ってしまえば文字データのやり取りをする通信です。
//htmlだろうが、Jsonだろうが、全て文字として送られその後に意味を解釈されます。
//ですので文字のやり取りこそがphpの真骨頂であり、
//文字に関する機能が多言語と比べると驚くくらいに沢山存在しています。
//(そのかわり、純粋な計算に弱いです(ベクトルとか))
//それらの中で、最低限のものだけ解説します。

/*printf */
echo "/*printf */\n";
//phpにもあります。
//古いバージョンだとhtmlに直らないのであまり一般的ではありませんが、
//新しいphpだとhtmlに直してから動くので使っても良いでしょう。
//Cライクに書きたいならアリですが、単にデバッグ目的ならvar_dump()の方が適切です。
//(ここに無い機能もほぼC言語と同等です)
printf("こんにちは\n");
printf("こんにちは%s\n", "たなか");
printf("こんにちは%s,年齢:%d\n", "たなか", 12);
$name = "たなか";
$age = 12;
printf("こんにちは%s,年齢:%d\n", $name, $age);

/*sprintf */
echo "/*sprintf */\n";
//printfで表示される文字列をデータとしての文字列として使いたい場合もあります。
//そういうときに使います。
$str = sprintf("こんにちは%s,年齢%d\n", "さとう", 15);
printf($str);

/*文字を操作諸々 */
echo "/*文字を操作諸々 */\n";
//文字数を調べる
$len = mb_strlen("12345678");
printf("文字数を調べる:" . $len . "\n");
//文字を取り出す
$str = "吾輩は猫である。名前はまだない。";
echo mb_substr($str,4) . "\n";//４文字目以降
echo mb_substr($str,4,1) . "\n";//4文字目だけ
echo mb_substr($str,4,10) . "\n";//4文字目から10文字
echo mb_substr($str,-4) . "\n";////最後から4文字

/*文字列の検索*/
echo "/*文字列の検索 */\n";
//検索
$result = mb_substr_count("あいうえおかきくくくくくく","く");
echo $result . PHP_EOL;//検索文字数を表示
//置換
$result = str_replace("く","ク","あいうけおかきくくくく");//くをクへ。
echo $result . PHP_EOL;//検索文字数を表示

?>
</pre>