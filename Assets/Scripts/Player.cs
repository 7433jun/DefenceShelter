using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    [SerializeField] Transform firePosition;
    [SerializeField] AudioSource shotSound;

    bool shotFlag = true;

    Ray ray = new Ray();

    //юс╫ц
    RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        ray.origin = Camera.main.gameObject.transform.position;
        ray.direction = Camera.main.gameObject.transform.forward;

        Physics.Raycast(ray, out hit);
        Debug.DrawRay(ray.origin, ray.direction * Vector3.Distance(ray.origin, hit.point), Color.blue);

        Shot();
    }

    private void Shot()
    {
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            if (shotFlag)
            {
                StartCoroutine(ShotCoroutine());
            }
        }
    }

    IEnumerator ShotCoroutine()
    {
        shotFlag = false;

        shotSound.Play();

        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            Vector3 hitPosition = raycastHit.point;

            Debug.Log(hitPosition);
        }

        CreateBullet(raycastHit.point);

        Debug.Log("shot");

        yield return new WaitForSeconds(0.12f);

        shotFlag = true;
    }

    private void CreateBullet(Vector3 target)
    {
        GameObject newBullet = Instantiate(bullet, firePosition.position, Quaternion.identity);

        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        bulletScript.target = target;
    }
}
