using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public int mineCount = 20;
    public GameObject tilePrefab;
    
    private Tile[,] tiles;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        tiles = new Tile[width, height]
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tileObject = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                tileObject.transform.parent = transform;

                tileObject tile = tileObject.GetComponent<Tile>():
                tiles[x, y] = tile;
            }
        }

        PlaceMines();
        CalculateAdjacentMines();
    }

    void PlaceMines()
    {
        for (int i = 0; i < mineCount; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            while (tiles[x, y].isMine)
            {
                x = Random.Range(0, width);
                y = Random.Range(0, height);
            }

            tiles[x, y].isMine = true;
        }
    }

    void CalculateAdjacentMines()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (tiles[x, y].isMine)
                    continue;
                
                int adjacentMines = 0;

                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = x + dx;
                        int ny = y + dy;

                        if (nx >= 0 && nx < width && ny >= 0 && ny < height && tiles[nx, ny].isMine)
                        {
                            adjacentMines++;
                        }
                    }
                }
                
                tiles[x, y].adjacentMines = adjacentMines;
            }
        }
    }
}