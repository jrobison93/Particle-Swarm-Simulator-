using UnityEngine;
using System.Collections;

public class SwarmParticle : MonoBehaviour
{
    double bestFitness;
    Vector3 bestPosition;
    Vector3 velocity;


	public void SetUp(float posx, float posy, float velx, float vely)
    {
        transform.position = new Vector3(posx, posy, 0);
        velocity = new Vector3(velx, vely, 0);
        bestFitness = double.MaxValue;
    }

    public void Move(Vector3 target, Vector2 globalBest, bool newTarget)
    {
        transform.position = transform.position + (velocity * Time.deltaTime);

        //Debug.Log(target);

        if(newTarget || (GetFitness(target) < bestFitness))
        {
            bestFitness = GetFitness(target);
            bestPosition = transform.position;
        }

        velocity.x += (0.25f * Random.Range(0f, 1f) * (globalBest.x - transform.position.x)) + (0.25f * Random.Range(0f, 1f) * (bestPosition.x - transform.position.x));
        velocity.y += (0.25f * Random.Range(0f, 1f) * (globalBest.y - transform.position.y)) + (0.25f * Random.Range(0f, 1f) * (bestPosition.y - transform.position.y));

    }

    public double GetFitness(Vector3 target)
    {
        return Vector3.Distance(transform.position, target);
    }
}
