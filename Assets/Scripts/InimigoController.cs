using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6f;
    [SerializeField]
    private float _horizontalSpeed = 3f; 
    private bool _moveDiagonal = false;

    private Rigidbody2D _rb2d;

    private void Start()
    {
        Destroy(this.gameObject, 3f);
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_moveDiagonal)
        {
            if (_rb2d.position.y <= 0)
            {
                _moveDiagonal = true;
                int direction = Random.Range(0, 2) * 2 - 1; 
                _rb2d.velocity = new Vector2(_horizontalSpeed * direction, _speed); 
            }
            else
            {
                _rb2d.velocity = new Vector2(0, _speed);
            }
        }
    }
}
