using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridP : MonoBehaviour
{
    
    public Transform tile;
    public Vector2 worldGridSize;
    public Vector2 sizeCell;

    List<Node> tilesNodeList;
    Node[,] grid;

    private void Start()
    {
        grid = new Node[(int)worldGridSize.x, (int)worldGridSize.y];
        tilesNodeList = new List<Node>();
        CreateGrid();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
        }
    }
    void CreateGrid()
    {
        Vector2 realGridSize = worldGridSize * sizeCell;

        for (int x = 0; x < worldGridSize.x; x++)
        {
            for (int y = 0; y < worldGridSize.y; y++)
            {
                float posX = x * sizeCell.x - (realGridSize.x - 2 * (sizeCell.x / 2)) / 2;
                float posZ = y * sizeCell.y - (realGridSize.y - 2 * (sizeCell.y / 2)) / 2;
                Vector3 tilePos = new Vector3(posX, .5f, posZ);

                grid[x, y] = new Node(tilePos, false);
                print("grid number = [" + x + "][" + y + "]");
                tilesNodeList.Add(grid[x, y]);
            }
        }

        SpawnTiles();

    }

    public Node[,] GetNodeGrid()
    {
        return grid; 
    }
    void SpawnTiles()
    {
        foreach (Node tileG in grid)
        {
            print(tileG.worldPos);
            GameObject tileClone = (GameObject)Instantiate(tile.gameObject, tileG.worldPos, Quaternion.identity);
            tileClone.transform.parent = this.gameObject.transform;
        }
    }

    public Node GetNodeFromWorldPoint(Vector3 worldPos)
    {
        float percentX = (worldPos.x + (worldGridSize.x * sizeCell.x) / 2) / (worldGridSize.x * sizeCell.x);
        float percentY = (worldPos.z + (worldGridSize.y * sizeCell.y) / 2) / (worldGridSize.y * sizeCell.y);
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        
        int x = Mathf.RoundToInt((worldGridSize.x - 1) * percentX);
        int y = Mathf.RoundToInt((worldGridSize.y - 1) * percentY);

        
        return grid[x, y];
    }

    public void PrintNodeFromWorldPosition(Vector3 worldPos)
    {
        float percentX = (worldPos.x + (worldGridSize.x * sizeCell.x) / 2) / (worldGridSize.x * sizeCell.x);
        float percentY = (worldPos.z + (worldGridSize.y * sizeCell.y) / 2) / (worldGridSize.y * sizeCell.y);
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((worldGridSize.x - 1) * percentX);
        int y = Mathf.RoundToInt((worldGridSize.y - 1) * percentY);

        print("Node: [" + x + "," + y + "]");
    }

    private void OnDrawGizmos()
    {
        if (grid != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 4;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            foreach (Node n in tilesNodeList)
            {

                if (GetNodeFromWorldPoint(worldPosition) == n)
                {
                    //print("point: " + worldPosition);
                    Gizmos.color = (n.isOccupied)? Color.red : Color.cyan;
                    Gizmos.DrawWireCube(n.worldPos+Vector3.up/2, new Vector3(sizeCell.x, 0.1f, sizeCell.y));
                }
            }
        }
    }

}
