using UnityEngine;

public class GridSystem : MonoBehaviour {

    [SerializeField]
    private Vector2 size;
    [SerializeField]
    private GameObject DebugTile;
    [SerializeField]
    private float distanceBetweenTiles;
    private Vector3 tileSize;
    private GameObject[,] gridObjects;
    private void Start()
    {
        Vector3 tileSize;
        gridObjects = new GameObject[(int)size.x, (int)size.y];

        // x axis
        for(int i = 0; i < size.x; i++)
        {

            // y axis
            for (int j = 0; j < size.y; j++)
            {
                // create standard tile
                GameObject cTile = Instantiate(DebugTile);

                tileSize = new Vector3(1, 1, 1);
                // set correct position in grid
                cTile.transform.position = new Vector3(
                    (tileSize.x + distanceBetweenTiles) * i,
                    0,
                    (tileSize.z + distanceBetweenTiles) * j
                    );

                gridObjects[i,j] = cTile;
            }


        }
        Debug.Log(gridObjects);
    }

}
