using DocumentsLibrary;
using DocumentsLibrary.Models;
using DocumentsLibrary.Interfaces;

#region Fill container with documents

DocumentsContainer container = new();
container.Add(
    new Passport("000000001", "Дія", "Надія", Sex.Female, 
        new DateTime(1991, 8, 24), "Українська", 1000, "19910824-00001",
        "м. Камʼянець-Подільський, Хмельницька область, Україна", 
        "м. Камʼянець-Подільський, пр-т Тараса Шевченка буд. 174/13, кв. 17", new DateTime(2000, 7, 25),
        3801800001, new DateTime(2020, 5, 10), new DateTime(2015, 12, 13), new DateTime(2023, 1, 12),
        surname: "Володимирівна")
);
container.Add(
    new InternationalPassport("GG000001", "Дія", "Надія", Sex.Female, 
        new DateTime(1991, 8, 24), "Українська", 1000, "19910824-00001", 
        "м. Камʼянець-Подільський, Хмельницька область, Україна", 
        "м. Камʼянець-Подільський, пр-т Тараса Шевченка буд. 174/13, кв. 17", new DateTime(2000, 7, 25),
        3801800001, new DateTime(2020, 5, 10), new DateTime(2015, 12, 13), new DateTime(2023, 1, 12),
        "P", "UKR", surname: "Володимирівна")
);
container.Add(
    new ITNDocument(3801800001, "Дія", "Надія", new DateTime(2020, 5, 10), 
        surname: "Володимирівна")
);
container.Add(
    new StudentPass("TM13920001", "Дія", "Надія", new DateTime(2022, 9, 26), 
        new DateTime(2026, 6, 30), "Денна", 
        "Державний університет \"Житомирська політехніка\" Факультет інформаційно-комп'ютерних технологій")
);
container.Add(
    new DiaDocument("-", "Дія", "Надія", Sex.Female, new DateTime(1991, 8, 24), 
        "Українська", 1000, "19910824-00001", "м. Камʼянець-Подільський, Хмельницька область, Україна", 
        "м. Камʼянець-Подільський, пр-т Тараса Шевченка буд. 174/13, кв. 17", new DateTime(2000, 7, 25),
        3801800001, new DateTime(2020, 5, 10), new DateTime(2015, 12, 13), new DateTime(2023, 1, 12),
        surname: "Володимирівна")
);
container.Add(
    new DrivingLicense("BXH300001", "Дія", "Надія", Sex.Female, new DateTime(1991, 8, 24),
        "Українська", 1000, "19910824-00001", "м. Камʼянець-Подільський, Хмельницька область, Україна",
        "м. Камʼянець-Подільський, пр-т Тараса Шевченка буд. 174/13, кв. 17", new DateTime(2000, 7, 25),
        3801800001, new DateTime(2020, 5, 10), new DateTime(2015, 12, 13), new DateTime(2023, 1, 12),
        new Dictionary<string, DateTime>
        {
            {"B", new DateTime(2016, 02, 25)},
            {"B1", new DateTime(2016, 02, 25)},
            {"C", new DateTime(2018, 07, 10)},
            {"C1", new DateTime(2018, 07, 10)},
        }, surname: "Володимирівна")
);

#endregion

#region Moving documents in container

Console.WriteLine(container);

foreach (var doc in container.Documents)
    if (doc is DiaDocument)
        container.Move(doc, 1);
        
Console.WriteLine(container);

#endregion

Console.WriteLine("\n\n");

#region Display translatable documents

foreach (var doc in container.Documents)
    if (doc is ITranslatable)
        Console.WriteLine($"{doc.DocumentName}: {doc.Number}");

#endregion

Console.WriteLine("\n\n");

#region Get running text for all documents

foreach (var doc in container.Documents)
    Console.WriteLine($"{doc.DocumentName}: {doc.GetRunningTex()}");

#endregion

#region Display driving license

foreach (var doc in container.Documents)
    if (doc is DrivingLicense)
        Console.WriteLine(doc);

#endregion
