using UnityEngine;

public class CamerasManager : MonoBehaviour, IManager
{
    [SerializeField]
    private Camera inGameCamera;

    [SerializeField]
    private Camera uiCamera;

    public void StartGame()
    {
        SwapCameras();
    }

    public void EndGame()
    {
        SwapCameras();
    }

    // Костиль, потрібний для анімації переходу камери на запуску гри
    private void SwapCameras()
    {
        inGameCamera.gameObject.SetActive(!inGameCamera.gameObject.activeSelf);
        uiCamera.gameObject.SetActive(!uiCamera.gameObject.activeSelf);
    }
}