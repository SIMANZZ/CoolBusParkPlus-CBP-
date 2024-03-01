using System;
using System.IO;
using System.Windows.Forms;

public class Logger
{
    private string logFilePath;

    public Logger(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }

    public void LogGridContents(DataGridView dataGridView)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Grid contents at {DateTime.Now}:");
                writer.WriteLine(dataGridView.Name);
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        writer.Write(cell.Value.ToString() + "\t");
                    }
                    writer.WriteLine();
                }
                writer.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error logging grid contents: {ex.Message}");
        }
    }
}
