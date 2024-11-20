using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player Player;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = Player.transform.position + Vector3.up * 0.5f;
        cameraPosition.z = -10;
        transform.position = cameraPosition;
        
    }
}