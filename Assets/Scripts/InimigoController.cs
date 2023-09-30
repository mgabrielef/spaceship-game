using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6f;
    [SerializeField]
    private float _horizontalSpeed = 3f; // Velocidade horizontal quando na diagonal
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
            // Verifica se o inimigo atingiu a metade da tela verticalmente
            if (_rb2d.position.y <= 0)
            {
                // Inicia o movimento diagonal para baixo
                _moveDiagonal = true;
                int direction = Random.Range(0, 2) * 2 - 1; // Gera -1 ou 1 aleatoriamente
                _rb2d.velocity = new Vector2(_horizontalSpeed * direction, _speed); // Velocidade diagonal para baixo
            }
            else
            {
                // Movimento vertical para cima
                _rb2d.velocity = new Vector2(0, _speed);
            }
        }
    }
}
