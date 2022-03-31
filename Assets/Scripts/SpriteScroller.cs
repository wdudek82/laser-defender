using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField]
    private Vector2 moveSpeed;

    private Material _material;

    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        var offset = moveSpeed * Time.deltaTime;
        _material.mainTextureOffset += offset;
    }
}
