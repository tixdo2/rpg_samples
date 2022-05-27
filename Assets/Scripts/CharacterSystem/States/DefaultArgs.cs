using Input;
using UnityEngine;

namespace CharacterSystem.States
{
    public class DefaultArgs
    {
        public IPlayerInputSubject input;
        public MovementData movementData;
        public Animator animator;
        public CharacterController characterController;
        public Transform root;
    }
}