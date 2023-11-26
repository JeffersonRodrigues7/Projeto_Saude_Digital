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
        // Obtém o componente Button do GameObject atual
        meuBotao = GetComponent<Button>();

        // Adiciona um listener para o evento onClick
        meuBotao.onClick.AddListener(BotaoFoiSolto);
        
    }

    // Este método é chamado quando o botão é solto
    void BotaoFoiSolto()
    {
        catWalk();
        // Faça o que você precisa fazer quando o botão é solto
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


    

