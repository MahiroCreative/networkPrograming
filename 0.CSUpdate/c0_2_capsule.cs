using System;

namespace co0_ReStudy1
{
    internal class c0_2_capsule
    {
        static void Main(string[] args)
        {
            /*インスタンスの作成*/
            GameObject obj1 = new GameObject("Slime",88,new Vector2(1,2));
            GameObject obj2 = new GameObject("Rucky", 72, new Vector2(3, 4));
            GameObject obj3 = new GameObject();

            /*生成時の状態の確認*/
            obj1.Show();
            obj2.Show();
            obj3.Show();

            /*オーバーロードの確認*/
            obj3.Pos = obj1.Pos + obj2.Pos;
            obj2.Pos = obj2.Pos - obj1.Pos;

            /*最終確認*/
            obj1.Show();
            obj2.Show();
            obj3.Show();
        }
    }

    /*プロパティによるカプセル化*/
    //C++だとカプセル化はアクセス修飾子とメソッドの組み合わせ(getter,setter)で行いますが、
    //C#ではプロパティという機能を用いて行うのが一般的です。
    //プロパティにも通常のプロパティと自動実装プロパティがあり、
    //状況に合わせて使い分けます。
    //(大抵の場合は自動実装プロパティで済みます)
    public class GameObject
    {
        //自動実装プロパティ
        public string Name { get; set; }//読み込み書き込み可
        public string Age { get; }//読み込み可,書き込み不可

        //通常のプロパティ
        //読み込み時、もしくは書き込み時に何か処理させたい場合
        private int _score;
        public int Score
        {
            get { return _score / 8; }//８分の一されたスコアが返ってくる。
            set { _score = value * 8; }//8倍された値がスコアに入る。
        }
        public Vector2 Pos { get; set; }

        //コンストラクタ
        public GameObject()
        {
            Name = string.Empty;
            Score = 0;
            Pos = new Vector2();
        }
        public GameObject(string str,int sco,Vector2 pos)
        {
            Name = str;
            Score = sco;
            Pos = pos;
        }

        /*メソッド*/
        public void Show()
        {
            Console.WriteLine("Name:{0}, Score:{1}, X:{2}, Y{3}, Lenght{4}", Name , Score, Pos.X, Pos.Y, Pos.Length);
        }
    }

    /*演算子オーバーロード*/
    public class Vector2
    {
        /*フィールド*/
        private float _x;
        private float _y;
        
        /*プロパティ*/
        public float X { get { return _x; }}
        public float Y { get { return _y;}}
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
            Console.WriteLine("X:{0},Y{1}",X,Y);
        }
        public void Set(float x, float y)
        {
            _x = x;
            _y = y;
        }
        public Vector2 Normalized(Vector2 v)
        {
            return new Vector2(v.X / v.Length, v.Y /v.Length);
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
