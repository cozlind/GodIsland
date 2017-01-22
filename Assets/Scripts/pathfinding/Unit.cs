using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {


	public Transform target;
	public float speed = 1.3f;
	Vector3[] path;
	int targetIndex;
    Rigidbody rigidbody;

    Vector3 prevPosition;
    [SerializeField]
    HumanModelCTRL modelCtrl;

	void Start() {
        rigidbody = GetComponent<Rigidbody>();
        prevPosition = transform.position;
        //PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
    }
    void Update()
    {
        Vector3 diff = transform.position - prevPosition;
        diff.y = 0;
        if (diff.magnitude != 0f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
            
        }
        prevPosition = transform.position;
        modelCtrl.SetSpeed(Mathf.Max((diff.magnitude / speed) / Time.deltaTime, 1));
        
    }

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			targetIndex = 0;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {
            //if (transform.position == currentWaypoint)
            if (Vector3.Distance(transform.position, currentWaypoint) <= DynamicPathFinding.waypointDistance)
            {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);




            Ray ray = new Ray(transform.position,transform.forward - Vector3.up * 0.1f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2))
            {
                Debug.DrawRay(ray.origin, ray.direction);
                rigidbody.velocity = ((currentWaypoint - transform.position) * 1.5f + Vector3.up * 3);
           

            }




			yield return null;

		}
	}

	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}
