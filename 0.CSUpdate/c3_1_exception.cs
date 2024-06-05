using System;
using System.Threading.Tasks;


namespace co3_ExceptionAndAsync
{
    /*例外処理*/
    //例外処理とは例外が発生した際に行う処理です。
    //オフラインのアプリであればただ終了すれば良い場合も多いですが、通信しているような物はそうはいきません。
    //成功するまで繰り返すなり、ユーザに終了を促したりするような処理が必要になります。
    //なので、通信を行う上では必須ですし、最近の大規模ゲームでも必須になります。

    internal class c3_1_exception
    {
        static void Main(string[] args)
        {
            /*try-catch-finally*/
            Console.WriteLine("/*try-catch-finally*/");
            //try句：例外が発生する可能性のある処理
            //catch句(省略可)：例外が発生した際に行う処理
            //finally句(省略可):tryまたはcatch実行後に必ず実行される処理
            try
            {
                var z = 0;
                Console.WriteLine(1 / z);//0で割ってるのでエラー(Consoleメソッドのエラーとして扱われる)
            }
            catch (Exception ex)//どのようなエラーが発生したかがexに入る
            {
                Console.WriteLine(ex.Message);//エラーメッセージの表示
            }
            finally
            {
                Console.WriteLine("終了");
            }


            /*様々な例外*/
            //教科書p482~484にプログラムが受け取れる様々な例外が乗っています。
            //エラーコードを読む際に大変役立つので一度は読んでおくと良いでしょう。
            //元々は個別のエラーに対処できるように分けられた型でしたが、
            //ネットワーク処理で起こるエラーは分類が大変難しく、単なるエラーとして取得するのが一般的です。
            //なので近年ではこのよう個別の分類の取得は殆ど行われていません。


            /*throw*/
            Console.WriteLine("/*throw*/");
            //try-cathは実行時のプログラミング上の例外でした。
            //throwはプログラマが指定する例外です。

            //0~2の範囲外の数字を入力すると例外が発生する関数
            static void Order(int i)
            {
                if (i < 0 || i > 2)
                {
                    throw new Exception();//0~2なら例外が発生
                                          //簡単のためにExpection()で実行していますが、
                                          //本来ならArgumentException()あたりが妥当です。(p484参照)
                }
                Console.WriteLine("正常な入力です");
            }
            //実行
            Console.Write("Input: ");
            var temp = Console.ReadLine();
            Order(int.Parse(temp));


            /*try-catchとthrow*/
            Console.WriteLine("/*try-catchとthrow*/");
            //ここで重要なのは、try-catchは例外が取得されても実行し続け、
            //throwは例外が取得されると止まってしまう点です。
            //例外を取得しても実行を続けたい場合は、try-catchで囲む必要があります。
            try
            {
                ReadData();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);//エラーの表示
                Console.WriteLine(ex.InnerException.Message);//エラー内さらに内部階層のエラー
            }
            Console.WriteLine("処理終了");
            //例外処理のあるメソッド
            static void ReadData()
            {
                try
                {
                    AccessDatabase();
                }
                catch (Exception ex) 
                {
                    throw new Exception("アクセス失敗", ex);
                }
            }
            //例外時に実行されるメソッド
            static void AccessDatabase()
            {
                throw new Exception("データベースが壊れています");
            }

        }
    }
}
