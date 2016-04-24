using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject particle;
    public int numParticles = 5;
    
    private ArrayList particleSwarm;
    private Vector3 globalBestPosition;
    private double globalBestFitness;
    private Vector3 targetPosition;
    private bool newTarget;
    private float vert;
    private float hori;

	// Use this for initialization
	void Start ()
    {
        vert = Camera.main.orthographicSize;
        hori = vert * Screen.width / Screen.height;
        targetPosition = new Vector2(0f, 0f);
        globalBestFitness = double.MaxValue;
        newTarget = true;
        InitializeSwarm();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveSwarm();	
	}

    void MoveSwarm()
    {
        foreach(GameObject part in particleSwarm)
        {
            SwarmParticle particle = part.GetComponent<SwarmParticle>();
            particle.Move(targetPosition, globalBestPosition, newTarget);

            if(particle.GetFitness(targetPosition) < globalBestFitness)
            {
                globalBestFitness = particle.GetFitness(targetPosition);
                globalBestPosition = particle.transform.position;
            }
        }
        newTarget = false;
    }

    void InitializeSwarm()
    {
        particleSwarm = new ArrayList();
        for(int i = 0; i < numParticles; i++)
        {
            GameObject tempParticle = Instantiate(particle) as GameObject;
            tempParticle.GetComponent<SwarmParticle>().SetUp(Random.Range(-hori, hori),
                Random.Range(-vert, vert), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            particleSwarm.Add(tempParticle);
        }

    }

    public Vector3 GetTarget()
    {
        return targetPosition;
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = position;
        globalBestFitness = double.MaxValue;
        Debug.Log("Position: " + position.x + ", " + position.y + ", " + position.z);
        newTarget = true;
    }
}
