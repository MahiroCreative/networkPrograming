<pre>
<?php
/*Method*/
//文法としてはC言語とほぼ同じですが、
//用意された関数をうまく使うのがphpでのコツになります。
//またphp独特の仕様もいくつかありますが、特に必要ないものは触りません。

/*ユーザ定義関数*/
echo "/*ユーザ定義関数*/" . "<br>";
function Add($a1,$a2)
{
    $ans = $a1 + $a2;
    return $ans;
}
//実行
echo Add(1, 2) . "<br>";
//型指定
//右端のintが戻り値の型指定
function AddInt(int $a1,int $a2): int
{
    $ans = $a1 + $a2;
    return $ans;
}
echo AddInt(1, "2") . "<br>";
//初期値
function Add2($a1=2,$a2=2)
{
    $ans = $a1 + $a2;
    return $ans;
}
echo Add2() . "<br>";
//可変引数
function Add3($a1, ...$arr)
{
    print_r($a1 . PHP_EOL); //PHP_EOL:改行コード
    var_dump($arr);
}
Add3(1, 2, 3, 4, 5, 6);

/*用意された関数(よく使うのだけ)*/
//ほかは公式参照：たいていあります。
echo "/*用意された関数*/" . PHP_EOL;
//乱数の生成
$num = mt_rand(1,100);//1~100の乱数
echo $num  . PHP_EOL;
//四捨五入する
$num = 126.456;
echo round($num) . PHP_EOL;
echo round($num,2) . PHP_EOL;
echo round($num,-1) . PHP_EOL;

/*可変関数*/
//関数を変数のように扱い、動的に実行する関数を選べます。
//デリゲート的なものです。
echo "/*可変関数 */" . "<br>";
//関数A
function A()
{
    echo "A()" . PHP_EOL;
}
//関数B
function B()
{
    echo "B()" . PHP_EOL;
}
//動的に実行する関数を決める
$mg = "B";//変数に実行したい関数名を入れ
$mg();//その変数を関数として実行できる。
$mg = "A"; //関数名を入れる
$mg(); //Aの実行

/*無名関数*/
//ラムダ式っぽいもの
$ramda = function($who){
    echo $who ."さんこんにちは！" . PHP_EOL;
};
$ramda("大原");
?>
</pre>