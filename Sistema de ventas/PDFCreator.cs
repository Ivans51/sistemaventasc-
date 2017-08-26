using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Sistema_de_ventas
{
    class PDFCreator
    {
        public static string DEST = "results/tables/simple_table.pdf";
        private PdfPTable tabla;
        private string segundoParrafo = "Este es el segundo y tiene una fuente rara";
        private string arial = "arial";
        private int tamaño = 22;
        private int estilo = Font.ITALIC;
        private BaseColor color = BaseColor.DARK_GRAY;
        
        public PDFCreator() {
        }

        public void crearPDF(string name, string parrafo, int numColumns, PDFTabla pdfTabla) {

            // Se crea el documento
            Document doc = new Document();
            // Se crea el OutputStream para el fichero donde queremos dejar el pdf.
            FileStream fs = new FileStream("Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            /*Se asocia el documento al OutputStream y se indica que el espaciado entre
            lineas sera de 20. Esta llamada debe hacerse antes de abrir el documento*/
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            // Se abre el documento.
            doc.Open();
            doc.Add(new Paragraph(parrafo));
            get(doc, segundoParrafo, arial, tamaño, estilo, color);
            tabla = new PdfPTable(numColumns);
            pdfTabla.addCellTable();
            /*for (int i = 0; i < size; i++) {
                tabla.addCell("celda " + i);
            }*/
            doc.Add(tabla);
            doc.Close();
        }
        
        public void get(Document documento, string segundoParrafo, string fuente, int tamaño, int estilo, BaseColor color) {
            documento.Add(new Paragraph(segundoParrafo, FontFactory.GetFont(fuente, tamaño, estilo, color)));
        }
        
        public PdfPTable getTabla() {
            return tabla;
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