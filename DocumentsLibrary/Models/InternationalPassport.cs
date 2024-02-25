using DocumentsLibrary.Interfaces;

namespace DocumentsLibrary.Models;

public class InternationalPassport : Passport, ITranslatable
{
    public string Type { get; private set; }
    public string CountryCode { get; private set; }
    
    public InternationalPassport(string number, string firstname, string lastname, Sex sex, DateTime dateOfBirth, 
        string nationality, int authority, string record, string placeOfBirth, string placeOfResidence, 
        DateTime registeredOn, ulong taxId, DateTime? taxChecked, DateTime dateOfIssue, DateTime dateOfExpire, 
        string type, string countryCode, string? surname = null) 
        : base(number, firstname, lastname, sex, dateOfBirth, nationality, authority, record, placeOfBirth,
            placeOfResidence, registeredOn, taxId, taxChecked, dateOfIssue, dateOfExpire, surname)
    {
        DocumentName = "Закордонний паспорт";
        Type = type;
        CountryCode = countryCode;
    }
    
    public override string GetRunningTex()
        => base.GetRunningTex() + $" • Document updated on {LoadedAt:t} | {LoadedAt:d}";

    public override Document GetRecordDocument()
    {
        // Retrieve passport from GOV db
        return base.GetRecordDocument();
    }

    public override Uri GetQR()
    {
        // Generate verification link (International WebService)
        return base.GetQR();
    }

    public override int GetBarcode()
    {
        // Generate verification code (International WebService)
        return base.GetBarcode();
    }
    
    public void TranslateToEN()
    {
        // Translate all fields to English
        Console.WriteLine("Translated to English.");
    }

    public void TranslateOriginal()
    {
        // Retrieve original data from the GOV db
        Console.WriteLine("Оригінал документу.");
    }

    public override string ToString() =>
        $"{base.ToString()}\n\tТип: {Type}\n\tКод держави: {CountryCode}";
}
