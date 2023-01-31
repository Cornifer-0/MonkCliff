using UnityEngine;

public enum MonkState
{
    None,
    CollectingFood,
    CuttingWood,
    Meditating,
    CollectingWater
}

public class MonkBehaviour : MonoBehaviour
{
    // Reference to the Rigidbody2D component
    private Rigidbody2D rigidBody;

    // Reference to the ResourceManager script
    public ResourceManager resourceManager;
    public float resourceGainInterval = 5.0f;
    private float nextResourceGainTime;
    private bool isWorking = false;

    // Enum to track the state of the monk

    public MonkState currentState = MonkState.None;

    // Destination transform for the monk to move towards
    private Transform destination;

    // Speed of the monk's movement
    public float speed = 2f;

    public void Start()
    {
        // Get reference to the Rigidbody2D component
        rigidBody = GetComponent<Rigidbody2D>();
        nextResourceGainTime = Time.time + resourceGainInterval;

    }

    private void Update()
    {
        switch (currentState)
        {
            case MonkState.None:
                // Do nothing
                break;
            case MonkState.CollectingFood:
                destination = resourceManager.VegetablesPatch;
                MoveTowardsDestination();
                // Call the resource manager to add food every x seconds
                break;
            case MonkState.CuttingWood:
                destination = resourceManager.Forest;
                MoveTowardsDestination();
                break;
            case MonkState.Meditating:
                destination = resourceManager.MeditationArea;
                MoveTowardsDestination();
                break;
            case MonkState.CollectingWater:
                destination = resourceManager.River;
                MoveTowardsDestination();
                break;
        }

        if (Time.time >= nextResourceGainTime)
        {
            if (isWorking)
            {
                switch (currentState)
                {
                    case MonkState.None:
                        break;
                    case MonkState.CollectingFood:
                        resourceManager.AddFood(1);
                        break;
                    case MonkState.CuttingWood:
                        // Call the resource manager to add wood every x seconds
                        resourceManager.AddWood(1);
                        break;
                    case MonkState.Meditating:
                        resourceManager.AddExperience(1);
                        break;
                    case MonkState.CollectingWater:
                        resourceManager.AddWater(1);
                        break;
                }
                nextResourceGainTime = Time.time + resourceGainInterval;
            }
        }
    }

    private void MoveTowardsDestination()
    {
        float distance = Vector2.Distance(transform.position, destination.position);
        if (distance > .5f)
        {
            isWorking = false;
            // Calculate the direction to move in
            Vector2 direction = (destination.position - transform.position).normalized;
            rigidBody.velocity = direction * speed;
        }
        else
        {
            isWorking = true;
            if (rigidBody.velocity.x + rigidBody.velocity.y > 2f)
            {
                rigidBody.velocity -= rigidBody.velocity * .1f;
            }
            else
            {
                rigidBody.velocity = new Vector2(0, 0);
            }         
        }
    }

    public void SetState(MonkState newState, Transform newDestination)
    {
        currentState = newState;
        destination = newDestination;
    }
}