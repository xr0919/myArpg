using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    private bool increasing = true;
    //text����
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
        

        //ͼƬ����
        float newAlpha = increasing ? textBtn.color.a + fadeSpeed * Time.deltaTime : textBtn.color.a - fadeSpeed * Time.deltaTime;

        // �л������͵ݼ��ķ���
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

        // �����µ���ɫ������ԭ����ɫ�� RGB �ɷ֣�ֻ�޸�͸����
        textBtn.color = new Color(textBtn.color.r, textBtn.color.g, textBtn.color.b, newAlpha);
    }
}
