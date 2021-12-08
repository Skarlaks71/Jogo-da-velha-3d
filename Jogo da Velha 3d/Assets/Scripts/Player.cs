using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform shapeDef;
    public LayerMask shapeMask;
    
    int playerShape;

    GameController gc;
    GridP grid;

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

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        Ray ray;
        RaycastHit hitData;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 4;

        ray = Camera.main.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out hitData, 1000, shapeMask))
        {
            Node selectNode = grid.GetNodeFromWorldPoint(hitData.transform.position);
            if (!selectNode.isOccupied)
            {
                print("distance ray: " + hitData.distance);
                
                print("Normal: " + hitData.normal);
                print("Point: " + hitData.point);
                grid.PrintNodeFromWorldPosition(hitData.point);
                Vector3 pointPos = new Vector3(selectNode.worldPos.x, 1, selectNode.worldPos.z);
                Instantiate(shapeDef, pointPos, Quaternion.identity);
                selectNode.isOccupied = true;
                selectNode.objectType = playerShape;
                gc.FinishedMovement((int)selectNode.index.x, (int)selectNode.index.y, playerShape);
            }
                
        }
    }
}
