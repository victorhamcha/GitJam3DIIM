using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteractions : MonoBehaviour
{
    public bool throns=false;
    public GameObject throwned;
    public ThreeDPlayerLooking cam;
    public bool grabbed=false;
    public bool Destructible=false;
    public Material originalMaterial;
    void Start()
    {
        originalMaterial = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {       
        if (throns&&Destructible)
        {
            Destroy(gameObject);
            throns = false;
            Instantiate(throwned, gameObject.transform.position, Quaternion.identity);
        }
        
        if(gameObject.tag=="poulet"&& collision.gameObject.tag=="platforme" && collision.gameObject.name != "four")
        {
            //Debug.Log("qlkdf");
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            if(scene.buildIndex == 3)
            {
                GameManager.instance.ReloadLevel();
                Debug.Log("loose");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (grabbed&&other.gameObject.tag=="platforme" && cam.minRotation> cam.transform.rotation.eulerAngles.x)
        {
            cam.minRotation = cam.transform.rotation.eulerAngles.x;
            //Debug.Log(Camera.main.transform.rotation.x*180/Mathf.PI);
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (grabbed && other.gameObject.tag == "platforme")
        {
            cam.minRotation = 90.0f;
            
        }
    }
}
