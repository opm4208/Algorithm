using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class List<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 20; // 상수값으로 배열의 크기 지정
        private T[] items;      // 일반화 배열 선언
        private int size;       // 현재 배열에 저장된 크기를 저장하기 위해 선언

        public List()       // 초기화
        {
            this.items = new T[DefaultCapacity];    // 상수의 크기만큼 새 배열을 선언
            this.size = 0;      // size 0으로 초기화
        }

        public int Capacity { get { return items.Length; } }       // get 으로 현재 배열의 길이를 반환
        public int Count { get { return size; } }       // get으로 현재 배열에 저장된 크기를 반환

        public T this[int index]        // 배열의 데이터를 부르고 저장함
        {
            get
            {
                if (index < 0 || index >= size)      // 만약 index가 0보다 작고 저장된 길이를 초과하면 오류 메세지 출력
                    throw new ArgumentOutOfRangeException();
                return items[index];        // 정상적인 index면 배열에 저장된 인덱스를 반환
            }

            set
            {
                if (index < 0 || index >= size)
                    throw new ArgumentOutOfRangeException();
                items[index] = value;       // 정상적인 index면 배열의 인덱스에 값을 저장
            }
        }

        public void Add(T item)     // 리스트에 값을 추가하는 함수
        {
            if (size < items.Length)    // 만약 저장된 크기가 배열의 선언된 크기를 넘지 않을시
            {
                items[size++] = item;    // 아이템 배열에 아이템을 추가
            }
            else    // 아닐시
            {
                Grow();    // 배열의 크기를 늘리기 위해 Grow함수 실행 
                items[size++] = item;     // 아이템 배열에 아이템을 추가
            }
        }
        public T? Find(Predicate<T> match)      // 리스트에 값이 있는지 확인하기 위한 함수 null값 허용
        {
            if (match == null) throw new ArgumentNullException();      // 만약 match가 null일때 오류 메세지 출력

            for (int i = 0; i < size; i++)      // 리스트에 저장된 크기만큼 반복
            {
                if (match(items[i]))        // 만약 배열의 값이 match랑 같으면
                    return items[i];        // 배열의 값을 반환
            }

            return default(T);  // 값형식이면 0 참조형식이면 null 반환
        }
        public int FindIndex(Predicate<T> match)    // 매개변수가 몇번째에 있는지 반환하는 함수
        {
            return FindIndex(0, size, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)     // 매개변수가 몇번째에 있는지 반환하는 함수
        {
            if (startIndex > size)      // 조건을 만족하지 않으면 오류 메세지 출력
                throw new ArgumentOutOfRangeException();
            if (count < 0 || startIndex > size - count)
                throw new ArgumentOutOfRangeException();
            if (match == null)
                throw new ArgumentNullException();

            int endIndex = startIndex + count;      // 시작위치와 찾는 크기를 더해서 찾을 위치로 저장
            for (int i = startIndex; i < endIndex; i++) // 시작위치부터 찾을 위치까지 반복
            {
                if (match(items[i])) return i;  // 만약 찾는값이 있으면 몇번째에 있는지 반환
            }
            return -1;      // 없으면 -1반환
        }
        public int Indexof(T item)  // 찾는 값을 배열에서 몇번째 있는지 반환하는 함수
        {
            return Array.IndexOf(items, item, 0, size);     // Array.IndexOf를 사용하여 item이 몇번째 인덱스에 있는지 반환 (찾을 배열, 찾을 값, 시작 위치, 시작 위치부터 찾을 크기) 없으면 -1반환
        }

        public bool Remove(T item)      // 리스트에서 값을 제거하는 함수
        {
            int index = Indexof(item);     // 제거할 값을 indexof함수에 대입하여 저장
            if (index >= 0)      // 제거할 값이 리스트에 있으면
            {
                RemoveAt(index);       //  RemoveAt 함수를 사용하여 제거한 리스트로 생성
                return true;        // 성공한 값을 반환
            }
            return false;       // 실패값을 반환
        }

        private void RemoveAt(int index)    // 값을 제거한 리스트를 새로 만들어 반환하는 함수
        {
            if (index < 0 || index >= size)     // 조건을 만족하지 않으면 오류 메세지 출력
                throw new IndexOutOfRangeException();

            size--;     // 저장된 크기를 줄인다.
            Array.Copy(items, index + 1, items, index, size - index);   // Array.Copy를 사용해 index를 빼고 저장
        }

        private void Grow()     // 배열의 크기를 늘리는 함수
        {
            int newCapacity = items.Length * 2;     // 현재 배열의 크기의 2배의 값을 저장
            T[] newitems = new T[newCapacity];      // 새로운 배열을 위의 저장한 크기만큼 생성
            Array.Copy(items, 0, newitems, 0, size);       // Array.Copy를 사용해 배열을 복사 Array.Copy(복사할 배열, 복사할 위치, 저장할 배열, 저장할 위치, 크기만큼 복사할 위치부터 복사) 
            items = newitems;       // 기존 배열에 새로 만든 배열의 주소를 저장
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list;
            private int index;
            private T current;

            public T Current { get { return current; } }

            public Enumerator(List<T> list)
            {
                this.list = list;
                this.index = -1;
                current = default(T);
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (index < list.Count - 1)
                {
                    current = list[++index];
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()
            {
                current = default(T);
                index = -1;
            }

        }

    }
}
