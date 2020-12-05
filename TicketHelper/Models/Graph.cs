using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketHelper.Models
{
    public class Graph
    {
        public HashSet<int> Vertices { get; set; } = new HashSet<int>();
        public Dictionary<int, LinkedList<int>> AdjacencyList { get; set; } = new Dictionary<int, LinkedList<int>>();        

        public void AddVertex(int id)
        {
            if (Vertices.Contains(id))
                throw new ArgumentException($"Vertice with same id ({id}) exists");
            
            if (AdjacencyList.ContainsKey(id))
                throw new ArgumentException($"{id} this key already exists in adjacency list");

            Vertices.Add(id);
            AdjacencyList.Add(id, new LinkedList<int>());
        }

        public void AddEdge(int v1, int v2)
        {
            if (!Vertices.Contains(v1))
                throw new ArgumentException($"There is no vertice with given id ({v1})");
            if (!Vertices.Contains(v2))
                throw new ArgumentException($"There is no vertice with given id ({v2})");

            if (!AdjacencyList[v1].Contains(v2) && !AdjacencyList[v2].Contains(v1))
            {
                AdjacencyList[v1].AddLast(v2);
                AdjacencyList[v2].AddLast(v1);
            }
        }

        public List<LinkedList<int>> FindAllPossiblePaths(int source, int destination)
        {
            var result = new List<LinkedList<int>>();
            Queue<LinkedList<int>> queue = new Queue<LinkedList<int>>();

            var path = new LinkedList<int>();
            path.AddLast(source);
            queue.Enqueue(path);

            while(queue.Any())
            {
                path = queue.Dequeue();
                var lastVertex = path.Last();

                if (destination == lastVertex)
                {
                    result.Add(path);
                } 
                else
                {
                    var neighbors = AdjacencyList[lastVertex];
                    foreach (var neighbor in neighbors)
                    {
                        if (!path.Contains(neighbor))
                        {
                            var newPath = new LinkedList<int>(path);
                            newPath.AddLast(neighbor);
                            queue.Enqueue(newPath);
                        }
                    }
                }
            }

            return result;
        }        
    }
}
