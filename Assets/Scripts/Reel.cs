using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 500f;
    private bool isSpinning;
    [SerializeField] private float symbolSpacing = 150f;
    private RectTransform[] symbols;
    [SerializeField] private float bottomLimit = -700f;

    private bool shouldStop;
    private Symbol.SymbolType targetSymbolType;
    [SerializeField] private RectTransform centerMarker;

    private const float centerY = -152f;

    public bool IsSpinning => isSpinning;


    private void Start()
    {
        symbols = GetComponentsInChildren<RectTransform>();
    }
    public void StartSpin()
    {
        isSpinning = true;
    }

    private void Update()
    {
        if (isSpinning == false)
        {
            return;
        }

        foreach (RectTransform symbol in symbols)
        {
            if (symbol == transform)
            {
                continue;
            }

            symbol.Translate(Vector3.down * spinSpeed * Time.deltaTime);

            if (symbol.localPosition.y < bottomLimit)
            {
                float highestY = GetHighestSymbolY();

                symbol.localPosition = new Vector3(symbol.localPosition.x, highestY + symbolSpacing, symbol.localPosition.z);
            }

            if (shouldStop)
            {
                Symbol symbolComponent = symbol.GetComponent<Symbol>();

                if (symbolComponent != null && symbolComponent.Type == targetSymbolType && IsCenterNear(symbol))
                {
                    SnapSymbolToCenter(symbol);

                    isSpinning = false;
                    shouldStop = false;
                }
            }
        }

    }

    private float GetHighestSymbolY()
    {
        float highestY = float.MinValue;

        foreach (RectTransform symbol in symbols)
        {
            if (symbol == transform)
            {
                continue;
            }

            if (symbol.localPosition.y > highestY)
            {
                highestY = symbol.localPosition.y;
            }
        }
        return highestY;
    }

    public void StopSpin(Symbol.SymbolType symbolType)
    {
        targetSymbolType = symbolType;
        shouldStop = true;
    }

    private bool IsCenterNear(RectTransform symbol)
    {
        return Mathf.Abs(symbol.position.y - centerMarker.position.y) < 10f;
    }

    private void SnapSymbolToCenter(RectTransform targetSymbol)
    {
        float offset = centerY - targetSymbol.localPosition.y;

        foreach (RectTransform symbol in symbols)
        {
            if (symbol == transform)
            {
                continue;
            }

            symbol.localPosition += Vector3.up * offset;
        }
    }

}
