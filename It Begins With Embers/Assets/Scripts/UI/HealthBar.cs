using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    public Slider m_Slider;

    public void setHealth(int Health)
    {
        m_Slider.value = Health;
    }
}
