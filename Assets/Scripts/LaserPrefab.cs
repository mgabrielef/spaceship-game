using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPrefab : MonoBehaviour
{
    public float laserSpeed = 15f; 
    private Rigidbody2D _rb2d;
    [SerializeField] 
    private ContagemPontos ContagemPontos;
    private string origem;

    void Start()
    {
        Destroy(this.gameObject, 0.7f);
        _rb2d = GetComponent<Rigidbody2D>();
        ContagemPontos = GameObject.Find("ContagemPontos").GetComponent<ContagemPontos>();
    }

    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + new Vector2(0, laserSpeed) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(this.gameObject.CompareTag("tiroPlayer")){
            if (other.CompareTag("inimigo")){
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                ContagemPontos.AddScore(1);
            }
        } else if(this.gameObject.CompareTag("tiroInimigo")){
            if(other.CompareTag("player")){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Time.timeScale = 0;
        } else if(other.CompareTag("inimigo")){
            Destroy(this.gameObject);
        }
        
        }
    }
}
