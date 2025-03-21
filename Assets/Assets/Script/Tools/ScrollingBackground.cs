using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float backgroundSpeed = 0.1f;
    float spriteSize;

    private Vector3 startPosition;
    public SpriteRenderer backgroundSprite;

    void Start()
    {
        startPosition = transform.position;
        spriteSize = backgroundSprite.sprite.bounds.size.x * transform.localScale.x;
    }

    void Update()
    {
        
            float newPosition = Mathf.Repeat(Time.time * backgroundSpeed, 2*spriteSize);
            transform.position = startPosition + Vector3.left * newPosition;
    
    }
}