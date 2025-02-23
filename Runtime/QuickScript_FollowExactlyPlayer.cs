using UnityEngine;

public class QuickScript_FollowExactlyPlayer : MonoBehaviour { 

    public Transform m_whatToFollow;
    public Transform m_whatToMove;

    public bool m_useCameraMain = true;
    public bool m_usePlayerTag = true;

    public void Reset()
    {
        m_whatToMove = transform;
    }
    public void Update()
    {
        if (m_whatToFollow == null && m_useCameraMain) {         
            m_whatToFollow = m_useCameraMain ? Camera.main.transform :  Camera.allCameras[0]?.transform;
        }

        if (m_whatToFollow == null && m_usePlayerTag)
        {
            m_whatToFollow = GameObject.FindGameObjectWithTag("Player")?.transform;   
        }

        if (m_whatToFollow == null)
        {
            return;
        }
        m_whatToMove.position = m_whatToFollow.position;
        m_whatToMove.rotation = m_whatToFollow.rotation;
    }
}
