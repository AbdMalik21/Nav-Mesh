using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerControllerTouchScreen : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ButtonCondition put, pause;

    private void Start()
    {
    }

    void Update()
    {
        put = GetComponent<ButtonCondition>();
        pause = GetComponent<ButtonCondition>();
        foreach (Touch touch in Input.touches)
	{
		if (touch.phase == TouchPhase.Began)
        	{
            	Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            	RaycastHit hit;

            	if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                }
        	}
	}
        
    }
}
