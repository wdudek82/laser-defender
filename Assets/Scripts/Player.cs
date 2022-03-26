using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;

    [Header("Padding")]
    [SerializeField]
    private float paddingLeft;

    [SerializeField]
    private float paddingRight;

    [SerializeField]
    private float paddingTop;

    [SerializeField]
    private float paddingBottom;

    private Vector2 _rawInput;
    private Vector2 _minBounds;
    private Vector2 _maxBounds;

    void Update()
    {
        Move();
    }

    private void Start()
    {
        InitBounds();
    }

    void InitBounds()
    {
        var mainCamera = Camera.main;
        if (!mainCamera)
        {
            throw new Exception("Camera not found!");
        }

        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }

    void Move()
    {
        var delta = _rawInput * moveSpeed * Time.deltaTime;
        var newPos = new Vector2();
        var position = transform.position;
        newPos.x = Mathf.Clamp(position.x + delta.x, _minBounds.x + paddingLeft, _maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(position.y + delta.y, _minBounds.y + paddingBottom, _maxBounds.y - paddingTop);
        transform.position = newPos;
    }
}
