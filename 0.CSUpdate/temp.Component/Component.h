#pragma once
/*
�R���\�[���ɕ�����₷���\�����邽�߂̃\�[�X�R�[�h�ł��B
*/
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define SCREE_NLENGTH 20

//�R���\�[���ɏo�͂��邽�߂̃o�b�t�@���쐬����N���X
//�o�b�t�@:�~���Ă����ꏊ
//�R���\�[���ɕ\������̈�����߁Aupdate���ɐV������ʂ�����Ă���B
class ScreenBuffer
{
public:
	//�y�����o�ϐ��z
	//SCREE_NLENGTH�ŉ�ʂ̃T�C�Y�����߂�
	union {
		//��ʕ\���p�̃o�b�t�@
		char buffer[SCREE_NLENGTH * (SCREE_NLENGTH + 1) + 1];
		char buffer2[SCREE_NLENGTH][SCREE_NLENGTH + 1];
	};

	//�y�����o�֐��z
	//�R���X�g���N�^
	ScreenBuffer()
	{
		Clear();
	}
	//Clear()���\�b�h�̍쐬
	void Clear()
	{
		//Buffer���X�y�[�X�ŃN���A
		for (int i = 0; i < SCREE_NLENGTH * (SCREE_NLENGTH + 1); i++)
		{
			buffer[i] = ' ';
		}
		//�s�̏I���ɉ��s�����
		for (int i = 0; i < SCREE_NLENGTH; i++)
			buffer2[i][SCREE_NLENGTH] = '\n';

		//�S�Ă̏I����NULL����
		buffer[SCREE_NLENGTH * (SCREE_NLENGTH + 1)] = '\0';
	}
};

//��L�ō쐬�����o�b�t�@�ɓ��͂��鏈���̃N���X
class InputData
{
	//�ꕶ�����̃o�b�t�@
	static char Buffer;
public:
	//�o�b�t�@��Update
	static void Update()
	{
		//kbhit�֐��Ƃ́A�����L�[�������ꂽ�ꍇ0�ȊO�̒l��Ԃ��A�����L�[��������Ă��Ȃ��ꍇ��0��Ԃ��֐�
		//(2005�N�ɁA_kbhit�֐��ɕύX����܂���(VC++��p))
		if (_kbhit()) {
			//�������G�R�[�����ɃR���\�[������ 1 ������ǂݎ��B
			//�G�R�[�F���͂��ꂽ���e���R���\�[���ɕ\�����邱��
			Buffer = _getch();
		}
	}
	//����Key�̃`�F�b�N
	static bool KeyCheck(char key)
	{
		if (Buffer == key)
			return true;
		return false;
	}
};

//�yextern�z
//�����\�[�X�R�[�h���܂����ŕϐ��⃁�\�b�h���g�p����Ƃ��Ɏ��Ɏg���܂��B
//�S�t�@�C�����̂ǂꂩ�ɒ�`����Ă���錾�������s����`�͍s��Ȃ��錾���@�ł��B
//�܂�A�����t�@�C���Ɍׂ��ăO���[�o���ϐ������L����ۂɁA�g���B
extern ScreenBuffer g_ScreenBuffer;