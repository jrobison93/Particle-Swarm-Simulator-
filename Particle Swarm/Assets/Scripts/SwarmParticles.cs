using UnityEngine;
using System.Collections;

public class SwarmParticle : MonoBehaviour
{
    double bestFitness;
    Vector3 bestPosition;
    Vector3 velocity;


	public SwarmParticle(float posx, float posy, float velx, float vely)
    {
        transform.position.Set(posx, posy, transform.position.z);
        velocity = new Vector3(velx, vely, 0);
        bestFitness = double.MaxValue;
    }

    public void Move(Vector2 target, Vector2 globalBest, bool newTarget)
    {
        transform.position = transform.position + (velocity * Time.deltaTime);

        if(newTarget || GetFitness(target) < bestFitness)
        {
            bestFitness = GetFitness(target);
            bestPosition = transform.position;
        }

        velocity.x += (0.5f * Random.Range(0, 1) * (globalBest.x - transform.position.x)) + (0.5f * Random.Range(0, 1) * (bestPosition.x - transform.position.x));
        velocity.y += (0.5f * Random.Range(0, 1) * (globalBest.y - transform.position.y)) + (0.5f * Random.Range(0, 1) * (bestPosition.y - transform.position.y));

    }

    public double GetFitness(Vector2 target)
    {
        return Vector2.Distance(transform.position, target);
    }
}
