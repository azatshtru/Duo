using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject aimArm;

    public GameObject[] arms;

    private Transform target;

    Vector3 direction;
    float angle;
    float xFlip;

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        if(dir.x >= 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
            xFlip = 0;
        }

        if (dir.x < 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
            xFlip = 180;
        }
    }

    public void ActivateAim()
    {
        foreach (GameObject arm in arms)
        {
            arm.SetActive(false);
        }

        aimArm.SetActive(true);
        direction = (target.position - aimArm.transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(xFlip == 180)
        {
            angle *= -1;
        }

        aimArm.transform.rotation = Quaternion.Euler(xFlip, 0, (angle));
    }

    public void DeactivateAim()
    {
        foreach (GameObject arm in arms)
        {
            arm.SetActive(true);
        }

        aimArm.SetActive(false);
    }

    public void UpdateTarget(Transform _target)
    {
        target = _target;
    }
}
