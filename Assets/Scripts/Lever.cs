using UnityEngine;
using UnityEngine.UI;
public class Lever : MonoBehaviour
{
    [SerializeField] private SlotMachineManager slotMachineManager;
    [SerializeField] private GameObject leverUp;
    [SerializeField] private GameObject leverDown;

    public void OnLeverClicked()
    {
        leverUp.SetActive(false);
        leverDown.SetActive(true);
        slotMachineManager.Spin();
    }

    public void SetLeverUp()
    {
        leverUp.SetActive(true);
        leverDown.SetActive(false);
    }

    public void SetLeverDown()
    {
        leverUp.SetActive(false);
        leverDown.SetActive(true);
    }
}
