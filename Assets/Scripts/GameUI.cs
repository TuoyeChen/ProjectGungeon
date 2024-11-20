using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Default;

    public GameObject GamePass;
    public GameObject GameOver;

    private void Awake()
    {
        Default = this;
    }

    private void OnDestroy()
    {
        Default = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        GamePass
            .transform.Find("BtnRestart")
            .GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
            });
        GameOver
            .transform.Find("BtnRestart")
            .GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
            });
    }

    // Update is called once per frame
    void Update() { }
}
