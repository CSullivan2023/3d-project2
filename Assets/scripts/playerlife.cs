using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerlife : MonoBehaviour
{
    bool dead = false;
    private void Update()
    {
        if (transform.position.y < -10f)
        {
            die();
        }
    }
    // Start is called before the first frame update



    // Update is called once per frame
    void die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        Debug.Log("ded");
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
