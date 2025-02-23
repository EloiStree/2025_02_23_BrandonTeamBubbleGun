using UnityEngine;
using UnityEngine.Events;

public class QuickScript_BubbleTimePusher : MonoBehaviour
{

    public GameObject m_whatToSpawn;
    public Transform m_whereToSpawn;
    public GameObject m_parentHolder;
    public float m_minTime = 0;
    public float m_maxTime = 3;
    public float m_minForce = 5;
    public float m_maxForce = 20;
    public ForceMode m_forceMode= ForceMode.Impulse;

    public float m_killTime = 30;

    public bool m_isLoading;
    public float m_currentLoadingTime;

    public UnityEvent<float> m_onLoadingUpdated;


 
    [ContextMenu("Start loading")]
    public void StartLoading()
    {
        m_isLoading = true;        
    }
    [ContextMenu("Stop loading")]
    public void StopLoading()
    {
        m_isLoading = false;
        float percentLoad =  m_currentLoadingTime-m_minTime / (m_maxTime - m_minTime);
        percentLoad = Mathf.Clamp01(percentLoad);
        ShotWithForcePercent(percentLoad);

        m_currentLoadingTime = 0;
        m_onLoadingUpdated.Invoke(percentLoad);

        
    }
    public void ShotWithForcePercent(float forcePrecent) {

        GameObject go = Instantiate(m_whatToSpawn, m_whereToSpawn.position, m_whereToSpawn.rotation);
        go.transform.SetParent(m_parentHolder.transform);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(m_whereToSpawn.forward * Mathf.Lerp(m_minForce, m_maxForce, forcePrecent), m_forceMode);
        }    

        if (m_killTime > 0f)
        {
            Destroy(go, m_killTime);
        }
        m_currentLoadingTime = 0;
        m_onLoadingUpdated.Invoke(0);
    }

    public void Update()
    {
        if (m_isLoading)
        {
            m_currentLoadingTime += Time.deltaTime;
        }
    }

}
