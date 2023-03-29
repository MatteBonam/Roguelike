using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool triggerActive = false;
 
    public GameObject text;  //Add reference to UI Text here via the inspector

    private void Update() 
    {
        text.SetActive(triggerActive);
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            SomeCoolAction();
        }
    }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                triggerActive = true;
            }
        }
 
        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                triggerActive = false;
            }
        }
 
        public void SomeCoolAction()
        {
            Destroy(gameObject);
        }
}
