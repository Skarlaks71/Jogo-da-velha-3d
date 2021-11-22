using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform shapeDef;
    public LayerMask shapeMask;
    
    int playerShape;

    GridP grid;

    private void Awake()
    {
        grid = GameObject.Find("grid").GetComponent<GridP>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnObject();
        }
    }

    public int PlayerShape
    {
        get { return playerShape; }
        set { playerShape = value; }
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
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 999);
                print("Normal: " + hitData.normal);
                print("Point: " + hitData.point);
                grid.PrintNodeFromWorldPosition(hitData.point);
                Instantiate(shapeDef, selectNode.worldPos+hitData.normal, Quaternion.identity);
                selectNode.isOccupied = true;
                selectNode.objectType = playerShape;
            }
                
        }
    }
}
