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

    [SerializeField] Animator anima;
    [SerializeField] SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        move.x = Input.GetAxisRaw("Horizontal")*_velocidade * 1000 * Time.deltaTime ;        

        controleAnima();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(move.x, _rb.velocity.y);
    }

    public void controleAnima()
    {
        if (_rb.velocity.x != 0)
        {
            anima.SetBool("Move", true);
        }
        else
        {
            anima.SetBool("Move", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && podePular == true)
        {
            _rb.AddForce(Vector2.up * _forcaPulo, ForceMode2D.Impulse);
            anima.SetTrigger("Jump");
            podePular = false;
        }

        if (_rb.velocity.x > 0 && podePular == true)
        {
            sprite.flipX = false;
        }
        else if (_rb.velocity.x < 0 && podePular == true)
        {
            sprite.flipX = true;
        }

        if (podePular == true)
        {
            _velocidade = 3;
        }
        else
        {
            _velocidade = 1.5f;

        }

        anima.SetBool("noChao", podePular);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "chao")
        {
            podePular = true;
        }
    }
}
