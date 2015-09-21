using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform player;
    public float rotationDamping;
    public float spreadFactor;
    public float delayTime = .2f;
    private float counter = 0;
    public Renderer muzzleFlash;
    


	
	void Start () {

        //hides muzzleflash 
        muzzleFlash.enabled = false;
	
	}
	


	
	void Update () {

        //delay on shooting
        counter += Time.deltaTime;

        if(counter > delayTime)
        {
            attack();
            counter = 0;
        }

        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}



    void attack() {

        //enemy attacks have spread and aren't 100% accurate
        Vector3 direction = transform.forward;
        direction.x += Random.Range(-spreadFactor, spreadFactor);
        direction.y += Random.Range(-spreadFactor, spreadFactor);
        direction.z += Random.Range(-spreadFactor, spreadFactor);


        //if attack hits player, pleayer health goes down
        RaycastHit hit;
        if(Physics.Raycast (transform.position, direction, out hit))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<HealthScript>().health -= 5f;
            }

            //show muzzle flash when shooting
            StartCoroutine("MuzzleFlash");
        }
    }


    //muzzle flash 
    IEnumerator MuzzleFlash() {

        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(.2f);
        muzzleFlash.enabled = false;

        
        

    }
}
