using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private Vector3 destinationPosition;        // The destination Point
    private float destinationDistance;          // The distance between myTransform and destinationPosition

    private Camera camera;
	private Animator animator;
	private NavMeshAgent navAgent;
	private Unit me;
	
    public float moveSpeed = 1;                     // The Speed the character will move
	public float hitdist = 100.0f;

	void Start () {
		//Game.GetGc().player = this;

        camera = Game.gc.GetComponent<Camera>().gameObject.GetComponent<Camera>();
        animator = GetComponent<Animator>();
		navAgent = GetComponent<NavMeshAgent>();
		me = GetComponent<Unit>();


        destinationPosition = transform.position;
	}

	void Update () {
		if ( (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) ) && GUIUtility.hotControl ==0) {

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit rcHit = new RaycastHit();

			if (Physics.Raycast(ray, out rcHit, hitdist)){
				//Detect Terrain (layer 8)
				if(rcHit.collider.gameObject.layer == 8)
				{
					destinationPosition = rcHit.point;
					destinationPosition.y = transform.position.y;

					destinationDistance = Vector3.Distance(destinationPosition, transform.position);
					if(destinationDistance < .5f)
	                    return;

					if(me.IsAlive())
					{
						transform.LookAt(destinationPosition);
						animator.SetFloat("speed", 1);
					}

					//navAgent.SetDestination(rcHit.point);
				}
            }
			return;
		}

		destinationDistance = Vector3.Distance(destinationPosition, transform.position);
		
		if(destinationDistance < .5f || !me.IsAlive())
			animator.SetFloat("speed", 0);
    }
}
