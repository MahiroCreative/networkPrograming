#pragma once
/*
コンソールに分かりやすく表示するためのソースコードです。
*/
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define SCREE_NLENGTH 20

//コンソールに出力するためのバッファを作成するクラス
//バッファ:蓄えておく場所
//コンソールに表示する領域を決め、update毎に新しい画面を作っている。
class ScreenBuffer
{
public:
	//【メンバ変数】
	//SCREE_NLENGTHで画面のサイズを決める
	union {
		//画面表示用のバッファ
		char buffer[SCREE_NLENGTH * (SCREE_NLENGTH + 1) + 1];
		char buffer2[SCREE_NLENGTH][SCREE_NLENGTH + 1];
	};

	//【メンバ関数】
	//コンストラクタ
	ScreenBuffer()
	{
		Clear();
	}
	//Clear()メソッドの作成
	void Clear()
	{
		//Bufferをスペースでクリア
		for (int i = 0; i < SCREE_NLENGTH * (SCREE_NLENGTH + 1); i++)
		{
			buffer[i] = ' ';
		}
		//行の終わりに改行入れる
		for (int i = 0; i < SCREE_NLENGTH; i++)
			buffer2[i][SCREE_NLENGTH] = '\n';

		//全ての終わりにNULL文字
		buffer[SCREE_NLENGTH * (SCREE_NLENGTH + 1)] = '\0';
	}
};

//上記で作成したバッファに入力する処理のクラス
class InputData
{
	//一文字分のバッファ
	static char Buffer;
public:
	//バッファのUpdate
	static void Update()
	{
		//kbhit関数とは、何かキーが押された場合0以外の値を返し、何もキーが押されていない場合は0を返す関数
		//(2005年に、_kbhit関数に変更されました(VC++専用))
		if (_kbhit()) {
			//文字をエコーせずにコンソールから 1 文字を読み取る。
			//エコー：入力された内容をコンソールに表示すること
			Buffer = _getch();
		}
	}
	//入力Keyのチェック
	static bool KeyCheck(char key)
	{
		if (Buffer == key)
			return true;
		return false;
	}
};

//【extern】
//複数ソースコードをまたいで変数やメソッドを使用するときに時に使います。
//全ファイル中のどれかに定義されている宣言だけを行い定義は行わない宣言方法です。
//つまり、複数ファイルに跨ってグローバル変数を共有する際に、使う。
extern ScreenBuffer g_ScreenBuffer;