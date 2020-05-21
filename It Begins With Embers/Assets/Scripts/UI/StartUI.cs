using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartUI : MonoBehaviour
{

    public float timer = 0;
    public GameObject Button;
    public GameObject[] UiToGo;
    public GameObject[] UiToSetActive;
    public GameObject Fire;
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
        controls.Gameplay.Start.performed += ctx => StartGame();
    }

    void StartGame()
    {
        for (int i = 0; i < UiToGo.Length; i++)
        {
            UiToGo[i].SetActive(false);
        }
        Fire.SetActive(true);
        for (int i = 0; i < UiToSetActive.Length; i++)
        {
            UiToSetActive[i].SetActive(true);
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
