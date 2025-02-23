using UnityEngine;

public class QuickScript_HitToRandomRepopAround : MonoBehaviour {


    private void Reset()
    {
        Rigidbody t = GetComponentInParent<Rigidbody>();
        if (t != null)
            m_whatToMove = t.transform;
        else
            m_whatToMove = transform;
    }

    public Transform m_whatToMove;


    public float m_repopDistance = 20;
    public int m_lifeAtStart = 7;
    public int m_life = 7;

    private void Start()
    {
        m_life = m_lifeAtStart;
    }
    public void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Hit" + collision.gameObject.name, collision.gameObject);
        SlimBulletTag tag = null;
        tag = collision.gameObject.GetComponent<SlimBulletTag>();
        if (tag == null)
            tag = collision.gameObject.GetComponentInParent<SlimBulletTag>();
        if (tag == null)
            tag = collision.gameObject.GetComponentInChildren<SlimBulletTag>();
        if (tag == null)
            return;

        m_life--;
        if (tag.m_oneShot)
            m_life = 0;
        if (m_life <= 0)
        {
            float randomX= Random.value *m_repopDistance;
            float randomZ= Random.value *m_repopDistance;
            Vector3 randomPos = new Vector3(randomX, 0, randomZ);
            m_whatToMove.position = randomPos; 
            m_life = m_lifeAtStart;
           GameObject go = GameObject.Instantiate(m_whatToMove.gameObject, m_whatToMove.position+Vector3.right, m_whatToMove.rotation);
            go.transform.parent = m_whatToMove.transform.parent;
            go.transform.localScale = m_whatToMove.localScale;

        }
    }
}
