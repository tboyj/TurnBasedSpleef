using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> PlayerList = new List<GameObject>();
    public const int TotalPlayers = 4;
    public Color[] playerColors = {Color.blue, Color.red, Color.green, Color.orange};
    private GameObject p;
    private BoardGenerator boardGenerator;
    void Awake()
    {
    }
    void Start()
    {
        p = GameObject.Find("Player").gameObject;
        boardGenerator = GameObject.Find("Board").GetComponent<BoardGenerator>();

        for (int i = 0; i < TotalPlayers; i++) {
            if (boardGenerator.playerStartPositions[i] == null) {
                Debug.LogError("Player start position " + i + " is not set.");
                continue;
            }
            GameObject player = Instantiate(p, boardGenerator.playerStartPositions[i], Quaternion.identity);
            player.GetComponent<SpriteRenderer>().color = playerColors[i];
            player.name = "Player" + (i + 1);
            PlayerList.Add(player);
        }
        GameObject.Destroy(p);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
