using System;
using UnityEngine;

namespace AnimationSystem
{
    public class FootIK : MonoBehaviour
    {
        [SerializeField] private Transform leftToe;
        [SerializeField] private Transform rightToe;
        [SerializeField] private LayerMask mask;
        [SerializeField] private float rayWidth;
        [SerializeField] private float yOffset;
        [SerializeField] private float footHeight;
        
        private Animator animator;
        private Vector3 leftGiz;
        private Vector3 rightGiz;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if(!animator) return;
            

            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("LeftIKWeight"));
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, animator.GetFloat("RightIKWeight"));
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("LeftIKWeight"));
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, animator.GetFloat("RightIKWeight"));
            
            var leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
            var rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);
            
            PushRay(leftFoot, leftToe, AvatarIKGoal.LeftFoot);
            PushRay(rightFoot, rightToe, AvatarIKGoal.RightFoot);

        }

        private void PushRay(Transform foot, Transform toe,  AvatarIKGoal goal)
        {
            var origin = foot.position;
            origin.y += yOffset;
            if (Physics.Raycast(origin, -foot.up, out var hit, rayWidth, mask))
            {
                var point = hit.point;
                point.y += footHeight;
                Debug.DrawLine(origin, origin - (foot.up * rayWidth), Color.red);
                animator.SetIKPosition(goal, point);
                var rotation = Quaternion.LookRotation(foot.forward, hit.normal);
                animator.SetIKRotation(goal,rotation);
            }
            
            
            
        }

        private void OnDrawGizmos()
        {
            if(leftGiz != Vector3.zero)
                Gizmos.DrawCube(leftGiz, Vector3.one * 0.1f);
            if(rightGiz != Vector3.zero)
                Gizmos.DrawCube(rightGiz, Vector3.one * 0.1f);
        }
    }
}