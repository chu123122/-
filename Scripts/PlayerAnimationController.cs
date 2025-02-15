using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAnimationController:MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidBody2D;
        private IsGroundTrigger _isGroundTrigger;
        private void Awake()
        {
            _animator=this.GetComponent<Animator>();
            _rigidBody2D=this.GetComponent<Rigidbody2D>();
            _isGroundTrigger=this.GetComponent<IsGroundTrigger>();
        }

        private void Update()
        {
            UpdateAnimatorValue();
        }

        private void UpdateAnimatorValue()
        {
            _animator.SetFloat("velocityX",Mathf.Abs(_rigidBody2D.velocity.x));
            _animator.SetFloat("velocityY",_rigidBody2D.velocity.y);
            _animator.SetBool("isGround",_isGroundTrigger.isGround);
        }
    }
}