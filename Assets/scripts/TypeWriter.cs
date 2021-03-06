﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

class TypeWriter : MonoBehaviour, IPointerClickHandler
{
    Text textComp;
    string[] texts;
    bool next = false; // Go to next text part
    bool partEnded = false; // Text part has finished
    bool skipTypewriter = false;
    public bool finished = false;

    private void Awake()
    {
        textComp = GetComponent<Text>();
        texts = textComp.text.Split(new string[] { "<<__STOP__>>" }, StringSplitOptions.None);
        textComp.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (partEnded)
        {
            next = true;
        } else
        {
            skipTypewriter = true;
        }
    }

    public IEnumerator Show()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            partEnded = false;

            int tempText = 0;

            foreach (char c in texts[i])
            {
                if (skipTypewriter)
                {
                    textComp.text += texts[i].Remove(0, tempText);
                    skipTypewriter = false;
                    break;
                } else
                {
                    tempText++;
                    textComp.text += c;
                    yield return new WaitForSeconds(0.125f);
                }
            }

            partEnded = true;
            yield return new WaitUntil(() => next == true || texts.Length - 1 == i);
            next = false;
        }

        finished = true;
    }
}
