using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PriorityQueue
{
    internal class PriorityQueue<TElement>                  // 우선순위 큐
    {
        private struct Node                                 // 구조체 선언 (값과, 우선순위)로 구성
        {
            public TElement element;
            public int priority;
        }

        private List<Node> nodes;                           // 노드로 구성된 리스트 선언

        public PriorityQueue()
        {
            nodes = new List<Node>();                       // 리스트 할당
        }

        public int Count { get { return nodes.Count; } }    // 리스트의 구성노드 수를 반환

        public void EnQueue(TElement element,int priority)  // 큐의 데이터를 추가하는 함수
        {
            Node node = new Node {element=element, priority=priority }; // 새로 추가할 노드 선언하고 초기화
            nodes.Add(node);                                // 리스트에 새 노드 추가
            int newnodeIndex= nodes.Count-1;                // 현재 새로 추가한 노드의 인덱스를 저장

            while (true)                                    // 이진트리의 조건을 만족할때까지 반복
            {
                int parentsIndex = GetParentsIndex(newnodeIndex);   // 새로 추가한 노드의 부모 인덱스를 저장

                // 새로 추가된 노드가 부모 노드보다 우선순위가 높으면 위치를 바꾼다
                if (nodes[newnodeIndex].priority < nodes[parentsIndex].priority)
                {
                    nodes[newnodeIndex] = nodes[parentsIndex];      // 새 노드의 위치에 부모 노드를 저장
                    nodes[parentsIndex] = nodes[newnodeIndex];      // 부모노드의 위치에 새 노드를 저장
                    newnodeIndex = parentsIndex;                    // 새노드의 인덱스를 바뀐 위치로 저장
                }
                else if (newnodeIndex == 0)                         // 만약 새 노드가 리스트의 0인덱스면 종료
                {
                    break;
                }
                else
                {
                                                                    // 새로 추가한 노드의 우선순위가 부모 노드보다 낮으면 종료
                }
                {
                    break;
                }
            }
        }

        public TElement DeQueue()                                   // 큐의 첫번째 값을 삭제하고 반환하는 함수
        {
            TElement element = nodes[0].element;                    // 반환해줄 큐의 첫번째 값을 저장

            nodes[0] = nodes[nodes.Count-1];                        // 큐의 마지막에 있던 노드를 첫번째 위치로 이동
            nodes.RemoveAt(nodes.Count - 1);                        // 마지막에 있던 노드 삭제
            int lastnode = 0;                                       // 첫번째 위치로 이동한 노드의 인덱스 저장

            // 이진트리의 조건에 따라 노드 변경
            while(true)
            {
                int rightChild = GetLeftChildIndex(lastnode);       // 오른쪽 자식의 인덱스를 저장
                int leftChild = GetRightChildIndex(lastnode);       // 왼쪽 자식의 인덱스를 저장

                // 자식 노드가 2개일때
                if (rightChild<nodes.Count)
                {
                    // 자식들의 값을 비교하여 우선순위가 더 큰 쪽과 비교
                    int childIndex = nodes[leftChild].priority < nodes[rightChild].priority ? leftChild : rightChild;

                    // 이동한 노드의 우선순위가 자식보다 낮을때
                    if (nodes[lastnode].priority > nodes[childIndex].priority)
                    {
                        nodes[lastnode] = nodes[childIndex];
                        nodes[childIndex] = nodes[lastnode];
                        lastnode = childIndex;
                    }
                    else
                    {
                        break;
                    }

                }
                // 자식노드가 하나일때
                else if(leftChild<nodes.Count)
                {
                    // 이동한 노드의 우선순위가 자식보다 낮을때
                    if (nodes[lastnode].priority > nodes[leftChild].priority)
                    {
                        nodes[lastnode] = nodes[leftChild];
                        nodes[leftChild] = nodes[lastnode];
                        lastnode = leftChild;
                    }
                    else
                    {
                        break;
                    }
                }
                // 자식이 없을때
                else
                {
                    break;
                }
            }

            return element; // 처음에 저장한 큐의 첫번째 값을 반환
        }

        public TElement peeek() // 큐의 첫번째 값을 반환
        {
            return nodes[0].element;
        }

        private int GetParentsIndex(int childIndex) // 부모의 인덱스를 반환하는 함수
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parents)  // 왼쪽 자식의 인덱스를 반환하는 함수
        {
            return parents * 2 + 1;
        }

        private int GetRightChildIndex(int parents) // 오른쪽 자식의 인덱스를 반환하는 함수
        {
            return parents * 2 + 2;
        }
    }
}
