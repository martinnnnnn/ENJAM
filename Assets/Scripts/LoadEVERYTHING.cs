using UnityEngine;
using System.Collections;

public class LoadEVERYTHING : MonoBehaviour {


    public GameObject GameManagersPrefab;
    public GameObject SpawnPrefabs;
    public GameObject GroundPrefab;
    public GameObject WindowsPrefab;
    public GameObject BerzerkManagerPrefab;
    public GameObject VanAnimationPrefab;
    public GameObject PlayerPrefab;
    public GameObject SoundManagerPrefab;




    // Use this for initialization
    void Start ()
    {
        GameObject GameManagers = Instantiate(GameManagersPrefab) as GameObject;
        GameObject Spawn = Instantiate(SpawnPrefabs) as GameObject;
        GameObject Ground = Instantiate(GroundPrefab) as GameObject;
        GameObject Windows = Instantiate(WindowsPrefab) as GameObject;
        GameObject BerzerkManager = Instantiate(BerzerkManagerPrefab) as GameObject;
        GameObject VanAnimation = Instantiate(VanAnimationPrefab) as GameObject;
        GameObject Player = Instantiate(PlayerPrefab) as GameObject;
        GameObject SoundManager = Instantiate(SoundManagerPrefab) as GameObject;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
