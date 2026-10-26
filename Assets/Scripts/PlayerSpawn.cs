using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject p;
    private BoardGenerator boardGenerator;
    void Awake()
    {
    }
    void Start()
    {
        p = GameObject.Find("Player").gameObject;
        boardGenerator = GameObject.Find("Board").GetComponent<BoardGenerator>();

        for (int i = 0; i < 4; i++) {
            if (boardGenerator.playerStartPositions[i] == null) {
                Debug.LogError("Player start position " + i + " is not set.");
                continue;
            }
            GameObject player = Instantiate(p, boardGenerator.playerStartPositions[i], Quaternion.identity);
            player.name = "Player" + (i + 1);
        }
        GameObject.Destroy(p);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
