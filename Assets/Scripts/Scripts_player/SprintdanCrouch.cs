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
    private float tinggi_merangkak = 0.6f;

    private bool sedang_merangkak;

    private PlayerFootsteps player_footsteps;
    private float sprint_Volume = 1f;
    private float merangkak_volume = 0.1f;
    private float walk_vol_min = 0.2f;
    private float walk_vol_max = 0.6f;

    private float walk_step_distance = 0.4f;
    private float sprint_step_distance = 0.25f;
    private float Crouch_step_distance = 0.5f;
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        look_Root = transform.GetChild(0);

        player_footsteps = GetComponentInChildren<PlayerFootsteps>();

    }

    void Start() {
        player_footsteps.volume_Min = walk_vol_min;
        player_footsteps.volume_Max = walk_vol_max;
        player_footsteps.step_Distance = walk_step_distance;
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

            player_footsteps.step_Distance = sprint_step_distance;
            player_footsteps.volume_Min = sprint_Volume;
            player_footsteps.volume_Max = sprint_Volume;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !sedang_merangkak){
            playerMovement.speed = kecepatan_bergerak;

            player_footsteps.volume_Min = walk_vol_min;
            player_footsteps.volume_Max = walk_vol_max;
            player_footsteps.step_Distance = walk_step_distance;
        }
    }

    //merangkak
    void merangkak(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(sedang_merangkak){
                //sedang berdiri
                look_Root.localPosition = new Vector3(0f, tinggi_berdiri, 0f);
                playerMovement.speed = kecepatan_bergerak;

                player_footsteps.volume_Min = walk_vol_min;
                player_footsteps.volume_Max = walk_vol_max;
                player_footsteps.step_Distance = walk_step_distance;

                sedang_merangkak = false;
            }else{
                //sedang merangkak
                look_Root.localPosition = new Vector3(0f, tinggi_merangkak, 0f);
                playerMovement.speed = merayap;

                player_footsteps.step_Distance = Crouch_step_distance;
                player_footsteps.volume_Min = merangkak_volume;
                player_footsteps.volume_Max = merangkak_volume;

                sedang_merangkak = true;
            }
        }

    }
} 
