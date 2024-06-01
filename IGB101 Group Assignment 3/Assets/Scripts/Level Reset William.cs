using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelReset : MonoBehaviour
{

    GameManager gameManager;
    public string levelReset;
    public AudioSource[] audioSources;


    // Start is called before the first frame update
    void Start() { 
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider otherObject){

        if (otherObject.transform.tag == "Player"){
                SceneManager.LoadScene(levelReset);
        }
    }
}
