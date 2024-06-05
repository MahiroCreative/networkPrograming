using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace co3_ExceptionAndAsync
{
    /*非同期処理*/
    //非同期処理とは複数の処理を同時に実行する処理です。
    //通常、あるメソッドを実行中に別のメソッド実行すると、別のメソッドの処理が終了するまで処理が再開されません。
    //こういう処理を『同期処理』と言います。
    //非同期処理はあるメソッドを実行中に別のメソッドを実行しても、別のメソッドの終了を待たずに処理を続けて実行します。
    //これが非同期処理と呼ばれ、ロード画面でミニゲームで遊べたりするのがこれです。
    //最近当たり前のように使われていますが、昔はかなりハードルが高い技術でした。
    //(その難易度の高さがps3の参入障壁になっていたほどです)
    //ネットワークプログラミングが一般的になった今では、前提知識レベルになっており、必須知識になりました。

    /*スレッドとタスク*/
    //スレッド：処理の流れ、タスクの塊。cpuレベルで処理
    //タスク：スレッド内で実行される単一処理。プログラミングレベルで処理
    //あるタスクを現在のスレッドから別スレッドに投げて、現在のスレッドに他のタスクを実行させるのが非同期処理です。
    //(6コア12スレッドcpuとかありますよね？　スレッドとはアレです。12スレッドとは12個まで同時にタスクをこなせるということ)

    internal class c3_2_Async
    {
        /*非同期処理の取り消し*/
        static CancellationTokenSource _token;

        static void Main(string[] args)
        {
            /*非同期メソッド*/
            Console.WriteLine("/*非同期メソッド*/");
            TimerAsync(3);
            TimerAsync(2);
            Console.WriteLine("/*非同期メソッド*/の終了");

            /*非同期処理の実装*/
            Console.WriteLine("/*非同期処理の実装*/");
            TimerAsync2(3);
            TimerAsync2(2);
            Console.WriteLine("/*非同期処理の実装*/の終了");

            /*タスクの終了を待つ*/
            Console.WriteLine("/*タスクの終了を待つ*/");
            Task t = TimerAsync3(3);
            t.Wait();//タスク終了まで待機
            Console.WriteLine("/*タスクの終了を待つ*/の終了");

            /*複数のタスクの終了を待つ*/
            //複数のタスクの終了を待つ場合
            Console.WriteLine("/*複数のタスクの終了を待つ*/");
            Task[] tasks =
            {
                TimerAsync3(3),
                TimerAsync3(2),
                TimerAsync3(1),
            };
            Task.WaitAll(tasks);
            Console.WriteLine("/*複数のタスクの終了を待つ*/の終了");

            /*タスクからの値の取得*/
            Console.WriteLine("/*タスクからの値の取得*/");
            ValueTask<int>[] tasks2 =
            {
                AddAsync(1,2),
                AddAsync(3,4),
                AddAsync(5,6),
            };
            foreach (var temp in tasks2)
            {
                Console.WriteLine(temp.Result);
            }
            Console.WriteLine("/*タスクからの値の取得*/の終了");

            /*非同期処理の例外*/
            Console.WriteLine("/*非同期処理の例外*/");
            Task t2 = MethodAsync();
            t2.Wait();
            Console.WriteLine("/*非同期処理の例外*の終了");

            /*usingステートメント*/
            //C#ではメモリの明示的な開放が出来ませんでしたが、
            //実はIDisposeインタフェースを継承しているクラスなら開放できます。
            //その際に、メモリ確保している存在範囲を決めるのが、usingステートメントになります。
            //(CancellationTokenSourceはIDisposeを継承しています)
            using (CancellationTokenSource _temp = new CancellationTokenSource())
            {
                //このスコープ内の間は_tempのメモリを確保し、抜けると開放する。
            }
            //ネットワーク処理では非常に頻繁に使います。

            /*非同期処理の取り消し*/
            //あまりに重い処理の場合、ユーザが任意に取り消したい場合があります(ファイルのコピーなど)。
            //そういう場合のための取り消し処理の記述方法です。
            using (_token = new CancellationTokenSource())
            {
                Task tas1 = ExcuteCancelAsync(2);
                Task tas2 = CountAsync(5);
                try
                {
                    tas2.Wait();
                    Console.WriteLine("処理終了");
                }
                catch
                {
                    string m = t2.IsCanceled ? "キャンセル" : "エラー";
                    Console.WriteLine(m);
                    tas1.Wait();
                    Console.ReadLine();
                }
            }



            /*メインスレッドの終了処理*/
            Console.ReadLine();//何かで待たないとメインスレッドが終了してしまうので。
        }

        /*非同期メソッド*/
        //async修飾子をつけることで非同期メソッドになります。
        //非同期メソッドには名前の末尾にAsyncを付けます。
        //ただし、これはスレッドの使い方の導入をしているのみで、
        //非同期処理を実装していないので非同期処理になっていません。
        static public async void TimerAsync(int second)
        {
            Console.WriteLine($"{second}秒タイマー開始");
            Thread.Sleep(second * 1000);//スレッドの処理を引数値ぶん停止
            Console.WriteLine($"{second}秒タイマー終了");
        }

        /*非同期処理の実装*/
        //非同期処理の実装にはタスクを生成し、その中で処理を実行させるという流れが必要です。
        static public async void TimerAsync2(int second)
        {
            //await演算子はタスクが完了するまで呼び出し元に制御を戻す演算子です。
            //Taskで別スレッドに処理を渡し、awaitでタスクが終了するまでメインスレッド(呼び出し元)に戻す。
            //という形で非同期処理を実現します。
            await Task.Run(() => TimerAsync(second));

            /*解説*/
            //実のところこのC#のawaitは非常に強力であり、他に数多あった非同期プログラミングを駆逐した過去があります。
            //この処理の発明により非同期処理が一気に一般化されました。
        }

        /*タスクの終了を待つ*/
        //現状のままだと何らかの処理が返ってくるまで実行を待つ、というような処理が取れません。
        //また、戻り値を使って何かをする、ということもできません。
        //そこでタスク型を使用します。
        static public async Task TimerAsync3(int second)
        {
            //await演算子はタスクが完了するまで呼び出し元に制御を戻す演算子です。
            //Taskで別スレッドに処理を渡し、awaitでタスクが終了するまでメインスレッド(呼び出し元)に戻す。
            //という形で非同期処理を実現します。
            await Task.Run(() => TimerAsync(second));

            /*解説*/
            //実のところこのC#のawaitは非常に強力であり、他に数多あった非同期プログラミングを駆逐した過去があります。
            //この処理の発明により非同期処理が一気に一般化されました。
        }

        /*タスクからの値の取得*/
        //ValueTask<T>を用いることでタスクから値を取得できます。
        static public async ValueTask<int> AddAsync(int a, int b)
        {
            var ans = await Task.Run(() => a + b);
            Thread.Sleep(2000);//2秒待つ
            return ans;
        }

        /*非同期処理の例外*/
        //非同期処理をtry-catchで囲めば例外を取得できます。
        //下記は1秒ごとにtry,catch,finallyと表示されます。
        static async Task MethodAsync()
        {
            try
            {
                await Task.Run(() => Method("try"));
                throw new Exception();
            }
            catch
            {
                await Task.Run(() => Method("catch"));
            }
            finally
            {
                await Task.Run(() => Method("finally"));
            }
        }
        static void Method(string message)
        {
            Thread.Sleep(1000);
            Console.WriteLine(message);
        }

        /*非同期処理の取り消し*/
        //ここはかなり難しいので、理解より感じてください。
        //変に悩んでもドツボにはまるだけです。
        //必要時に思い出してコピペで良いですし、ChatGptでも良いでしょう。
        static async Task ExcuteCancelAsync(int second)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                _token.Cancel();
            });
        }
        static async Task CountAsync(int second)
        {
            await Task.Run(() =>
            {
                if (second < 1 || second > 10)
                {
                    throw new Exception();//例外をスロー
                }
                CancellationToken t = _token.Token;
                var q = Enumerable.Range(0, second);
                foreach (var x in q)
                {
                    t.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                    Console.WriteLine(x);
                }
            });
        }
    }
}
