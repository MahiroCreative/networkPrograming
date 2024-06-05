using System;

namespace co1_ReStudy2
{
    internal class c1_1_abstAndInter
    {
        static void Main(string[] args)
        {
            /*抽象クラス*/
            Console.WriteLine("【抽象クラス：】");
            Slime ene1 = new Slime();
            Goblin ene2 = new Goblin();
            ene1.Show();
            ene1.Attack();
            ene2.Show();
            ene2.Attack();

            /*インターフェース*/
            Console.WriteLine("【インターフェース：】");
            IHp[] hps = { new CreePeer(), new Block() };
            foreach (IHp hp in hps)
            {
                hp.Damage(1);
                hp.Show();
                hp.Damage(2);
                hp.Show();
            }
        }
    }


    /*抽象クラス*/
    //抽象クラスとは実装の無いメンバーを含むクラスで、継承すること前提のクラスです。
    abstract class Enemy
    {
        //抽象プロパティなので、継承後に実装
        abstract public string Name { get; }
        abstract public int Level { get; }

        //抽象メソッドなので、継承後に実装　
        public abstract void Attack();

        //通常メソッドなので、この場で実装
        public void Show()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Level);
        }
    }
    class Slime : Enemy
    {
        public override string Name { get { return "スライム"; } }
        public override int Level { get { return 8; } }
        public override void Attack()
        {
            Console.WriteLine("28のダメージ！");
        }
    }
    class Goblin : Enemy
    {
        public override string Name { get { return "ゴブリン"; } }
        public override int Level { get { return 12; } }
        public override void Attack()
        {
            Console.WriteLine("38のダメージ！");
        }
    }


    /*インターフェース*/
    //C#では多重継承をしたいときに使用します。
    //・仕様
    //実装を持つメンバは持てない
    //インスタンスを生成できない
    //継承後にメンバは全て実装しなければならない
    //アクセス修飾子で修飾できない
    //多重継承可能
    //実装する際には、オーバーライドしない
    //インタフェースを定義する際には名前の先頭に『I』と付ける
    interface IHp
    {
        void Damage(int a);
        void Show();
    }
    class CreePeer : IHp
    {
        private int _hp = 10;
        private string _name = "CreePeer";

        public void Damage(int a) { _hp = _hp - a; }
        public void Show()
        {
            Console.WriteLine(_name);
            Console.WriteLine(_hp);
        }
    }
    class Block : IHp
    {
        private int _hp = 10;
        private string _name = "Block";

        public void Damage(int a) { _hp = _hp - a * 2; }
        public void Show()
        {
            Console.WriteLine(_name);
            Console.WriteLine(_hp);
        }
    }
}
