using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool bisa_unlock = true;

    [SerializeField]
    private float sensitivity = 5f;

    [SerializeField]
    private int step_lembut = 10;

    [SerializeField]
    private float weight_lembut = 0.4f;
    
    [SerializeField]
    private float sudut_roll = 10f;

    [SerializeField]
    private float rollSpeed= 3f;

    [SerializeField]
    private Vector2 look_limit_bawaan = new Vector2(-70f, 80f);

    private Vector2 look_angles;

    private Vector2 mouse_look_saatIni;
    private Vector2 smooth_move;
    
    private float roll_angle_saatIni;

    private int last_look_frame;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            ndelok_sekitar();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        LockAndUnlockCursor();

        if(Cursor.lockState==CursorLockMode.Locked){
            ndelok_sekitar();
        }
    }
    
    void LockAndUnlockCursor(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Cursor.lockState==CursorLockMode.Locked){
                Cursor.lockState = CursorLockMode.None;
            }else{
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }//ngelock cursor

    void ndelok_sekitar(){
        mouse_look_saatIni = new Vector2 (
            Input.GetAxis(mouseAxis.MOUSE_Y), Input.GetAxis(mouseAxis.MOUSE_X));


        look_angles.x += mouse_look_saatIni.x * sensitivity * (invert ? 1f : -1f);
        look_angles.y += mouse_look_saatIni.y * sensitivity;

        look_angles.x = Mathf.Clamp(look_angles.x, look_limit_bawaan.x, look_limit_bawaan.y);

        roll_angle_saatIni = 
            Mathf.Lerp(roll_angle_saatIni, Input.GetAxisRaw(mouseAxis.MOUSE_X)
            * sudut_roll, Time.deltaTime * rollSpeed);

        lookRoot.localRotation = Quaternion.Euler(look_angles.x, 0f, roll_angle_saatIni);
        playerRoot.localRotation = Quaternion.Euler(0f, look_angles.y, 0f);


    }//ndelok sekeliling
}
