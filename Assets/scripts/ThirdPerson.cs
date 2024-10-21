using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private Camera cam;
    [SerializeField]private float smootthing;
    private float velocidadRotacion;
    CharacterController controller;
    private Animator anim;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
       
        if (input.sqrMagnitude > 0)
        {
            anim.SetBool("walking", true);

            //se calcula el angulo al que terngo que rotarme en funcion de los imputs y orientacion de camara
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            float angulosuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion , smootthing);

            transform.eulerAngles = new Vector3(0, angulosuave, 0);
            Vector3 movimiento = Quaternion.Euler(0, angulosuave, 0) * Vector3.forward;
            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            anim.SetBool("walking", false);
        }


    }
}
