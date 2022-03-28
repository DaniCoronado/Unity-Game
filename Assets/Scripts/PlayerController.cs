using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;

    public Text winText;
    public Text vidasText;
    public int vidas;

    private Rigidbody rb;

    private int count;


    private float distancia;

    private GameObject target;
    private GameObject player;
    private GameObject test_target;
    private string new_target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        vidas = 5;
        SetCountText();
        setVidas();
        winText.text = "";
    }

    void Update()
    {
        CalculaMinimo();
    }

    void CalculaMinimo()
    {
        float distanceToClosestPickUp = Mathf.Infinity;
        GameObject closestPickup = null;
        GameObject[] alltargets = GameObject.FindGameObjectsWithTag("Pick Up");

        foreach (GameObject currentPickup in alltargets)
        {
            if (currentPickup.activeInHierarchy)
            {
                float distanceToPickup = (currentPickup.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToPickup < distanceToClosestPickUp)
                {
                    distanceToClosestPickUp = distanceToPickup;
                    closestPickup = currentPickup;
                }
            }
        }

        Debug.DrawLine(this.transform.position, closestPickup.transform.position);

        var lookPos = closestPickup.transform.position - this.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Minion"))
        {
            other.gameObject.SetActive(false);
            vidas = vidas - 1;
            setVidas();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
    
    void setVidas()
    {
        vidasText.text = "Vidas: " + vidas.ToString();
        if (vidas <= 0)
        {

            winText.text = "you lose!";
        }
    }


}