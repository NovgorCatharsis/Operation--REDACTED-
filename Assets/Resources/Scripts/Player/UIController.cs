using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;

    private CameraController cameraController;

    private VisualElement root;
    private Label chargesLabel;

    void OnEnable()
    {
        root = uiDocument.rootVisualElement;
        chargesLabel = root.Q<Label>("chargesLabel");
        UpdateUI(10);
    }

    public void UpdateUI(int charges)
    {
        chargesLabel.text = $"Charges: {charges}";
    }
}
