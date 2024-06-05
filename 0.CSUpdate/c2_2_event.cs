using System;

namespace co2_DelegateAndEvent
{
    /*イベント*/
    //イベントとはプログラミング実行中のオブジェクトの状態を通知する仕組みです。
    //例：ボタンが押された。ダウンロードが完了した。など。
    //このイベントに応じて実行される処理をイベントハンドラーと言います。
    //このイベントは内部的にはデリゲートで実装されていて、
    //イベントに応じてデリゲートを実行するという形で処理されています。

    internal class c2_2_event
    {
        static void Main(string[] args)
        {
            /*イベントハンドラーの作成*/
            Console.WriteLine("/*イベントハンドラーの作成*/");
            EventSample x = new EventSample();//インスタンス作成
            x.ValueChanged += new EventHandler<ValueChangeEventArgs>(x_ValueChanged);//イベントの追加
            x.Value = 18;//イベント実行

            /*色々なイベントハンドラーの作成*/
            //イベントはデリゲートで作られているので、ラムダ式などでも実装できます。
            Console.WriteLine("/*色々なイベントハンドラーの作成*/");
            EventSample y = new EventSample();//インスタンス作成
            y.ValueChanged += new EventHandler<ValueChangeEventArgs>(y_ValueChanged);//通常
            y.ValueChanged += y_ValueChanged;//型推論
            y.ValueChanged += delegate (object s1, ValueChangeEventArgs e1) { Console.WriteLine(e1.NewValue); };//匿名メソッド
            y.ValueChanged += (s1, e2) => Console.WriteLine(e2.NewValue);//ラムダ式
            y.Value = 19;//イベント実行

            /*シンプルなイベントハンドラー*/
            //ここまでのイベントハンドラーは厳密さ重視だったので、やや複雑です。
            //一般的なイベントハンドラーはもう少しシンプルに運用されます。以下はその例です。
            //エンターキーを押したら、入力される仕組みです。
            Console.WriteLine("/*シンプルなイベントハンドラー*/");
            Simple simple = new Simple();
            simple.ValueChanged += (s, e) => Console.WriteLine("!?");//イベント発生時に「！？」と出力
            Console.ReadLine();//エンター待ち
            simple.Value = 1;

            /*解説*/
            //このイベントという処理は通常の形で書くとコードが非常に長くなることが分かります。
            //そのため、一般的にラムダ式を用いて書くことが殆です。
            //また、イベント時に実行するという概念からも分かるように、
            //ネットワーク通信で頻繁に使われる処理になります。
            //(通信が正しく来たら、〇〇する。という形になるので)
            //そのため、ネットワーク通信を学ぶためには前提知識として
            //デリゲート　→　ラムダ式　→　イベント　の順に理解しておく必要があります。
            //また、普通のゲーム制作でもUIイベントは全てこの処理で行われています。
        }




        /*イベントを持つクラスの作成*/
        //これからプロパティの値が変化した際にそれを通知するイベントを持つクラスを作成する。
        //プロパティValueが変化した際に、ValueChangeイベントが発生するようにする。

        /*イベント引数*/
        //イベントハンドラー型が持てる引数はEventArgs型かその派生型のみである。
        //そのため、イベントで使用する引数クラスを事前に作成する。
        public class ValueChangeEventArgs : EventArgs
        {
            public int NewValue { get; set; }
        }
        //クラスの作成
        public class EventSample
        {
            /*イベントハンドラー型の宣言*/
            //イベントを宣言する時の方として使用するのが、イベントハンドラー型です。
            //デリゲート型として宣言します。EventHandler,EventHandler<T>で宣言します。
            //TはEventArgs型かその派生型しか定義できない。
            //[文法]アクセス修飾子 event EventHandler or EventHandler<T> イベント名;
            public event EventHandler<ValueChangeEventArgs> ValueChanged;

            /*イベント通知メソッドの作成*/
            //イベントの通知があった際に実行されるメソッドです。
            //メソッド名にOnと付けるのが通例です。
            //また、protected　かつ　virtual　にするのが一般的です。
            //これは派生クラスで通知処理を行ったり、その派生先でオーバーライドするのが普通だからです。
            protected virtual void OnValueChange(int newValue)
            {
                //エラー処理(何らかの理由で値が変化していない場合)
                if (ValueChanged == null) return;

                //新しい値を渡すための引数の作成
                ValueChangeEventArgs args = new ValueChangeEventArgs();
                args.NewValue = newValue;//値を引数に
                ValueChanged(this, args);//引数の受け渡し(だれからのイベントか知るために、thisも渡す)
            }

            /*イベントを用いたプロパティValueの作成*/
            private int _value;
            public int Value
            {
                get { return _value; }
                set
                {
                    if (_value == value) return;//同じ値なら何もしない
                    _value = value;
                    OnValueChange(value);//イベントの通知
                }
            }
        }

        /*イベントハンドラーの作成*/
        //イベントハンドラーのメソッド名は『インスタンス名_イベントハンドラー名』とします。
        //また、戻り値の方や引数の型は格納するイベントハンドラーの型と一致する必要があります。
        //今回は値が変更されたらその値を表示するイベントハンドラーを作成しています。
        //ValeChangeEventArgsから通知を受け取る　→　実行　の流れです。
        static void x_ValueChanged(object sender, ValueChangeEventArgs e)
        {
            Console.WriteLine(e.NewValue);
        }
        static void y_ValueChanged(object sender, ValueChangeEventArgs e)
        {
            Console.WriteLine(e.NewValue);
        }

        /*シンプルなイベントハンドラーを持つクラス*/
        //シンプルにイベントハンドラーから通知のみが来るクラスを作成する。
        class Simple
        {
            public event EventHandler ValueChanged;
            private int _value = 0;
            public int Value
            {
                get { return _value; }
                set
                {
                    _value = value;
                    if (ValueChanged == null) return;
                    ValueChanged(this, EventArgs.Empty);//引数がない場合はEventArgs.Emptyを渡す。
                }
            }
        }
    }
}
