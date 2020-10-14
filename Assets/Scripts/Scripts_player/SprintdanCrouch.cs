using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintdanCrouch : MonoBehaviour {
    // Start is called before the first frame update
     private PlayerMovement playerMovement;
    public float kecepatan_lari = 10f;
    public float kecepatan_bergerak = 5f;
    public float merayap = 2f;

    private Transform look_Root;
    private float tinggi_berdiri = 1.6f;
    private float tinggi_merangkak = 1f;

    private bool sedang_merangkak;
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        look_Root = transform.GetChild(0);


    }
    // Update is called once per frame
    void Update()
    {
     sprint(); 
     merangkak();  
    }
    

    //mlayu
    void sprint(){
        if(Input.GetKeyDown(KeyCode.LeftShift) && !sedang_merangkak){
            playerMovement.speed = kecepatan_lari;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !sedang_merangkak){
            playerMovement.speed = kecepatan_bergerak;
        }
    }

    //merangkak
    void merangkak(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(sedang_merangkak){
                look_Root.localPosition = new Vector3(0f, tinggi_berdiri, 0f);
                playerMovement.speed = kecepatan_bergerak;

                sedang_merangkak = false;
            }else{
                look_Root.localPosition = new Vector3(0f, tinggi_merangkak, 0f);
                playerMovement.speed = merayap;

                sedang_merangkak = true;
            }
        }

    }
} 
