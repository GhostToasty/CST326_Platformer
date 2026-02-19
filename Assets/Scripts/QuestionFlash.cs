using System;
using UnityEngine;

public class QuestionFlash : MonoBehaviour
{
    public float offsetAmount = 0.2f;
    
    Renderer _render;
    private float offset = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _render = GetComponent<Renderer>();
        InvokeRepeating(nameof(OffsetMaterial), 0.2f, 0.2f);
    }

    void OffsetMaterial()
    {
        offset = offsetAmount + offset;
        _render.material.mainTextureOffset = new Vector2(0, offset);
    }
}
