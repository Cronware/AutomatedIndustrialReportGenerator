using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

namespace AutomatedIndustrialReportGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxSchedule.SelectedIndex = 0;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            dataGridViewMachineData.DataSource = dbHelper.GetMachineData();
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            if (dataGridViewMachineData.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Save PDF Report",
                    FileName = "Machine_Report.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Document document = new Document(PageSize.A4);
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                    document.Add(new Paragraph("Machine Data Report", titleFont));
                    document.Add(new Paragraph($"Generated on: {DateTime.Now}\n\n", cellFont));

                    PdfPTable table = new PdfPTable(dataGridViewMachineData.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataGridViewColumn column in dataGridViewMachineData.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                        cell.BackgroundColor = new BaseColor(220, 220, 220);
                        table.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dataGridViewMachineData.Rows)
                    {
                        if (row.IsNewRow) continue;

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(new Phrase(cell.Value?.ToString() ?? "", cellFont));
                        }
                    }

                    document.Add(table);
                    document.Close();

                    MessageBox.Show("PDF Report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewMachineData.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save Excel Report",
                    FileName = "Machine_Report.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Machine Data");

                        for (int col = 0; col < dataGridViewMachineData.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dataGridViewMachineData.Columns[col].HeaderText;
                        }

                        for (int row = 0; row < dataGridViewMachineData.Rows.Count; row++)
                        {
                            if (dataGridViewMachineData.Rows[row].IsNewRow) continue;

                            for (int col = 0; col < dataGridViewMachineData.Columns.Count; col++)
                            {
                                worksheet.Cell(row + 2, col + 1).Value = dataGridViewMachineData.Rows[row].Cells[col].Value?.ToString() ?? "";
                            }
                        }

                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Excel Report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter a recipient email.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), "Machine_Report.pdf");
                GeneratePDFReport(tempFilePath); 

                EmailHelper emailHelper = new EmailHelper();
                bool emailSent = emailHelper.SendEmail(
                    textBoxEmail.Text,
                    "Industrial Report",
                    "Please find the attached machine data report.",
                    tempFilePath
                );

                if (emailSent)
                {
                    MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to send email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GeneratePDFReport(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document document = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                    document.Add(new Paragraph("Machine Data Report", titleFont));
                    document.Add(new Paragraph($"Generated on: {DateTime.Now}\n\n", cellFont));

                    PdfPTable table = new PdfPTable(dataGridViewMachineData.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataGridViewColumn column in dataGridViewMachineData.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont))
                        {
                            BackgroundColor = new BaseColor(220, 220, 220)
                        };
                        table.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dataGridViewMachineData.Rows)
                    {
                        if (row.IsNewRow) continue;

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(new Phrase(cell.Value?.ToString() ?? "", cellFont));
                        }
                    }

                    document.Add(table);
                    document.Close();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxEnableAutomation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnableAutomation.Checked)
            {
                UpdateReportTimerInterval();
                timerReport.Start();
                MessageBox.Show("Automated reporting enabled!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                timerReport.Stop();
                MessageBox.Show("Automated reporting disabled!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void UpdateReportTimerInterval()
        {
            switch (comboBoxSchedule.SelectedItem.ToString())
            {
                case "Daily":
                    timerReport.Interval = (int)TimeSpan.FromDays(1).TotalMilliseconds; 
                    break;
                case "Weekly":
                    timerReport.Interval = (int)TimeSpan.FromDays(7).TotalMilliseconds; 
                    break;
                case "Monthly":
                    timerReport.Interval = (int)TimeSpan.FromDays(30).TotalMilliseconds; 
                    break;
                case "Minute":
                    timerReport.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds; 
                    break;
            }
        }


        private void timerReport_Tick(object sender, EventArgs e)
        {
            string recipientEmail = textBoxEmail.Text;

            if (string.IsNullOrWhiteSpace(recipientEmail))
            {
                MessageBox.Show("No recipient email provided for automated reports.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), "Machine_Report.pdf");
                GeneratePDFReport(tempFilePath);

                EmailHelper emailHelper = new EmailHelper();
                bool emailSent = emailHelper.SendEmail(
                    recipientEmail,
                    "Automated Industrial Report",
                    "This is an automatically generated report.",
                    tempFilePath
                );

                if (emailSent)
                {
                    MessageBox.Show($"Automated report sent successfully to {recipientEmail}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to send automated report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
