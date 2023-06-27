using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent enemigo;
    private GameObject jugador;
    private Vector3 direccionRotacionZonbie;
    private ControlJugador controlJugador;
    

    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponent<NavMeshAgent>(); 
        jugador = GameObject.Find("Jugador");
        controlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlJugador.GameOver == false) 
        {
            MirarAlJugador();
            enemigo.SetDestination(jugador.transform.position);
        }
    }

    private void MirarAlJugador()
    {
        direccionRotacionZonbie = enemigo.transform.position - jugador.transform.position;
        direccionRotacionZonbie.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direccionRotacionZonbie);
        transform.rotation = rotation;
    }
}
