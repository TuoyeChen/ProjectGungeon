using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player Player;
    public EnemyBullet EnemyBullet;

    public enum States
    {
        FollowPlayer,
        Shoot,
    }

    public States State = States.FollowPlayer;

    public float FollowPlayerSeconds = 3.0f;
    public float CurrentSeconds = 0f;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == States.FollowPlayer)
        {
            if (CurrentSeconds >= FollowPlayerSeconds)
            {
                State = States.Shoot;
                CurrentSeconds = 0f;
            }
            var directionToPlayer = (Player.transform.position - transform.position).normalized;
            transform.Translate(directionToPlayer * Time.deltaTime);
            CurrentSeconds += Time.deltaTime;
        }
        else if (State == States.Shoot)
        {
            CurrentSeconds += Time.deltaTime;

            if (CurrentSeconds >= 1f)
            {
                State = States.FollowPlayer;
                FollowPlayerSeconds = Random.Range(2f, 4f);
                CurrentSeconds = 0f;
            }

            if (Time.frameCount % 20 == 0)
            {
                var directionToPlayer = (Player.transform.position - transform.position).normalized;
                var playerBullet = Instantiate(EnemyBullet);
                playerBullet.transform.position = transform.position;
                playerBullet.Direction = directionToPlayer;
                playerBullet.gameObject.SetActive(true);
            }
        }
    }
}
