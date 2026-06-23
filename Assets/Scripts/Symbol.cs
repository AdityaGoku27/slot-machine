using UnityEngine;

public class Symbol : MonoBehaviour
{
    public enum SymbolType
    { 
        Bell,
        Cherry,
        Bar,
        Seven
    }

    [SerializeField] private SymbolType symbolType;

    public SymbolType Type => symbolType;

}
