using System.Data;

namespace Csharp241010
{
	internal class Program
	{
		/*
		[ Delegate : 대리자 ]
		- 특정 반환 형식과 매개변수를 가지는 method의 참조를 저장하는 형식
		- 대리자. 인스턴스를 통해 함수를 호출할 수 있다.
		- delegate는 method에 대한 참조이며 delegate에 메소드의 주소할당 후 delegate를 호출하면 이 delegate가 method를 호출해줌.
		- delegate는 method에 대한 참조이기 때문에 자신이 참조할 반환 형식과 매개변수를 명시해야 함

		[ 선언 ]
		한정자 delegate int 델리게이트이름(매개변수1, 매개변수2, ...)

		[ 요약 ]
		1. delegate 선언
		2. 선언한 delegate가 참조할 method를 선언
		3. delegate의 인스턴스를 만들고 delegate가 참조할 method를 매개변수로 넘긴다.
		4. delegate 호출

		- method를 동적으로 바인딩할 수 있어 유연성이 좋다.
		- 이벤트 처리나 call-back method에 자주 사용
		*/
		// 1. delegate 선언
		public delegate int MyDel(int a, int b);
		// 2. 참조할 method 선언
		static int Plus(int a, int b)
		{
			return a + b;
		}
		static int Minus(int a, int b)
		{
			return a - b;
		}
		static void Message(string msg) { Console.WriteLine(msg); }

		static void Main(string[] args)
		{
			// 3. delegate 인스턴스 생성
			MyDel callback;
			// 3. 참조할 method를 매개변수로 넘기기
			callback = new MyDel(Plus);
			// 4. 호출
			Console.WriteLine(callback(1, 2));

			// 간략화
			MyDel callback2 = Minus;
			//MyDel callback3 = Message;	// 반환타입과 매개변수가 달라 오류발생
			// 현재 MyDel의 반환형과 매개변수는 int형
			// 반환형만 int면 괜찮나? 매개변수와 반환형 둘 다 같아야 하는가? 
		}
	}
}