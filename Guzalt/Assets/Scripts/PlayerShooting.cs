using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public VariableJoystick shootJoystick;
    public LineRenderer aimLine;
    public GameObject bullet;
    public Transform gunEnd;
    public float shootVelocity;

    public GameObject[] arms;
    public GameObject aimArm;

    Vector3 recDir;
    bool canShoot;
    bool isLoaded;

    private void Update()
    {
        if(isLoaded == true)
        {
            canShoot = true;
        }

        Vector3 dir = new Vector3(shootJoystick.Horizontal, shootJoystick.Vertical, 0);

        if (dir.magnitude >= 0.5f)
        {
            RenderAim(dir);
            ActivateAim(dir);
        }
        else
        {
            RenderAim(Vector3.zero);
            DeactivateAim();
        }

        if (dir != Vector3.zero)
        {
            canShoot = false;
            isLoaded = true;
            recDir = dir;
        }

        if(dir == Vector3.zero && canShoot == true && recDir.magnitude >= 0.5f)
        {
            GameObject bulletGO = (GameObject)Instantiate(bullet, gunEnd.position, Quaternion.identity);

            bulletGO.GetComponent<Bullet>().GetDirection(recDir, shootVelocity);

            isLoaded = false;
            canShoot = false;
        }
    }

    void RenderAim(Vector3 direction)
    {
        aimLine.SetPosition(0, gunEnd.position);

        Vector3 _direction = gunEnd.position + (direction.normalized * 8f);

        aimLine.SetPosition(1, _direction);
    }

    void ActivateAim(Vector3 direction)
    {
        foreach(GameObject arm in arms)
        {
            arm.SetActive(false);
        }

        aimArm.SetActive(true);

        aimArm.transform.rotation = Quaternion.Euler(0, 0, 90 + (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
    }

    void DeactivateAim()
    {
        foreach (GameObject arm in arms)
        {
            arm.SetActive(true);
        }

        aimArm.SetActive(false);
    }
}
