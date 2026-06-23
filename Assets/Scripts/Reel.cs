using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 500f;
    private bool isSpinning;


    private void Start()
    {
        StartSpin();
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

        transform.Translate(Vector3.down * spinSpeed * Time.deltaTime);
    }
}
