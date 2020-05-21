using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Quest1 : MonoBehaviour
{
    public PlayerControls controls; // Input controls

    public Text questLog = null;
    private PlayerItems items = null;
    private int stickAmount = 10;
    private int vineAmount = 10;
    public bool isQuestComplete = false;
    public GameObject yButton = null;
    public GameObject fire = null;
    private Player player = null;

    private void Awake()
    {
        controls = new PlayerControls(); // Creates player controls
        items = FindObjectOfType<PlayerItems>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isQuestComplete)
        {
            questLog.text = "Objective: Build a Hut \n" + "Sticks: " + items.stickCount + "/10 \n" + "Vines: " + items.vineCount + "/10";
        }
        if(items.stickCount == stickAmount && items.vineCount == vineAmount && !isQuestComplete)
        {
            Debug.Log("Quest Complete");
            isQuestComplete = true;
            questLog.text = "Objective: Build a Hut \n" + "Complete";
        }
        if(isQuestComplete && Vector2.Distance(player.transform.position, fire.transform.position) <= 1.0f)
        {
            yButton.SetActive(true);
            controls.Gameplay.Y.performed += xtc => LoadNewScene();
        }
        else
        {
            yButton.SetActive(false);
        }
    }

    void LoadNewScene()
    {
        
        SceneManager.LoadScene(1);
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
