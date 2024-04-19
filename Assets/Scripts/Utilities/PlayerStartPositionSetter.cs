using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStartPositionSetter : MonoBehaviour, IDataPersistence
{
    //feito pelo thiago
    [SerializeField] private StartingPositionData positionData;

    //feito por gustavo e jefferson
    [SerializeField] public StartingPositionData newPositionData;
    [SerializeField] public BoolVariable hasfoundKey;

    [SerializeField] public Image NextDayImage;
    [SerializeField] public Text NextDayText;

    private Vector3 playerPosition;
    private string gameObjectNameForPosition;
    private Direction playerDirection;

    //Gambiarra para setar posição inicial
    public float XValue = 0;
    public float YValue = 0;
    public bool shouldSetInitialPosition = false;

    private void Start()
    {
        Animator animator = transform.GetChild(0).GetComponent<Animator>();
        SetPosition();
        SetDirection(animator);

        if (SceneManager.GetActiveScene().name == "Village")
        {
            setInitialPosition(GameManager.Instance.lastSceneVisited);
        }
    }

    private void setInitialPosition(string lastScene)
    {
        if (GameManager.Instance.isNewDay)
        {
            GameManager.Instance.isNewDay = false;
            StartCoroutine(FadeOutContinueMessage());
            transform.position = new Vector3(-16.49f, 0.53f, 0);
            return;
        }

        switch (lastScene)
        {
            case "HouseIndoors":
                transform.position = new Vector3(-11.35f, 12.49f, 0);
                break;

            case "School":
                transform.position = new Vector3(13.61f, 2.31f, 0);
                break;

            case "OldStudentRoom":
                transform.position = new Vector3(13.61f, -13.18f, 0);
                break;

            default:
                if (hasfoundKey != null)
                {
                    Debug.Log("Key Village: " + hasfoundKey.Value);
                    setStartPosition();
                }
                break;
        }
    }

    private IEnumerator FadeOutContinueMessage()
    {
        NextDayImage.enabled = true;
        NextDayText.enabled = true;

        Color ImageStartColor = new Color(0, 0, 0, 1);
        Color ImageFinalColor = new Color(0, 0, 0, 0);
        NextDayImage.color = ImageStartColor;

        Color TextStartColor = new Color(1, 1, 1, 1);
        Color TextFinalColor = new Color(1, 1, 1, 0);
        NextDayText.color = TextStartColor;

        yield return new WaitForSeconds(1f);

        float elapsedTime = 0f;
        float fadeDuration = 1f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            NextDayImage.color = Color.Lerp(ImageStartColor, ImageFinalColor, t);
            NextDayText.color = Color.Lerp(TextStartColor, TextFinalColor, t);
            yield return null;
        }

        NextDayImage.enabled = false;
        NextDayText.enabled = false;
    }


    /*private void SetPosition()
    {
        Vector3 startingPosition = positionData.GetPosition();

        if (startingPosition.sqrMagnitude > 0)
            transform.position = startingPosition;
    }*/

    public void LoadData(GameData data)
    {
        playerPosition = data.playerPosition;
        gameObjectNameForPosition = data.gameObjectNameForPosition;
        playerDirection = data.playerDirection;
    }

    public void SaveData(GameData data)
    {
        // Nada para salvar
        return;
    }

    private void SetPosition()
    {
        Vector3 startingPosition = Vector3.zero;
        if (playerPosition.sqrMagnitude > 0)
        {
            startingPosition = playerPosition;
        }

        else if (gameObjectNameForPosition != "")
        {
            GameObject target = GameObject.Find(gameObjectNameForPosition);
            if (target)
                startingPosition = target.transform.position;
        }

        transform.position = startingPosition;
    }

    private void SetDirection(Animator animator)
    {
        float xDirection = 0f;
        float yDirection = 0f;
        bool directionSetted = true;

        //switch (positionData.GetDirection())
        switch (playerDirection)
        {
            case Direction.Up:
                yDirection = 1f;
                break;

            case Direction.Down:
                yDirection = -1f;
                break;

            case Direction.Right:
                xDirection = 1f;
                break;

            case Direction.Left:
                xDirection = -1f;
                break;

            default:
                directionSetted = false;
                break;
        }

        if (directionSetted)
        {
            animator.SetFloat("xDirection", xDirection);
            animator.SetFloat("yDirection", yDirection);
        }
    }

    public void SetPositionOnGFX(float delay)
    {
        StartCoroutine(COSetPositionOnGFX(delay));
    }

    private IEnumerator COSetPositionOnGFX(float delay)
    {
        yield return new WaitForSeconds(delay);

        Transform child = transform.GetChild(0);

        //Debug.Log("childPosition: " + child.position);
        //Debug.Log("childLocalPosition: " + child.localPosition);
        //Debug.Log("transformPosition: " + transform.position);

        transform.position = child.position;
        child.localPosition = new Vector3(0, 0, 0);

        //Debug.Log("new childPosition: " + child.position);
        //Debug.Log("new childLocalPosition: " + child.localPosition);
        //Debug.Log("new transformPosition: " + transform.position);
    }

    public void setStartPosition()
    {
        if(newPositionData != null)
        {
            newPositionData.setPos = false;
            transform.position = new Vector3(newPositionData.vector3Position.x, newPositionData.vector3Position.y, 0);
        }
    }

}
