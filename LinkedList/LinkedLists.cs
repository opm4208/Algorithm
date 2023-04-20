using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedListNode<T>      // 연결리스트 노드 클래스
    {
        internal LinkedList<T> list;             // 노드에 연결된 리스트
        internal LinkedListNode<T> prev;         // 노드의 앞에있는 노드를 저장할 변수
        internal LinkedListNode<T> next;         // 노드의 뒤에있는 노드를 저장할 변수
        private T item;                 // 값을저장할 변수

        public LinkedListNode(T value)  // 생성자
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public LinkedList<T> List { get { return list; } }      // List get
        public LinkedListNode<T> Prev { get { return prev; } }  // Prev get
        public LinkedListNode<T> Next { get { return next; } }  // Next get

        public T Item { get { return item; } set { item = value; } }    // item get set 
    }
    
    public class LinkedList<T>              // 연결리스트 클래스
    {
        LinkedListNode<T> head;             // 연결리스트의 제일앞에 있는 노드를 저장할 변수
        LinkedListNode<T> tail;             // 연결리스트의 제일뒤에 있는 노드를 저장할 변수
        int count;

        public LinkedList()                 // 생성자
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }             // 리스트의 헤드 get
        public LinkedListNode<T> Last { get { return tail; } }              // 리스트의 테일 get
        public int Count { get { return count; } }                          // 리스트의 갯수 get

        public void AddFirst(T item)
        {
            LinkedListNode<T> newnoad = new LinkedListNode<T> (this,item);  // 노드를 추가하기 위해 새로운 노드를 생성

            if(head == null)        // 아무것도 없는 리스트일떄
            {
                head = newnoad;     // head에 새로만든 노드를 대입
                tail = newnoad;     // tail에 새로만든 노드를 대입
            }
            else                    //노드가 있는 리스트일떄
            {
                newnoad.next = head;// 새로만든 노드의 다음 노드로 현재 헤드 노드를 저장
                head.prev = newnoad;// 현재 헤드 노드의 앞에 노드로 새로 만든 노드를 저장
                head= newnoad;      // 헤드를 새로만든 노드로 저장
            }

            count++;                // 노드를 추가해서 count 증가
        }

        public void AddLast(T item)
        {
            LinkedListNode<T> newnoad = new LinkedListNode<T>(this, item);

            // 아무것도 없는 리스트일떄, 노드가 있는 리스트일떄
            if (tail== null)        // 아무것도 없는 리스트일떄
            {
                head = newnoad;
                tail = newnoad;
            }
            else
            {
                newnoad.prev = tail;
                tail.next= newnoad;
                tail= newnoad;
            }
            count++;
        }

        public void AddBefore(LinkedListNode<T> node, T item)
        {
            // 아무것도 없는 리스트일때, 주어진 노드와 추가하려는 리스트가 다를때
            if(node.list == null)
                throw new ArgumentNullException(nameof(node));
            if (node.list!=this)
                throw new InvalidOperationException();

            LinkedListNode<T> newnoad = new LinkedListNode<T>(this, item);

            // 주어진 노드가 head일때, 주어진 노드가 head가 아닐때
            if (head == node)
            {
                node.prev = newnoad;
                newnoad.next = node;
                head = newnoad;
            }
            else
            {
                newnoad.prev = node.prev;
                node.prev = newnoad;
                newnoad.next = node;
                newnoad.prev.next = newnoad;
            }
            count++;
        }

        public void AddAfter(LinkedListNode<T> node, T item)
        {
            // 아무것도 없는 리스트일때, 주어진 노드와 추가하려는 리스트가 다를때
            if (node.list == null)
                throw new ArgumentNullException(nameof(node));
            if (node.list != this)
                throw new InvalidOperationException();

            LinkedListNode<T> newnoad = new LinkedListNode<T>(this, item);

            // 주어진 노드가 tail일때, 주어진 노드가 tail이 아닐때
            if (tail == node)
            {
                node.next = newnoad;
                newnoad.prev = node;
                tail = newnoad;
            }
            else
            {
                newnoad.next = node.next;
                node.next = newnoad;
                newnoad.prev = node;
                newnoad.next.prev = newnoad;
            }
            count++;
        }

        public void Remove(T value)
        {
            // 값이 리스트에 없을때 있을떄 제거한 값이 헤드나 테일일때 중간 노드일때
            if(head==null) // 리스트가 비어있으면 예외처리
                throw new Exception();
            LinkedListNode<T> deledtenode = Find(value);
            if (deledtenode != null) // 값이 리스트안에 있었을때
            {
                if(head==deledtenode) // 삭제할 노드가 헤드일때
                {
                    head = deledtenode.next;
                    deledtenode.next.prev = null;
                    deledtenode.next= null;
                }
                else if(tail == deledtenode) // 삭제할 노드가 테일일때
                {
                    tail = deledtenode.prev;
                    deledtenode.prev.next = null;
                    deledtenode.prev = null;
                }
                else
                {
                    deledtenode.prev.next= null;
                    deledtenode.prev= null;
                    deledtenode.next.prev = null;
                    deledtenode.next = null;
                }
            }
            count--;
        }

        public void Remove(LinkedListNode<T> node)
        {
            // 값이 리스트에 없을때 있을떄 제거한 값이 헤드나 테일일때 중간 노드일때
            if (head == null) // 리스트가 비어있으면 예외처리
                throw new Exception();
            if (node.list != this)  // 삭제하려는 노드랑 삭제하려는 리스트가 다를시 예외처리
                throw new InvalidOperationException();
            if (Find(node))
            {
                if (head == node) // 삭제할 노드가 헤드일때
                {
                    head = node.next;
                    node.next.prev = null;
                    node.next = null;
                }
                else if (tail == node) // 삭제할 노드가 테일일때
                {
                    tail = node.prev;
                    node.prev.next = null;
                    node.prev = null;
                }
                else
                {
                    node.prev.next = null;
                    node.prev = null;
                    node.next.prev = null;
                    node.next = null;
                }
            }
            count--;
        }
        public LinkedListNode<T> Find(T value)  // 값으로 노드 찾기 리스트안에 찾는 값의 노드가 있으면 반환 없으면 null반환
        {
            LinkedListNode<T> newnoad = head;
            while (true)                        // 리스트안의 노드를 처음부터 끝까지 반복해서 값이 노드안에 있나 확인
            {
                if (newnoad.Item.Equals(value))
                {
                    return newnoad;
                }
                if (newnoad.next != null)
                {
                    newnoad = newnoad.next;
                }
                else
                {
                    break;
                }
            }
            newnoad = null;
            return newnoad;
        }
        public bool Find(LinkedListNode<T> node)    // 노드가 리스트안에 있는지 확인 있으면 true 없으면 false 반환
        {
            LinkedListNode<T> newnoad = head;
            while (true)                            // 반복문으로 리스트안에 찾는 노드가 있는지 확인
            {
                if (newnoad == node)
                {
                    return true;
                }
                if (newnoad.next != null)
                {
                    newnoad = newnoad.next;
                }
                else
                {
                    break;
                }
            }
            return false;
        }
    }
}
