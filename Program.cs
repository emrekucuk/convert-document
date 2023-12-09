using SautinSoft;

// Read Example File
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "example.doc");
var reader = new StreamReader(filePath);
var content = await reader.ReadToEndAsync();

// Replace Content
content = content.Replace("{{NAME}}", "II.");
content = content.Replace("{{SURNAME}}", "Kleopat");

System.Console.WriteLine(content);

// New Example File
var newFilePath = "new-example.doc";
var newFile = File.Create(newFilePath);
var streamWriter = new StreamWriter(newFile, System.Text.Encoding.UTF8);
await streamWriter.WriteAsync(content);
await streamWriter.FlushAsync();
streamWriter.Close();


// Convert to Html
string htmlFilePath = Path.GetFullPath("example.html");

RtfToHtml rtf = new RtfToHtml();
rtf.Convert(newFilePath, htmlFilePath);


// Convert to Pdf

string pdfFile = @"example.pdf";

SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

p.HtmlToPdfConvertFile(htmlFilePath, pdfFile);