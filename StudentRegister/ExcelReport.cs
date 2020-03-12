using Spire.Xls;

namespace Student_Register
{
    class FilesReport
    {
        private static Workbook GenerateExcel(SubjectRegister subjectRegister)
        {

            Workbook workbook = new Workbook();
            workbook.LoadFromFile("Files/Template.xlsx", ExcelVersion.Version2010);
            Worksheet worksheet = workbook.Worksheets[0];

            var students = subjectRegister.GetStudentList();
 
            worksheet.SetCellValue(4, 3, subjectRegister.Code + " " + subjectRegister.Id + " " + subjectRegister.Subject);
            worksheet.SetCellValue(5, 3, subjectRegister.Professor);
            worksheet.SetCellValue(6, 3, subjectRegister.StartDateString());
            worksheet.SetCellValue(7, 3, subjectRegister.EndDateString());

            int count = 9;
            bool first = false;
            foreach (var student in students)
            {
                if (first)
                {
                    worksheet.InsertRow(count);
                    worksheet.Copy(worksheet.Range["A" + (count - 1).ToString() + ":J" + (count - 1).ToString()], worksheet.Range["A" + count.ToString() + ":J" + count.ToString()], true);
                }

                worksheet.SetCellValue(count, 1, student.Id.ToString());
                worksheet.SetCellValue(count, 3, student.Career);
                worksheet.SetCellValue(count, 4, student.FullName);
                first = true;
                count++;
            }
            worksheet.SetCellValue(count, 3, students.Count.ToString());
            return workbook;  
        }
        public static void ExportExcel(SubjectRegister subjectRegister)
        {
            var workbook = GenerateExcel(subjectRegister);
            workbook.SaveToFile("Files/Registro.xlsx", ExcelVersion.Version2010);
        }
        public static void ExportPdf(SubjectRegister subjectRegister)
        {
            var workbook = GenerateExcel(subjectRegister);
            workbook.SaveToFile("Files/Registro.pdf", Spire.Xls.FileFormat.PDF);
        }  
    }
}
