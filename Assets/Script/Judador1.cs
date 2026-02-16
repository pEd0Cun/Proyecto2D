using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador1 : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;

    private Rigidbody2D rb;
    private float movimientoX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movimientoX * velocidad, rb.velocity.y);
    }

    // 👉 ESTE MÉTODO aparecerá en Player Input
    public void AlMoverse(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        movimientoX = input.x;
    }
}
