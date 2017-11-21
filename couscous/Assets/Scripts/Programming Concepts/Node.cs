using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public Vector2 worldPos;
    public bool pass;
    public int gridX;
    public int gridY;
    private Node parent;
    LayerMask mask;

    private float g;
    private float h;

    public Node Parent {
        get {
            return parent;
        }

        set {
            parent = value;
        }
    }

    public float G {
        get {
            return g;
        }

        set {
            g = value;
        }
    }

    public float H {
        get {
            return h;
        }

        set {
            h = value;
        }
    }

    public Node(bool _pass, Vector2 _worldPos, int _gridX, int _gridY) {
        worldPos = _worldPos;
        pass = _pass;
        gridX = _gridX;
        gridY = _gridY;
        G = -1;
        H = -1;
        mask = -1;
    }

    public Node() {
        worldPos = Vector2.zero;
        pass = false;
        gridX = 0;
        gridY = 0;
        G = -1;
        H = -1;
        mask = -1;
    }

    public Node(int x, int y) {
        worldPos = Vector2.zero;
        pass = false;
        gridX = x;
        gridY = y;
        G = -1;
        H = -1;
        mask = -1;
    }

    public float getFCost() {
        return G + H;
    }

    override public string ToString() {
        return "At: [" + gridX + ", " + gridY + "] G,H [" + G + ", " + H + "] " + "WorldPos: " + worldPos.ToString(); 
    }

    public int CompareTo(Node obj) {
        return this.getFCost().CompareTo(obj.getFCost());
    }

    public LayerMask getTerrain() {
        for(int i = 0; i < 31 && mask == -1; i++) {
            if(Physics2D.OverlapCircle(worldPos,.1f, i) != null) {
                mask = i;
            }
        }
        return mask;
    }

}
