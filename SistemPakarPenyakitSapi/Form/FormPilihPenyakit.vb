Public Class FormPilihPenyakit
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub FormPilihPenyakit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As DataSet = KontrolPenyakit.ReadData()
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tabelpenyakit"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As String = DataGridView1.CurrentCell.RowIndex

        Dim id As String = DataGridView1.Rows(row).Cells(0).Value.ToString()

        FormAturan.TextBox2.Text = id
        Me.Close()
    End Sub
End Class