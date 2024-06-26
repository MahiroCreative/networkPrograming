<pre>
<?php
/*Class*/
//phpにもクラスや継承があります。
//もちろん独特の仕様もありますが、ここでは一般形だけ扱います。
//なお、phpのクラスは後から増築されたものであり、結構歪です。

/*クラス*/
class SimpleClass
{
    //メンバ変数
    private $id = 0;
    public $name;
    public static $count =0;

    //コンストラクタ
    function __construct()
    {
        SimpleClass::$count++;
    }

    //メソッド
    public function SetID($value)
    {
        $this->id = $value;
    }
    public function CallValue()
    {
        var_dump($this->id);
        var_dump($this->name);
        var_dump(SimpleClass::$count);
    }

}

//実行
echo "/*クラス*/" . PHP_EOL;
$temp = new SimpleClass();
$temp = new SimpleClass();
$temp = new SimpleClass();
$temp->SetID(777);
$temp->name = "Ohara";
$temp->CallValue();

/*継承*/
class SimpleClass2 extends SimpleClass
{
    //メソッド
    public function SampleMethod()
    {
        echo "Heloo" . PHP_EOL;
    }
}
//実行
echo "/*継承*/" . PHP_EOL;
$temp = new SimpleClass2();
$temp = new SimpleClass2();
$temp = new SimpleClass2();
$temp->SetID(777);
$temp->name = "Ohara";
$temp->CallValue();
$temp->SampleMethod();

/*解説 */
//他にも
//・インターフェース
//・抽象クラス抽象メソッド
//・トレイト(PHP独特)
//などがありますが、長くなるのでここでは扱いません。

?>
</pre>