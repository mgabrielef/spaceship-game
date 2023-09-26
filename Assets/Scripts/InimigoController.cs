using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    [SerializeField]
    private float _speed = -8f;

    private Rigidbody2D _rb2d;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + new Vector2(0, _speed) * Time.deltaTime);
    }
}
