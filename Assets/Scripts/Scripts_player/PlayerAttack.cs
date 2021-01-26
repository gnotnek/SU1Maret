using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{

    private WeaponManager weapon_manager;

    public float fireRate = 15f;
    private float nextTimetoFire;
    public float damage = 20f;

    //private Animator zoomCamAim;
    private bool zoomed;
    private Camera mainCam;
    private GameObject chrosshair;

    [SerializeField]
    private GameObject spear_preafab;
    [SerializeField]
    private Transform spear_StartPosition;
    
    void Awake() {
        weapon_manager = GetComponent<WeaponManager>();

    }
    

    void Start(){
       
    }

    // Update is called once per frame
    void Update(){
        weaponShoot();   
    }

    void weaponShoot(){

        //assault
        if(weapon_manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE){            
            //nek dipanjer klik kiri ne di execute
            if(Input.GetMouseButton(0) && Time.time > nextTimetoFire){
                nextTimetoFire = Time.time + 1f / fireRate;

                weapon_manager.GetCurrentSelectedWeapon().shootAnimation();

                //BulletFire();
            }
        }
        //regullar ora dipanjer
        else{
            if(Input.GetMouseButtonDown(0)){
                //revolver
                if(weapon_manager.GetCurrentSelectedWeapon().bulletType == WeaoponBulletType.BULLET){
                    weapon_manager.GetCurrentSelectedWeapon().shootAnimation();
                    //BulletaFire();
                } else {
                    //spear/tombak
                    weapon_manager.GetCurrentSelectedWeapon().shootAnimation();
                    if(weapon_manager.GetCurrentSelectedWeapon().bulletType==WeaoponBulletType.SPEAR){
                        ThrowSpear(true);
                    }
                    


                }
            }

        }

        void ThrowSpear(bool throwspear){
            if(throwspear){
                GameObject spear = Instantiate(spear_preafab);
                spear.transform.position = spear_StartPosition.position;
                spear.GetComponent<SpearScript>().launch(mainCam);
            }
        }

    }





}
