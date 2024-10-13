using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp241010
{
	/*
	[ 버블 정렬 ]
	- 전체 배열을 순회하면서 항목이 다른 항목보다 큰 경우 두 항목을 교환
	- 가장 간단한 정렬 알고리즘
	- 오름차순이나 내림차순
	- 불필요한 비교 발생 가능

	[ 분할 정복 ]
	- 큰 문제를 작은 하위 문제로 분할하여 그 하위 문제들의 해답을 조합하여 전체 문제의 해답을 얻는 것

	1. 분할 : 원래 문제를 작은 하위 문제들로 분할
	- 보통 재귀적인 방법으로 이루어지고 원래 문제를 해결하기 위해 여러 하위 문제로 분할됨

	2. 정복 : 각 하위 문제를 재귀적으로 해결
	- 하위 문제의 크기가 충분히 작아서 직접 해결할 수 있는 경우에 해당

	3. 결합 : 각 하위 문제의 해답을 결합하여 원래 문제의 해답을 얻음.
	- 이 단계에서는 분할된 하위 문제들의 해답을 조합하여 전체 문제의 해답을 생성

	2^8
	2^4, 2^4
	2^2 * 2^2

	[ 퀵 정렬 ]
	- 퀵 정렬의 핵심은 주어진 배열을 pivot을 기준으로 작은 값은 왼쪽, 큰 값은 오른쪽으로 나누어 정렬
	- 주어진 배열을 특정 pivot값을 기준으로 두 개의 서브 배열로 분할하고, 각 서브 배열을 재귀적으로 정렬하여 최종적으로 정렬된 배열을 얻는 알고리즘
	*/
	internal class Sort
	{
		static int[] BubbleSort(int[] arr)
		{
			// 배열의 모든 요소 탐색
			for (int i = 0; i < arr.Length; i++)
			{
				// 각 반복에서 가장 큰 요소가 맨 뒤로 이동하므로 끝 인덱스 감소하여 반복 횟수 줄임
				for (int j = 0; j < arr.Length - i - 1; j++)
				{
					// 현재 요소와 다음 요소를 비교하여 정렬이 필요한 경우 교환
					if (arr[j] > arr[j + 1])
					{
						Swap(arr, j, j + 1);  // 두 요소의 위치 교환
					}
				}
			}
			return arr; // 정렬된 배열 반환
		}
		// 테스트용 Swap
		static void Swap(int[] arr, int idx1, int idx2)
		{
			int temp = arr[idx1];
			arr[idx1] = arr[idx2];
			arr[idx2] = temp;
		}

		static void QuickSort(int[] items)
		{
			QuickSortHelper(items, 0, items.Length - 1);
		}
		static void QuickSortHelper(int[] items, int left, int right)
		{
			while (left < right)
			{
				// 배열을 분할하고 분할 인덱스 받기
				int partitionIndex = Partition(items, left, right);

				// 분할된 배열의 왼쪽 부분에 대해 재귀적으로...
				if (partitionIndex - left < right - partitionIndex)
				{
					QuickSortHelper(items, left, partitionIndex - 1);
					left = partitionIndex + 1;
				}
				else
				{
					QuickSortHelper(items, partitionIndex + 1, right);
					right = partitionIndex - 1;
				}
			}
		}
		// 배열을 분할하고 분할 인덱스를 반환
		static int Partition(int[] arr, in int left, int right)
		{
			// 중간 값을 피벗으로 선택
			int pivotIndex = (left + right) / 2;
			int pivotValue = arr[pivotIndex];

			Swap(arr, pivotIndex, right);
			// 배열을 순회하며 피벗보다 작은 값을 찾아내고 피벗보다 큰 값을 교환
			// 피벗의 왼쪽에는 피벗보다 작은 값, 오른쪽에는 큰 값이 위치
			// 마지막으로 피벗을 올바른 위치로 이동시키고 그 위치를 반환

			// 배열을 돌면서 피벗보다 작은 값들을 저장
			int storeIndex = left;
			for (int i = left; i < right; i++)
			{
				if (arr[i] < pivotValue)
				{
					// 현재 값이 피벗보다 작으면 해당 값을 storeIndex에 위치한 값과 교환
					Swap(arr, i, storeIndex);
					storeIndex++;
				}
			}
			Swap(arr, storeIndex, right);
			return storeIndex;
		}
		static void Main()
		{
			Random random = new Random();
			int[] data = new int[100000];
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = random.Next(100000);
			}
			Stopwatch sw = Stopwatch.StartNew();
			//BubbleSort(data);
			QuickSort(data);
			sw.Stop();

			double seconds = sw.Elapsed.TotalSeconds;
			Console.WriteLine($"정렬에 걸린 시간 : {seconds}초");
		}
	}
}