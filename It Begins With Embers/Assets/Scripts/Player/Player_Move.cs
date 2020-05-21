using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    float m_fHorizontalInput = 0;
    float m_fVerticalInput = 0;
    public float m_fSpeed = 10.0f;
    SpriteRenderer m_Sprite;
    Animator m_Animator;
    public GameObject torch;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = this.GetComponent<Animator>();
        m_Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_fHorizontalInput = Input.GetAxisRaw("Horizontal");
        m_fVerticalInput = Input.GetAxisRaw("Vertical");
        Move(m_fHorizontalInput, m_fVerticalInput);

    }

    void Move(float horizontal, float vertical)
    {
        Vector2 movement = new Vector2(horizontal, vertical);

        // Check for things before final movement


        updateAnimation(movement);
        movement.Normalize();
        transform.Translate(movement * Time.deltaTime * m_fSpeed);
    }

    void updateAnimation(Vector2 DirectionXY)
    {
        if(DirectionXY.x > 0)
        {
            m_Sprite.flipX = true;
            torch.transform.localPosition = new Vector3(0.35f, 0.2f);
        }
        else if (DirectionXY.x < 0)
        {
            m_Sprite.flipX = false;
            torch.transform.localPosition = new Vector3(-0.35f, 0.2f);
        }
        else { }

        if(DirectionXY == Vector2.zero)
        {
            m_Animator.SetBool("Move", false);
        }
        else
        {
            m_Animator.SetBool("Move", true);
        }

    }
}
