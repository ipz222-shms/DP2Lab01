namespace DocumentsLibrary.Models;

public class DiaDocument : Passport
{
    public DiaDocument(string number, string firstname, string lastname, Sex sex, DateTime dateOfBirth, 
        string nationality, int authority, string record, string placeOfBirth, string placeOfResidence, 
        DateTime registeredOn, ulong taxId, DateTime? taxChecked, DateTime dateOfIssue, DateTime dateOfExpire, 
        string? surname = null) : base(number, firstname, lastname, sex, dateOfBirth, nationality, authority, record, 
        placeOfBirth, placeOfResidence, registeredOn, taxId, taxChecked, dateOfIssue, dateOfExpire, surname)
    {
        DocumentName = "єДокумент";
    }
    
    public override string GetRunningTex()
        => "Документ діє під час воєнного стану. Ой у лузі червона калина похилилася, чогось наша славна Україна " +
           "зажурилася. А ми тую червону калину підіймемо, а ми нашу славну Україну, гей, гей, розвеселимо!";
}
