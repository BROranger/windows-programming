#pragma once
#define MaxSize 100
typedef char ElemType;

typedef struct  SqStack
{
	char data[100];
	int top;
}SqStack;
void InitStack(SqStack * &s);
bool Push(SqStack* &s, ElemType e);
bool Pop(SqStack * &s, ElemType &e);
bool StackEmpty(SqStack*s);
bool GetTop(SqStack *s, ElemType &e);
void DestoryStack(SqStack* &s);
extern "C" _declspec(dllexport) void __stdcall trans(char *exp, char postexp[]);
extern "C" _declspec(dllexport) double __stdcall compvalue(char * postexp);