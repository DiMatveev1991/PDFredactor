using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Text;
using MasterPoveritel2;
using ConsoleApp20;
using System.IO;

namespace F_res
{
    public class Parsimfile
    {
        public void df(string file, string outfile)
        {
            DirectoryInfo di = new DirectoryInfo(file);
            string[] files1 = Directory.GetFiles(file);
            FileInfo[] files = di.GetFiles();
            for (int i=0; i<files.Length; i++)
            {
            var t = new MyLocationTextExtractionStrategy("руководителя");

            //Parse page 1 of the document above
            using (var r = new PdfReader(files1[i]))
            {
                var ex = PdfTextExtractor.GetTextFromPage(r, 1, t);
            }

            //Loop through each chunk found
            foreach (var p in t.myPoints)
            {
                WriterPDF sd = new WriterPDF (outfile);
                sd.WritePDF(files[i], p.Rect.Bottom);

            }
            }
        }
    }
}

