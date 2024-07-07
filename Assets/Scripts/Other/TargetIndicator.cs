using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetIndicator : MonoBehaviour
{

    public GameObject toAlanHouse;
    public GameObject toSchool;
    public GameObject toOldStudent;
    public GameObject toTeacherHouse;
    public GameObject toBathroom;

    public float distanciaObjetivo;
    public Text objetivo;
    private Transform Target;

    public void ChangeTarget(Transform target)
    {
         Target = target;
    }

    private void validaCenas()
    {


        if (GameManager.Instance.GetCenaValue("13"))
        {
            ChangeTarget(toSchool.transform);
            objetivo.text = "Encontre a Beatriz na escola";
            activeObjective(toSchool);
        }

        else if (GameManager.Instance.GetCenaValue("11"))
        {
            ChangeTarget(toOldStudent.transform);
            objetivo.text = "Visite o aluno antigo!";
            activeObjective(toOldStudent);
        }

        else if (GameManager.Instance.GetCenaValue("8"))
        {
            ChangeTarget(toSchool.transform);
            objetivo.text = "Hora de ir para a escola novamente!";
            activeObjective(toSchool);
        }
        else if (GameManager.Instance.GetCenaValue("7"))
        {
            ChangeTarget(toBathroom.transform);
            objetivo.text = "URGENTE! vá ao banheiro!!";
            activeObjective(toBathroom);
        }
        else if (GameManager.Instance.GetCenaValue("5"))
        {
            ChangeTarget(toSchool.transform);
            objetivo.text = "Hora de fazer mais uma prova!";
            activeObjective(toSchool);
        }
        else if (GameManager.Instance.GetCenaValue("4_4"))
        {
            ChangeTarget(toAlanHouse.transform);
            objetivo.text = "Compartilhe com Alan o que aprendeu";
            activeObjective(toAlanHouse);
        }
        else if (GameManager.Instance.GetCenaValue("4_3"))
        {
            ChangeTarget(toSchool.transform);
            objetivo.text = "Volte à escola para entregar o lanche da professora";
            activeObjective(toSchool);
        }
        else if (GameManager.Instance.GetCenaValue("4_minigame"))
        {
            ChangeTarget(toTeacherHouse.transform);
            objetivo.text = "Devolva a chave para o Rogério";
            activeObjective(toTeacherHouse);
        }
        else if (GameManager.Instance.GetCenaValue("4_1"))
        {
            ChangeTarget(toTeacherHouse.transform);
            objetivo.text = "Entenda por qual motivo a professora está sem o seu lanche";
            activeObjective(toTeacherHouse);
        }
        else if (GameManager.Instance.GetCenaValue("3"))
        {
            ChangeTarget(toSchool.transform);
            objetivo.text = "Converse com a professora na escola";
            activeObjective(toSchool);
        }
        else if (GameManager.Instance.GetCenaValue("1"))
        {
            ChangeTarget(toAlanHouse.transform);
            objetivo.text = "Entenda porque Alan não foi à escola";
            activeObjective(toAlanHouse);
        }
        else
        {
            objetivo.text = "Algo deu errado, você está sem objetivo";
        }
    }

    private void Start()
    {
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

    private void activeObjective(GameObject objective)
    {
        if (objective == toAlanHouse)
        {
            toAlanHouse.SetActive(true);
            toBathroom.SetActive(false);
            toTeacherHouse.SetActive(false);
            toOldStudent.SetActive(false);
            toSchool.SetActive(false);
        }

        else if (objective == toBathroom)
        {
            toAlanHouse.SetActive(false);
            toBathroom.SetActive(true);
            toTeacherHouse.SetActive(false);
            toOldStudent.SetActive(false);
            toSchool.SetActive(false);
        }

        else if (objective == toSchool)
        {
            toAlanHouse.SetActive(false);
            toBathroom.SetActive(false);
            toTeacherHouse.SetActive(false);
            toOldStudent.SetActive(false);
            toSchool.SetActive(true);
        }

        else if (objective == toTeacherHouse)
        {
            toAlanHouse.SetActive(false);
            toBathroom.SetActive(false);
            toTeacherHouse.SetActive(true);
            toOldStudent.SetActive(false);
            toSchool.SetActive(false);
        }

        else if(objective == toOldStudent)
        {
            toAlanHouse.SetActive(false);
            toBathroom.SetActive(false);
            toTeacherHouse.SetActive(false);
            toOldStudent.SetActive(true);
            toSchool.SetActive(false);
        }
    }
}
