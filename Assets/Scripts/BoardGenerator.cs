using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [Tooltip("Number of rows on the board")]
    public int rows = 4;
    [Tooltip("Number of tiles in each row")]
    public int rowLength = 4;
    float xOffset;
    float yOffset;
    private GameObject row;
    private GameObject tile;
    [Tooltip("Starting positions for players")]
    public Vector3[] playerStartPositions = new Vector3[4];
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        xOffset = (rowLength -1) / 2f;
        yOffset = (rows -1) / 2f;
        playerStartPositions[0] = new Vector3(-xOffset, yOffset, 0);
        playerStartPositions[1] = new Vector3(xOffset, yOffset, 0);
        playerStartPositions[2] = new Vector3(xOffset, -yOffset, 0);
        playerStartPositions[3] = new Vector3(-xOffset, -yOffset, 0);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculates player starting positions based on the number of rows and row length
        row = transform.Find("Row").gameObject;
        tile = row.transform.GetChild(0).gameObject;
        for (int i = 0; i < rows; i++) {
            GameObject newRow = Instantiate(row, this.transform);
            newRow.transform.position = new Vector3(-xOffset, yOffset-i, 0);
            Debug.Log("Row " + i + " created");
            tile=newRow.transform.GetChild(0).gameObject;
            for (int j = 0; j < rowLength; j++) {
                GameObject newTile = Instantiate(tile.gameObject, newRow.transform);
                newTile.transform.position = new Vector3(j-xOffset, i-yOffset, 0);
                Debug.Log("Tile " + i + "."+ j + " created");
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
