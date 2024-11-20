using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelController : MonoBehaviour
{
    public TileBase GroundTile;
    public Tilemap GroundTilemap;

    public Player Player;
    public Enemy Enemy;
    public Final Final;

    /*
     * 1 代表地块
     * @ 主角
     * e 敌人
     * # 终点
     */
    public List<string> InitRoom { get; set; } =
        new List<string>()
        {
            "1111111111",
            "1        1",
            "1        1",
            "1        1",
            "1         ",
            "1  @      ",
            "1        1",
            "1        1",
            "1        1",
            "1111111111",
        };
    public List<string> NormalRoom { get; set; } =
        new List<string>()
        {
            "1111111111",
            "1        1",
            "1        1",
            "1  e     1",
            "          ",
            "          ",
            "1        1",
            "1     e  1",
            "1        1",
            "1111111111",
        };
    public List<string> FinalRoom { get; set; } =
        new List<string>()
        {
            "1111111111",
            "1        1",
            "1        1",
            "1        1",
            "    #    1",
            "         1",
            "1        1",
            "1        1",
            "1        1",
            "1111111111",
        };

    private void Awake()
    {
        Player.gameObject.SetActive(false);
        Enemy.gameObject.SetActive(false);
    }

    void Start() { 
        var currentRoomStartPosX = 0;
        GenerateRoom(currentRoomStartPosX, InitRoom);
        currentRoomStartPosX += InitRoom.First().Length + 2;
        GenerateRoom(currentRoomStartPosX, NormalRoom);
        currentRoomStartPosX += InitRoom.First().Length + 2;
        GenerateRoom(currentRoomStartPosX, FinalRoom);
    }
    

    // Update is called once per frame
    void Update() { }

    void GenerateRoom(int startPosX, List<string> roomCode)
    {
        for (var i = 0; i < roomCode.Count; i++)
        {
            var rowCode = roomCode[i];
            for (int j = 0; j < rowCode.Length; j++)
            {
                var code = rowCode[j];
                var x = startPosX + j;
                var y = roomCode.Count - i;

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
                else if (code == '#')
                {
                    var enemy = Instantiate(Final);
                    enemy.transform.position = new Vector3(x + 0.5f, y + 0.5f, 0);
                    enemy.gameObject.SetActive(true);
                }
            }
        }
    }
}
