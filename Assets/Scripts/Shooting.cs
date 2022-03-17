using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform spawnPointBullet;
    [SerializeField] private Camera camera;
    public float timeReload = 0.5f;
    public bool shooting = false;

    private Touch[] touch;
    private float timeNextShoot;

    private void Start()
    {
        timeNextShoot = 0;
    }

    void Update()
    {
        if (shooting && Input.touchCount == 1)
        {
            touch = Input.touches;
            Vector3 lastTouch = touch[0].position;

            if (lastTouch != Vector3.zero && timeNextShoot < Time.time)
            {
                timeNextShoot = Time.time + timeReload;
                Ray ray = camera.ScreenPointToRay(lastTouch);
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                float distance;
                if (plane.Raycast(ray, out distance))
                {
                    GameObject bullet = Instantiate(prefabBullet, spawnPointBullet.position, new Quaternion(), transform);
                    bullet.GetComponent<Bullet>().SetPosTouch(ray.GetPoint(distance));
                }
            }
        }
    }
}
