using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace co0_ReStudy1
{
    internal class c0_3_inheritance
    {
        static void Main(string[] args)
        {
            /*継承*/
            Slime slime = new Slime("スラ坊",new Vector2(1,2),10,8);
            Draky dracky = new Draky("ドラッキ",new Vector2(3,4),12,9);

            /*オーバーライドの確認*/
            slime.Show();
            slime.TypeName();
            dracky.Show();
            dracky.TypeName();

            /*ポリモフィズム*/
            GameObject[] gameObject = new GameObject[2];
            gameObject[0] = slime;
            gameObject[1] = dracky;

            /*ポリモフィズムの確認*/
            gameObject[0].Show();
            gameObject[0].TypeName();
            gameObject[1].Show();
            gameObject[1].TypeName();

            /*動作確認1*/
            slime.Pos = new Vector2(4,5);
            dracky.Pos = new Vector2(6, 6);

            /*動作確認2*/
            gameObject[0].Show();
            gameObject[1].Show();
        }
    }

    /*継承*/
    //継承は親クラスの機能を引き継いだ子クラスを作成できる。
    //メモリ上の実態としては、親クラスを作ってから子クラスを作成している。
    public class Slime : GameObject
    {
        //プロパティ
        public int HP { get; set; }
        public int AT { get; }

        //コンストラクタ
        public Slime() { }
        public Slime(string str,Vector2 pos,int hp, int at) : base(str,pos)
        {
            HP = hp;
            AT = at;
        }

        //オーバーライド
        public override void Show()
        {
            Console.WriteLine("Name:{0}, HP:{1}, AT{2}, X:{3}, Y:{4}, Lenght:{5}", Name, HP, AT, Pos.X, Pos.Y, Pos.Length);
        }
        public override void TypeName()
        {
            Console.WriteLine("Slime");
        }
    }
    public class Draky : GameObject
    {
        //プロパティ
        public int HP { get; set; }
        public int AT { get; }

        //コンストラクタ
        public Draky() { }
        public Draky(string str, Vector2 pos, int hp, int at) : base(str, pos)
        {
            HP = hp;
            AT = at;
        }

        //オーバーライド
        public override void Show()
        {
            Console.WriteLine("Name:{0}, HP:{1}, AT{2}, X:{3}, Y:{4}, Lenght:{5}", Name, HP, AT, Pos.X, Pos.Y, Pos.Length);
        }
        public override void TypeName()
        {
            Console.WriteLine("Draky");
        }
    }


    /*流用*/
    public class GameObject
    {
        //プロパティ
        public string Name { get; set; }
        public Vector2 Pos { get; set; }

        //コンストラクタ
        public GameObject()
        {
            Name = string.Empty;
            Pos = new Vector2();
        }
        public GameObject(string str, Vector2 pos)
        {
            Name = str;
            Pos = pos;
        }

        /*メソッド*/
        public virtual void Show()
        {
            Console.WriteLine("Name:{0}, X:{1}, Y{2}, Lenght{3}", Name, Pos.X, Pos.Y, Pos.Length);
        }
        public virtual void TypeName()
        {
            Console.WriteLine("GameObject");
        }

    }
    public class Vector2
    {
        /*フィールド*/
        private float _x;
        private float _y;

        /*プロパティ*/
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public float Length
        {
            get { return MathF.Sqrt(_x * _x + _y * _y); }
        }

        /*コンストラクタ*/
        public Vector2()
        {
            _x = 0;
            _y = 0;
        }
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        /*メソッド*/
        public void Show()
        {
            Console.WriteLine("X:{0},Y{1}", X, Y);
        }
        public void Set(float x, float y)
        {
            _x = x;
            _y = y;
        }
        public Vector2 Normalized(Vector2 v)
        {
            return new Vector2(v.X / v.Length, v.Y / v.Length);
        }

        /*演算子オーバーロード*/
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }
        //実数倍
        public static Vector2 operator *(Vector2 left, float right)
        {
            return new Vector2(left.X * right, left.Y * right);
        }
        //実数割り
        public static Vector2 operator /(Vector2 left, float right)
        {
            return new Vector2(left.X / right, left.Y / right);
        }
    }
}
