using UnityEngine;

public class resourceTracker : MonoBehaviour
{

    [SerializeField] private int fuelAmount = 500;
    [SerializeField] private int totalCash = 0;
    [SerializeField] private int winningCashAmount = 150;
    [SerializeField] private int maxFuelAmount = 500;
    private bool isLoss = false;
    private bool isWin = false;
    public static resourceTracker Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int getFuelAmount()
    {
        return fuelAmount;
    }

    public int getMaxFuelAmount()
    {
        return maxFuelAmount;
    }

    public void useFuel(int amount)
    {
        fuelAmount -= amount;
        if (fuelAmount < 0)
        {
            fuelAmount = 0;
            isLoss = true;
        }
    }

    public int getTotalCash()
    {
        return totalCash;
    }

    public void addCash(int amount)
    {
        totalCash += amount;
    }

    public bool getLoss()
    {
        return isLoss;
    }
}
