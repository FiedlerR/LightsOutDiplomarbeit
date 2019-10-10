﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    public bool isActiv;
    Animator m_animator;
    public GameObject scriptObject;
    public float scriptDelay;
    float m_time = 0;
    void Start()
    {
        m_animator = GetComponent<Animator>();
        useSwitch();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void useSwitch()
    {
   
        if (isActiv && m_time <= 0)
        {
            m_time = scriptDelay;
            StartCoroutine("timer");
            m_animator.SetBool("isActivated", false);
            isActiv = false;
            //Debug.Log("activ");
            // scriptObject.SendMessage("script");
        }
        else if (m_time <= 0)
        {
            m_time = scriptDelay;
            StartCoroutine("timer");
            m_animator.SetBool("isActivated", true);
            isActiv = true;
            //Debug.Log("!activ");
            //scriptObject.gameObject.SendMessage("script");
            //scriptObject.SendMessage("script");
        }
    }

    private IEnumerator timer()
    {
        while (m_time > 0)
        {
            m_time -= 1f;
           // Debug.Log(m_time);
            yield return new WaitForSeconds(1f);
        }

        scriptObject.SendMessage("script");
    }


}
