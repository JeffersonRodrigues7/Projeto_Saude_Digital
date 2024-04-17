using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetIndicator : MonoBehaviour
{

    public Transform toAlanHouse;
    public Transform toSchool;
    public Transform toTeacherHouse;
    
    public float distanciaObjetivo;
    public Text objetivo;
    private Transform Target;

    public void ChangeTarget(Transform target)
    {
         Target = target;
    }

    private void validaCenas()
    {
        if (GameManager.Instance.GetCenaValue("5"))
        {
            ChangeTarget(toSchool);
            objetivo.text = "Hora de fazer mais uma prova!";
        }
        else if (GameManager.Instance.GetCenaValue("4_4"))
        {
            ChangeTarget(toAlanHouse);
            objetivo.text = "Compartilhe com Alan o que aprendeu";
        }
        else if (GameManager.Instance.GetCenaValue("4_3"))
        {
            ChangeTarget(toSchool);
            objetivo.text = "Volte à escola para entregar o lanche da professora";
        }
        else if (GameManager.Instance.GetCenaValue("4_minigame"))
        {
            ChangeTarget(toTeacherHouse);
            objetivo.text = "Devolva a chave para o Rogério";
        }
        else if (GameManager.Instance.GetCenaValue("4_1"))
        {
            ChangeTarget(toTeacherHouse);
            objetivo.text = "Entenda por qual motivo a professora está sem o seu lanche";
        }
        else if (GameManager.Instance.GetCenaValue("3"))
        {
            ChangeTarget(toSchool);
            objetivo.text = "Converse com a professora na escola";
        }
        else if (GameManager.Instance.GetCenaValue("1"))
        {
            ChangeTarget(toAlanHouse);
            objetivo.text = "Entenda porque Alan não foi à escola";
        }else
        {
            objetivo.text = "Algo deu errado, você está sem objetivo";
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
