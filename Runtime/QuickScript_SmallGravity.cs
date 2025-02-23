using UnityEngine;

public class QuickScript_SmallGravity : MonoBehaviour
{
    public Rigidbody m_toAffect;
    public ForceMode m_forceType = ForceMode.Acceleration;
    public float m_gravityForce = 0.1f;

    public float m_touchImpact = 5;
    public ForceMode m_touchForceMode = ForceMode.Impulse;

    public void Update()
    {
        if (m_toAffect != null)
        {
          
            m_toAffect.AddForce(Vector3.down * m_gravityForce, m_forceType);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (m_toAffect != null)
        {

            Vector3 velocity = m_toAffect.linearVelocity;
            velocity.y -= m_gravityForce;
            m_toAffect.linearVelocity = velocity;
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 oppositeDirect= m_toAffect.transform.position - contactPoint;

            m_toAffect.AddForce(oppositeDirect * m_touchImpact, m_touchForceMode);
        }
    }
 
}
