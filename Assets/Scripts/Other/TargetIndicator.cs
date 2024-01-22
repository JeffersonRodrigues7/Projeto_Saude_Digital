using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform Target;
    public float distanciaObjetivo;
    public bool cenaFinalizada;


    public void ChangeTarget(Transform target)
    {
        Target = target;
    }


    // Update is called once per frame
    void Update()
    {
        var dir = Target.position - transform.position;


        if(dir.magnitude < distanciaObjetivo)
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

    private void SetChildrenActive(bool value)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
