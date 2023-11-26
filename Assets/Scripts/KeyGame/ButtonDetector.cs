using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDetector : MonoBehaviour
{
    private Button meuBotao;
    public PlayerSwipeController playerSwipeController;

    void Start()
    {
        // Obt�m o componente Button do GameObject atual
        meuBotao = GetComponent<Button>();

        // Adiciona um listener para o evento onClick
        meuBotao.onClick.AddListener(BotaoFoiSolto);
        
    }

    // Este m�todo � chamado quando o bot�o � solto
    void BotaoFoiSolto()
    {
        catWalk();
        // Fa�a o que voc� precisa fazer quando o bot�o � solto
    }

    public void catRun()
    { 
        playerSwipeController.moveSpeed = 10.0f;
    }

    public void catWalk()
    {
        
        playerSwipeController.moveSpeed = 3.0f;
    }
}


    

