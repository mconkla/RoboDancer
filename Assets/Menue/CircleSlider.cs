using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//public class OnKeyInteract : UnityEngine.XR.Interaction.Toolkit.XRSimpleInteractable
public class CircleSlider: MonoBehaviour
{
    [SerializeField] private Transform handle;
    [SerializeField] private Image fill;
    [SerializeField] private Text valText;
    private Vector3 mousePos;

    public float r;
    
    // Update is called once per frame
    public void OnHandelDrag()
    {
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg ;
        angle = (angle <= 0) ? (360 + angle) : angle;
        if (angle<=225 || angle>=315)
        {
            Quaternion r = Quaternion.AngleAxis( angle + 135f, Vector3.forward);
            handle.rotation = r;
            angle = ((angle >= 315) ? (angle - 360) : angle) + 45;
            fill.fillAmount = 0.75f - (angle / 360f); 
            valText.text = Mathf.Round((fill.fillAmount * 100) / 0.75f).ToString(CultureInfo.InvariantCulture);
        }
    }
}
