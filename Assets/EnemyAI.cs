using Pathfinding;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Quien es el target
    public Transform target;

    //Cada cuantos tiempos se actualiza el path
    public float updateRate = 2f;

    //Catching
    private Seeker seeker;
    private Rigidbody2D rb;

    //El path calculado
    public Path path;

    //La velocidad por segundo del AI
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //La maxima distancia que tiene el AI desde un waypoint a otro waypoint
    public float nextWaypointDistance = 3;

    //El waypoint donde nos movemos en el momento
    private int currentWaypoint = 0;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.LogError("No hay jugador, Pánico!!!");
            return;
        }

        //Iniciar el nuevo path al target position, retorna el resultado a un metodo OnPathComplete 
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath ());
    }


    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            //TODO: Insert a player search here
            yield return false;
        }

        //Iniciar el nuevo path al target position, retorna el resultado a un metodo OnPathComplete 
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a path. Did it have an error? " +p.error);

        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            //TODO: Insert a player search here
            return;
        }

        //TODO: Always look at player?
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;
            Debug.Log("End of path reatched");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }


}
