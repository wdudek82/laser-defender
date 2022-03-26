using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;

    private Vector2 _rawInput;

    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
        Debug.Log(_rawInput);
    }

    private void Move()
    {
        var delta = _rawInput * moveSpeed * Time.deltaTime;
        transform.position += (Vector3)delta;
    }
}
