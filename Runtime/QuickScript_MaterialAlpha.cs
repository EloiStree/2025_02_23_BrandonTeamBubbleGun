using UnityEngine;

public class QuickScript_MaterialAlpha: MonoBehaviour
{
    public Material m_material;
    public float m_alphaPercent = 1;
    public float m_minAlpha = 0.2f;
    public float m_maxAlpha = 1;

    public void SetPercent(float percent)
    {
        m_alphaPercent = percent;
        float value = Mathf.Lerp(m_minAlpha, m_maxAlpha, m_alphaPercent);
        Color c = m_material.color;
        c.a = m_alphaPercent;
        m_material.color = c;
    }
}