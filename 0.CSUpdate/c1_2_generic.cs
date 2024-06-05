using System;

namespace co1_ReStudy2
{
    internal class c1_2_generic
    {
        /*ジェネリック*/
        //C++ではテンプレートと呼ばれる機能です。
        static void Main(string[] args)
        {
            /*ジェネリックメソッド*/
            void swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
            //確認
            Console.WriteLine("[ジェネリックメソッド:]");
            float a = 1.2f, b = 1.7f;
            Console.WriteLine("a={0},b={1}", a, b);
            swap<float>(ref a, ref b);
            Console.WriteLine("a={0},b={1}", a, b);

            
            /*ジェネリッククラス*/
            Tuple<string, int> user1 = new Tuple<string, int>();
            Tuple<string, int> user2 = new Tuple<string, int>();
            user1.Item1 = "tanaka"; user1.Item2 = 78;
            user2.Item1 = "tanaka"; user2.Item2 = 88;
            //以下のような使われ方をする事が多い
            //ID,名前,得点 と考える
            Tuple<int, Tuple<string, int>> userData1 = new Tuple<int, Tuple<string, int>>();
            Tuple<int, Tuple<string, int>> userData2 = new Tuple<int, Tuple<string, int>>();
            userData1.Item1 = 1;
            userData1.Item2 = user1;
            userData2.Item1 = 2;
            userData2.Item2 = user2;
            //確認
            Console.WriteLine("ID:{0},name:{1},score:{2}", userData1.Item1, userData1.Item2.Item1, userData1.Item2.Item2);
            Console.WriteLine("ID:{0},name:{1},score:{2}", userData2.Item1, userData2.Item2.Item1, userData2.Item2.Item2);

            
            /*ジェネリックインターフェース*/
            Console.WriteLine("[ジェネリックインターフェース:]");
            Sample<string> sample = new Sample<string>();
            sample.Value = "gege";
            Console.WriteLine("{0}", sample.GetValue());

            
            /*ジェネリックの型制約*/
            //実装しているクラスの方参照


            /*標準で用意されたイテレータを使った制約*/
            //ほかにもあるので、マイクロソフトのリファレンスで確認してください。
            static T Min<T>(T v1, T v2) where T : IComparable
            {
                return v1.CompareTo(v2) < 0 ? v1 : v2;
            }
            Console.WriteLine(Min(4, 5));
            Console.WriteLine(Min(8.9f, 5.2f));


            /*DB風ジェネリックの作成*/
            //データベースの作成
            Dictionary<int, userData<string, int, int, int>> userList = new Dictionary<int, userData<string, int, int, int>>();
            //ユーザ登録
            userData<string, int, int, int> temp = new userData<string, int, int, int>();
            temp.Data1 = "one"; temp.Data2 = 1; temp.Data3 = 2; temp.Data4 = 3;
            userList.Add(1, temp);
            //ユーザ登録
            temp = new userData<string, int, int, int>();
            temp.Data1 = "two"; temp.Data2 = 2; temp.Data3 = 3; temp.Data4 = 4;
            userList.Add(2, temp);
            //ユーザ登録
            temp = new userData<string, int, int, int>();
            temp.Data1 = "three"; temp.Data2 = 3; temp.Data3 = 4; temp.Data4 = 5;
            userList.Add(3, temp);
            //確認
            foreach (var item in userList)
            {
                Console.WriteLine("{0},{1},{2},{3},{4}", item.Key, item.Value.Data1, item.Value.Data2, item.Value.Data3, item.Value.Data4);
            }
        }
    }

    /*ジェネリッククラス*/
    //クラス内で使われる型を実装時に任意で設定できる。
    //任意に設定する型を『クラス名<T>』で指定する。
    //また、以下のような単純に複数の値を入れるようなクラスは
    //Tupleと一般的に呼ばれます。
    class Tuple<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
    }

    /*ジェネリックインターフェース*/
    //ジェネリックで定義する事を矯正するインターフェースです。
    //ジェネリックインターフェースをジェネリッククラスで継承することもできます。
    class Sample<T> : IComponent<T>
    {
        public T Value { get; set; }
        public T GetValue() { return Value; }
    }
    interface IComponent<T>
    {
        T Value { get; set; }

        T GetValue() { return Value; }
    }

    /*ジェネリックの型制約*/
    //ジェネリックはあらゆる型を指定できます。
    //しかし、使用できる型を制限したい場合もあります。
    //その際に型制約を使います。
    //例えば、受け取った値の比較をしてその結果を返すジェネリック型を作りたいとします。
    //しかし、全ての型だと比較できないものもあります。
    //そういう場合は型制約を行うということです。
    //構文:
    //where 型パラメータ名 : 型制約

    //struct制約
    //値型は全てstructという話がありました。
    //つまり、値型のみの制約です(stringなどの参照型は弾かれます).
    class temp1<T> where T : struct { }

    //class制約
    //参照型は全てclassという話がありました。
    //つまり、参照型のみの制約です(intやboolは外れます)
    class temp2<T> where T : class { }

    //型名による制約
    //指定クラスを継承してるかどうかでの制約
    class temp3<T> where T : BaseClass { }

    //型名による制約
    //指定インターフェースを継承しているかどうかでの制約
    class temp4<T> where T : A, B, C, D<T> { }

    //new制約
    //引数無しコンストラクタを持つ型のみを指定
    //以下は、BaseClassかつ、new制約
    class temp5<T> where T : BaseClass, new() { }

    //生の型制約
    //型パラメータに、異なる型パラメータの制約を指定することを生の型制約と呼びます。
    //以下の例だと、T2型を継承している型かどうかの制約ということです。
    class temp6<T1, T2> where T1 : T2 { }

    //部品
    class BaseClass { /*演習用です。*/}
    interface A { }
    interface B { }
    interface C { }
    interface D<T> { }

    /*DB風ジェネリックの作成*/
    public class userData<T1, T2, T3, T4>
    {
        public T1 Data1 { get; set; }
        public T2 Data2 { get; set; }
        public T3 Data3 { get; set; }
        public T4 Data4 { get; set; }
    }
}
