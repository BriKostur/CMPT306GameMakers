using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndTrigger : MonoBehaviour {

    GameObject cam;
    bool isPlaying = false;

	// Use this for initialization
	void Start () {
        isPlaying = false;
        cam = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPlaying(bool state) {
        isPlaying = state;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        

        if (SceneManager.GetActiveScene().name == "Level Editor")
        {
            Debug.Log(isPlaying);
            if (isPlaying == true)
            {

                if (coll.gameObject.tag == "Player")
                {
                    cam.SendMessage("ShowEndMenu");
                        this.GetComponent<AudioSource>().Play();
                    
                }
            }
        }

        else
        {
            if (coll.gameObject.tag == "Player")
            {
                this.GetComponent<AudioSource>().Play();
            }
            Invoke("backToTitleScreen", 2);
        }
    }

    void backToTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
