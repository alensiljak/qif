# qif
A utility project for creating and consuming *.qif files. This project complies with documented Quicken Interchange Format (QIF) files specification. It is a completely managed, open source QIF API.

This API enables you to import or export {"*.qif files. It also allows you to create or modify transactions and represent them easily in code as entities. This is written exclusively in C#, using VS 2008. Basically, this API can enable your application to completely handle any aspect of a QIF file. You can create transactions in an easy to understand model and export it to the versatile Quicken export file format, or you can easily import your QIF file, and have immediate access to all transactions in the file.

This project only produces a class library (*"}.dll). Just drop this library in place and reference it in your .NET application, and you're ready to go.

Here's a sample usage (If you need a live example, you can download ApiTest source code included in this project):

**C# / .NET Example**
```chsarp
// This returns a QifDom object (defined in the QifImport namespace). The QifDom represents all transactions found in the QIF file.
QifDom qifDom = QifDom.Import.ImportFile(@"c:\quicken.qif");
// --or--
QifDom qd = new QifDom();
qd.Import(@"c:\quicken.qif"); // NOTE: This will replace existing transactions in the QifDom instance.

... /* create or modify transactions */ ...

// This writes the QifDom to a file (overwrites if file is already present).
QifDom.ExportFile(qifDom, @"c:\quicken.qif");
// --or--
qd.Export(@"c:\quicken.qif");
```

**Automation Example in VB**
```
Sub Sample()
    Dim a As New QifDomComWrapper
    
    ' Import sample QIF file
    a.Import "c:\sample_import.qif"
    
    ' Prepare a new transaction
    Dim c As New BasicTransaction
    
    ' Set the payee property
    With c
        .Payee = "Test Payee"
    End With
    
    ' Add the transaction
    a.BankTransactions.Add c
    
    ' Export the current QIF DOM
    a.Export "c:\sample_export.qif"
End Sub
```
All transactions present in the DOM are written according to the QIF file format specification. Dates and numbers should be written according to globalization standards.