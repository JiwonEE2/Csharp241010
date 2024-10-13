using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp241010
{
	internal class DelegateChain
	{
		/*
		[ delegate chain ]
		- 여러 개의 메서드를 참조(연결)할 수 있다.
		*/
		delegate void Student(string s);
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

		/*
		[ delegate를 사용한 Event ]
		일련의 사건이 발생했다는 사실을 다른 객체에게 전달
		1. delegate 선언
		2. class 내에서 선언한 Delegate instance를 event 한정자 선언
		event handler 작성
		class의 instance를 생성하고 이 객체의 이벤트에 event handler를 등록
		event가 발생하면 event handler가 호출
		*/
		// 1. delegate 선언
		delegate void EventHandler(string str);
		class EventTest
		{
			public event EventHandler eve;
			public void Func(int num)
			{
				int temp = num % 10;
				if (temp != 0 && temp % 3 == 0)
				{
					// 3,6,9로 끝날 때마다 이벤트 발생
					eve($"{num}");
				}
			}
		}
		public delegate void TestDel(int a, int b);
		public static void SumNumber(int a, int b)
		{
			Console.WriteLine($"덧셈 : {a + b}");
		}
		public static void MulNumber(int a, int b)
		{
			Console.WriteLine($"곱셈 : {a * b}");
		}

		/////////////////////////////////////////////
		public static void MyHandler(string str)
		{
			Console.WriteLine(str);
		}

		static void Main()
		{
			Test t = new Test();
			t.Print01("홍길동");

			Student student = new Student(t.Print01);
			t.Print01("홍길서");

			student += t.Print02; // method 연결
			t.Print02("홍길남");

			student += t.Print03;

			TestDel testDel = SumNumber;
			testDel += MulNumber;
			testDel -= MulNumber; // method 제거

			// delegate에 참조된 메서드를 순차적으로 호출
			testDel.Invoke(10, 20);

			// event 객체 생성
			EventTest eventTest = new EventTest();
			//eventTest.eve += new EventHandler(MyHandler);

			// 간략화
			eventTest.eve += MyHandler;
			for (int i = 0; i < 30; i++)
			{
				eventTest.Func(i);
			}
		}
	}
}