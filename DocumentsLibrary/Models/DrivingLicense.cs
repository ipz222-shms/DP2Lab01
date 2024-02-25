using System.Text;

namespace DocumentsLibrary.Models;

public class DrivingLicense : Passport
{
    public Dictionary<string, DateTime> CategoryIssuingDate { get; private set; }
    public string Category => string.Join(", ", CategoryIssuingDate.Keys);

    public DrivingLicense(string number, string firstname, string lastname, Sex sex, DateTime dateOfBirth, 
        string nationality, int authority, string record, string placeOfBirth, string placeOfResidence, 
        DateTime registeredOn, ulong taxId, DateTime? taxChecked, DateTime dateOfIssue, DateTime dateOfExpire, 
        Dictionary<string, DateTime>? categories = null, string? surname = null) : base(number, firstname, lastname, sex, 
        dateOfBirth, nationality, authority, record, placeOfBirth, placeOfResidence, registeredOn, taxId, taxChecked, 
        dateOfIssue, dateOfExpire, surname)
    {
        DocumentName = "Посвідчення водія";
        CategoryIssuingDate = categories ?? new Dictionary<string, DateTime>();
    }

    public override string GetRunningTex()
        => $"• Документ оновлено о {LoadedAt:t} | {LoadedAt:d} • Дійсне до {DateOfExpire:t} | {DateOfExpire:d}";
    
    public override Document GetRecordDocument()
    {
        // Retrieve passport from GOV db
        return base.GetRecordDocument();
    }

    public override string ToString()
    {
        var result = new StringBuilder($"{DocumentName}: {Number}\n\t1. Прізвище: {Lastname}");
        result.Append($"\n\t2. Ім'я та по батькові: {Firstname} {Surname ?? ""}");
        result.Append($"\n\t3. Дата і місце народження: {DateOfBirth:d} | {PlaceOfBirth}");
        result.Append($"\n\t4a. Дата видачі: {DateOfIssue:d}");
        result.Append($"\n\t4b. Дійсний до: {DateOfExpire:d}");
        result.Append($"\n\t4c. Орган, що видав: {Authority}");
        result.Append($"\n\t4d. Запис № (УЗНР): {RecordNumber}");
        result.Append($"\n\t5. Номер документа: {Number}");
        result.Append($"\n\t9. Категорія: {Category}");
        result.Append("\n\t10. Дата відкриття категорії:");
        foreach (var category in CategoryIssuingDate)
            result.Append($"\n\t\t{category.Key} / {category.Value:d};");
        return result.ToString();
    }
}
