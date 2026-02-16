using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
 
public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadCaminata = 4f;
    //r[SerializeField] private float alturaSalto = 4f;
 
    private Rigidbody2D rb;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    public void Moverse(float movimientoX)
    {
        rb.velocity = new Vector2(movimientoX * velocidadCaminata, rb.velocity.y);
    }
 
}