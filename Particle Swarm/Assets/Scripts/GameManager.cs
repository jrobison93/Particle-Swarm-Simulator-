using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject particle;

    private SwarmParticle[] particleSwarm;
    private Vector2 globalBest;
    private Vector2 targetPosition;

	// Use this for initialization
	void Start ()
    {
        InitializeSwarm();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveSwarm();
	
	}

    void MoveSwarm()
    {

    }

    void InitializeSwarm()
    {

    }

    public Vector2 GetTarget()
    {
        return targetPosition;
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Position: " + position.x + ", " + position.y + ", " + position.z);
    }
}
