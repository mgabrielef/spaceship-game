using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserInimgoPrefab : MonoBehaviour
{

    private float _speedY = 15f;

    private Rigidbody2D _rb2d;
    
    void Start()
    {
        Destroy(this.gameObject, 0.7f);
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position+new Vector2(0, _speedY)*Time.deltaTime);   
    }

    void OnTriggerEnter2DInimigo(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
