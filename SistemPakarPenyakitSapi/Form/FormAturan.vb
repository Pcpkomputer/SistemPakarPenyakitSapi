Public Class FormAturan

    Public Sub refreshGrid()

        ListView1.Clear()

        ListView1.View = View.Details
        ListView1.FullRowSelect = True

        ListView1.Columns.Add("ID Gejala", 100)
        ListView1.Columns.Add("Nama Gejala", 100)
        ListView1.Columns.Add("CF Rule", 50)

        Dim ds As DataSet = KontrolAturan.ReadData()
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tabelaturan"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns(0).ReadOnly = True
        TextBox1.Text = ambilID()
        TextBox2.Text = ""

        'Dim t = "1".Length
        'MsgBox(t)
    End Sub

    Public Function ambilID() As String
        Dim id As String = "err"
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand("SELECT TOP 1 * FROM aturan ORDER BY id_aturan DESC", Koneksi.bukaKoneksi())
        Dim reader As OleDb.OleDbDataReader = query.ExecuteReader()
        While reader.Read
            id = reader.Item(0)
        End While
        Dim digit As Integer
        id = id.Substring(1)
        Int32.TryParse(id, digit)
        digit = digit + 1
        Dim result = "A" + digit.ToString("D4")
        Return result
    End Function

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub FormAturan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshGrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormPilihPenyakit.MdiParent = FormDashboard
        FormPilihPenyakit.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormPilihGejala.MdiParent = FormDashboard
        FormPilihGejala.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If DataGridView1.CurrentCell.RowIndex > -1 Then
            Dim row As String = DataGridView1.CurrentCell.RowIndex
            Dim value As String = DataGridView1.Rows(row).Cells(0).Value.ToString()

            FormDetailAturan.isiDG(value)
            FormDetailAturan.MdiParent = FormDashboard
            FormDetailAturan.Show()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim idaturan, idpenyakit As String
        idaturan = TextBox1.Text
        idpenyakit = TextBox2.Text

        If idaturan.Length > 0 And idpenyakit.Length > 0 And ListView1.Items.Count > 0 Then



            Dim check = ""
            Koneksi.tutupKoneksi()
            Dim l As New OleDb.OleDbCommand(String.Format("SELECT * FROM aturan WHERE id_penyakit='{0}'", idpenyakit), Koneksi.bukaKoneksi())
            Dim reader As OleDb.OleDbDataReader
            reader = l.ExecuteReader()

            If reader.HasRows Then
                MsgBox("Data aturan berserta penyakitnya sudah terdapat dalam database!")
            Else
                Koneksi.tutupKoneksi()
                Dim query As New OleDb.OleDbCommand(String.Format("INSERT INTO aturan VALUES ('{0}','{1}')", idaturan, idpenyakit), Koneksi.bukaKoneksi())
                query.ExecuteNonQuery()

                For i = 0 To ListView1.Items.Count - 1
                    Koneksi.tutupKoneksi()
                    Dim q As New OleDb.OleDbCommand(String.Format("INSERT INTO data_aturan VALUES ('{0}','{1}',{2})", idaturan, ListView1.Items(i).SubItems(0).Text, ListView1.Items(i).SubItems(2).Text), Koneksi.bukaKoneksi())
                    q.ExecuteNonQuery()

                Next

                MsgBox("Data berhasil ditambahkan!")
                refreshGrid()
            End If




        Else
            MsgBox("Isikan semua data!")
        End If
    End Sub
End Class