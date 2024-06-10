using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    private bool increasing = true;
    //text渐变
    public Text textBtn;
    public float fadeSpeed = 0.5f;

    public InputAction anyKeyDownAction;

    //Enemy logic
    public Transform enemyTrans;
    //Camera logic
    public TP_CameraController tpCamera;
    public Transform cameraTrans;
    //look at pos
    public Transform playerTrans;

    private void OnEnable()
    {
        enemyTrans.GetComponent<AICombatSystem>().enabled = false;
        anyKeyDownAction.Enable();
        anyKeyDownAction.performed += OnAnyKeyDown;
    }

    private void OnDisable()
    {
        

        anyKeyDownAction.performed -= OnAnyKeyDown;
        anyKeyDownAction.Disable();
    }

    private void OnAnyKeyDown(InputAction.CallbackContext context)
    {
        this.gameObject.SetActive(false);
        enemyTrans.GetComponent<AICombatSystem>().enabled = true;
        //tpCamera.SetLookPlayerTarget(playerTrans);
        //cameraTrans.eulerAngles = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        

        //图片渐变
        float newAlpha = increasing ? textBtn.color.a + fadeSpeed * Time.deltaTime : textBtn.color.a - fadeSpeed * Time.deltaTime;

        // 切换递增和递减的方向
        if (newAlpha >= 1f)
        {
            newAlpha = 1f;
            increasing = false;
        }
        else if (newAlpha <= 0.2f)
        {
            newAlpha = 0.2f;
            increasing = true;
        }

        // 设置新的颜色，保持原有颜色的 RGB 成分，只修改透明度
        textBtn.color = new Color(textBtn.color.r, textBtn.color.g, textBtn.color.b, newAlpha);
    }
}
