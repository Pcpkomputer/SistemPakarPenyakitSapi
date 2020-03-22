Public Class FormGejala
    Public Sub refreshGrid()
        Dim ds As DataSet = KontrolGejala.ReadData()
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tabelgejala"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns(0).ReadOnly = True
        TextBox1.Text = ambilID()
        TextBox2.Text = ""
    End Sub

    Public Function ambilID() As String
        Dim id As String = "err"
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand("SELECT TOP 1 * FROM gejala ORDER BY id_gejala DESC", Koneksi.bukaKoneksi())
        Dim reader As OleDb.OleDbDataReader = query.ExecuteReader()
        While reader.Read
            id = reader.Item(0)
        End While
        Dim digit As Integer
        id = id.Substring(1)
        Int32.TryParse(id, digit)
        digit = digit + 1
        Dim result = "G" + digit.ToString("D4")
        Return result
    End Function

    Private Sub FormGejala_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshGrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idgejala As String = TextBox1.Text
        Dim namagejala As String = TextBox2.Text

        If idgejala.Length > 0 And namagejala.Length > 0 Then

            Dim entitasGejala As New EntitasGejala
            With entitasGejala
                .idgejala_ = idgejala
                .namagejala_ = namagejala
            End With

            KontrolGejala.CreateData(entitasGejala)
            refreshGrid()
        Else
            MsgBox("Masukkan semua data!")
        End If


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyCode = 46 Then
            Dim row As String = DataGridView1.CurrentCell.RowIndex
            Dim value As String = DataGridView1.Rows(row).Cells(0).Value.ToString()

            KontrolGejala.DeleteData(value)
            MsgBox("Data berhasil dihapus!")
            refreshGrid()
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim row As String = DataGridView1.CurrentCell.RowIndex
        Dim value As String = DataGridView1.Rows(row).Cells(0).Value.ToString()
        Dim v2 As String = DataGridView1.Rows(row).Cells(1).Value.ToString()

        Dim entitasGejala As New EntitasGejala

        With entitasGejala
            .idgejala_ = value
            .namagejala_ = v2
        End With

        KontrolGejala.UpdateData(entitasGejala)
        MsgBox("Data berhasil diubah!")
        refreshGrid()
    End Sub
End Class