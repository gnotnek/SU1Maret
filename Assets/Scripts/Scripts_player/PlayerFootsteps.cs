using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFootsteps : MonoBehaviour {

    private AudioSource footsteps_sound;

    [SerializeField]
    private AudioClip[] footstepClips;

    private CharacterController character_Controller;

    [HideInInspector]
    public float volume_Min, volume_Max;

    private float accumulated_Distance;

    [HideInInspector]
    public float step_Distance;

    void Awake(){
        footsteps_sound = GetComponent<AudioSource>();

        character_Controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update(){
        CheckToPlayFootstepSound();
    }

    void CheckToPlayFootstepSound(){
        if(!character_Controller.isGrounded)
        return;
      
        if(character_Controller.velocity.sqrMagnitude > 0){
            //akumulasi jarak paling jauh kyta jalan
            //sampai kita memaikan foosteps sound
            accumulated_Distance += Time.deltaTime;

            if(accumulated_Distance>step_Distance){
                footsteps_sound.volume = Random.Range(volume_Min, volume_Max);
                footsteps_sound.clip = footstepClips[Random.Range(0, footstepClips.Length)];
                footsteps_sound.Play();

                accumulated_Distance = 0f;
            }
        }else {
            accumulated_Distance = 0f;
        }
    }
}
