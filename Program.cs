using System.Text;
using SautinSoft;

// Read Example File
System.Console.WriteLine("Read to Document");
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "example.doc");
var reader = new StreamReader(filePath);
var content = await reader.ReadToEndAsync();

System.Console.WriteLine("Replace to content");
// Replace Content
content = content.Replace("{{NAME}}", "II.");
content = content.Replace("{{SURNAME}}", "Kleopat");

// System.Console.WriteLine();
// System.Console.WriteLine(content);
// System.Console.WriteLine();


// // New Example File
// System.Console.WriteLine("Created new document");
// var newFilePath = "new-example.doc";
// var newFile = File.Create(newFilePath);
// var streamWriter = new StreamWriter(newFile, System.Text.Encoding.UTF8);
// await streamWriter.WriteAsync(content);
// await streamWriter.FlushAsync();
// streamWriter.Close();


// // Convert to Html
string htmlFilePath = Path.GetFullPath("example.html");
System.Console.WriteLine("Convert string to html");

RtfToHtml r = new RtfToHtml();
MemoryStream inpMS = new MemoryStream(Encoding.UTF8.GetBytes(content));
MemoryStream outMS = new MemoryStream();

r.Convert(inpMS, outMS, new RtfToHtml.HtmlFixedSaveOptions());
var htmlString = Encoding.UTF8.GetString(outMS.ToArray());


// // This file is necessary only to show the result.
File.WriteAllText(htmlFilePath, htmlString);

// Open the result for demonstration purposes.
// System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFilePath) { UseShellExecute = true });

// Convert to Pdf
string pdfFile = @"example.pdf";
System.Console.WriteLine("Convert html to pdf");
SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
p.HtmlToPdfConvertFile(htmlFilePath, pdfFile);