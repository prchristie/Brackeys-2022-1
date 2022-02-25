using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MonsterMovementHandler : MonoBehaviour
{
    [SerializeField] private float nodeProximitySensor;
    [SerializeField] private float speed;
    
    private MapManager _mapMan;

    private Node _nextNode;

    // Start is called before the first frame update
    void Start()
    {
        _mapMan = MapManager.Singleton;
        _nextNode = _mapMan.startNode;
    }

    // Update is called once per frame
    void Update()
    {
        CheckNextNodeProximity();

        MoveTowardsNextNode();
    }

    private void MoveTowardsNextNode()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _nextNode.transform.position,
            speed * Time.deltaTime);
    }

    private void CheckNextNodeProximity()
    {
        if (Vector3.Distance(transform.position, 
                _nextNode.transform.position) < nodeProximitySensor)
        {
            UpdateNextNode();
        }
    }

    private void UpdateNextNode()
    {
        List<Node> potentialNextNodes = _nextNode.neighbours;
        if (potentialNextNodes.Count == 0) return;
        _nextNode = potentialNextNodes[Random.Range(0, potentialNextNodes.Count)];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, nodeProximitySensor);
    }
}
