using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class Dijkstras
    {
        const int INF = 99999;  // 갈수없는 거리를 표현 변경불가능
        public static void ShortestPath(int[,] graph, int start, out int[] distance, out int[] path)    // 그래프와 시작지점을 입력받아 시작노드와의 거리와 전노드를 반환하는 함수
        {
            int size = graph.GetLength(0);  // 그래프의 길이를 저장
            distance = new int[size];
            path = new int[size];
            bool[] visite = new bool[size];
            for(int i=0; i<size; i++)   // 값 초기화
            {
                distance[i] = graph[start,i];   // 시작지점의 각 노드의 거리를 저장
                path[i] = distance[i]<INF ? start:-1;   // 시작지점의 거리가 무한이 아니면 경로를 시작지점으로 저장 아니면 -1
            }

            for(int i = 0; i < size; i++)   // 반복하면서 시작노드부터 거리가 작은 노드 순으로 탐색을 시작하며 탐색한 노드를 방문처리하며 진행
            {
                int min = INF;
                int next = -1;
                for(int j = 0; j < size; j++)   // 가장 작은 값 찾기
                {
                    if (!visite[j]&&distance[j] < min)  // 아직 방문하지 않았고 시작지점 부터의 거리가 가장 작은값을 찾는다
                    {
                        next= j;                // 가장작은 거리의 노드(순서)를 저장
                        min = distance[j];      // 가장작은 거리 저장
                    }
                }
                if (next < 0) break;    // 만약 다 방문했거나 거리가다 무한이면 종료

                for(int k=0; k < size; k++)
                {
                    if (distance[k] > distance[next] + graph[next, k])  // 시작지점 부터의 다음 노드의 거리가 시작지점부터 현재 노드까지의 거리와 현재노드와 다음 노드의 거리보다 클시
                    {
                        distance[k] = distance[next] + graph[next,k];   // 더 작은길의 값을 저장
                        path[k] = next;                                 // 지나가는 경로로 현재 노드를 저장
                    }
                }
                visite[i]= true;                                        // 현재노드를 방문으로 처리
            }
        }
    }
}
