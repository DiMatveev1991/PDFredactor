using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace pdfslit
{
    public class slitpdf
    {
        public static void Merge(string file)
        {
            string OutFile = file + @"\TotalPdf.pdf";
            string [] files1 = Directory.GetFiles(file);
            List<string> dinosaurs = new List<string>(files1);
            using (FileStream stream = new FileStream(OutFile, FileMode.Create))
            using (Document doc = new Document())
            using (PdfCopy pdf = new PdfCopy(doc, stream))
            {
                doc.Open();

                PdfReader reader = null;
                PdfImportedPage page = null;

                //fixed typo
                dinosaurs.ForEach(file =>
                {
                    reader = new PdfReader(file);

                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);
                    }

                    pdf.FreeReader(reader);
                    reader.Close();
                });
            }
        }
    }
}
