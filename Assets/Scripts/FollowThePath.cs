using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed;

    [HideInInspector]
    public int waypointIndex;

    public bool moveAllowed;

	// Use this for initialization
	private void Start () {
        waypointIndex = 0;
        moveAllowed = false;
        transform.position = waypoints[waypointIndex].transform.position;      
	}
	
	// Update is called once per frame
	private void Update () {
        if (moveAllowed)
            if(GameControl.GetPlayerWalkBackwards()){
                MoveBackwards();
            }else{
                Move();
            }          
	}

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
    private void MoveBackwards()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex -= 1;
            }
        }
    }
}
