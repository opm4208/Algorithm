using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class Graph
    {
        /******************************************************
		 * 그래프 (Graph)
		 * 
		 * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐
		 * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
		 * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
		 ******************************************************/

        // <인접행렬 그래프>
        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
        // 2차원 배열을 [출발정점, 도착정점] 으로 표현
        // 장점 : 인접여부 접근이 빠름
        // 단점 : 메모리 사용량이 많음
        bool[,] matrixGraph1 = new bool[,] 
        {
            {false,true,true,true,true },
            {true,false,true,false,true },
            {true,true,false,false,false },
            {true,false,false,false,true },
            {true,true,false,true,false }
        };

        const int INF = int.MaxValue;
        int[,] matrixGraph2 = new int[5, 5]
        {
            { 0,132,162,INF,INF},
            { 0,132,162,INF,INF},
            { 0,132,162,INF,INF},
            { 0,132,162,INF,INF},
            { 0,132,162,INF,INF}
        };

        // 예시 - 양방향 연결 그래프
        List<List<int>> listGraph;
        List<List<(int, int)>> listGraph2;

        public void CreateGraph()
        {
            listGraph = new List<List<int>>();
            for(int i=0; i<5; i++)
            {
                listGraph.Add(new List<int>());
            }
            listGraph[0].Add(1);
            listGraph[1].Add(0);
            listGraph[1].Add(3);
        }
    }
}
