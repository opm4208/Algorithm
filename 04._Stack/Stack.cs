using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// 구현 목록 푸쉬 팝 피크 
    /// </summary>
    internal class Stack<T>
    {
        private List<T> container;  // 리스트 변수

        public Stack() //생성자
        { 
            container=new List<T>();
        }

        // 푸쉬
        public void Push(T item)    // 스택에 값을 저장할 함수
        {
            container.Add(item);    // 리스트에 값을 추가
        }

        // 팝
        public T Pop()              // 스택에 마지막으로 저장된 값을 출력하는 함수
        {
            if(container.Count > 0) // 스택에 저장된 경우
            {
                T item = container[container.Count - 1];
                container.RemoveAt(container.Count - 1);
                return item;
            }
            else                    // 스택에 값이 없을때 예외처리
            {
                throw new IndexOutOfRangeException();
            }
        }

        // 피크
        public T Peek()             // 스택에 마지막으로 저장된 값을 반환
        {
            if (container.Count > 0)
            {
                return container[container.Count - 1];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
