using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject wavePrefab;
    [SerializeField] float time = 0.5f;
    [SerializeField] float spanRandomFactor = 0.3f;
    [SerializeField] int noOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWavePoints =new  List<Transform>();

        foreach (Transform child in wavePrefab.transform)
        {
            waveWavePoints.Add(child);
        }

        return waveWavePoints; 
    }


    public GameObject GetWavePrefab() { return wavePrefab; }
    public float GetTime() { return time; }
    public float GetSpanRandom() { return spanRandomFactor; }
    public int GetNoOfEnemies() { return noOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
