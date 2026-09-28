using UnityEngine;
using System.Collections.Generic;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;
    [Range(10, 500)]
    public int startingAgentCount = 250;
    const float AgentDensity = 0.08f;
    [Range(1f, 100f)]
    public float driveFactor = 15f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 100f)]
    public float neighbourRadius = 1.5f;
    [Range(0.1f, 100f)]
    public float avoidanceRadiusMultipier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    int agentId;

    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        foreach (Collider2D neighbourCollider in contextColliders)
        {
            if (neighbourCollider != agent.AgentCollider)
            {
                context.Add(neighbourCollider.transform);
            }
        }
        return context;
    }
    void CreateNewAgent()
    {
        FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * agentId * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );
            newAgent.name = "Agent " + agentId;
            agentId++;
            newAgent.Initialize(this);
            agents.Add(newAgent);
    }
    void CollisionOnFlockAgent()
    {

        FlockAgent deadAgent = CommonResource.instance.deadFlockAgent;
        bool isAgentDead = agents.Remove(deadAgent);
        if (isAgentDead)
        {
            CommonResource.instance.UpdateScore(10);
            Destroy(deadAgent.gameObject);
        }
    }
    void Awake()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultipier;
        agentId = 0;
    }
    void Start()
    {
        for (int i = 0; i < startingAgentCount; i++)
        {
            CreateNewAgent();
        }
    }

    void Update()
    {
        
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            Vector3 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
        CollisionOnFlockAgent();
    }
}
