using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    private float _speed = 5f;
    private float _h, _v;

    private Rigidbody2D _rb2d;
    public GameObject prefabLaser;
    private float _playerLaserSpeed = 15f; // Defina a velocidade do laser do jogador aqui

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        Atirar();
    }

    private void Atirar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject laser = Instantiate(prefabLaser, transform.position + new Vector3(0, 1, 0), transform.rotation);
            LaserPrefab laserScript = laser.GetComponent<LaserPrefab>();
            laserScript.laserSpeed = _playerLaserSpeed; // Configura a velocidade do laser do jogador
        }
    }

    void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + new Vector2(_h, _v) * _speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("inimigo")){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        print("A colisão está acontecendo: stay");
    }

    void OnCollisionExit2D(Collision2D other)
    {
        print("A colisão deixou de acontecer: exit");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger enter!");
    }
}
