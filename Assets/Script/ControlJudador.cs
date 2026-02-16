using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlJudador : MonoBehaviour


{
    private Movimiento movimiento;
    private Vector2 entradaControl;
    // Start is called before the first frame update
    void Start()
    {
        movimiento = GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.Moverse(entradaControl.x);
    }
    public void AlMoverse(InputAction.CallbackContext context)
    {
        entradaControl = context.ReadValue<Vector2>();
    }
}
