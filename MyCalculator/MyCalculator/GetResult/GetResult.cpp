// GetResultDll.cpp : 定义 DLL 应用程序的导出函数。
//

#include "GetResult.h"
#include<malloc.h>
#include<stack>
#include<iostream>
#include<stdio.h>
#include<math.h>
using namespace std;

void InitStack(SqStack * &s)
{
	s = (SqStack *)malloc(sizeof(SqStack));
	s->top = -1;
}

bool Push(SqStack* &s, ElemType e)
{
	if (s->top == MaxSize - 1)
		return false;
	s->top++;
	s->data[s->top] = e;
	return true;
}
bool Pop(SqStack * &s, ElemType &e)
{
	if (s->top == -1)
		return false;
	e = s->data[s->top];
	s->top--;
	return true;
}
bool StackEmpty(SqStack*s)
{
	return(s->top == -1);
}
bool GetTop(SqStack *s, ElemType &e)
{
	if (s->top == -1)
		return false;
	e = s->data[s->top];
	return true;
}
void DestoryStack(SqStack* &s)
{
	free(s);
}
void __stdcall trans(char* exp, char postexp[])
{
	char e;
	char temp = *exp; //定义temp用于存储上一位的表达式值
	SqStack * Optr;  //定义运算符栈指针
	InitStack(Optr); //初始化运算符栈
	int i = 0;   //i作为postexp的下标
	if (*exp == '-') { //判断表达式的第一个是不“-”，如果是说明是单目运算符，需要补0
		postexp[i++] = '0';
		postexp[i++] = '#';
	}
	while (*exp != '\0')
	{
		switch (*exp)
		{
		case'(': //判断为左括号
			Push(Optr, '(');
			temp = *exp;
			exp++;
			break;
		case')'://判断为右括号
			Pop(Optr, e);
			while (e != '(') {
				postexp[i++] = e;
				Pop(Optr, e);
			}
			temp = *exp;
			exp++;
			break;
		case'+':
			while (!StackEmpty(Optr)) {  //栈不为空时循环
				GetTop(Optr, e);  //取栈顶元素
				if (e != '(')
				{
					postexp[i++] = e; //取出e放入postexp中
					Pop(Optr, e);  //出栈元素e
				}
				else
					break;
			}
			Push(Optr, *exp);  //将‘+’或者‘-’进栈
			temp = *exp;
			exp++;
			break;
		case'-':
			while (!StackEmpty(Optr)) {  //栈不为空时循环
				GetTop(Optr, e);  //取栈顶元素
				if (e != '(')
				{
					postexp[i++] = e; //取出e放入postexp中
					Pop(Optr, e);  //出栈元素e
				}
				else if (temp == '(') { //当“-”前一个为“（”是，说明减号是单目减，进行补0操作
					postexp[i++] = '0';
					postexp[i++] = '#';
					break;
				}
				else
					break;
			}
			Push(Optr, *exp);  //将‘+’或者‘-’进栈
			temp = *exp;
			exp++;
			break;
		case'*':
		case'/':
			while (!StackEmpty(Optr))
			{
				GetTop(Optr, e);
				if (e == '*' || e == '/')
				{
					postexp[i++] = e;
					Pop(Optr, e);
				}
				else
					break;
			}
			Push(Optr, *exp);//将‘*’或‘/’放入栈中
			temp = *exp;
			exp++;
			break;
		case'%':
		case'^':
		case'!':
			while (!StackEmpty(Optr))
			{
				GetTop(Optr, e);
				if (e == '*' || e == '/' || e == '+' || e == '-')
				{
					postexp[i++] = e;
					Pop(Optr, e);
				}
				else
					break;
			}
			Push(Optr, *exp);
			temp = *exp;
			exp++;
			break;
		default: //如果是数字的情况
			while (*exp >= '0'&&*exp <= '9'||*exp =='.')
			{
				postexp[i++] = *exp;
				temp = *exp;
				exp++;
			}
			postexp[i++] = '#'; //用#标识一个数字串结束
		}
		
	}
	while (!StackEmpty(Optr)) {
		Pop(Optr, e);
		postexp[i++] = e;  //将剩余运算栈中的运算符出栈
	}
	postexp[i] = '\0';  //以\0作为结束标识

	DestoryStack(Optr);

}
int fac(int x)   //递归函数  
{
	int f;
	if (x == 0 || x == 1)
		f = 1;
	else
		f = fac(x - 1)*x;
	return f;
}

double __stdcall compvalue(char * postexp) {
	long double a, b, c, d, e;
	stack<long double> stack;
	while (*postexp != '\0') {
		switch (*postexp) {
		case '+':
			a = stack.top();
			stack.pop();
			b = stack.top();
			stack.pop();
			c = a + b;
			stack.push(c);
			break;
		case'-':
			a = stack.top();
			stack.pop();
			b = stack.top();
			stack.pop();
			c = b - a;
			stack.push(c);
			break;
		case'*':
			a = stack.top();
			stack.pop();
			b = stack.top();
			stack.pop();
			c = a * b;
			stack.push(c);
			break;
		case'/':
			a = stack.top();
			stack.pop();
			b = stack.top();
			stack.pop();
			if (a != 0) {
				c = b / a;
				stack.push(c);
				break;
			}
			else {
				throw new exception("除零错误");
			}
			break;
		case'%':
			a = stack.top();
			stack.pop();
			c = a * 0.01;
			stack.push(c);
			break;
		case'^':
			a = stack.top();
			stack.pop();
			b = stack.top();
			stack.pop();
			c = pow(b, a);
			stack.push(c);
			break;
		case'!':
			a = stack.top();
			stack.pop();
			c = fac(a);
			stack.push(c);
			break;
		default:
			d = 0;
			while (*postexp >= '0'&& *postexp <= '9'||*postexp == '.') {
				if (*postexp >= '0'&& *postexp <= '9') {
					d = 10 * d + *postexp - '0';
					postexp++;
				}
				else if(*postexp =='.') {
					postexp++;
					double step = 0.1;
					while (*postexp!='#') {
						d += step * ((*postexp) - '0');
						step /= 10;
						postexp++;
					}
				}
			}
			stack.push(d);
			break;
		}
		postexp++;
	}
	e = stack.top();
	return e;
}
