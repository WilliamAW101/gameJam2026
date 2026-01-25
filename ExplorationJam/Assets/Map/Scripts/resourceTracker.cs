using UnityEngine;

public class resourceTracker : MonoBehaviour
{

    [SerializeField] private int fuelAmount = 500;
    [SerializeField] private int totalCash = 0;
    [SerializeField] private int winningCashAmount = 150;
    [SerializeField] private int maxFuelAmount = 500;
    private bool isLoss = false;
    private bool isWin = false;
    private int highestItemID = -1;
    private int mediumItemID = -1;
    private int lowestItemID = -1;
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

    // keep crap privated, so we have getters and setters
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

    public void setHighestItemID(int id)
    {
        highestItemID = id;
    }
    public void setMediumItemID(int id)
    {
        mediumItemID = id;
    }
    public void setLowestItemID(int id)
    {
        lowestItemID = id;  
    }

    public int getHighestItemID()
    {
        return highestItemID;
    }
    public int getMediumItemID()
    {
        return mediumItemID;
    }
    public int getLowestItemID()
    {
        return lowestItemID;
    }
}
