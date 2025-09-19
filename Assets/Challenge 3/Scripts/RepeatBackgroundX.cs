using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private float backgroundHeight;
    private float forceLimitHeight;
    private PlayerControllerX player;

    private void Start()
    {
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
        backgroundHeight = GetComponent<BoxCollider>().size.y;
        forceLimitHeight = backgroundHeight * 0.75f;
        player = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }

        // indicate if player height is 3/4 ways up
        if (player.transform.position.y > forceLimitHeight)
        {
            player.isLowEnough = false;
        }
        else
        {
            player.isLowEnough = true;
        }

        // indicate if player has exceeded the background height
        if (player.transform.position.y > backgroundHeight)
        {
            player.shouldBounceBack = true;
        }
        else
        {
            player.shouldBounceBack = false;
        }
    }

 
}


