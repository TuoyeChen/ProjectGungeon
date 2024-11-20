using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerBullet PlayerBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, vertical) * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            var playerBullet = Instantiate(PlayerBullet);
            playerBullet.transform.position = transform.position;
            playerBullet.Direction = Vector2.right;
            playerBullet.gameObject.SetActive(true);
        }
        
    }
}
