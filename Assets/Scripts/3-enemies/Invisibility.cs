using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake () 
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Ensure we have a valid SpriteRenderer component
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
            return;
        }

        spriteRenderer.enabled = false;
    }

    void Start()
    {
        // // Get the SpriteRenderer component attached to this GameObject
        // spriteRenderer = GetComponent<SpriteRenderer>();
        
        // // Ensure we have a valid SpriteRenderer component
        // if (spriteRenderer == null)
        // {
        //     Debug.LogError("SpriteRenderer component not found on this GameObject.");
        //     return;
        // }

        // spriteRenderer.enabled = false;
    }

    void OnEnable()
    {
        spriteRenderer.enabled = false;
    }

    void OnDisable()
    {
        spriteRenderer.enabled = true;
    }

}
