using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class firstPerson : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float vidas;

    [Header("Movimiento")]

    [SerializeField] private float velocidadMovimiento;
    private Camera cam;
    [SerializeField] private float magnitudGravedad;
    private Vector3 movimientoVertical;
    [SerializeField] private float alturaSalto;

    [Header("Deteccion Suelo")]
    [SerializeField] Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] LayerMask queEsSuelo;

    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();

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
            //se calcula el angulo al que terngo que rotarme en funcion de los imputs y orientacion de camara
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0)* Vector3.forward;
            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }

        aplicarGravedad();
        tocoSuelo();
    }

    private void aplicarGravedad()
    {
        movimientoVertical.y += magnitudGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }

    private void tocoSuelo()
    {
       Collider[] collsDetectados = Physics.OverlapSphere(pies.position, radioDeteccion, queEsSuelo);

        if (collsDetectados.Length > 0) 
        { 
          movimientoVertical.y = 0;
            Saltar();   
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }

    private void Saltar()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
         movimientoVertical.y = Mathf.Sqrt(-2* magnitudGravedad * alturaSalto);    
       }
    }

    public void recibirdanio(float danioRecibido)
    {
        vidas -= danioRecibido;
        if(vidas <= 0)
        {
            Destroy(gameObject);
            
        }
    }

}
