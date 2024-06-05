#include "DxLib.h"
#include <iostream>
#include<string>
using namespace std;

/*作成した関数*/
//Http通信でGet命令を出し、その結果を得る。
string HttpGet(const char* Domain, const char* URI);

/*学生への注意点*/
//【ネットワーク通信を行う上で必要な知識】
// ・TCP/IP
// ・HTTP通信
// ・SQL
// ・PHP
// 上記４つを、自分で調べて『一体なにか？』くらいは分かっておきましょう。
// 特にHTTP通信に関してはしっかり調べる必要があります。
// 
//【DxLibの方で必要な知識】
//Dxlibの通信関係は正直言って貧弱です。
//winsockという太古のAPIを改造して使っており、かなり原始的です。
//そのため、インターネットを経由した通信を行うにはリファレンスに載っている関数では足りません。
//非公開関数(一応使えるが未完成のもの)を使う必要があります。
//『dxライブラリ隠し関数』で検索して『そういうものがある』と知りましょう。
// 
//【今回のコードに関して】
//実現可能だと探っているだけのやっつけ検証コードです。
//学生発表ならこれでも良いですが、実用レベルの実装だと問題だらけです。
//学習用のコードだと思い、不特定多数に公開するような物を作る際には流用するのは止めましょう。


/*Main*/
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	//windowモード
	ChangeWindowMode(TRUE);
	if (DxLib_Init() == -1)	// ＤＸライブラリ初期化処理
	{
		return -1;
	}

	/*Http通信でGet命令を指定のアドレスに行っている*/
	//ランキングの更新
	string  ans1 = HttpGet("mahiro.punyu.jp", "/simpleRanking/updateRanking.php?name=testName&score=78");
	//画面クリア
	ClearDrawScreen();
	//ランキングの取得
	string  ans2 = HttpGet("mahiro.punyu.jp", "/simpleRanking/getRanking.php");


	WaitKey();// キー入力待ち
	DxLib_End();// ＤＸライブラリ使用の終了処理
	return 0;// ソフトの終了 
}


/// <summary>
/// Http通信でのGet命令を送る事ができる命令
/// </summary>
/// <param name="Domain">Domain名を入力</param>
/// <param name="URI">URIを入力</param>
/// <returns>string型で実行結果を得る(予定でまだやってません)</returns>
string HttpGet(const char* Domain, const char* URI)
{
	/*適当な変数*/
	string ans;
	int i = 12;//文字の表示位置用

	/*文字関係*/
	unsigned int Cr = GetColor(255, 255, 255);	 // 白色の値を取得
	SetFontSize(12);                             //サイズ変更
	SetFontThickness(4);                         //太さを変更

	/*ネットワーク用の変数*/
	const int DATA_SIZE = 2560;//8bitのでかい数(char最大要素数は268435455)
	char StrBuf[DATA_SIZE] = "";    // データバッファ
	IPDATA Ip;        // 接続用ＩＰアドレスデータ
	int NetHandle;        // ネットワークハンドル
	int DataLength;        // 受信データ量保存用変数

	/*Http通信を作成するための変数*/
	char HttpCmd[128] = "";

	//DxLibの余計な機能を切る。
	SetUseDXNetWorkProtocol(false);

	//DNSからドメイン名でIPアドレス取得
	int test = GetHostIPbyName(Domain, &Ip);
	DrawFormatString(0, 0, Cr, "GetDomain:%d", test);//0なら正常

	//取得したIPアドレスの確認
	DrawFormatString(0, i, Cr, "IpAdress;%d,%d,%d,%d", Ip.d1, Ip.d2, Ip.d3, Ip.d4);

	// 通信を確立
	NetHandle = ConnectNetWork(Ip, 80);
	DrawFormatString(0, i * 2, Cr, "NetHandle:%d", NetHandle);

	// 確立が成功した場合のみ中の処理をする
	if (NetHandle != -1)
	{
		//Http命令の作成
		sprintf_s(HttpCmd, "GET %s HTTP/1.1\nHost: %s\n\n", URI, Domain);
		DrawFormatString(0, i*3, Cr, "HttpCmd:\n%s", HttpCmd);


		// データ送信(http命令を送る)
		NetWorkSend(NetHandle, HttpCmd, strlen(HttpCmd));

		// データがくるのを待つ
		while (!ProcessMessage())
		{
			// 取得していない受信データ量を得る
			DataLength = GetNetWorkDataLength(NetHandle);

			// 取得してない受信データ量が-1じゃない場合はループを抜ける
			if (DataLength != -1)
			{
				break;
			}
		}

		// データ受信
		NetWorkRecv(NetHandle, StrBuf, DATA_SIZE);    // データをバッファに取得

		// 受信したデータを描画
		DrawString(0, i * 8, StrBuf, GetColor(255, 255, 255));

		// キー入力待ち
		WaitKey();

		// 接続を断つ
		CloseNetWork(NetHandle);
	}

	return ans;
}