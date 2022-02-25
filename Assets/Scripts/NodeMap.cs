using System;
using System.Collections.Generic;
using System.Linq;
using QuikGraph;
using UnityEngine;

public class NodeMap
{
    public AdjacencyGraph<Node, Edge<Node>> Graph { get; private set; }

    public NodeMap()
    {
        Graph = new AdjacencyGraph<Node, Edge<Node>>();
    }

    public void AddEdges(List<Node> n)
    {
        foreach (var node in n)
        {
            foreach (var neighbour in node.neighbours)
            {
                Graph.AddEdge(new Edge<Node>(node, neighbour));
            }
        }
    }

    public void AddNodes(List<Node> nodes)
    {
        foreach (var n in nodes)
        {
            Graph.AddVertex(n);
        }
        AddEdges(nodes);
    }
}
