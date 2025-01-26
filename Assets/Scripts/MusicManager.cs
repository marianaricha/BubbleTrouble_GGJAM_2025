using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set;}
    public AudioSource src;
    void Awake()
    {
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject); 
        StartMusic();
    }

    private void StartMusic(){
        src = GetComponent<AudioSource>();
		src.Play(); 
    }

    public void SpeedUpMusic(){
        if(GameManager.Instance.velocityBoost <= 2){
            src.pitch *= ((GameManager.Instance.velocityBoost-1)/8) + 1;
        }else{
            src.pitch = 2;   
        }
    }

}
