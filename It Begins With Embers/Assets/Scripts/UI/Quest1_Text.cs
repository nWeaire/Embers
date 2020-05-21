using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Quest1_Text : MonoBehaviour
{
    PlayerItems items;

    private void Start()
    {
        items = FindObjectOfType<PlayerItems>();
    }

    private void Update()
    {
        this.GetComponent<Text>().text = "Objective: Build a Hut \n" + "Sticks: " + items.stickCount + "/10 \n" + "Vines: " + items.vineCount + "/10";
    }

}
