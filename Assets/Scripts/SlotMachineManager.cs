using UnityEngine;
using System.Collections;
using TMPro;

public class SlotMachineManager : MonoBehaviour
{
    [SerializeField] private Reel reel1;
    [SerializeField] private Reel reel2;
    [SerializeField] private Reel reel3;

    [SerializeField] private Lever lever;

    private Symbol.SymbolType reel1Result;
    private Symbol.SymbolType reel2Result;
    private Symbol.SymbolType reel3Result;

    [SerializeField] private int startingCredits = 100;
    [SerializeField] private int spinCost = 10;
    private int credits;

    [SerializeField] private TMP_Text creditText;

    [SerializeField] private GameObject winPopup;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private TMP_Text payoutText;

    private void Start()
    {
        credits = startingCredits;
        UpdateCreditUI();
    }

    public void Spin()
    {
        if (credits < spinCost)
        {
            return;
        }

        credits -= spinCost;

        UpdateCreditUI();

        reel1.StartSpin();
        reel2.StartSpin();
        reel3.StartSpin();

        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {

        reel1Result = GetRandomSymbol();
        reel2Result = GetRandomSymbol();
        reel3Result = GetRandomSymbol();

        yield return new WaitForSeconds(5f);

        reel1.StopSpin(reel1Result);

        yield return new WaitForSeconds(2f);

        reel2.StopSpin(reel2Result);

        yield return new WaitForSeconds(2f);

        reel3.StopSpin(reel3Result);

        yield return new WaitUntil(() => !reel3.IsSpinning);

        CheckWin();
        lever.SetLeverUp();
    }

    private Symbol.SymbolType GetRandomSymbol()
    {
        int randomIndex = Random.Range(0,4);

        return (Symbol.SymbolType)randomIndex;
    }

    private void CheckWin()
    {
        if (reel1Result == reel2Result && reel2Result == reel3Result)
        {
            int payout = GetPayout();
            credits += payout;

            UpdateCreditUI();

            ShowPopup(payout);

            Debug.Log($"WIN +{payout}");
            Debug.Log($"Credits: {credits}");
        }
        else
        {
            Debug.Log("LOSE");
            Debug.Log($"Credits: {credits}");
        }
    }

    private int GetPayout()
    {
        switch (reel1Result)
        {
            case Symbol.SymbolType.Bell:
                return 20;

            case Symbol.SymbolType.Cherry:
                return 30;

            case Symbol.SymbolType.Bar:
                return 50;

            case Symbol.SymbolType.Seven:
                return 100;

            default:
                return 0;
        }
    }

    private void UpdateCreditUI()
    {
        creditText.text = $"Credits: {credits}";
    }

    private void ShowPopup(int payout)
    {
        winPopup.SetActive(true);
        winText.text = "YOU WIN!";
        payoutText.text = $"+{payout} Credits";

        StartCoroutine(HidePopup());
    }

    private IEnumerator HidePopup()
    {
        yield return new WaitForSeconds(2f);
        winPopup.SetActive(false);
    }
}
