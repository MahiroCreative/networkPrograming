using System;

/*コーディング規約*/
//https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/coding-style/coding-conventions
//上記リンクに色々書かれているが、必須で守るべきは以下
//【全体】
//・変数(配列): キャメルケース(例:temp string なら tempString)
//・関数/クラス/構造体: パスカルケース(例:show string なら ShowString)
//・インターフェース: I + パスカルケース(例:show string なら IShowString)
//【メンバー】
//・public: パスカルケース(例:temp string なら TempString)
//・private: _ + キャメルケース(例:temp string なら _tempString)
//・internal: _ + キャメルケース(例:temp string なら _tempString)
//・public static: s + _ +  パスカルケース(例:temp string なら s_TempString)
//・private static: s + _ +  キャメルケース(例:temp string なら s_tempString)

namespace co0_ReStudy1
{
    internal class c0_1_basic
    {
        /*値型と参照型*/
        //C#には値型と参照型が存在する。
        //値型はメモリに値をそのまま入れる型であり、参照型はメモリにアドレスを入れる型である。
        //つまり、値型はC/C++のポインタ型とほぼ同じものだと思って良い。
        //値型もC/C++とは違い、int型のような基本型でも構造体で作られている。
        //そのため、.ToString()のような便利なメンバーが付いているが、C/C++と比べて重くなる。

        /*値型*/
        //メモリに直接値を保存している型。
        bool sBool = false;//論理値
        char sChar = 'a';//文字
        int sInt;//整数
        long sLong;//整数
        float sFloat;//実数
        double sDouble;//実数
        decimal sDecimal;//10進数
        A a;//構造体

        /*参照型*/
        //メモリにはアドレスを入れ、値そのものは別の場所に確保している型。
        string sString;//文字列
        object sObject;//オブジェクト型(全ての型を収納可能)
        Vector2 sVector;//クラス型
        IVector IsVector;//インターフェース型
        Signal sSignal;//デリゲート型

        /*エントリーポイント*/
        //プログラムは必ずこのメソッドからスタートする。
        static void Main(string[] args)
        {
            /*インスタンスの作成*/
            //クラスはそのまま使うのではなく、
            //インスタンスを作成(動的メモリ確保)し、そちらを使う。
            Vector2 v1 = new Vector2();
            Vector2 v2 = new Vector2(1, 2);
            Vector2 v3 = new Vector2();
            A temp = new A();

            /*構造体に値を入れる*/
            temp.temp1 = "firstInput";
            temp.temp2 = "secondInput";
            temp.temp3 = "thirdInput";


            /*インスタンスを用いずにクラスを利用*/
            Vector2.s_Temp = temp.temp1;

            /*メソッド*/
            Console.WriteLine("v1,x:{0},y:{1},lenght:{2}",v1.GetX(),v1.GetY(),v1.Length);
            Console.WriteLine("v2,x:{0},y:{1},lenght:{2}", v2.GetX(), v2.GetY(), v2.Length);
            v3.Set(3,4);
            Console.WriteLine("v3,x:{0},y:{1},lenght:{2}", v3.GetX(), v3.GetY(), v3.Length);

            /*スタティックメソッド*/
            Vector2.WriteCount();
            v3 = Vector2.Add(v2,v3);
            Console.WriteLine("v3,x:{0},y:{1},lenght:{2}", v3.GetX(), v3.GetY(), v3.Length);

        }
    }

    /*構造体*/
    //構造体はメモリに直接実態を確保
    struct A
    {
        public string temp1;
        public string temp2;
        public string temp3;
    }

    /*クラス*/
    //クラスは基本的には以下で構成されてる
    //・フィールド(メンバ変数)
    //・コンストラクタ
    //・デストラクタ
    //・メソッド(メンバ関数)
    //publicで外部アクセス可能になり、privateで外部アクセスが不可になる。
    class Vector2
    {
        /*フィールド*/
        private float _x;
        float _y;//何も付けないとprivate
        public float Length;
        public static string s_Temp = "";
        private static int s_count = 0;

        /*コンストラクタ*/
        //インスタンス作成時に必ず実行されるメソッド
        //引数によりどれが実行されるか変わる
        public Vector2()
        {
            _x = 0;
            _y = 0;
            Length = 0;
            s_count++;
        }
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
            Length = MathF.Sqrt(_x * _x + _y * _y);
            s_count++;
        }

        /*デストラクタ*/
        //インスタンス削除時に実行されるメソッド
        //ただしC#だといつ実行されるか分からない
        ~Vector2()
        {
            s_count--;
        }

        /*メソッド*/
        public void Set(float x, float y)
        {
            _x = x;
            _y = y;
            Length = MathF.Sqrt(_x * _x + _y * _y);
        }
        public float GetX()
        {
            return _x;
        }
        public float GetY()
        {
            return _y;
        }

        /*スタティックメソッド*/
        public static Vector2 Add(Vector2 v1, Vector2 v2)
        {
            float x = v1.GetX() + v2.GetX();
            float y = v1.GetY() + v2.GetY();
            return new Vector2(x, y);
        }
        public static void WriteCount()
        {
            Console.WriteLine("Count:{0}", s_count);
        }

    }



    /*インターフェース*/
    interface IVector { }

    /*デリゲート*/
    delegate void Signal();

}
