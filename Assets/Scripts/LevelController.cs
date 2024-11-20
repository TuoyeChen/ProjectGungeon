using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelController : MonoBehaviour
{
    public TileBase GroundTile;
    public Tilemap GroundTilemap;

    public Player Player;
    public Enemy Enemy;

    /*
     * 1 代表地块
     * @ 主角
     * e 敌人
     */
    public List<string> InitRoom { get; set; } =
        new List<string>()
        {
            "1111111111",
            "1        1",
            "1        1",
            "1        1",
            "1        1",
            "1  @     1",
            "1        1",
            "1     e  1",
            "1        1",
            "1111111111",
        };

    private void Awake()
    {
        Player.gameObject.SetActive(false);
        Enemy.gameObject.SetActive(false);
    }

    void Start()
    {
        for (var i = 0; i < InitRoom.Count; i++)
        {
            var rowCode = InitRoom[i];
            for (int j = 0; j < rowCode.Length; j++)
            {
                var code = rowCode[j];
                var x = j;
                var y = InitRoom.Count - i;

                if (code == '1')
                {
                    GroundTilemap.SetTile(new Vector3Int(x, y, 0), GroundTile);
                }
                else if (code == '@')
                {
                    var player = Instantiate(Player);
                    player.transform.position = new Vector3(x + 0.5f, y + 0.5f, 0);
                    player.gameObject.SetActive(true);
                    Global.Player = player;
                }
                else if (code == 'e')
                {
                    var enemy = Instantiate(Enemy);
                    enemy.transform.position = new Vector3(x + 0.5f, y + 0.5f, 0);
                    enemy.gameObject.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update() { }
}
