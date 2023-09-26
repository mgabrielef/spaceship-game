using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    private float _speed = 5f;
    private float _h, _v;

    private Rigidbody2D _rb2d;
    public GameObject prefabLaser;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        //transform.Translate(h*_speedX*Time.deltaTime,v*_speedY* Time.deltaTime, 0);
        Atirar();
    }

    private void Atirar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefabLaser, transform.position + new Vector3(0, 1, 0), transform.rotation);
        }
    }
    void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + new Vector2(_h,_v)*_speed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Destroy(other.gameObject);
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
