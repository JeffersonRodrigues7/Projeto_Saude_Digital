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

    private GameObject[] goals;

    public float distanciaObjetivo;
    public Text objetivo;
    private Transform Target;

    public void ChangeTarget(Transform target)
    {
         Target = target;
    }

    private void validaCenas()
    {
        if (GameManager.Instance.GetCenaValue("11"))
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
            activeObjective(toTeacherHouse);
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
        goals[0] = toAlanHouse;
        goals[1] = toBathroom;
        goals[2] = toSchool;
        goals[3] = toTeacherHouse;
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
            goals[0].SetActive(true);
            goals[1].SetActive(false);
            goals[2].SetActive(false);
            goals[3].SetActive(false);
        }
        else if (objective == toBathroom)
        {
            goals[0].SetActive(false);
            goals[1].SetActive(true);
            goals[2].SetActive(false);
            goals[3].SetActive(false);
        }
        else if (objective == toSchool)
        {
            goals[0].SetActive(false);
            goals[1].SetActive(false);
            goals[2].SetActive(true);
            goals[3].SetActive(false);
        }
        else if (objective == toTeacherHouse)
        {
            goals[0].SetActive(false);
            goals[1].SetActive(false);
            goals[2].SetActive(false);
            goals[3].SetActive(true);
        }
    }
}
