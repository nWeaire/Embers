using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort_Controller : MonoBehaviour
{
    BoxCollider2D[] tempList;
    public List<BoxCollider2D> m_aObjectsInFrame;
    
    // Update is called once per frame
    void Update()
    {
        m_aObjectsInFrame.Clear();
        tempList = FindObjectsOfType<BoxCollider2D>();
        for (int i = 0; i < tempList.Length; i++)
        {
            m_aObjectsInFrame.Add(tempList[i]);
        }

        m_aObjectsInFrame.Sort(YPositionComparison);
        for (int i = 0; i < m_aObjectsInFrame.Count; i++)
        {
            //Debug.Log(i + ". " + m_aObjectsInFrame[i].name + " at " + m_aObjectsInFrame[i].transform.position.y);
            m_aObjectsInFrame[i].GetComponent<SpriteRenderer>().sortingOrder = 1 + i;
        }
    }

    private int YPositionComparison(BoxCollider2D a, BoxCollider2D b)
    {
        if (a == null) return (b == null) ? 0 : -1;
        if (b == null) return 1;

        var ay = a.transform.position.y;
        var by = b.transform.position.y;
        return by.CompareTo(ay);
    }

}
