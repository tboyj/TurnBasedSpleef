using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [Tooltip("Number of rows on the board")]
    public int rows;
    [Tooltip("Number of tiles in each row")]
    public int rowLength;
    private GameObject row;
    private GameObject tile;
    [Tooltip("Starting positions for players")]
    public Vector3[] playerStartPositions = new Vector3[4];
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        playerStartPositions[0] = new Vector3(0, 0, 0);
        playerStartPositions[1] = new Vector3((1 * rowLength) - 1, 0, 0);
        playerStartPositions[2] = new Vector3(0, (-1 * rows) + 1, 0);
        playerStartPositions[3] = new Vector3((1 * rowLength) - 1, (-1 * rows) + 1, 0);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculates player starting positions based on the number of rows and row length
        row = transform.Find("Row").gameObject;
        tile = row.transform.GetChild(0).gameObject;
        for (int i = 0; i < rows; i++) {
            GameObject newRow = Instantiate(row, this.transform);
            newRow.transform.position = new Vector3(0, -i, 0);
            Debug.Log("Row " + i + " created");
            tile=newRow.transform.GetChild(0).gameObject;
            for (int j = 0; j < rowLength; j++) {
                GameObject newTile = Instantiate(tile.gameObject, newRow.transform);
                newTile.transform.position = new Vector3(j, -i, 0);
                Debug.Log("Tile " + j + " created");
            }
            GameObject.Destroy(tile);
        }
        GameObject.Destroy(row);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
