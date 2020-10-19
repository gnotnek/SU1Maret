using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour{

    [SerializeField]
    private WeaponHandler[] weapons;

    private int currentWeapon_index;



    // Start is called before the first frame update
    void Start(){
        currentWeapon_index = 0;
        weapons[currentWeapon_index].gameObject.SetActive(true);



    }

    // Update is called once per frame
    void Update(){
        
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            turnOnSelected_weapon(0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            turnOnSelected_weapon(1);
        }

    } //update

    void turnOnSelected_weapon(int weaponindex){
        if(currentWeapon_index==weaponindex) return;

        //mateni weapon saiki
        weapons[currentWeapon_index].gameObject.SetActive(false);
        //ngekei weapon le dipilih
        weapons[weaponindex].gameObject.SetActive(true);

        currentWeapon_index = weaponindex;
    }

    public WeaponHandler GetCurrentSelectedWeapon(){
        
        return weapons[currentWeapon_index];
    }
}
