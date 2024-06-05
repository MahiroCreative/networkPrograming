using System;
using System.Collections;
//コレクションを使うのに必要
using System.Collections.Generic;
using System.Globalization;

namespace Qs4_Generic
{
    internal class c0_4_collection
    {
        static void Main(string[] args)
        {
            /*コレクション*/
            //C++にもありましたが、C#にもコレクションがあります。
            //簡単に言ってしまえば、一つの変数に複数の変数を入れられる機能です。
            //配列との最大の違いは、要素を後から追加したり減らしたり出来るということです。
            //(Cだと動的メモリ確保と呼ばれるような内容)
            //Listを例に説明します。
            //
            //【文法:】
            //コレクション名<型名> 変数名 = new コレクション名<型名>();
            //
            //コレクションもクラスの派生で作成されたもの(つまり参照型)なので、
            //コンストラクタを呼び出して、インスタンスを作成します。

            //宣言と初期化
            List<string> list = new List<string>();

            //要素の追加
            list.Add("1");
            //配列を用いた要素の追加
            string[] insert = { "2", "3", "4", "5" };
            list.AddRange(insert);//これでlistには"1","2","3","4","5"が入っている。

            //確認
            Console.WriteLine("[要素の追加:]");
            foreach (string item in list) { Console.WriteLine(item); }

            //要素の挿入
            //インデックスを指定することで、任意の位置に入れれます。
            //入れ替えでなく、挿入なので、それまでの要素は下方にズレていきます。
            list.Insert(2, "in");//list : {"1","2","in","3","4","5"}

            //確認
            Console.WriteLine("[要素の挿入:]");
            foreach (string item in list) { Console.WriteLine(item); }

            //要素の削除
            //要素の削除には
            //・要素内容を指定して削除
            //・インデックスで削除
            //の２種類あります。
            list.Remove("in");//list : {"1","2","3","4","5"}
            list.RemoveAt(2);//list : {"1","2","4","5"}

            //確認
            Console.WriteLine("[要素の削除:]");
            foreach (string item in list) { Console.WriteLine(item); }

            //要素数の確認
            Console.WriteLine("[現在の要素数:]{0}", list.Count);

            //要素への単純アクセス
            //要素を減らしたり増やしたりすることなくアクセスする方法です.
            //配列と同じです(つまりインデクサとして作られています)。
            list[0] = "0";//list : {"0","2","4","5"}
            //確認
            Console.WriteLine("[要素への単純アクセス:]");
            foreach (string item in list) { Console.WriteLine(item); }

            /*主要なコレクション*/
            //教科書が良くまとまってるので、
            //具体的な個別の使い方等は教科書を見てください。
            //かんたんC#:p240^250
            //【主なコレクション一覧】
            //・List:通常のリスト
            //・LinkedList:双方向リスト
            //・Dictionary:(key,value)形式のコレクション.辞書配列が作れる。
            //・SortedList:(key,value)形式だが、keyの順に並び変えて保存されるコレクション。
            //・SortedDictionary:SortedListと同じだが、内部構造が二分木構造
            //・Queue:Queueが作れる
            //・Stack:Stackが作れる。

            //Dictionaryの例:
            //クラスを型指定することも出来ます。
            Dictionary<string, GameObject> GameObjectList = new Dictionary<string, GameObject>();
            //インスタンスの格納
            GameObjectList.Add("tanaka", new GameObject("tanaka", 80));
            GameObjectList.Add("masaru", new GameObject("masaru", 64));
            //確認
            Console.WriteLine("[クラスを格納したコレクション:]");
            GameObject temp = GameObjectList["tanaka"];
            Console.WriteLine("{0},{1}", temp.Name, temp.Hp);
            temp = GameObjectList["masaru"];
            Console.WriteLine("{0},{1}", temp.Name, temp.Hp);

            //Queueの例(FIFO):
            //パズルゲームなどで使用
            Queue<GameObject> blcokList = new Queue<GameObject>();
            //インスタンスの格納
            blcokList.Enqueue(new GameObject("first", 1));
            blcokList.Enqueue(new GameObject("second", 2));
            blcokList.Enqueue(new GameObject("third", 3));
            //確認
            Console.WriteLine("[Queueの例:]");
            Console.WriteLine(blcokList.Dequeue().Name);
            Console.WriteLine(blcokList.Dequeue().Name);
            Console.WriteLine(blcokList.Dequeue().Name);

            //Stackの例(LIFO):
            //一つ前の状態に戻すときなどに使用
            Stack<GameObject> stack = new Stack<GameObject>();
            //インスタンスの格納
            stack.Push(new GameObject("first", 1));
            stack.Push(new GameObject("second", 2));
            stack.Push(new GameObject("third", 3));
            //確認
            Console.WriteLine("[Stackの例:]");
            Console.WriteLine(stack.Pop().Name);
            Console.WriteLine(stack.Pop().Name);
            Console.WriteLine(stack.Pop().Name);

            //ランキングの例:
            //<key,value>
            SortedDictionary<int, GameObject> ranking = new SortedDictionary<int, GameObject>();
            //インスタンスの格納
            ranking.Add(98, new GameObject("tanaka", 98));
            ranking.Add(108, new GameObject("tanaka", 108));
            ranking.Add(78, new GameObject("tanaka", 78));
            //並べ替え

            //確認
            Console.WriteLine("[ランキングの例:]");
            foreach (var a in ranking)
            {
                Console.WriteLine("名前:{0},得点:{1}", a.Value.Name, a.Key);
            }
        }
    }

    public class GameObject
    {
        public string Name { get; }
        public int Hp { get; }

        public GameObject()
        {
            Hp = 0;
            Name = "noName";
        }
        public GameObject(string name, int hp)
        {
            Name = name;
            Hp = hp;
        }

    }
}
