using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    // 추가할 기능: 접근, 추가, 삭제
    internal class Dictionary<Tkey, Tvalue> where Tkey : IEquatable<Tkey>
    {
        private const int intDefaultCapacity = 1000;    // 해싱테이블은 성능을 위해 크게 데이터 공간을 차지한다

        private struct Entry                            // 테이블에 사용할 구조체
        {
            public enum State { None, Using, Deleted};  // 아직 데이터가 안들어왔으면 None, 데이터가 존재하면 Using, 데이터가 삭제되면 Deleted
            public State state;
            public Tkey Key;
            public Tvalue Value;
        }

        private Entry[] table;                          // 구조체를 저장할 table
        public Dictionary()                             // 생성자
        {
            table = new Entry[intDefaultCapacity];      // 테이블을 초기설정 만큼의 크기로 저장
        }

        public void Add(Tkey tkey, Tvalue tvalue)       // 테이블에 값을 추가하는 함수
        {
            int index = Math.Abs(tkey.GetHashCode()%table.Length);  // 키값을 해쉬코드화 하여 테이블의 크기만큼 나머지한 값을 절대값하여 인덱스로 사용

            while (true)
            {
                if(tkey.Equals(table[index].Key))       // 만약 추가하는 키 값이 이미 존재하는 경우 예외처리 발생
                {
                    throw new ArgumentException();
                }
                if (table[index].state != Entry.State.Using)    // 테이블의 인덱스가 사용중이 아닐때 값을 저장 후 사용으로 상태 변경
                {
                    table[index].Key = tkey;
                    table[index].Value = tvalue;
                    table[index].state = Entry.State.Using;
                    break;
                }
                index = ++index%table.Length;           // 테이블이 사용중인 경우 다음 값으로 저장
            }
        }

        public bool Remove(Tkey tkey)                   // 입력한 키값을 찾아 제거하는 함수
        {
            int index = Math.Abs(tkey.GetHashCode() % table.Length);
            while (true)
            {
                if (tkey.Equals(table[index].Key))      // 입력한 키값과 같은 값을 찾으면 제거 상태로 변경 후 true 반환
                {
                    table[index].state = Entry.State.Deleted;
                    return true;
                }
                if (table[index].state != Entry.State.None) // 테이블의 인덱스가 None이 아니면 인덱스 변경
                {
                    index = ++index%table.Length;
                }
                else                                    // 테이블의 인덱스가 None이면 종료 후 false 반환
                {
                    break;
                }
            }
            return false;                              
        }

        public Tvalue this[Tkey tkey]                   // 테이블의 get, set
        {
            get
            {
                int index = Math.Abs(tkey.GetHashCode() % table.Length);

                while (true)
                {
                    if (tkey.Equals(table[index].Key) && (table[index].state!=Entry.State.Deleted))  // 찾는 키와 테이블의 인덱스의 키 값이 같으면 테이블의 인덱스에 저장된 값을 반환
                    {
                        return table[index].Value;
                    }
                    if (table[index].state !=Entry.State.None)  // 테이블의 인덱스의 상태가 None이 아닐때 인덱스 증강
                    {
                        index = ++index % table.Length;
                    }
                    else                                        // 테이블의 인덱스의 상태가 None이면 종료 후 예외처리 발생
                    {
                        break;
                    }
                }
                throw new InvalidOperationException();
            }
            set
            {
                int index = Math.Abs(tkey.GetHashCode() % table.Length);

                while (true)
                {
                    if (tkey.Equals(table[index].Key)&& (table[index].state==Entry.State.Using))  // 찾는키와 같으면 테이블의 인덱스에 값을 저장 후 종료
                    {
                        table[index].Value = value;
                        return;
                    }
                    if (table[index].state != Entry.State.None)
                    {
                        index = ++index % table.Length;
                    }
                    else
                    {
                        break;
                    }
                }
                throw new InvalidOperationException();
            }
        }
    }
}
