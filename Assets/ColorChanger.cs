using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color disactiveColor, activeColor;


    public void SetActiveSpriteColor(SpriteRenderer sprite)
    {
        sprite.color = activeColor;
    }
}
