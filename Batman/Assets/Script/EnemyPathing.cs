using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {


    [SerializeField] WaveConfig waveConfig;
    [SerializeField] List<Transform> waypoint;
    
    int wayPointIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        waypoint = waveConfig.GetWaypoints();
        transform.position = waypoint[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }


    private void Move()
    {
        if (wayPointIndex <= waypoint.Count - 1)
        {
            var targetposition = waypoint[wayPointIndex].transform.position;
            var moveThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetposition, moveThisFrame);

            if (transform.position == targetposition)
            {
                wayPointIndex += 1;
            }
        }
        else
            Destroy(gameObject);
    }
}
