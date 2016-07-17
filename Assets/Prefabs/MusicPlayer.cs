using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {


    static MusicPlayer instance = null;
    // Use this for initialization

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
        
    }
    

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer: loaded leve " + level);
        music.Stop();

        if (level == 0)
        {
            music.clip = startClip;
        }
        if( level == 1)
        {
            music.clip = gameClip;
        }
        if (level == 2)
        {
            music.clip = endClip;
        }
        music.Play();
    }

    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
