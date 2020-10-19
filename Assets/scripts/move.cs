using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private GameObject endPosition;
    [SerializeField]
    private AudioSource arriveSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != endPosition.transform.position)
        {
            float xPos = transform.position.x + 0.01f;
            float yPos = transform.position.y + 0.01f;

            float xDestination = endPosition.transform.position.x;
            float yDestination = endPosition.transform.position.y;

            if (xPos > xDestination) { xPos = xDestination; }
            if (yPos > yDestination) { yPos = yDestination; }

            transform.position = new Vector2(xPos, yPos);

            if (transform.position == endPosition.transform.position)
            {
                arriveSound.Play();
            }
        }
    }
}
