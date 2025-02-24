#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MoneyBurned.Dotnet.Lib.Data;

public class Resource(string name, Cost cost)
{
    public string Name { get; private set; } = name;
    public decimal CostPerWorkHour { get; private set; } = cost.ValuePerHour;

    public override string ToString()
    {
        return string.Format("Resource {0} at {1:C2}/h", Name, CostPerWorkHour);
    }

}