using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtiraController : MonoBehaviour
{
    public GameObject prefabLaser;
    [SerializeField]
    private float _speed = -4f;
    public float fireRate = 9f;
    private float nextFire;
    public float laserSpeed = -8f;
    private float _enemyLaserSpeed = -15f;
    private Rigidbody2D _rb2d;

    private void Start()
    {
        Destroy(this.gameObject, 3f);
        _rb2d = GetComponent<Rigidbody2D>();
    }
    

    void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + new Vector2(0, _speed) * Time.deltaTime);

        if (Time.time > nextFire)
        {
            GameObject laser = Instantiate(prefabLaser, transform.position + new Vector3(0, -1, 0), Quaternion.Euler(0, 0, 180));
            LaserPrefab laserScript = laser.GetComponent<LaserPrefab>();
            laserScript.laserSpeed = _enemyLaserSpeed; 
            nextFire = Time.time + fireRate;
        }

         
    }
}
