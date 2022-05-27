using System;
using CharacterSystem.States;
using FiniteStateMachine;
using Input;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class Character : MonoBehaviour, IFiniteStateMachine
    {
        [SerializeField] private Transform root;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;
        [SerializeField] private MovementData movementData;
        
        private IState currentState;
        private IPlayerInputSubject input;
        
        [Inject]
        private void Construct(IPlayerInputSubject playerInput)
        {
            input = playerInput;
        }

        private void Start()
        {
            var args = new DefaultArgs
            {
                input = input,
                movementData = movementData,
                animator = animator,
                characterController = characterController,
                root = root
            };
            
            ChangeState(new DefaultState(args));
        }

        public void ChangeState(IState state)
        {
            if (state == null) return;
            
            currentState?.Exit();
            currentState = state;
            currentState.Enter();
        }

        private void Update()
        {
            currentState?.Update();
        }

        private void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }

        private void LateUpdate()
        {
            currentState?.LateUpdate();
        }
    }
}