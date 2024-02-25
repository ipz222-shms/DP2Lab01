using DocumentsLibrary.Interfaces;

namespace DocumentsLibrary.Models;

public class StudentPass : Document, IQRCheck, IBarcodeCheck
{
    public string StudyForm { get; private set; }
    public string UniversityDetails { get; private set; }
    
    public StudentPass(string number, string firstname, string lastname, DateTime dateOfIssue, DateTime dateOfExpire,
        string studyForm, string universityDetails, string? surname = null) : base(number, firstname, lastname, surname)
    {
        DocumentName = "Студентський квиток";
        DateOfIssue = dateOfIssue;
        DateOfExpire = dateOfExpire;
        StudyForm = studyForm;
        UniversityDetails = universityDetails;
    }

    public override string GetRunningTex()
        => $"• Документ оновлено о {LoadedAt:t} | {LoadedAt:d}";

    public Uri GetQR()
    {
        // Generate verification link
        return new Uri("https://google.com/");
    }

    public int GetBarcode()
    {
        // Generate verification code
        return Random.Shared.Next();;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
