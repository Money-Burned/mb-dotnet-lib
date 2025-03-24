namespace MoneyBurned.Dotnet.Lib.Data;

public class Resource
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    private decimal costPerWorkHour = 0M;
    public decimal CostPerWorkHour { get { return GetTotalCost(); } set { costPerWorkHour = value; } }
    public bool IsGenericRole { get; set; } = false;
    public int Amount { get; set; } = 1;
    public ResourceCategory Category { get; set; }

    public Resource() {
        Name = string.Empty;
        costPerWorkHour = 0M;
        Amount = 0;
    }

    public Resource(string name, Cost cost, bool isGeneric = false, ResourceCategory category = default)
    {
        Name = name;
        CostPerWorkHour = cost.ValuePerHour;
        IsGenericRole = (category == ResourceCategory.GroupOfAssets || category == ResourceCategory.GroupOfPersons) || isGeneric;
        Category = category;        
    }

    public Resource(string name, Cost cost, int amount, ResourceCategory category = ResourceCategory.GroupOfPersons)
    {
        if (!(category == ResourceCategory.GroupOfAssets || category == ResourceCategory.GroupOfPersons))
        {
            throw new ArgumentException("Please use the common constructor for non-generic resources!");
        }

        Name = name;
        CostPerWorkHour = cost.ValuePerHour;
        IsGenericRole = true;
        Amount = amount;
        Category = category;
    }

    private decimal GetTotalCost()
    {
        return costPerWorkHour * Amount;
    }

    public override string ToString()
    {
        return string.Format($"{(IsGenericRole ? $"{Amount}x " : String.Empty)}{Category} at {CostPerWorkHour:C2}/h");
    }

}