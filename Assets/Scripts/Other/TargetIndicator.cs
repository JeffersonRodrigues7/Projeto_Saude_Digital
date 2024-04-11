using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetIndicator : MonoBehaviour
{

    public Transform toAlanHouse;
    public Transform toSchool;
    public Transform toTeacherHouse;
    
    public float distanciaObjetivo;
    private Transform Target;

    public void ChangeTarget(Transform target)
    {
         Target = target;
    }

    private void validaCenas()
    {
        if (GameManager.Instance.GetCenaValue("4_3"))
        {
            ChangeTarget(toSchool);
        }
        else if (GameManager.Instance.GetCenaValue("4_minigame"))
        {
            ChangeTarget(toTeacherHouse);
        }
        else if (GameManager.Instance.GetCenaValue("4_1"))
        {
            ChangeTarget(toTeacherHouse);
        }
        else if (GameManager.Instance.GetCenaValue("3"))
        {
            ChangeTarget(toSchool);
        }
        else if (GameManager.Instance.GetCenaValue("1"))
        {
            ChangeTarget(toAlanHouse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        validaCenas();

        if (Target != null)
        {
            var dir = Target.position - transform.position;


            if (dir.magnitude < distanciaObjetivo)
            {
                SetChildrenActive(false);
            }
            else
            {
                SetChildrenActive(true);
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
        }
    }

    private void SetChildrenActive(bool value)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
