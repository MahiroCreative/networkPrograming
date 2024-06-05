using System;

namespace co2_DelegateAndEvent
{
    internal class c2_1_delegate
    {
        /*デリゲート*/
        //デリゲートは変数にメソッドを格納する機能です。
        //つまり、C++でいうところの関数ポインタです。
        //処理を動的に変更したい場合に使用します。

        static void Main(string[] args)
        {
            /*基本のデリゲート*/
            Console.WriteLine("/*基本のデリゲート*/");
            //デリゲート型変数xを作成し、関数Redへの参照を渡している。
            Signal x = new Signal(Red);
            //格納された関数の実行
            x.Invoke();

            /*型推論によるデリゲート*/
            //newとInvoke()を省略できる。
            Console.WriteLine("/*型推論によるデリゲート*/");
            Signal y = Red;
            y();

            /*匿名メソッドによる生成*/
            //名前のないメソッドという扱いで、その場で簡単に作るメソッド。
            Console.WriteLine("/*匿名メソッドによる生成*/");
            Signal z = delegate { Console.WriteLine("緑"); };
            Message m = delegate (string t) { Console.WriteLine(t); };
            Calculate c = delegate (int a, int b) { return a + b; };
            z();
            m("Hey");
            Console.WriteLine(c(1, 2));

            /*ラムダ式の基礎1*/
            //ラムダ式は匿名メソッドを発展させたものです。
            //匿名メソッドで生成した物を、ラムダ式でも生成してみると以下になります。
            Console.WriteLine("/*ラムダ式の基礎1*/");
            Signal s = () => Console.WriteLine("ラムダ");//引数が無いことは()で示す。
            Message l = t => Console.WriteLine(t);//tが引数(型は宣言から推論)
            Calculate g = (a, b) => { return a + b; };//(a,b)が引数
            s();
            m("HeyHey");
            Console.WriteLine(g(2, 4));

            /*ラムダ式の基礎2*/
            //上記だけでは分かりにくいので、
            //デリゲートからラムダ式化してく変遷を見ていきます。
            Console.WriteLine("/*ラムダ式の基礎2*/");
            Calculate cr1 = delegate (int a, int b) { return a + b; };//デリゲート
            Calculate cr2 = (int a, int b) => { return a + b; };//ラムダ式第一段階
            Calculate cr3 = (a, b) => a + b;//ラムダ式最終段階（引数に型が無くなり、returnなども無くなった）
            //どんな型でも計算できるのでなく、宣言の型だと想定して計算される。
            Console.WriteLine(cr1(1, 2));
            Console.WriteLine(cr2(3, 4));
            Console.WriteLine(cr3(5, 6));

            /*デリゲートの登録と削除*/
            //デリゲート型には複数のデリゲートを登録できます。
            Console.WriteLine("/*デリゲートの登録と削除*/");
            Signal te = Red;
            te += Blue;
            te += Yellow;
            //実行
            te();
            //登録削除して実行
            te -= Blue;
            te();

            /*汎用的なデリゲート*/
            //.Netに標準で用意されているデリゲート。大きくActionとFuncに部類されます。
            //いちいちデリゲートを宣言せずにデリゲートを使用できます。
            //Action:戻り値を持たないメソッドを持てる
            //Func:戻り地を持つメソッドを持てる
            Console.WriteLine("/*汎用的なデリゲート*/");
            Action s1 = Red;//引数なし
            Action<string> s2 = Green;//引数有り(stringが引数)
            Func<int, int, int> s3  = Add;//<引数,引数,戻り値>
            s1();
            s2("s2実行");
            Console.WriteLine(s3(1,2));

            /*ラムダ式を用いた汎用デリゲート*/
            Console.WriteLine("/*ラムダ式を用いた汎用デリゲート*/");
            Action a1 = () => Console.WriteLine("a1実行");
            Action<string> a2 = m => Console.WriteLine(m);
            Func<int,int,int> f1 = (a,b) => a + b;
            a1();
            a2("a2実行");
            Console.WriteLine(f1(1,2));
        }

        /*デリゲートの作成(宣言)*/
        //delegate 戻り値の型　デリゲート名(引数リスト)
        delegate void Signal();
        delegate void Message(string text);
        delegate int Calculate(int va1, int va2);

        /*デリゲートに格納する関数の作成*/
        //staticでないとエラーが出る。
        static void Red()
        {
            Console.WriteLine("赤");
        }
        static void Blue()
        {
            Console.WriteLine("青");
        }
        static void Yellow()
        {
            Console.WriteLine("黄色");
        }
        static void Green(string m)
        {
            Console.WriteLine(m);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
