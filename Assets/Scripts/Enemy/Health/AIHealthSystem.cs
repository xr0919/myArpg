using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace UGG.Health
{
    public class AIHealthSystem : CharacterHealthSystemBase
    {



        private void LateUpdate()
        {
            OnHitLockTarget();
        }

        public override void TakeDamager(float damagar, string hitAnimationName, Transform attacker)
        {
            SetAttacker(attacker);
            _animator.Play(hitAnimationName, 0, 0f);
            GameAssets.Instance.PlaySoundEffect(_audioSource, SoundAssetsType.hit);
        }

        private void OnHitLockTarget()
        {
            if (_animator.CheckAnimationTag("Hit"))
            {
                transform.rotation = transform.LockOnTarget(currentAttacker, transform, 50);
            }
        }
    }

}