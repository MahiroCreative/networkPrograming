<pre>
<?php
/*Array*/
//phpはDB操作に特化した言語ですので、
//複数のデータを扱う配列にも機能が沢山あります。
//ですが、ここでは最低限だけ扱います。

/*配列 */
echo "/*配列 */" . PHP_EOL;
//通常配列
$arr0 = [1,2,3];
$arr1 = array();
//配列への要素追加
$arr1[0] = "zero";
$arr1[1] = "one";
//連想配列
$arr2 = ["name"=> "takeshi", "age"=>12];
//連想配列の追加
$arr2["address"] = "fukuoka";
//出力
echo $arr0[0] . PHP_EOL;
echo $arr1[0] . PHP_EOL;
echo $arr2["name"] . PHP_EOL;
echo $arr2["address"] . PHP_EOL;
echo "要素数:" . count($arr2) . PHP_EOL;

/*文字列から配列の作成 */
echo "/*文字列から配列の作成 */" . PHP_EOL;
$data = "takashi,inoue,dtakeda";
$arr3 = explode(",",$data);
var_dump($arr3);
var_dump(implode($arr3));

/*配列をソートする*/
echo "/*配列をソートする*/" . PHP_EOL;
$arr4 = [2, 1, 3, 4, 5];
sort($arr4);//降順
var_dump($arr4);
rsort($arr4);//昇順
var_dump($arr4);
shuffle($arr4);//シャッフル
var_dump($arr4);
$arr5 = array_reverse($arr4);//逆順
var_dump($arr5);

/*各配列の要素に関数を適用する */
echo "/*各配列の要素に関数を適用する*/" . PHP_EOL;
function pow2($val)//2乗する関数
{
    return $val * $val;
}

$data = [1,2,3,4,5];
$arr9 = array_map("pow2",$data);
var_dump($arr9);

?>
</pre>