using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
	[SerializeField] private float ataque = 1f;
	[SerializeField] private float velocidad = 5f;
	
	public float tiempoDeVida = 3f;

	private Rigidbody2D rb;
	private EquipoEnum equipoEnum;

	private void Awake()
	{
    	rb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, tiempoDeVida);
	}

	public void AjustarEquipoEnum(EquipoEnum equipoEnum)
	{
    	this.equipoEnum = equipoEnum;
	}

	public void AjustarDireccion(Vector2 direccion)
	{
    	rb.velocity = direccion.normalized * velocidad;
	}

private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Golpe a: " + other.gameObject.name);

  
    if (other.CompareTag("Background")) return;

  
    if (other.CompareTag("Enemy"))
    {
        if (other.TryGetComponent<Salud>(out Salud saludDelOtro) &&
            other.TryGetComponent<Equipo>(out Equipo equipoDelOtro))
        {
            if (equipoDelOtro.EquipoActual != equipoEnum)
            {
                saludDelOtro.PerderSalud(ataque);
            }
        }
    }


    Destroy(gameObject);
}
}
