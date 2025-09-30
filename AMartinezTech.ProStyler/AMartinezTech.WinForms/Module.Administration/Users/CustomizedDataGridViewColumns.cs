namespace AMartinezTech.WinForms.Module.Administration.Users;

public class CustomizedDataGridViewColumns
{
    public static void Apply(DataGridView dataGridView)
    {
        //Desable aut generate columns
        dataGridView.AutoGenerateColumns = false;

        // Add columns
        var colId = new DataGridViewTextBoxColumn
        {
            Name = "id",
            HeaderText = "ID",
            DataPropertyName = "id", // Vincula con la propiedad del resultado
            Width = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
            Visible = false

        };
        dataGridView.Columns.Add(colId);

        var colName = new DataGridViewTextBoxColumn
        {
            Name = "Name",
            HeaderText = "NOMBRE",
            DataPropertyName = "name", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        };
        dataGridView.Columns.Add(colName);


        var colIsActive = new DataGridViewTextBoxColumn
        {
            Name = "IsActiveName",
            HeaderText = "ESTADO",
            DataPropertyName = "IsActiveName", // Vincula con la propiedad del resultado
            Width = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },

        };
        colIsActive.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridView.Columns.Add(colIsActive);
    }
}
