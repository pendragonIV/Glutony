using UnityEngine;

public class LayerSwitcher : MonoBehaviour
{
    [SerializeField] private string _entryLayerName;
    [SerializeField] private string _exitLayerName;

    private void OnTriggerEnter(Collider colliding)
    {
        if (colliding.CompareTag("LayerSwitchable") || colliding.CompareTag("Unedible"))
        {
            colliding.gameObject.layer = LayerMask.NameToLayer(_entryLayerName);
        }
    }

    private void OnTriggerExit(Collider colliding)
    {
        if (colliding.CompareTag("LayerSwitchable") || colliding.CompareTag("Unedible"))
        {
            colliding.gameObject.layer = LayerMask.NameToLayer(_exitLayerName);
        }
    }
}
