using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim{
    NONE,
    SELF_AIM,
    AIM
    
}

public enum WeaponFireType{
    SINGLE,
    MULTIPLE
}

public enum WeaoponBulletType{
    BULLET,
    SPEAR,
    NONE
}
public class WeaponHandler : MonoBehaviour{

    private Animator anim;
    public WeaponAim weapon_aim;
    
    [SerializeField]
    private GameObject muzzFlash;
    
    [SerializeField]
    private AudioSource shootSound, reloadSound;

    public WeaponFireType fireType;
    public WeaoponBulletType bulletType;
    public GameObject attack_point;

    

    public void shootAnimation(){
        anim.SetTrigger(animationTag.SHOOT_TRIGGER);
    }

    public void aim(bool canAim){
        anim.SetBool(animationTag.AIM_PARAMETER, canAim);
    }

    void turn_on_MUzzleFlash(){
        muzzFlash.SetActive(true);
    }
    void turn_off_MUzzleFlash(){
        muzzFlash.SetActive(false);
    }

    void play_ShootSound(){
        shootSound.Play();
    }

    void Play_RealodSound(){
        reloadSound.Play();
    }

    void Turn_on_attackPoint(){
        attack_point.SetActive(true);
    }
    void Turn_off_attackPoint(){
        if(attack_point.activeInHierarchy) attack_point.SetActive(false);
    }

    private void Awake() {
        anim = GetComponent<Animator>();

    } //awake

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
