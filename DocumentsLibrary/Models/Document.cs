namespace DocumentsLibrary.Models;

public abstract class Document
{
    public string DocumentName { get; protected set; }
    public DateTime LoadedAt { get; private set; }
    public string Number { get; private set; }
    
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public string? Surname { get; private set; }
    public byte[]? Photo { get; protected set; } 
    public DateTime? DateOfIssue { get; protected set; }
    public DateTime? DateOfExpire { get; protected set; }

    protected Document(string number, string firstname, string lastname, string? surname = null)
    {
        DocumentName = "Документ";
        LoadedAt = DateTime.Now;
        
        Number = number;
        Firstname = firstname;
        Lastname = lastname;
        Surname = surname;
    }
    
    public abstract string GetRunningTex();

    // Display method, might be another abstract method for generating UI object.
    public override string ToString()
    {
        var result = $"{DocumentName}: {Number}\n\tВласник: {Lastname} {Firstname} {Surname ?? ""}" +
                        $"\n\tPhoto: {(Photo is null ? "Відсутнє" : "Присутнє")}";
        if (DateOfIssue is not null)
            result += $"\n\tДата видачі: {DateOfIssue:d}";
        if (DateOfExpire is not null)
            result += $"\n\tДійсний до: {DateOfExpire:d}";
        return result;
    }
}
