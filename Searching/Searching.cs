using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Searching
{
    internal class Searching
    {
        // <순차 탐색>
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.CompareTo(list[i]) == 0)
                    return i;
            }
            return -1;
        }

        // <이진탐색>
        public static int BinarySearch<T>(in IList<T> Iist, in T item) where T : IComparable<T>
        {
            int low = 0;
            int high = Iist.Count - 1;

            while (low <= high)
            {
                int middle = (low + high) >> 1;
                int compare = Iist[middle].CompareTo(item);

                if(compare<0)
                    low= middle+1;
                else if(compare > 0)
                    high= middle-1;
                else
                    return middle;
            }
            return -1;
        }

        // <깊이 우선 탐색>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        // 백트래킹
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] path)
        {
            visited = new bool[graph.GetLength(0)];
            path = new int[graph.GetLength(0)];

            for(int i=0; i<graph.GetLength(0); i++)
            {
                visited[i] = false;
                path[i] = -1;
            }
            SearchNode(graph, start, visited, path);
        }

        private static void SearchNode(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true;
            for(int i=0; i<graph.GetLength(0); i++)
            {
                if (graph[start, 1] && !visited[i])
                {
                    SearchNode(graph,i, visited, parents);
                }
            }
        }

        // <너비 우선 탐색>
        // 그래프의 분기를 만났을 때 모든 분기를 저장한 뒤,
        // 저장한 분기를 하나씩 탐색
        public static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0)
            {
                int next = bfsQueue.Dequeue();
                visited[next] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] &&       // 연결되어 있는 정점이며,
                        !visited[i])            // 방문한적 없는 정점
                    {
                        parents[i] = next;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }
    }
}
