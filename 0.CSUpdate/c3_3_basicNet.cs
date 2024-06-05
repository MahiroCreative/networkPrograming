using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace co3_ExceptionAndAsync
{
    internal class c3_3_basicNet
    {
        /*C#のネットワーク通信*/
        //ここではC#の基本的なネットワーク通信について解説します。
        //処理の記述自体は単純なのですが、文法としては最終章レベルの知識が必須になります。

        /*ざっくりと通信の話*/
        //http通信(TCP/IP):HPを見るような通信。速度がいらない通信。大量にさばける。
        //ソケット通信(UDP/IP):格ゲーのようなリアルタイム通信。大量には捌けない。ゲーム毎に鯖が必要。
        //誤解が盛り盛りの解説ですが、ざっくり上記のように思ってください。
        //(ぶっちゃけどっちでもソケットは開きます。通信時に開く方式と開きっぱ方式です)
        //典型的なスマホゲーは全部httpだと思って良いです。UDPは授業では基本やりません。

        /*Mainメソッドを通信用にする*/
        //非同期処理が必ず必要なので、MainにasyncとTaskを入れる。
        //主にawait処理に必要
        //通常のMainで使う場合はasyncとタスクのメソッドを持つクラスを作成しよう
        static async Task Main(string[] args)
        {
            ///*基礎的なhttp通信*/
            ////みなさんがブラウザでHPを見るときに使っている通信方式です。
            ////通信先のURLがあれば通信できます。

            /*解説：Get通信とPost通信*/
            //基本的にはGetが情報を取得する時、Postが情報を書き直す時に使用します。
            //ですが、結局どちらでもできるのでかなり曖昧です。(これは元々が別々で発展した通信方式なので)
            //ただし、データを隠蔽したやり取りはPostのみになるので、
            //取得はget,アップロードはpostと使い分けるのが一般的です。

            /*Get通信を行う*/
            //URL設定
            const string url = @"http://mahiro.punyu.jp/StudyHttp/HelloHttp.php";
            ////通信用のインスタンスの作成(メモリ確保)
            HttpClient _client = new HttpClient();
            //Get通信(ソケット確保)
            var result = await _client.GetAsync(url);
            //通信結果をを文字列として取得
            string text = await result.Content.ReadAsStringAsync();
            //ソケット(とメモリ)の開放
            _client.Dispose();
            //出力
            Console.WriteLine(text);

            /*Post通信を行う*/
            //URL設定
            const string url2 = @"http://mahiro.punyu.jp/StudyHttp/HelloHttp.php";
            ////通信用のインスタンスの作成
            HttpClient _client2 = new HttpClient();
            //Post通信(本来なら第2引数でデータを渡す。今回は無いのでnull)
            var result2 = await _client2.PostAsync(url2, null);
            //通信結果を文字列として取得
            string text2 = await result2.Content.ReadAsStringAsync();
            //ソケット(とメモリ)の開放
            _client2.Dispose();
            //出力
            Console.WriteLine(text2);


            /*データの送信*/
            //データの書き換えはクライアント側のコードだけでは確認できません。
            //受け取ったデータを元に処理するプログラムがサーバ側に必要です。
            //イメージとしては
            //1.クライアントで送信データを作る
            //2.サーバのプログラムにわたす
            //3.サーバ側のプログラムが送信データを元に処理
            //4.結果を返す
            //という流れになり、サーバサイドプログラミンが必要になります。
            //以下の内容ははサーバサイド言語としてphpが既に書かれている先にアクセスしています。

            /*Getで送受信*/
            //http通信において、データの送信はURLの後に?記述して送信する。
            //URL ?  変数名  =  値 となる。(複数送る場合は&で区切る)
            //具体的には以下(?name=testName&score=77 がデータ送信部)
            const string url3 = @"http://mahiro.punyu.jp/StudyHttp/HelloGetHttp.php?name=testName&score=77";
            HttpClient _client3 = new HttpClient();////通信用のインスタンスの作成
            var result3 = await _client3.GetAsync(url3);//Get通信
            string text3 = await result3.Content.ReadAsStringAsync();//結果を文字列として取得
            _client3.Dispose();//ソケット開放
            Console.WriteLine(text3);//出力

            /*Postで送受信*/
            const string url4 = @"http://mahiro.punyu.jp/StudyHttp/HelloPostHttp.php";
            HttpClient _client4 = new HttpClient();
            //通信データの作成
            var data4 = new Dictionary<string, string>()
            {
                {"name","testName" },
                {"score","77" }
            };
            var content4 = new FormUrlEncodedContent(data4);//post用のcontentデータに変換
            //post通信
            var result4 = await _client4.PostAsync(url4, content4);
            string text4 = await result4.Content.ReadAsStringAsync();
            _client4.Dispose();
            Console.WriteLine(text4);//出力

            /*一般的な非同期通信の書き方*/
            //メモリやソケットの開放処理はdispose()ではなく、usingを使うのが一般的です。
            //こうすることによって、{}内の処理が終われば自動的に開放処理が行われます。
            //disposeだと何らかの理由でメソッドが飛ばされる可能性があるので、この形が好まれます。
            using (var tempClient = new HttpClient())
            {
                //今回は送信データが無いので、表記が変わるはずです。
                var tempResult = await tempClient.GetAsync(url4);
                string tempText = await tempResult.Content.ReadAsStringAsync();
                Console.WriteLine(tempText);
            }

            /*イテレータ1*/
            //メソッドが呼び出されるたびに返り値を順番に返しています。
            //ここで重要なのはメソッドからの返り値を配列のように扱っているという点です。
            //これにより複雑なコードを書いて配列をいちいち作ることなく、返り値を返せます。
            var ite = new IteratorSample();
            foreach(var str in ite.GetStrings())
            {
                Console.WriteLine(str);
            }

            /*イテレータ2*/
            //もう少し実用的なイテレータです。
            foreach(var temp in ite.GetPrime(11))
            {
                Console.WriteLine(temp);
            }



            /*本当のHttp通信*/
            //C#を使っているのでかなり簡単ですが、本来ならもっと色々な手順を間に挟む必要があります。
            //・クライアント側のネットワーク用のポートを取得
            //・ドメイン名を元にドメインサーバからアクセスしたいサーバのIPアドレスを取得
            //・取得したIPのサーバにアクセスし、URLを渡して取得したいコンテンツのアドレスを取得
            //・ソケットを開く
            //・通信開始～
            //とかなり面倒です。C++だと全部コーディングしてやります。
            //(Dxlibだとネットワークが貧弱なので、何一つ省略できません)
            //基本情報のネットワーク処理レベルの知識は必須になりますので、
            //C++でネットワーク処理を実装する際は頑張ってください。
        }
    }

    class IteratorSample
    {
        /*イテレータ1*/
        //イテレータはメソッドの一種です。
        //ですが通常のメソッドと違い、その時々の値を返してくれます。
        //ネットワーク通信では往々にしてそういう場合が多い(実行待ちなど)ので、軽く解説します。
        public IEnumerable<string> GetStrings()
        {
            //yield returnによって、返り値をスタックできる。
            yield return "あいうけお";
            yield return "かきくけこ";
            yield return "さしすせそ";
        }

        /*イテレータ2*/
        //もう少し実用的なイテレータです。
        //与えられた値に含まれる奇数を列挙するイテレータ。
        public IEnumerable<int> GetPrime(int num)
        {
            for(int i=0;i<num;i++)
            {
                if(i%2 !=0)
                {
                    //奇数の場合のみ返す。
                    yield return i;
                }

            }
        }
    }
}

