using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlJugador : MonoBehaviour
{
    Camera camara;
    private float distanciaDisparo = 1000f;
    Rigidbody jugador;
    [SerializeField] private float velocidad = 10f;
    public float vida = 100f;
    public bool GameOver = false;
    Vector3 clickPosition;
    void Start()
    {
        jugador = GetComponent<Rigidbody>();
        camara = GetComponent<Camera>();
        
    }

    void Update()
    {
        MoverPersonaje();
        if(vida < 0)
        {
            GameOver = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
            
        }
    }

    void MoverPersonaje()
    {
        float movimietoHorizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float movimientoVertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        Vector3 fuerzaDesplazamiento = new Vector3(movimietoHorizontal, 0, movimientoVertical);
        jugador.MovePosition(jugador.position + fuerzaDesplazamiento);
    }

    void Disparar()
    {
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit disparo;
        
        if (Physics.Raycast(rayo, out disparo))
        {
            if (disparo.collider.CompareTag("Terreno")) 
            {
                clickPosition = disparo.point; 
            }
        }
        clickPosition.y = transform.position.y;
        if (Physics.Raycast(transform.position, clickPosition, out disparo, distanciaDisparo) && disparo.rigidbody != null)
        {
            Debug.Log("Holi");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        vida -= 10;
    }
}
