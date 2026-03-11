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

    public static bool TryReadResources(string resourceString, out List<Resource> resources)
    {
        resources = [];
        try
        {
            string[] resourceStringArray = resourceString.Split([';', '+'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (resourceStringArray != null && resourceStringArray.Length > 0)
            {
                for (int i = 0; i < resourceStringArray.Length; i++)
                {
                    string[] resource = resourceStringArray[i].Split(":", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    if (resource.Length == 2)
                    {
                        resources.Add(new Resource(resource[0], new Cost(resource[1]), false, ResourceCategory.Person));
                    }
                    else
                    {
                        // TODO: This is a very basic implementation and should be improved in the future. It only checks for 'x' or '*' to determine if it's a generic role, but there could be other formats or indicators for generic roles. Additionally, it assumes that the format is always "amount x cost" or "cost" which may not always be the case. A more robust parsing logic should be implemented to handle different formats and edge cases.
                        if(resource[0].ToLower().Contains('x') || resource[0].ToLower().Contains('*'))
                        {
                            string[] amountAndCost = resource[0].Split(['x', '*'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                            resources.Add(new Resource("People", new Cost(amountAndCost[1]), int.Parse(amountAndCost[0]), ResourceCategory.GroupOfPersons));
                        }
                        else
                        {
                            resources.Add(new Resource("Person", new Cost(resource[0]), true, ResourceCategory.Person));
                        }
                    }
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Resources from resource string input are not valid because of {0}", ex.Message);
            return false;
        }
    }    

    public override string ToString()
    {
        return string.Format($"{(IsGenericRole ? $"{Amount}x " : String.Empty)}{(IsGenericRole ? Category : Name)} at {CostPerWorkHour:C2}/h");
    }

}