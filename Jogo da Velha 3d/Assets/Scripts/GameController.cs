using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{

    public GameObject player;
    public GameObject opponent;
    public GameObject gridGO;


    private void Start()
    {
        
        DrawShapeForPlayer();
    }

    void DrawShapeForPlayer()
    {
        player.GetComponent<Player>().PlayerShape = Random.Range(0, 2);
    }

    //call this function when the player had finished your move
    public void FinishedMovement(int x, int y, int shapeType)
    {
        //loop for grid to test if you win or not
        //if you win: the game is over
        //if not: change the player

        Node[,] grid = gridGO.GetComponent<GridP>().GetNodeGrid();
        Vector2 gridSize = gridGO.GetComponent<GridP>().worldGridSize;

        //checkRow
        for (int i=0; i< gridSize.x; i++)
        {
            if(grid[x,i].isOccupied)
            {
                if(grid[x, i].objectType != shapeType)
                {
                    break;
                }

                if (i == gridSize.x - 1)
                    return; // win

            }
            else
            {
                break;
            }
        }

        //checkCol
        for (int i = 0; i < gridSize.y; i++)
        {
            if (grid[i, y].isOccupied)
            {
                if (grid[i, y].objectType != shapeType)
                {
                    break;
                }

                if (i == gridSize.y - 1)
                    return; // win

            }
            else
            {
                break;
            }
        }

        //CheckMiddle
        if(x==y && x==(int)(gridSize.x-1)/2)
        {

        }

        //checkMainDiagonal
        if(x==y)
        {

        }

        //checkSecondaryDiagonal
        if(x+y == gridSize.x-1)
        {
            for(int i=0; i < gridSize.x; i++)
            {
                if (grid[i, (int)(gridSize.x - 1) - i].objectType!=shapeType)
                {
                    break;
                }

                if(i== gridSize.x - 1)
                {
                    //win
                }
            }
        }
    }
}
