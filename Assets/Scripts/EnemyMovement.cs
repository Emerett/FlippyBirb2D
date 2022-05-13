using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : PoweupMovement
{
    public SpriteRenderer displayedSprite;
    public Sprite [] enemySprite;

    private void Start()
    {
        displayedSprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        FlipSprite();
        TrackPlayer();
    }

    void FlipSprite()
    {
        if (player != null)
        {
            if (player.transform.position.y > transform.position.y)
            {
                displayedSprite.sprite = enemySprite[1];
            }

            else
            {
                displayedSprite.sprite = enemySprite[0];
            }
        }
    }
}
