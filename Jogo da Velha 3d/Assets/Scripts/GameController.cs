using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{

    public GameObject player;
    public GameObject opponent;
    public GameObject gridGO;
    public Transform shapeSphere;
    public Transform shapeCylinder;

    int realPlayer;
    int aiPlayer;

    private void Start()
    {
        DrawShapeForPlayer();
    }

    void DrawShapeForPlayer()
    {
        realPlayer = Random.Range(0, 2);
        aiPlayer = (realPlayer == 0) ? 1 : 0;

        player.GetComponent<Player>().PlayerShape = realPlayer;
        opponent.GetComponent<EnemyAi>().PlayerShape = aiPlayer;

        if (realPlayer == 0)
        {
            player.GetComponent<Player>().shapeDef = shapeSphere;
            opponent.GetComponent<EnemyAi>().shapeDef = shapeCylinder;
        }
        else
        {
            player.GetComponent<Player>().shapeDef = shapeCylinder;
            opponent.GetComponent<EnemyAi>().shapeDef = shapeSphere;
        }
        
    }

    //call this function when the player had finished your move
    public void FinishedMovement(int x, int y, int shapeType)
    {
        //loop for grid to test if you win or not
        //if you win: the game is over
        //if not: change the player

        Node[,] grid = gridGO.GetComponent<GridP>().GetNodeGrid();
        Vector2 gridSize = gridGO.GetComponent<GridP>().worldGridSize;

        //checkCol
        for (int i=0; i< gridSize.x; i++)
        {
            if(grid[x,i].isOccupied)
            {
                if(grid[x, i].objectType != shapeType)
                {
                    break;
                }

                if (i == gridSize.x - 1)
                {
                    print("Win in col!");
                    EndGame();
                    return;
                }
            }
            else
            {
                break;
            }
        }

        //checkRow
        for (int i = 0; i < gridSize.y; i++)
        {
            if (grid[i, y].isOccupied)
            {
                if (grid[i, y].objectType != shapeType)
                {
                    break;
                }

                if (i == gridSize.y - 1)
                {
                    print("Win in row!");
                    EndGame();
                    return;
                }
            }
            else
            {
                break;
            }
        }


        //checkMainDiagonal
        if(x==y)
        {
            for(int i = 0; i < gridSize.x; i++)
            {
                if (grid[i, i].objectType != shapeType)
                    break;

                if (i == gridSize.x - 1)
                {
                    print("Win in MainDiagonal!");
                    EndGame();
                    return;
                }
            }
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
                    print("Win in SecondaryDiagonal!");
                    EndGame();
                    return;
                }
            }
        }

        ChangePlayer(shapeType);

    }

    void EndGame()
    {
        Debug.Log("You Win!");
    }

    void ChangePlayer(int shapePlayer)
    {
        if (shapePlayer == realPlayer)
        {
            player.SetActive(false);
            opponent.GetComponent<EnemyAi>().MakeAiTurn();
        }
        else
        {
            player.SetActive(true);
        }
    }

}
