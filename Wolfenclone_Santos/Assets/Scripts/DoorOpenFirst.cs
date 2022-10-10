using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject theDoor;
    public AudioSource doorFX;

    //When something passes through the object
    void OnTriggerEnter(Collider other)
    {
        doorFX.Play();
        //go to theDoor and have the animator play the animation "DoorOpen"
        theDoor.GetComponent<Animator>().Play("DoorOpen");
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(CloseDoor());
    }

    //IEnumerator must have a time
    IEnumerator CloseDoor()
    { //wait, return a new wait time in seconds (in this case 5)
      //Then play the doorFx, then play the Closedoor animation
        yield return new WaitForSeconds(5);
        doorFX.Play();
        theDoor.GetComponent<Animator>().Play("DoorClose");
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
