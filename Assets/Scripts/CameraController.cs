using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Global.Player)
        {
            var cameraPosition = Global.Player.transform.position + Vector3.up * 0.5f;
            cameraPosition.z = -10;
            transform.position = cameraPosition;
        }
    }
}
