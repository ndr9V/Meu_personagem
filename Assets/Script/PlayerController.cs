using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 move;
    [SerializeField] float _velocidade;
    [SerializeField] float _forcaPulo;
    [SerializeField] bool podePular;
    [SerializeField] Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        move.x = Input.GetAxisRaw("Horizontal");        
        _rb.velocity = new Vector2(move.x* _velocidade, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && podePular == false)
        {
            _rb.AddForce(Vector2.up * _forcaPulo, ForceMode2D.Impulse);
            podePular = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        podePular = false;
    }
}
