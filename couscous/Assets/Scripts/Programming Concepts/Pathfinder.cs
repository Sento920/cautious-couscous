using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    public Grid grid;
    List<Node> closedList;
    List<Node> openList;
    bool found;

    private void Start() {
        openList = new List<Node>();
        closedList = new List<Node>();
        found = false;
    }

    LinkedList<Node> FindPath(Vector2 Start, Vector2 end){
        found = false;
        LinkedList<Node> path = new LinkedList<Node>();
        Node curr = grid.WorldToGrid(Start);
        openList.Add(curr);
        openList.Sort();
        while(!found && openList.Count != 0) {
            //Curr is currently the best Node.
            curr = openList[0];
            openList.RemoveAt(0);
            List<Node> neigh = grid.GetBro(curr);
            for(int i = 0; i < neigh.Count; i++) {
                if(neigh[i].worldPos == end) {
                    Node parent = neigh[i];
                    while(parent != null) {
                        path.AddFirst(parent);
                        curr = parent;
                        parent = curr.Parent;
                    }
                    found = true;
                } else if(!openList.Contains(neigh[i]) && !closedList.Contains(neigh[i])) {
                    neigh[i].G = curr.G + Vector2.Distance(curr.worldPos, neigh[i].worldPos);
                    neigh[i].H = Vector2.Distance(neigh[i].worldPos, end) + grid.GetTerrain(neigh[i].worldPos);
                    openList.Add(neigh[i]);
                }
            }
            closedList.Add(curr);
        }
        return path;
    }

   
}
