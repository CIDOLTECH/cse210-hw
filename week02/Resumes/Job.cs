public class Job
{
    // Member variables (by convention: underscore + lowercase)
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Displays the job info in the format:
    // "Job Title (Company) StartYear-EndYear"
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
