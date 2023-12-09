using SautinSoft;

// Read Example File
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "example.doc");
var reader = new StreamReader(filePath);
var content = await reader.ReadToEndAsync();

// Replace Content
content = content.Replace("{{NAME}}", "II.");
content = content.Replace("{{SURNAME}}", "Kleopat");

System.Console.WriteLine();
System.Console.WriteLine(content);
System.Console.WriteLine();

// New Example File
System.Console.WriteLine("Created new document");
var newFilePath = "new-example.doc";
var newFile = File.Create(newFilePath);
var streamWriter = new StreamWriter(newFile, System.Text.Encoding.UTF8);
await streamWriter.WriteAsync(content);
await streamWriter.FlushAsync();
streamWriter.Close();


// Convert to Html
string htmlFilePath = Path.GetFullPath("example.html");
System.Console.WriteLine("Convert word to html");
RtfToHtml rtf = new RtfToHtml();
rtf.Convert(newFilePath, htmlFilePath);


// Convert to Pdf
string pdfFile = @"example.pdf";
System.Console.WriteLine("Convert html to pdf");
SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
p.HtmlToPdfConvertFile(htmlFilePath, pdfFile);