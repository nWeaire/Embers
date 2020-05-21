using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 m_v2Direction;
    Player m_oTarget;
    public float m_fSpeed = 4.0f;
    public float m_fAgroDistance = 20.0f;
    Vector3 m_v2StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_v2StartPosition = this.transform.position;
        m_oTarget = FindObjectOfType<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(this.transform.position, m_oTarget.transform.position) <= m_fAgroDistance)
        {
            follow();
        }
        else
        {
            idle();
        }
    }

    void idle()
    {
        if (Vector2.Distance(this.transform.position, m_v2StartPosition) > 1.0f)
        {
            Vector2 direction = m_v2StartPosition - this.transform.position;
            direction.Normalize();
            transform.Translate(direction * m_fSpeed * Time.deltaTime);
        }
        else { }
    }

    void follow()
    {
        m_v2Direction = m_oTarget.transform.position - this.transform.position;
        m_v2Direction.Normalize();
        transform.Translate(m_v2Direction * m_fSpeed * Time.deltaTime);
    }



}
