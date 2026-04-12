using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float velocidadEscalar = 3f;
    [SerializeField] private float multiplicadorCarrera = 1.8f;

    [Header("Salto")]
    [SerializeField] private float alturaSalto = 4f;
    [SerializeField] private int cantidadSaltosTotales = 2; 
    [SerializeField] private LayerMask capaDeSalto;

    [Range(0, 1)]
    [SerializeField] private float modificadorVelSalto = 0.5f;

    [Header("Escalar")]
    [SerializeField] private LayerMask capaEscalera;

    private int saltosRestantes;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private Animator animator;

    private float escalaGravedad;
    private bool estaCorriendo = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = cantidadSaltosTotales;
        animator = GetComponent<Animator>();

        saltosRestantes = cantidadSaltosTotales;
        escalaGravedad = rb.gravityScale;
    }

    void Update()
    {

        // Detectar si el jugador mantiene presionado Shift
        estaCorriendo = Input.GetKey(KeyCode.LeftShift);

        // Si toca el suelo, reiniciamos saltos
        if (EstaEnSuelo())
        {
            saltosRestantes = cantidadSaltosTotales;
        }
    }

    public void Moverse(float movimientoX)
    {
        float velocidadActual = estaCorriendo ? velocidadCaminata * multiplicadorCarrera : velocidadCaminata;

        rb.velocity = new Vector2(movimientoX * velocidadActual, rb.velocity.y);

        // Animaciones
        animator.SetBool("seEstaMoviendo", movimientoX != 0);
        animator.SetBool("estaCorriendo", estaCorriendo && movimientoX != 0);

        // Voltear personaje
        VoltearTransform(movimientoX);
    }

    public void VoltearTransform(float movimientoX)
    {
        if (movimientoX != 0)
        {
            transform.localScale = new Vector2(
                Mathf.Sign(movimientoX) * Mathf.Abs(transform.localScale.x),
                transform.localScale.y
            );
        }
    }

    /***
    public void Saltar(bool debeSaltar)
    {
        if (!debeSaltar) return;
        //Si aún tiene saltos disponibles
        if (saltosRestantes > 0)
        {
            float velInicialSalto = Mathf.Sqrt(alturaSalto * -2f * Physics2D.gravity.y * rb.gravityScale);
            rb.velocity = new Vector2(rb.velocity.x, velInicialSalto);
            saltosRestantes--;
        }
    }
    ***/

    public void Saltar(bool debeSaltar)
	{
    	if (debeSaltar)
    	{
        	if (boxCollider.IsTouchingLayers(capaDeSalto))
        	{
            	rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(-2f * escalaGravedad * Physics2D.gravity.y * alturaSalto));
        	}
    	}
    	else
    	{
        	if (rb.velocity.y > Mathf.Epsilon)
        	{
            	rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * modificadorVelSalto);
        	}
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