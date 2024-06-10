using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponAnimationEvent : MonoBehaviour
{
    [SerializeField] private Transform hipGS;
    [SerializeField] private Transform handGS;
    [SerializeField] private Transform handKatana;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HitHideGS();
    }

    /// <summary>
    /// ��ʾ��
    /// </summary>
    public void ShowGS()
    {
        //����ֲ���������״̬
        if (!handGS.gameObject.activeSelf)
        {
            //��ʾ�ֲ���
            handGS.gameObject.SetActive(true);

            //���ر�����
            hipGS.gameObject.SetActive(false);

            //�����ֲ�Ĭ�ϵ�
            handKatana.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// ���ش�
    /// </summary>
    public void HideGS()
    {
        //����ֲ�������ʾ״̬
        if (handGS.gameObject.activeSelf)
        {
            //�����ֲ���
            handGS.gameObject.SetActive(false);

            //��ʾ������
            hipGS.gameObject.SetActive(true);

            //��ʾ�ֲ�Ĭ�ϵ�
            handKatana.gameObject.SetActive(true);
        }
    }

    private void HitHideGS()
    {
        if (animator.CheckAnimationTag("Hit") || animator.CheckAnimationTag("ParryHit"))
        {
            handKatana.gameObject.SetActive(true);

            hipGS.gameObject.SetActive(true);
            handGS.gameObject.SetActive(false);
        }
    }
}
