using System;
using UnityEngine;
using System.Collections;
using System.Linq;

public class Magnetic : MonoBehaviour
{
    public GameObject[] Magnets;

    public double GravitationalConstant = 6.67E-11;

    void Start()
    {
        Magnets = GameObject.FindGameObjectsWithTag("Magnet");
    }

    // Update is called once per frame
    void Update()
    {

        double ownMass = this.GetComponent<Rigidbody2D>().mass;

        foreach (GameObject magnet in Magnets)
        {
            if (this.transform.position != magnet.transform.position)
            {
                var distance = Vector2.Distance(this.transform.position, magnet.transform.position) -1;

                var force = getMagneticForce(distance, magnet.GetComponent<Rigidbody2D>().mass);

                Vector2 forceVector = magnet.transform.position - transform.position;
                forceVector.x *= force;
                forceVector.x *= force;


                Debug.Log("This:" + transform.position);
                Debug.Log("Magnet:" + magnet.transform.position);
                Debug.Log("Force:" + forceVector);
                Debug.Log("Distance:" + distance);

                 this.GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
               // this.GetComponent<Rigidbody2D>().velocity = forceVector;
                //Debug.Log(transform.position);
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("sadasds");
    }

    float getMagneticForce(double distance, double mass)
    {
        return (float)Math.Pow(mass, distance * -1 ) * 2;
    }
}
