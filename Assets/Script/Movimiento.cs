using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
 
public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float alturaSalto = 4f;
    [SerializeField] private float velInicialSalto = 2f;
    [SerializeField] private LayerMask capaDeSalto;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
 
    public void Moverse(float movimientoX)
    {
        rb.velocity = new Vector2(movimientoX * velocidadCaminata, rb.velocity.y);
    }

    public void Saltar(bool debeSaltar)

    {
        if (!boxCollider.IsTouchingLayers(capaDeSalto)){ return;}

        if(debeSaltar)
        {
            //Mejoramiento del Salto
            //rb.velocity = new Vector2(rb.velocity.x, velInicialSalto);
            velInicialSalto = Mathf.Sqrt(-2 * alturaSalto * Physics2D.gravity.y * rb.gravityScale);
            rb.velocity = new Vector2(rb.velocity.x, velInicialSalto);
        }
    }
 
}