using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{

    public Transform toAlanHouse;
    public Transform toTeacherHouse;
    public float distanciaObjetivo;
    public bool cenaFinalizada;
    public ScriptableObject cenaProvaFinalizada;
    public ScriptableObject cenaProfessoraComFome;
    private Transform Target;


    public void ChangeTarget(Transform target)
    {
         Target = target;
    }

    private void validaCenas()
    {
        if (cenaProvaFinalizada.Equals(true))
        {
            ChangeTarget(toAlanHouse);
        }
        else if (cenaProfessoraComFome.Equals(true))
        {
            ChangeTarget(toTeacherHouse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cenaFinalizada)
        {
            validaCenas();
        }

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
