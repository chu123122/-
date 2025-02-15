using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class IsGroundTrigger:MonoBehaviour
    {
         public bool isGround;
         public LayerMask groundLayer;
         public float radius;

        private void Update()
        {
            CheckIsGround();
        }

        private void CheckIsGround()
        {
            isGround = Physics2D.OverlapCircle( transform.position,radius,groundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere( transform.position,radius);
        }
    }
}