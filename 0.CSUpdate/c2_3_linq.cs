using System;
using System.Linq;

namespace co2_DelegateAndEvent
{
    /*LINQ*/
    //LINQとは、簡単に言えばSQLをC#上でも扱えるようにした機能です。
    //SQLとはDB操作用の言語でWebプログラミングではマストな言語になります。
    //これらを言語上で直接扱える事は実装当時は革命的な機能であり、他言語にも真似されていきました。
    //現在は大体どの言語にもありますが、それだけに知ってて当然な機能になります。

    internal class c2_3_linq
    {
        static void Main(string[] args)
        {
            /*クエリ文*/
            //LINQはクエリ文(主にSQL)を用いて、DBから情報を出したり入れたりできる機能になります。
            //どのように情報を引き出すか、または入れるかはクエリ文と呼ばれるもので記述します。

            /*簡単なクエリ文の例*/
            Console.WriteLine("/*簡単なクエリ文の例*/");
            //データソース(DB)の作成(作成するデータベースは以下)
            //id,Name,Age
            //0,"one",10
            //1,"two",16
            //0,"three",16
            DataSource1[] members = { new DataSource1(0, "one", 10), new DataSource1(1, "two", 16), new DataSource1(0, "three", 16) };
            //クエリの作成(右辺がクエリ文)
            var q = from x in members//membersのDB参照xとする
                    where x.Age == 16//Age==16を満たす条件の
                    select x.Name;//Nameを全て取得
            foreach (var temp in q) { Console.WriteLine(temp); }//出力

            /*匿名型*/
            //データベース格納用にいちいちクラスを作成するのは面倒です。
            //そのため、データベース操作に使うクラスは以下のような匿名型で作成されることが多いです。
            //以下の書き方で自動でデータだけを持つクラスの配列が作成されています。
            var member2 = new[]
            {
                new {Name="Takashi", SexId=1, AddresId=22},
                new {Name="Watanabe", SexId=2, AddresId=2},
                new {Name="Kanzaki", SexId=2, AddresId=22},
                new {Name="Iida", SexId=1, AddresId=2},
                new {Name="Arata", SexId=1, AddresId=22},
            };

            /*データソースの結合*/
            Console.WriteLine("/*データソースの結合*/");
            //性別DB
            var sex = new[]
            {
                new{ Id=1,Text="男性"},
                new { Id=2,Text="女性"}
            };
            //住所DB
            var address = new[]
            {
                new {Id =2,Text ="栃木"},
                new {Id =22,Text ="埼玉"}
            };
            //クエリの作成
            var q2 = from m in member2//member2のDB参照xとする
                     from s in sex//sexのDB参照xとする
                     from a in address//addressのDB参照xとする
                     where m.SexId == s.Id && m.AddresId == a.Id//条件式
                     select m.Name + ":" + s.Text + ":" + a.Text;//抽出内容
            foreach(var temp in q2) Console.WriteLine(temp);

            /*ラムダ式によるLINQ*/
            Console.WriteLine("/*ラムダ式によるLINQ*/");
            //クエリをメソッドに置き換えて実行することができます。
            //これによりクエリだけで記述した場合よりも柔軟性に富んだ処理ができます。
            //(つまり、ラムダ式でできる処理は何でもできるようになります)
            //ここでは基本的な使い方のみを解説します。
            var q3 = members
                .Where(x => x.Age < 16)
                .Select(x => x.Name);
            foreach (var temp in q3) Console.WriteLine(temp);

            /*クエリの詳細*/
            //教科書p454~466
            //クエリの詳細は理屈というより単なる暗記です。
            //例文を列挙するのみになってしまうので、ここは教科書に任せます。
            //一度は読んでおきましょう。SQL文の入門として最適です。

        }

        /*簡単なクエリ文の例(ソースデータ用のクラス)*/
        class DataSource1
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

            public DataSource1(int v1, string v2, int v3)
            {
                this.Id = v1;
                this.Name = v2;
                this.Age = v3;
            }

        }
    }
}
