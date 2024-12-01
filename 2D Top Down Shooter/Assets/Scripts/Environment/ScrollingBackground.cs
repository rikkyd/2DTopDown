using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed;
    public Transform[] background;
    private Vector3 direction;

    void Start()
    {
        direction = new Vector3(0, -1, 0); // Background scrolls downward
    }

    void Update()
    {
        positionUpdate();
        checkPosition();
    }

    private void checkPosition()
    {
        // Check if background[0] has moved below the threshold
        if (background[0].position.y <= -12)
        {
            moveToTop(0);
        }

        // Check if background[1] has moved below the threshold
        if (background[1].position.y <= -12)
        {
            moveToTop(1);
        }
    }

    private void moveToTop(int index)
    {
        // Move the background to the top of the other background
        if (index == 0)
        {
            background[0].position = background[1].position + new Vector3(0, 12, 0);
        }
        else if (index == 1)
        {
            background[1].position = background[0].position + new Vector3(0, 12, 0);
        }
    }

    private void positionUpdate()
    {
        // Move both backgrounds downward
        background[0].position += direction * Time.deltaTime * speed;
        background[1].position += direction * Time.deltaTime * speed;
    }
}
