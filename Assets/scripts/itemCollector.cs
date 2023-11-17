using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollector : MonoBehaviour
{
    int coins = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("coins:" + coins);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
