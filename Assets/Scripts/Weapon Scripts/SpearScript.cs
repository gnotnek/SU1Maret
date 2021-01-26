using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody mybody;
    public float speed = 30f;
    public float deactive_timer = 3f;
    public float damage = 15f;
    private void Awake() {
        mybody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Invoke("deactivatedGameObjek", deactive_timer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void deactivatedGameObjek(){
        if(gameObject.activeInHierarchy){
            gameObject.SetActive(false);
        }
    }

    public void launch(Camera mainCamera){
        mybody.velocity = mainCamera.transform.forward * speed;
        transform.LookAt(transform.position + mybody.velocity);
        
    }

    void OnTriggerEnter(Collider target) {
        //after kena enemy deactivate game objek

    }
}
