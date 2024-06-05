<pre>
<?php
/*if文*/
echo "/*if文*/" . "<br>";
//C言語とほぼ同じです。
if (false) {
    //C言語と同じ
} else if (false) {
    //C言語と同じ
} elseif (false) {
    //繋げても書ける
} else {
    echo "必ずここに来る" . "<br>";
}

/*論理演算子*/
//C言語とほぼ同じだが、違うものがある。
echo "/*論理演算子*/" . "<br>";
$temp = 1;
//厳密な比較(===)
if ($temp === "1") {
    //==だと曖昧な比較をされる
    //具体的には比較するものが数字と文字で も同じ物とされてしまう。
} elseif ($temp == "1") {
    echo "こっちが実行される2" . "<br>";
}
//厳密な比較(!==)
if ($temp !== "1") {
    echo "こっちが実行される1" . "<br>";
} elseif ($temp != "1") {
}
//xor(エクスクルシブオア)意外と使う
//右辺と左辺のどちらかだけtureの時に実行
if (true xor true) {
    //実行されない
} elseif (false xor false) {
    //実行されない
} elseif (false xor true) {
    //実行される
    echo "こっちが実行される3" . "<br>";
}

/*swtich文 */
//C言語と同じ
switch (3) {
    case 1:
        break;
    case 2:
        break;
    default:
        break;
}

/*match文 */
echo "/*match文 */" . "<br>";
//phpで特徴的な条件分岐としてmatch文があります。
//matchに渡した値によって返す値が変わります。
$temp2 = match (4) {
    1 => "one",
    2 => "two",
    3 => "three",
    default => "その他"
};
echo $temp2 . "<br>";
?>
</pre>