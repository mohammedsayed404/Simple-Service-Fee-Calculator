using Service_Fee_Calculator;
Console.Write("How May jobs you need :");
var NumberOfJob = int.Parse(Console.ReadLine()!);

List<RepairJob> jobs = new (NumberOfJob);
int jobsNumber = 1;
while (NumberOfJob -- > 0)
{

Console.Write($"Type of repair job {jobsNumber++} :(basic, regular, complex):");
var type = Console.ReadLine() ?? "";
Console.Write("Description: ");
var description = Console.ReadLine() ?? "";
Console.Write("Start date and time (yyyy-MM-ddTHH:mm:ss): ");
var start = DateTime.Parse(Console.ReadLine()! );
Console.Write("End date and time (yyyy-MM-ddTHH:mm:ss): ");
var end = DateTime.Parse(Console.ReadLine()! );
RepairJob job = type switch 
{
    "basic" => new BasicRepairJob(),
    "regular" => new RegularRepairJob(),
    "complex" => new ComplexRepairJob(),
    _ => throw new ArgumentException("Invalid type of repair job.")
    
};

job.Description = description;
job.Start = start;
job.End = end;
jobs.Add(job);

}

foreach (var job in jobs)
{
    Console.WriteLine($"Fee: {job.CalculateFee():C}");
}

//2023-09-28T09:00:00
