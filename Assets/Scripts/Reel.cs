using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 500f;
    private bool isSpinning;
    [SerializeField] private float symbolSpacing = 150f;
    private RectTransform[] symbols;
    [SerializeField] private float bottomLimit = -700f;


    private void Start()
    {
        StartSpin();
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
}
