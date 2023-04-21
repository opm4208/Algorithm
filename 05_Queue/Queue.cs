using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Queue
{
    /// <summary>
    /// 구현 목록: 카운트, 클리어, 엔큐, 데큐, 피크, 그로우, 이즈풀, 이즈엠프티, 무브넥스트
    /// 큐가 비어있을때: 처음 생성 되었을때, 저장된 값들을 전부 데큐 했을때. 헤드랑 테일이 같을때
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Queue <T>
    {
        private const int DefaultCapacity = 4;              // 처음 배열의 크기를 지정
        private int head;                                   // 큐의 첫번째 데이터 위치를 가리킨다
        private int tail;                                   // 데이터가 저장된 다음 위치를 가리킨다
        private T[] array;                                  // 큐를 구현할때 사용할 배열

        public Queue()                                      // 생성자
        {
            array = new T[DefaultCapacity+1];
            head = 0;
            tail = 0;
        }

        public int Count                                    // 큐의 실질적으로 저장된 값을 반환
        { 
            get
            {
                if (head <= tail)                           // 테일이 아직 주어진 배열을 넘어서 저장되지 않았을 경우
                {
                    return tail - head;                     // 테일부터 헤드사이가 실직적으로 저장된 값이다               
                }
                else                                        // 테일이 큐에 빈공간이 있어 배열의 처음구간으로 돌아갔을 경우
                {
                    return tail+array.Length-head;          // 배열의 처음부터 테일까지의 데이터 + 배열의 끝부터 헤드까지의 데이터
                }
            } 
        }

        public void Clear()                                 // 큐를 초기화
        {
            array = new T[DefaultCapacity+1];
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)                         // 큐에 값을 추가
        {
            // 예외처리 상황: 이미 주어진 배열에 데이터가 다 있는경우, 테일이 배열의 처음구간으로 가야하는 경우 = MoveNext에서 처리
            if (IsFull())
            {
                Grow();
            }

            array[tail] = item;                             // 현재 테일의 위치에 값을 저장
            MoveNext(ref tail);                             // 테일의 위치를 변경하기 위해 사용
        }

        public T Dequeue()                                  // 현재 큐의 첫번째 값을 꺼낸다
        {
            if (IsEmpty())                                  // 큐가 비어있을시 예외처리 발생
                throw new InvalidOperationException();

            T result = array[head];                         // 값을 반환하기 위해 저장된 값을 저장
            MoveNext(ref head);                             // 헤드의 위치를 변경
            return result;                                  // 저장한 값을 반환
        }

        public T Peek()                                     // 현재 큐의 첫번째 값을 확인
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return array[head];                             // 헤드의 위치의 값을 반환
        }

        private void Grow()                                 // 배열에 데이터가 다 차서 크기를 늘려줘야 할경우 작동
        {
            // 예외처리 상황: 테일이 헤드 뒤에 있는 경우, 테일이 헤드보다 아래에 있는 경우
            int newCapacity = array.Length*2; 
            T[] newArray = new T[newCapacity];              // 현재 크기의 2배의 배열을 생성
            if (head<tail)
            {
                Array.Copy(array, head, newArray, 0, tail); // 현재 배열의 헤드부터 테일까지 새배열에 저장
            }
            else
            {                                               // 테일이 헤드보다 아래인 경우는 나눠서 새 배열에 저장(배열의 처음부터 테일까지 + 헤드부터 배열의 마지막까지)
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
            }
            array = newArray;                               // 새로만든 배열을 현재 배열에 참조
            tail = Count;                                   // 테일을 지금 배열에 저장된 값으로 초기화
            head = 0;                                       // 헤드의 값을 다시 배열의 처음으로 초기화
        }
        private bool IsFull()                               // 큐에 값이 다 찼는지 확인
        {
            // 배열이 꽉 차는 조건: 테일이 헤드 앞인경우, 헤드가 0이고 테일이 배열의 크기 -1인 경우
            if (head > tail)
            {
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }
        }
        private bool IsEmpty()                              // 큐가 비웠는지 확인
        {
            // 큐가 비워진 조건: 처음 생성시, 데큐를 사용하여 헤드가 테일을 따라잡았을시
            return head == tail;
        }
        private void MoveNext(ref int index)                // 테일이나 헤드의 위치를 이동하기 위해 사용 ref를 사용해서 안의 값이 반환 되게 만듬
        {
            index = (index == array.Length - 1) ? 0 : index + 1;    // 만약 배열의 마지막에 있는 경우 다시 처음으로 아닌경우 +1
        }
    }
}
