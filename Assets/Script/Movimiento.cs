using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float velocidadEscalar = 3f;
    [Header("Salto")]
    [SerializeField] private float alturaSalto = 4f;
    [SerializeField] private int cantidadSaltosTotales = 2; 
    [SerializeField] private LayerMask capaDeSalto;

    [SerializeField] private LayerMask capaEscalera;

    private int saltosRestantes;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private Animator animator;
    private float escalaGravedad = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = cantidadSaltosTotales;
        animator = GetComponent<Animator>();
        escalaGravedad = rb.gravityScale;
    }

    void Update()
    {
        // Si toca el suelo, reiniciamos saltos
        if (EstaEnSuelo())
        {
            saltosRestantes = cantidadSaltosTotales;
        }
    }

    public void Moverse(float movimientoX)
    {
        rb.velocity = new Vector2(movimientoX * velocidadCaminata, rb.velocity.y);
        animator.SetBool("estarParado",movimientoX !=0);
    }
    public void VoltearTransform(float movimientoX)
    {
            transform.localScale = new Vector2(Mathf.Sign(movimientoX) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
    public void Saltar(bool debeSaltar)
    {
        if (!debeSaltar) return;

        // Si aún tiene saltos disponibles
        if (saltosRestantes > 0)
        {
            float velInicialSalto = Mathf.Sqrt(-2 * alturaSalto * Physics2D.gravity.y * rb.gravityScale);
            rb.velocity = new Vector2(rb.velocity.x, velInicialSalto);
            saltosRestantes--;
        }
    }

    private bool EstaEnSuelo()
    {
        return boxCollider.IsTouchingLayers(capaDeSalto);
    }
    public void Escalar(float movimientoY)
    {
	    if (!boxCollider.IsTouchingLayers(capaEscalera))
	    {
		    rb.gravityScale = escalaGravedad;
		    return;
	    }
	    rb.velocity = new Vector2(rb.velocity.x, movimientoY * velocidadEscalar);
	    rb.gravityScale = 0f;
    }
}