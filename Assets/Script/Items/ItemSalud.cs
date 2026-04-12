using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSalud : MonoBehaviour
{
    [SerializeField] private float saludBrindada = 100;
    [SerializeField] private AudioClip sonidoRecogerItem;

    private bool fueActivado = false;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Seguridad: agregar AudioSource si no existe
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fueActivado) return;

        if (collision.gameObject.TryGetComponent<Salud>(out Salud salud))
        {
            fueActivado = true;

            // Aumentar vida
            salud.RecuperarSalud(saludBrindada);

            // Reproducir sonido
            ReproducirSonido();

            // Ocultar sprite
            if (spriteRenderer != null)
                spriteRenderer.enabled = false;

            // Destruir objeto después de un pequeño tiempo seguro
            Destroy(gameObject, 1f);
        }
    }

    private void ReproducirSonido()
    {
        if (sonidoRecogerItem != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoRecogerItem);
        }
    }
}