using FiniteStateMachine;
using Input;
using UnityEngine;

namespace CharacterSystem.States
{
    public class DefaultState: IState
    {
        private readonly IPlayerInputSubject input;
        private readonly MovementData movementData;
        private readonly Animator animator;
        private readonly CharacterController characterController;
        private readonly Transform root;
        
        public DefaultState(DefaultArgs args)
        {
            input = args.input;
            movementData = args.movementData;
            characterController = args.characterController;
            animator = args.animator;
            root = args.root;
        }
        
        public void Enter()
        {
            
        }

        public void Exit()
        {
        }

        public void Update()
        {
            var vector2 = input.PlayerActions.Move.ReadValue<Vector2>() ;
            //RotateToDirection(vector2);
            var magnitude = vector2.magnitude;
            var vector3 = new Vector3(vector2.x, movementData.gravity, vector2.y) ;
            vector3 *= movementData.speed * Time.deltaTime;
            animator.SetFloat("Moving", vector2.x, 0.1f, Time.deltaTime);
            animator.SetFloat("Strafe", vector2.y, 0.1f, Time.deltaTime);
            characterController.Move(vector3);

        }

        private void RotateToDirection(Vector2 vector2)
        {
            if(vector2 == Vector2.zero) return;
            
            var vector3 = new Vector3(vector2.x, 0, vector2.y);
            var toRotation = Quaternion.LookRotation(vector3, Vector3.up);
            
            root.rotation = Quaternion.RotateTowards(root.rotation, toRotation, movementData.rotationSpeed*Time.deltaTime);
        }
    }
}