using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    public class WriterPDF
    {
       public string Path { get; set; }
       public WriterPDF(string path)
        {

            Path = path;
          }
        public void WritePDF(FileInfo file, float X)
        {
            string file1 = file.FullName;
            string FilePath = Path + @"\" + file.Name; ;
                PdfReader reader = new PdfReader(file1);
                Rectangle size = reader.GetPageSizeWithRotation(1);
                Document document = new Document(size);

                // open the writer
                FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                // the pdf content
                PdfContentByte cb = writer.DirectContent;


                // select the font properties "windows-1251"
              FileInfo FONT = new FileInfo ("Arial Cyr.ttf");
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                 BaseFont bf = BaseFont.CreateFont(FONT.FullName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf, 8);

                // write the text in the pdf content

                string text;
                float X1 = X + 10;
                cb.BeginText();
                text = "Начальник лаб. 204/3";
                // put the alignment and coordinates here
                cb.ShowTextAligned(2, text, 135, X1, 0);
                text = "Волченко  А. Г.";
                cb.ShowTextAligned(2, text, 490, X1, 0);
                text = "RA.RU.311493";
                // put the alignment and coordinates here
                cb.ShowTextAligned(2, text, 500, 695, 0);
                cb.EndText();
                // create the new page and add it to the pdf
                PdfImportedPage page = writer.GetImportedPage(reader, 1);
                cb.AddTemplate(page, 0, 0);

                // close the streams and voilá the file should be changed :)
                document.Close();
                fs.Close();
                writer.Close();
                Console.Read();
            
        }
    }
}
