using DocumentsLibrary.Interfaces;

namespace DocumentsLibrary.Models;

public class Passport : Document, ITax, IRecord, IResident, IQRCheck, IBarcodeCheck
{
    public Sex Sex { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Nationality { get; private set; }
    public int Authority { get; private set; }
    public string RecordNumber { get; private set; }
    public string PlaceOfBirth { get; private set; }
    public string PlaceOfResidence { get; private set; }
    public DateTime RegisteredOn { get; private set; }
    public ulong TaxIdentifier { get; private set; }
    public DateTime? TaxCheckedOn { get; private set; }
    
    public Passport(string number, string firstname, string lastname, Sex sex, DateTime dateOfBirth, string nationality,
        int authority, string record, string placeOfBirth, string placeOfResidence, DateTime registeredOn, ulong taxId, 
        DateTime? taxChecked, DateTime dateOfIssue, DateTime dateOfExpire, string? surname = null) 
        : base(number, firstname, lastname, surname)
    {
        DocumentName = "Паспорт громадянина України";
        Sex = sex;
        DateOfBirth = dateOfBirth;
        Nationality = nationality;
        Authority = authority;
        RecordNumber = record;
        PlaceOfBirth = placeOfBirth;
        PlaceOfResidence = placeOfResidence;
        RegisteredOn = registeredOn;
        TaxIdentifier = taxId;
        TaxCheckedOn = taxChecked;
        DateOfIssue = dateOfIssue;
        DateOfExpire = dateOfExpire;
    }

    public override string GetRunningTex()
        => $"• Документ оновлено о {LoadedAt:t} | {LoadedAt:d}";

    public virtual Document GetRecordDocument() => this;

    public byte[] GetPlaceOfResidencePdf()
    {
        // Generate PDF document from the GOV database
        return Array.Empty<byte>();
    }

    public virtual Uri GetQR()
    {
        // Generate verification link (Passports WebService)
        return new Uri("https://google.com/");
    }

    public virtual int GetBarcode()
    {
        // Generate verification code (Passports WebService)
        return Random.Shared.Next();
    }

    public override string ToString() =>
        $"{base.ToString()}\n\tОрган, що видав: {Authority}\n\tСтать: {Sex.ToString()}\n\tГромадянство: {Nationality}" +
        $"\n\tРНОКПП (ІПН): {TaxIdentifier}" +
        $"\n\tПройшов перевірку Державною податковою службою: {(TaxCheckedOn is null ? "Не пройшов." : ((DateTime)TaxCheckedOn).ToString("d"))}" +
        $"\n\tЗапис № (УНЗР): {RecordNumber}\n\tМісце народження: {PlaceOfBirth}\n\tМісце проживання: {PlaceOfResidence}" +
        $"\n\tДата реєстрації: {RegisteredOn:d}";
}
