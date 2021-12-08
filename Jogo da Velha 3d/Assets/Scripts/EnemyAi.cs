using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public Transform shapeDef;
    public LayerMask shapeMask;

    int playerShape;

    GameController gc;
    GridP grid;
    List<Node> tileFreeList = new List<Node>();

    public int PlayerShape
    {
        get { return playerShape; }
        set { playerShape = value; }
    }

    private void Awake()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        grid = GameObject.Find("grid").GetComponent<GridP>();

    }

    private void Start()
    {
        //tileFreeList = grid.tilesNodeList;
    }

    public void MakeAiTurn()
    {
        tileFreeList.Clear();
        foreach(Node n in grid.tilesNodeList)
        {
            if (n.isOccupied == false)
                tileFreeList.Add(n);
        }

        int chooseTile = -1;
        print("Count: " + tileFreeList.Count);
        chooseTile = Random.Range(0, tileFreeList.Count);
        print("Choose: "+chooseTile);
        Node selectNode = tileFreeList[chooseTile];
        Vector3 pointPos = new Vector3(selectNode.worldPos.x, 1, selectNode.worldPos.z);
        Instantiate(shapeDef, pointPos, Quaternion.identity);

        selectNode.isOccupied = true;
        selectNode.objectType = playerShape;

        print("[" + selectNode.index.x + "," + selectNode.index.y + "]");

        gc.FinishedMovement((int)selectNode.index.x, (int)selectNode.index.y, playerShape);
    }

}
