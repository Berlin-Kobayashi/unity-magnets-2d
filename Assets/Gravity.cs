using UnityEngine;
using System.Collections;
using System.Linq;

public class Gravity : MonoBehaviour
{
    public GameObject[] Magnets;

    public double GravitationalConstant = 6.67E-11;

    void Start()
    {
        Magnets = GameObject.FindGameObjectsWithTag("Magnet");
    }

    // Update is called once per frame
    void Update ()
    {

        double ownMass = this.GetComponent<Rigidbody2D>().mass;

        foreach (GameObject magnet in Magnets)
        {
            if (this.transform.position != magnet.transform.position)
            {
            double magnetMass = magnet.GetComponent<Rigidbody2D>().mass;

            var distance = Vector2.Distance(this.transform.position, magnet.transform.position);

            var force = GravitationalConstant*ownMass*magnetMass/(distance*distance);

            
           

            Vector2 forceVector = magnet.transform.position;

            forceVector.x *= (float)force;
            forceVector.y *= (float)force;

            Debug.Log(forceVector);

            this.GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
            }
        }

        
    }
}
