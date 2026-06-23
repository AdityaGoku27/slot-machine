using UnityEngine;
using System.Collections;

public class SlotMachineManager : MonoBehaviour
{
    [SerializeField] private Reel reel1;
    [SerializeField] private Reel reel2;
    [SerializeField] private Reel reel3;

    private void Start()
    {
        Spin();
    }
    public void Spin()
    {
        reel1.StartSpin();
        reel2.StartSpin();
        reel3.StartSpin();

        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {

        Symbol.SymbolType reel1Result = GetRandomSymbol();
        Symbol.SymbolType reel2Result = GetRandomSymbol();
        Symbol.SymbolType reel3Result = GetRandomSymbol();

        yield return new WaitForSeconds(5f);

        reel1.StopSpin(reel1Result);

        yield return new WaitForSeconds(2f);

        reel2.StopSpin(reel2Result);

        yield return new WaitForSeconds(2f);

        reel3.StopSpin(reel3Result);    
    }

    private Symbol.SymbolType GetRandomSymbol()
    {
        int randomIndex = Random.Range(0,4);

        return (Symbol.SymbolType)randomIndex;
    }
}
