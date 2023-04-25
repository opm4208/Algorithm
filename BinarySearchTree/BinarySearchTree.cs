using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    // 구성 요소 루트, 노드, 노드 추가, 노드 삭제, 노드 찾기, 노드 제거
    internal class BinarySearchTree<T> where T:IComparable<T>
    {
        private Node root;                  // 최상단 노드
        public BinarySearchTree()
        {
            root = null;
        }

        public void Add(T item)             // 값을 추가하는 함수
        {
            Node newnode = new Node(item,null,null,null);   // 새로 저장할 노드를 생성
            // 루트가 없으면 루트에 값을 추가
            if (root == null)
            {
                root = newnode;
                return;
            }
            Node current= root;                             // 비교할 노드를 저장 최상단부터 시작

            while (true)
            {
                // 값을 비교하여 작으면 왼쪽으로
                if (item.CompareTo(current.item)<0)
                {
                    // 왼쪽 자식이 없으면 왼쪽에 새노드를 저장
                    if (current.left == null)
                    {
                        current.left= newnode;
                        newnode.parent = current;
                        return;
                    }
                    // 있는경우 다시 비교 하기위해 왼쪽노드를 저장
                    else
                    {
                        current = current.left;
                    }
                }
                // 값을 비교하여 더 크면 오른쪽으로
                else if (item.CompareTo(current.item) > 0)
                {
                    // 오른쪽 자식이 없으면 오른쪽에 새노드를 저장
                    if(current.right == null)
                    {
                        current.right= newnode;
                        newnode.parent = current;
                        return;
                    }
                    // 있으면 비교할 노드를 오른쪽 노드로 저장
                    else
                    {
                        current= current.right;
                    }
                }
                // 값이 같을 경우 이진탐색트리에서 같은값은 무시한다
                else
                {
                    return;
                }
            }
        }

        public bool Remove(T item)                  // 값을 제거하고 bool형을 반환하는 함수
        {
            Node findnode = FindNode(item);         // 값으로 노드를 찾아 저장
            // 찾는 노드가 있는 경우
            if(findnode != null)                    
            {
                EraseNode(findnode);                // 실질적으로 노드 제거
                return true;
            }
            // 없는 경우
            else
            {
                return false;
            }
        }

        private Node FindNode(T item)               // 값으로 그 값을 갖고있는 노드를 찾는 함수
        {
            // 이진탐색 트리에서의 탐색은 찾는값보다 작으면 왼쪽 크면 오른쪽으로 탐색한다
            if(root == null)                        // 트리에 아무것도 없는 경우 null 반환
            {
                return null;
            }
            Node current =root;                     // 비교할 노드
            while (true)
            {
                // 비교값보다 작은 경우
                if(item.CompareTo(current.item)<0)
                {
                    current = current.left;         // 비교값을 왼쪽 노드로 변경
                }
                // 비교값보다 큰 경우
                else if(item.CompareTo(current.item) > 0)
                {
                    current=current.right;          // 비교값을 오른쪽 노드로 변경
                }
                // 찾는 노드가 없을때
                else if (current == null)           // 탈출 후 null 반환
                {
                    break;
                }
                // 같은 경우
                else
                {
                    return current;                 // 찾는 노드를 반환
                }
            }
            return null;
        }

        private void EraseNode(Node deletenode)     // 실질적으로 노드를 제거하는 함수
        {
            // 자식이 없을때
            if (deletenode.NoChild)
            {
                Node parent=deletenode.parent;      // 삭제할 노드의 부모노드를 저장
                if(deletenode.IsleftChild)          // 삭제할 노드가 부모노드의 왼쪽 자식일때
                {
                    parent.left = null;
                }
                else if(deletenode.IsRightChild)    // 삭제할 노드가 부모노드의 오른쪽 자식일때
                {
                    parent.right=null;
                }
                else                                // 삭제할 노드가 root인 경우
                {
                    root = null;
                }
            }
            // 자식이 하나일때
            if (deletenode.HasOnlyLeft || deletenode.HasOnlyRight)  // 왼쪽이나 오른쪽에 자식이 한명 있는 경우
            {
                Node parent = deletenode.parent;
                Node child = deletenode.HasOnlyLeft ? deletenode.left : deletenode.right;   // 자식이 왼쪽에 있는경우 왼쪽 오른쪽에 있는 경우 오른쪽 노드 저장
                // 삭제할 노드가 부모의 왼쪽 자식일 경우
                if (deletenode.IsleftChild)
                {
                    // 부모의 왼쪽자식에 삭제할 노드의 자식을 연결
                    parent.left = child;        
                    child.parent= parent;
                }
                // 삭제할 노드가 부모의 오른쪽 자식일 경우
                else if (deletenode.IsRightChild)
                {
                    // 부모의 오른쪽자식에 삭제할 노드의 자식을 연결
                    parent.right = child;
                    child.parent = parent;
                }
                // 삭제할 노드가 root 노드인 경우
                else
                {
                    // 자식을 root로 저장
                    root = child;
                    child.parent = null;
                }
            }
            // 자식이 둘다 있을때
            else
            {
                Node replaceNode = deletenode.left; // 비교할 노드를 왼쪽 자식으로 저장
                while (true)
                {
                    // 비교할 노드를 오른쪽 자식이 없을때까지 오른쪽 자식으로 저장
                    if(replaceNode.right== null)
                    {
                        break;
                    }
                    replaceNode = replaceNode.right;
                }
                deletenode.item = replaceNode.item; // 비교한 노드의 값을 삭제할 노드에 저장
                EraseNode(replaceNode);             // 비교한 노드를 삭제
            }
        }

        public class Node
        {
            // 노드의 구성 요소 값, 부모노드, 왼쪽 자식 노드, 오른쪽 자식 노드
            internal T item;
            internal Node parent;
            internal Node left;
            internal Node right;
            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            // 부모노드가 있고 자신이 부모노드의 왼쪽 일때
            public bool IsleftChild { get { return parent!=null && parent.left ==this; } }
            // 부모노드가 있고 자신이 부모노드의 오른쪽 일때
            public bool IsRightChild { get { return parent != null && parent.right == this; } }
            
            // 자신의 자식 노드들이 없을때
            public bool NoChild { get { return left == null && right == null; } }
            // 자신이 왼쪽 자식 노드가 있고 오른쪽 자식 노드가 없을때
            public bool HasOnlyLeft { get { return left != null && right == null;} }
            // 자신이 오른쪽 자식 노드가 있고 왼쪽 자식 노드가 없을때
            public bool HasOnlyRight { get {  return left == null && right != null; } }
        }
    }
}
