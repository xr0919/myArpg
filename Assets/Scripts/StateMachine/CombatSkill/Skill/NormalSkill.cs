using System.Collections;
using System.Collections.Generic;
using UGG.Move;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalSkill", menuName = "Skill/NormalSkill")]
public class NormalSkill : CombatSkillBase
{
    public override void InvokeSkill()
    {
        if (animator.CheckAnimationTag("Motion") && skillIsDone)
        {
            //�����ܱ����� ����û���������ͷž���
            if (combat.GetCurrentTargetDistance() > skillUseDistance + 0.1f)
            {
                movement.CharacterMoveInterface(combat.GetDirectionForTarget(), 1.4f, true);

                animator.SetFloat(verticalID, 1f, 0.25f, Time.deltaTime);
                animator.SetFloat(horizontalID, 0f, 0.25f, Time.deltaTime);
                //animator.SetFloat(runID, 1f, 0.25f, Time.deltaTime);
            }
            else
            {
                UseSkill();
            }
        }
    }
}
