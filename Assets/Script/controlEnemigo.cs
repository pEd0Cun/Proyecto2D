using System.Collections;
using System.Collections.Generic;

using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;

public class controlEnemigo : MonoBehaviour

{
[Header("Deteccion de suelo")]
[SerializeField] private Transform DetectorSuelo;
[SerializeField] private float distanciaAlSuelo = 0.4f;
[SerializeField] private LayerMask layerSuelo;
private Movimiento movimiento;
Vector2 direccionMovimiento;
    // Start is called before the first frame update
    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        //comienza moverse a la derecha con 1f
        direccionMovimiento = new Vector2(1f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        // se voltea a la izquieda 
       movimiento.VoltearTransform(direccionMovimiento.x);
       DetectarSuelo();
       //comienze a moverse 
       movimiento.Moverse(direccionMovimiento.x); 
    }

   
// detector es un rayo del suelo 
    void DetectarSuelo()
    {
        RaycastHit2D hit = Physics2D.Raycast(DetectorSuelo.position, Vector2.down,distanciaAlSuelo * transform.localScale.y,layerSuelo);
        if(hit.collider == null)
        {
            // camina hacia la izquierda si detecta piso
            direccionMovimiento.x *= -1f;
        }
    }
}
