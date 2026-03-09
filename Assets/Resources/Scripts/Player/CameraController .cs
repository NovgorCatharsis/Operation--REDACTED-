using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private AudioClip overchargeSound;

    public int overloadCharges;
    private int countdown = 2;
    private LayerMask oldMask;
    private bool isOverloaded;

    private PlayerInputController playerInputConroller;
    private UIController uiController;

    private void Awake()
    {
        overloadCharges = 10;
        isOverloaded = false;

        uiController = GetComponent<UIController>();
        playerInputConroller = GetComponent<PlayerInputController>();
        playerInputConroller.Overload += ToggleCamera;
    }


    private void ToggleCamera()
    {
        if (isOverloaded || overloadCharges == 0) return;
        oldMask = camera.cullingMask;
        camera.cullingMask = LayerMask.GetMask("Enemy", "Default");

        overloadCharges--;
        AudioSource.PlayClipAtPoint(overchargeSound, transform.position, 0.6f);
        uiController.UpdateUI(overloadCharges);
        isOverloaded = true;
        StartCoroutine(CameraCountdown());
    }

    public IEnumerator CameraCountdown()
    {
        yield return new WaitForSeconds(countdown);
        camera.cullingMask = oldMask;
        isOverloaded = false;
    }
}