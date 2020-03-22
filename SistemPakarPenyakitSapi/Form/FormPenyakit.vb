Public Class FormPenyakit
    Public Sub refreshGrid()
        Dim ds As DataSet = KontrolPenyakit.ReadData()
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tabelpenyakit"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns(0).ReadOnly = True
        TextBox2.Text = ""

    End Sub

    Public Function ambilID() As String
        Dim id As String = "err"
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand("SELECT TOP 1 * FROM penyakit ORDER BY id_penyakit DESC", Koneksi.bukaKoneksi())
        Dim reader As OleDb.OleDbDataReader = query.ExecuteReader()
        While reader.Read
            id = reader.Item(0)
        End While
        Dim digit As Integer
        id = id.Substring(1)
        Int32.TryParse(id, digit)
        digit = digit + 1
        Dim result = "P" + digit.ToString("D4")
        Return result
    End Function

    Private Sub FormPenyakit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        refreshGrid()
        TextBox1.Text = ambilID()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idpenyakit As String = TextBox1.Text
        Dim namapenyakit As String = TextBox2.Text
        Dim penangananpenyakit As String = RichTextBox1.Text

        If idpenyakit.Length > 0 And namapenyakit.Length > 0 And penangananpenyakit.Length > 0 Then
            Dim entitasPenyakit As New EntitasPenyakit
            With entitasPenyakit
                .idpenyakit_ = idpenyakit
                .namapenyakit_ = namapenyakit
                .penanganan_ = penangananpenyakit
            End With

            KontrolPenyakit.CreateData(entitasPenyakit)
            refreshGrid()
        Else
            MsgBox("Masukkan semua data!")
        End If



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = 46 Then
            Dim row As String = DataGridView1.CurrentCell.RowIndex
            Dim value As String = DataGridView1.Rows(row).Cells(0).Value.ToString()

            KontrolPenyakit.DeleteData(value)
            MsgBox("Data berhasil dihapus!")
            refreshGrid()
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim row As String = DataGridView1.CurrentCell.RowIndex
        Dim value As String = DataGridView1.Rows(row).Cells(0).Value.ToString()
        Dim v2 As String = DataGridView1.Rows(row).Cells(1).Value.ToString()
        Dim v3 As String = DataGridView1.Rows(row).Cells(2).Value.ToString()

        Dim entitasPenyakit As New EntitasPenyakit

        With entitasPenyakit
            .idpenyakit_ = value
            .namapenyakit_ = v2
            .penanganan_ = v3
        End With

        KontrolPenyakit.UpdateData(entitasPenyakit)
        MsgBox("Data berhasil diubah!")
        refreshGrid()
    End Sub
End Class