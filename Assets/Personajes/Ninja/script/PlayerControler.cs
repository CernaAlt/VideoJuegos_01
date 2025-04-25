using System;
using UnityEngine;



public class PlayerControler : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    //Start is called once before the first execution of Update after the MonoBehaviour is created

    public float velocidadMovimiento = 10f;
    public float fuerzaSalto = 20f;
    public LayerMask capaSuelo;
    public Transform verificadorSuelo;
    public float radioVerificacion = 0.2f;
    bool enSuelo;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //logs


        moverseHorizontalmente();
        setupSalto();

    }

    void setupSalto()
    {
        // Verifica si está en el suelo antes de permitir el salto
        enSuelo = Physics2D.OverlapCircle(verificadorSuelo.position, radioVerificacion, capaSuelo);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    void moverseHorizontalmente()
    {
        float movimiento = 0f;
        animator.SetInteger("Estado", 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movimiento = velocidadMovimiento;
            sr.flipX = false;
            animator.SetInteger("Estado", 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimiento = -velocidadMovimiento;
            sr.flipX = true;
            animator.SetInteger("Estado", 1);
        }

        rb.linearVelocity = new Vector2(movimiento, rb.linearVelocity.y);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Perdimos una vida por colisión con enemigo");
        }

        Debug.Log("Colisionado con: " + collision.gameObject.name);

    }
}
