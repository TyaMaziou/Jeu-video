using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicImageManager : MonoBehaviour
{
    [SerializeField] Sprite[] imagesCinematic;
    SpriteRenderer spriteRenderer;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (index <= imagesCinematic.Length) 
            {
                Debug.Log(index);
                spriteRenderer.sprite = imagesCinematic[index];
                index++;
                Debug.Log(index);
            }
        }
    }
}
