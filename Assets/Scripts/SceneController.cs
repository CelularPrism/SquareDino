using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private WayPoint[] wayPoints;
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private UIManager uiManager;

    private int indexPoint;
    private Movement movement;
    private FloorManager floorManager;
    private HealthSystem healthSystem;
    private Shooting shooting;

    private void Start()
    {
        indexPoint = 0;
        movement = transform.GetComponent<Movement>();
        shooting = transform.GetComponent<Shooting>();
        healthSystem = transform.GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (!movement.isMove && healthSystem.isLive)
        {
            floorManager = GetFloor();
            if (floorManager == null && indexPoint < wayPoints.Length)
            {
                shooting.shooting = false;
                uiManager.UpdateSlider();
                movement.SetPoint(wayPoints[indexPoint]);
                indexPoint++;
            } else if (indexPoint < wayPoints.Length)
            {
                shooting.shooting = true;
            } else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        } else if (!healthSystem.isLive)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private FloorManager GetFloor()
    {
        FloorManager floorManager = null;
        Vector3 positionSphere = new Vector3(transform.position.x, transform.position.y - transform.localScale.y * 0.1f, transform.position.z);
        if (Physics.CheckSphere(positionSphere, 0.5f, floorMask))
        {
            Collider[] colliders = Physics.OverlapSphere(positionSphere, 0.1f, floorMask);
            floorManager = colliders[0].GetComponent<FloorManager>();
            floorManager.ActivateEnemies();
        }

        return floorManager;
    }
}
