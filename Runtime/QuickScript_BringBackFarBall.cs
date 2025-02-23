using UnityEngine;

public class QuickScript_BringBackFarBall : MonoBehaviour
{

    public void Reset()
    {
        
        m_rigidbody= GetComponentInChildren<Rigidbody>();
        if (m_rigidbody == null)
            m_rigidbody = GetComponentInParent<Rigidbody>();
        if (m_rigidbody != null) { 
            m_ballCenter = m_rigidbody.transform;
        }
    }

    public Rigidbody m_rigidbody;
    public Transform m_ballCenter;
    public float m_minForce= 5;
    public float m_maxForce = 20;
    public float m_maxDistance = 3;
    public float m_maxDistanceFullForce = 10;
    public ForceMode m_forceMode = ForceMode.Acceleration;

    void Update()
    {
        float distance = transform.position.magnitude;

        if (distance > m_maxDistance)
        {
            float force = Mathf.Lerp(m_minForce, m_maxForce, Mathf.Clamp01((distance - m_maxDistance) / (m_maxDistanceFullForce - m_maxDistance)));
            Vector3 direction =- transform.position;
            m_rigidbody.AddForce(direction.normalized * force, m_forceMode);
        }
        
    }
}
