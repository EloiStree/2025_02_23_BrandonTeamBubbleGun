using UnityEngine;

public class QuickScript_ChangeRendererAlpha :MonoBehaviour
{
    public Renderer m_renderer;
    public float m_alphaPercent = 1;
    public float m_minAlpha = 0.2f;
    public float m_maxAlpha = 1;
    public Color m_minColor = Color.red;
    public Color m_maxColor = Color.green;


    public void SetPercent(float percent) { 
        m_alphaPercent = percent;
        float value = Mathf.Lerp(m_minAlpha, m_maxAlpha, m_alphaPercent);
        Color  c= Color.Lerp(m_minColor, m_maxColor, m_alphaPercent);
        c.a = value;
        m_renderer.material.color = c;
    }
}
