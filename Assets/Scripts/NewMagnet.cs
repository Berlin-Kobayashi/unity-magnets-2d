using UnityEngine;
using System.Collections;

public class NewMagnet : MonoBehaviour
{
    private float magneticPower = 1;

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
    }
	
	// Update is called once per frame
	void Update () {
         
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Magnetic") && !other.isTrigger)
        {
            IncreaseMagneticForce(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Magnetic") && !other.isTrigger)
        {
            DecreaseMagneticForce(other);
        }
    }

    void IncreaseMagneticForce(Collider2D magnetic)
    {
        magnetic.attachedRigidbody.AddForce((transform.position - magnetic.transform.position) * magneticPower, ForceMode2D.Force);

        this.GetComponent<Rigidbody2D>().AddForce((magnetic.transform.position - transform.position) * magneticPower, ForceMode2D.Force);
       
        // Debug.Log(magnetic.attachedRigidbody.velocity);
    }

    void DecreaseMagneticForce(Collider2D magnetic)
    {
        magnetic.attachedRigidbody.AddForce((transform.position - magnetic.transform.position) * magneticPower * -1, ForceMode2D.Force);

        this.GetComponent<Rigidbody2D>().AddForce((magnetic.transform.position - transform.position) * magneticPower * -1, ForceMode2D.Force);
      
        // Debug.Log(magnetic.attachedRigidbody.velocity);
    }

}
