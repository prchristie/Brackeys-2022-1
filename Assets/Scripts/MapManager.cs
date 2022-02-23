using System;
using System.Collections.Generic;
using QuikGraph;
using UnityEngine;

[ExecuteAlways]
public class MapManager : MonoBehaviour
{
    public Node startNode;
    public Node endNode;

    [SerializeField] private List<Node> nodes;

    public AdjacencyGraph<Node, Edge<Node>> DirectedMap { get; private set; }

    private void Awake()
    {
        AddNodesToGraph();
    }

    private void OnEnable()
    {
        AddNodesToGraph();
    }

    private void OnValidate()
    {
        AddNodesToGraph();
    }

    private void AddNodesToGraph()
    {
        DirectedMap = new AdjacencyGraph<Node, Edge<Node>>();
        foreach (var n in nodes)
        {
            DirectedMap.AddVertex(n);
        }
        
        foreach (var n in nodes)
        {
            foreach (var neighbour in n.neighbours)
            {
                DirectedMap.AddEdge(new Edge<Node>(n, neighbour));
            }
        }
        
        
    }

    private void OnDrawGizmos()
    {
        AddNodesToGraph();
        Gizmos.color = Color.red;
        foreach (var vertex in DirectedMap.Vertices)
        {
            foreach (var edge in DirectedMap.OutEdges(vertex))
            {
                var sourcePos = edge.Source.transform.position;
                var targetPos = edge.Target.transform.position;
                DrawArrow.ForGizmo(sourcePos,
                    (targetPos - sourcePos) * 0.9f);
            }
        }
    }
}