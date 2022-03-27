using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MinionControler : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private float distancia;

    private GameObject Player;



    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    void Update()
    {
        CalculaPlayer();
    }
    void CalculaPlayer()
    {

        Player=GameObject.Find("Player");

        Debug.DrawLine(this.transform.position, Player.transform.position);

        var lookPos = Player.transform.position - this.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

        transform.Translate(Vector3.forward * 3 * Time.deltaTime);
    }



}
