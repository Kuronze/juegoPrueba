using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private GameObject jugador;
    private ControlJugador controlJugador;
    private Vector3 posicionZombie;
    private float tiempoAparicion = 2f;
    private bool GameOver;


    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Jugador");
        controlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>();
        GameOver = controlJugador.GameOver;
        InvokeRepeating("InvocacionZombie", 1.5f, tiempoAparicion);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver = controlJugador.GameOver;
    }

    void InvocacionZombie()
    {
        posicionZombie = new Vector3(Random.Range(-29,29), 0, Random.Range(-29, 29));
        if (GameOver == false)
        {
            Instantiate(prefab, posicionZombie, prefab.transform.rotation);
        }
    }
}
