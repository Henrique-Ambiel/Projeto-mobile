using UnityEngine;

public class Node
{
    public Vector2Int gridPosition;
    public bool isWalkable;
    public Node parent; // para reconstrução do caminho

    public int gCost;
    public int hCost;
    public int FCost => gCost + hCost;

    public Node(Vector2Int position, bool walkable)
    {
        gridPosition = position;
        isWalkable = walkable;
    }
}
