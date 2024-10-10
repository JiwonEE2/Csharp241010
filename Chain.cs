using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp241010
{
	delegate void Student(string s);
	/*
	[ delegate chain ]
	- 여러 개의 메서드를 참조(연결)할 수 있다.
	*/
	class Test
	{
		public void Print01(string str)
		{
			Console.WriteLine($"학생{str}이/가 등교");
		}
		public void Print02(string str)
		{
			Console.WriteLine($"학생{str}이/가 점심먹고");
		}
		public void Print03(string str)
		{
			Console.WriteLine($"학생{str}이/가 하교");
		}
	}
	internal class Chain
	{
		public delegate void TestDel(int a, int b);
		public static void SumNumber(int a, int b)
		{
			Console.WriteLine($"덧셈 : {a + b}");
		}
		public static void MulNumber(int a, int b)
		{
			Console.WriteLine($"곱셈 : {a * b}");
		}
		static void Main()
		{
			Test t = new Test();
			t.Print01("홍길동");

			Student student = new Student(t.Print01);
			t.Print01("홍길서");

			student += t.Print02;	// 연결
			t.Print02("홍길남");

			student += t.Print03;

			TestDel testDel = SumNumber;
			testDel += MulNumber;

			// delegate에 참조된 메서드를 순차적으로 호출
			testDel.Invoke(10, 20);
		}		
	}
}