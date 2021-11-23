using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public bool isOccupied;
    public Vector3 worldPos;
    public int objectType = -1;
    public Vector2 index;

    public Node(Vector3 _worldPos, Vector2 _index, bool _isOccupied)
    {
        worldPos = _worldPos;
        index = _index;
        isOccupied = _isOccupied;
    }

}
