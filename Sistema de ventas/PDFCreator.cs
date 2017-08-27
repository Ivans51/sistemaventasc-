using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace Sistema_de_ventas
{
    class PDFCreator
    {
        public static string DEST = "results/tables/simple_table.pdf";
        private PdfPTable table;
        private string segundoParrafo = "";
        private string arial = "arial";
        private int tamaño = 22;
        private int estilo = Font.ITALIC;
        private BaseColor color = BaseColor.DARK_GRAY;
        private string rutaAbrir;

        public string RutaAbrir { get => rutaAbrir; set => rutaAbrir = value; }

        public PDFCreator() {
        }

        public void crearPDF(string name, string parrafo, int numColumns, PDFTabla pdfTabla) {

            // Se crea el documento
            Document doc = new Document();
            // Se crea el OutputStream para el fichero donde queremos dejar el pdf.
            FileStream fs = new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None);
            /*Se asocia el documento al OutputStream y se indica que el espaciado entre
            lineas sera de 20. Esta llamada debe hacerse antes de abrir el documento*/
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            // Se abre el documento.
            doc.Open();
            doc.Add(new Paragraph(parrafo));
            table = new PdfPTable(numColumns);
            table.HorizontalAlignment = 0;
            //leave a gap before and after the table
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            PdfPCell cell = new PdfPCell(new Phrase("Products"));
            cell.Colspan = 2;
            cell.Border = 0;
            cell.HorizontalAlignment = 1;
            get(doc, segundoParrafo, arial, tamaño, estilo, color);
            pdfTabla.addCellTable();
            /*for (int i = 0; i < size; i++) {
                tabla.addCell("celda " + i);
            }*/
            doc.Add(table);
            doc.Close();
            Process.Start(rutaAbrir);
        }
        
        public void get(Document documento, string segundoParrafo, string fuente, int tamaño, int estilo, BaseColor color) {
            documento.Add(new Paragraph(segundoParrafo, FontFactory.GetFont(fuente, tamaño, estilo, color)));
        }
        
        public PdfPTable getTabla() {
            return table;
        }

        public void setSegundoParrafo(string segundoParrafo) {
            this.segundoParrafo = segundoParrafo;
        }

        public void setArial(string arial) {
            this.arial = arial;
        }

        public void setTamaño(int tamaño) {
            this.tamaño = tamaño;
        }

        public void setEstilo(int estilo) {
            this.estilo = estilo;
        }

        public void setColor(BaseColor color) {
            this.color = color;
        }
    }
}