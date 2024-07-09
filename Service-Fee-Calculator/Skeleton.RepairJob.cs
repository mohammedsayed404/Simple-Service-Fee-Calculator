namespace Service_Fee_Calculator;


public abstract class RepairJob
{
    public string Description { get; set; } = "";

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public bool Successful { get; set; }

    protected double Duration => (End - Start).TotalHours;
    public abstract decimal CalculateFee();

}




public abstract class TeamRepairJob : RepairJob
{
    public int NumberOfMechanics { get; set; } = 1;

    public override decimal CalculateFee() => CalculateFeeSingleMechanic() * NumberOfMechanics;
    
    public abstract decimal CalculateFeeSingleMechanic();
}

//? BasicJob

public class BasicRepairJob : TeamRepairJob
{

    public override decimal CalculateFeeSingleMechanic()
    {
        var quarters = (int)Math.Ceiling(Duration * 4);

        return quarters * 5;
    }
}

//! Regular Job 
public class RegularRepairJob : TeamRepairJob
{

    public override decimal CalculateFeeSingleMechanic()
    {
        return (int)Math.Ceiling(Duration) * 80;
    }
}

//todo ComplexJob

public class ComplexRepairJob : RepairJob
{
    public override decimal CalculateFee()
    {
        if (Duration <= 4)
        {
            return 500;
        }

        return 800;
    }
}