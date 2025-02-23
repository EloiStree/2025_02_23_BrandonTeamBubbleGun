using Unity.VisualScripting;
using UnityEngine;
public class QuickScript_MoveTowardPlayer : MonoBehaviour
{

    public Transform m_whatToFollow;
    public Transform m_whatToMove;

    public float m_moveSpeed = 1;
    public float m_rotateAngle = 50;
    public float m_rotateLerp=1f;



    public void Reset()
    {
        m_whatToMove = transform;
        if (Camera.main != null)
            m_whatToFollow = Camera.main.transform;
        else m_whatToFollow = Camera.allCameras[0].transform;

    }

    private void Update()
    {
        if (m_whatToFollow == null || m_whatToMove == null)
        {
            return;
        }

        Vector3 direction = m_whatToFollow.position - m_whatToMove.position;
        direction.y = m_whatToMove.position.y;
        direction.Normalize();

        Vector3 move = direction * m_moveSpeed * Time.deltaTime;
        m_whatToMove.position += move;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        m_whatToMove.rotation = Quaternion.Lerp(m_whatToMove.rotation, targetRotation, m_rotateLerp * Time.deltaTime);

    }    
}
