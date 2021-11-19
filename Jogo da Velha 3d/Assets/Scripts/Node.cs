using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public bool isOccupied;
    public Vector3 worldPos;
    public int objectType;

    public Node(Vector3 _worldPos, bool _isOccupied)
    {
        worldPos = _worldPos;
        isOccupied = _isOccupied;
    }

}
