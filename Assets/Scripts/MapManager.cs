using System;
using System.Collections.Generic;
using QuikGraph;
using Sirenix.OdinInspector;
using UnityEngine;

// [ExecuteAlways]
public class MapManager : MonoBehaviour
{
    public static MapManager Singleton;

    [Required] [SerializeField] public Node startNode;
    [Required] [SerializeField] public Node endNode;

    [SerializeField] private List<Node> nodes;

    public NodeMap Map { get; private set; }

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
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
        Map = new NodeMap();
        Map.AddNodes(nodes);
    }

    private void OnDrawGizmos()
    {
        AddNodesToGraph();
        Gizmos.color = Color.red;
        foreach (var vertex in Map.Graph.Vertices)
        {
            foreach (var edge in Map.Graph.OutEdges(vertex))
            {
                var sourcePos = edge.Source.transform.position;
                var targetPos = edge.Target.transform.position;
                DrawArrow.ForGizmo(sourcePos,
                    (targetPos - sourcePos) * 0.9f);
            }
        }
    }
}