using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public GameObject m_oFire; // Fire
    public GameObject m_oTorch; // Torch object
    public GameObject m_oAButton; // Button above fire
    public PlayerControls controls; // Input controls

    float m_oTorchTimer = 0; // Timer for torch
    public float m_oTorchTimeLimit = 10.0f; // Time the torch lasts
    bool m_bTorch = false; // If the torch is on or off

    public int m_nHealth = 10;
    public float m_nSafeDistance = 5.0f;
    public int m_nDarknessDamage = 1;
    public float m_nDarknessTimer = 0;
    private bool m_isDead = false;

    private HealthBar m_healthBar;

    private void Awake()
    {
        controls = new PlayerControls(); // Creates player controls
        m_healthBar = FindObjectOfType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(this.transform.position, m_oFire.transform.position) <= 1f) // Checks if with in 1m of the fire
        {
            m_oAButton.SetActive(true); // Sets button to active
            controls.Gameplay.Start.performed += xtc => LightTorch(); // Checks if A button clicked and lights torch
        }
        else
        {
            m_oAButton.SetActive(false); // If further then 1m turn off button
        }

        if(m_bTorch) // If torch is on
        {
            updateTorch(); // Update Torch
        }

        if(!m_bTorch && Vector2.Distance(this.transform.position, m_oFire.transform.position) >= m_nSafeDistance && !m_isDead)
        {
            Darkness();
        }

        if(m_nHealth <= 0)
        {
            m_isDead = true;        
        }

        if(m_isDead)
        {
            m_oFire.SetActive(false);
            m_oTorch.SetActive(false);
        }


    }

    void LightTorch()
    {
        if(!m_bTorch) // If torch isn't on
        {
            m_oTorch.SetActive(true); // Turn the torch on
            m_bTorch = true; // Set bool to true
            m_oTorchTimer = m_oTorchTimeLimit; // resets torch timer
        }
        else if (m_bTorch && Vector2.Distance(this.transform.position, m_oFire.transform.position) <= 1f)
        {
            m_oTorchTimer = m_oTorchTimeLimit; // If torch is already lit reset torch timer
        }
    }

    void updateTorch()
    {
        m_oTorchTimer -= Time.deltaTime; // Update the timer
        float temp = m_oTorchTimer / m_oTorchTimeLimit;
        m_oTorch.GetComponentInChildren<Light2D>().intensity = 1 * temp;
        if(m_oTorchTimer <= 0)
        {
            m_bTorch = false;
            m_oTorch.SetActive(false);
        }
    }

    void Darkness()
    {
        m_nDarknessTimer += Time.deltaTime;
        if(m_nDarknessTimer >= 1.0f)
        {
            m_nHealth -= m_nDarknessDamage;
            m_healthBar.setHealth(m_nHealth);
            m_nDarknessTimer = 0.0f;
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
