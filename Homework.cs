/*
[ 과제 1 ]
k개의 공통된 요소 찾기

< 입력 >
int[] arr1 = { 1,5,5,10 };
int[] arr2 = { 3,4,5,5,10 };
int[] arr3 = { 5,5,10,20 };

< 결과 >
5,10
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp241010
{
	internal class Homework
	{
		static void ArrayComparer()
		{
			int[] arr1 = { 1, 5, 5, 10 };
			int[] arr2 = { 3, 4, 5, 5, 10 };
			int[] arr3 = { 5, 5, 10, 20 };

			// 범위기반 for문으로 바꾸면 더 좋을 것 같긴해
			// 확인 했던 숫자는 넘어가도록 하면 좋을 것 같긴해
			// (직전 숫자가 아닌)
			List<int> checkedNum = new List<int>();
			List<int> res = new List<int>();
			// 첫번째 배열의 for문에는 checkedNum 확인 및 추가
			for (int i = 0; i < arr1.Length; i++)
			{
				// checkedNum에 arr1[i]가 없는 경우에만 실행
				if (!checkedNum.Contains(arr1[i]))
				{
					// 중간 배열의 for문에는 첫번째 배열과 같은지 확인하고 break;
					for (int j = 0; j < arr2.Length; j++)
					{
						if (arr1[i] == arr2[j])
						{
							// 마지막 배열의 for문에는 첫번째 배열과 같은 지 확인하고 res에 추가 후 break;
							for (int k = 0; k < arr3.Length; k++)
							{
								if (arr1[i] == arr3[k])
								{
									res.Add(arr1[i]);
									break;
								}
							}
							break;
						}
					}
					checkedNum.Add(arr1[i]);
				}
			}
			for (int i = 0; i < res.Count; i++)
			{
				Console.Write(res[i]);
				Console.Write(", ");
			}
		}
		static void Main()
		{
			ArrayComparer();
		}
	}
}