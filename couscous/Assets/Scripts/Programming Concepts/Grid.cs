using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Grid : MonoBehaviour
{
    public LayerMask unwalkable;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public Node[,] grid;
    Vector2 bottomLeft;
    public int gridSizeX, gridSizeY;

    private void Start()
    {
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / (nodeRadius * 2f));
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / (nodeRadius * 2f));
        bottomLeft = (Vector2)transform.position - Vector2.right * gridWorldSize.x / 2 - Vector2.up * gridWorldSize.y / 2;
        CreateGrid();
        Debug.Log("Grid Created. X: " + gridSizeX + " Y: " + gridSizeY + " Bottom Left: " + bottomLeft);
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        for(int x = 0; x < gridSizeX; x++) {
            for(int y = 0; y < gridSizeY; y++) {
                grid[x, y] = new Node(x,y);
                // World position is the x,y locations multiplied by the radius to check and making sure its not 0 its multiplied by. 
                grid[x, y].worldPos = (bottomLeft + Vector2.right * ((x * nodeRadius * 2) + nodeRadius) + Vector2.up * ((y * nodeRadius * 2) + nodeRadius));
                //Check our radius for its intesection with the selected Layer Mask.
                grid[x, y].pass = (Physics2D.OverlapCircle(grid[x, y].worldPos, (nodeRadius -.1f), unwalkable) != null);
            }
        }

    }

    public List<Node> GetBro(Node node) {
        List<Node> list = new List<Node>();
        for(int x = -1; x <= 1; x++) {
            for(int y = -1; y <= 1; y++) {
                int x1 = x + node.gridX;
                int y1 = y + node.gridY;
                // if x & y are non 0, And the X / Y location is within the grid.
                if(!(x == 0 && y == 0) && (x1 < gridSizeX && x1 >= 0) && (y1 < gridSizeY && y1 >= 0)) {
                    list.Add(grid[x1, y1]);
                }
            }
        }
        return list;
    }

    public Node WorldToGrid(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt(Mathf.Clamp01(worldPosition.x / bottomLeft.x +.5f) * gridSizeX-1);
        int y = Mathf.RoundToInt(Mathf.Clamp01(worldPosition.y / bottomLeft.y +.5f) * gridSizeY-1);
        return grid[x, y];
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x,gridWorldSize.y,1f));
        if(grid != null) {
            for(int x = 0; x < gridSizeX; x++) {
                for(int y = 0; y < gridSizeY; y++) {
                    Gizmos.color = grid[x, y].pass ? Color.white : Color.red;
                    Gizmos.DrawCube(grid[x, y].worldPos, Vector2.one * nodeRadius * .25f);
                }
            }
        }
    }
    
    public int GetTerrain(Vector2 dest) {
        LayerMask curr = WorldToGrid(dest).getTerrain();
        int type = 0;
        switch(type) {
            case (0): 
                break;
            case (1):
                break;
            case (8):
                type = (int)curr;
                break;
        };

        return type;
    }
    
}
