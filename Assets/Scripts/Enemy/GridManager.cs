using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    [Header("Tilemaps")]
    public Tilemap groundTilemap;     // Tilemap do chão
    public List<Tilemap> obstacleTilemaps = new(); // Tilemaps de obstáculos
    private Dictionary<Vector2Int, Node> grid = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        GenerateGrid();
    }

    private void GenerateGrid()
    {
        BoundsInt bounds = groundTilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPos = new(x, y, 0);

                if (!groundTilemap.HasTile(cellPos))
                    continue;

                Vector2Int gridPos = new(x, y);
                bool isObstacle = false;
                foreach (Tilemap obstacleMap in obstacleTilemaps)
                {
                    if (obstacleMap.HasTile(cellPos))
                    {
                        isObstacle = true;
                        break;
                    }
                }


                grid[gridPos] = new Node(gridPos, !isObstacle);
            }
        }
    }

    public Node GetNode(Vector2 worldPosition)
    {
        Vector3Int cell = groundTilemap.WorldToCell(worldPosition);
        Vector2Int gridPos = new(cell.x, cell.y);

        if (grid.TryGetValue(gridPos, out Node node))
            return node;

        return null;
    }

    public Node GetNode(Vector2Int gridPosition)
    {
        if (grid.TryGetValue(gridPosition, out Node node))
            return node;

        return null;
    }

    public List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new();

        Vector2Int[] directions = {
            Vector2Int.up, Vector2Int.down,
            Vector2Int.left, Vector2Int.right
        };

        foreach (var dir in directions)
        {
            Vector2Int neighborPos = node.gridPosition + dir;
            if (grid.TryGetValue(neighborPos, out Node neighbor) && neighbor.isWalkable)
                neighbors.Add(neighbor);
        }

        return neighbors;
    }
}
