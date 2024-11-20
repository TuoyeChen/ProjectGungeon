using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector2 Direction;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Enemy")
        {
            GameUI.Default.GamePass.SetActive(true);
            other.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
}