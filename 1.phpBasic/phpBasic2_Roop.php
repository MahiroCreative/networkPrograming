<pre>
<?php
/*Roop文*/
//殆どC言語と同じですが、違う部分もあります。

/*while文 */
//C言語と同じです。
echo "/*while文 */" . "<br>";
$count = 0;
while ($count < 3) {
    echo "while" . $count . "<br>";
    $count++;
}

/*do~while文 */
//C言語と同じです。
echo "/*do~while文 */" . "<br>";
$count = 0;
do {
    echo "do~while" . $count . "<br>";
    $count++;
} while ($count < 3);

/*for文 */
//C言語と同じです。
echo "/*for文 */" . "<br>";
for ($cout = 0; $cout < 3; $cout++) {
    echo "for" . $count . "<br>";
}

/*foreach文 */
//C＃と動きは同じですが、書き方が違います。
//C#ではforeah(a in b)となり、bの配列からaに入って処理されます。
//phpではforeach(a as b)となり、aの配列からbに入って処理されます。
//英語で考えるとin~は~の中の、as~は~として、となるのでこうなります。
echo "/*foreach文 */" . "<br>";
$arr = [1, 2, 3];
foreach ($arr as $temp) {
    echo "foreach" . $temp . "<br>";
}
?>
</pre>