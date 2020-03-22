Public Class FormPilihGejala
    Private Sub FormPilihGejala_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As DataSet = KontrolGejala.ReadData()
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tabelgejala"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As String = DataGridView1.CurrentCell.RowIndex

        Dim id As String = DataGridView1.Rows(row).Cells(0).Value.ToString()
        Dim value As String = DataGridView1.Rows(row).Cells(1).Value.ToString()


        Dim sudahada As Boolean = False
        For i = 0 To FormAturan.ListView1.Items.Count - 1
            If FormAturan.ListView1.Items(i).SubItems(0).Text = id Then
                sudahada = True
            End If
        Next

        If sudahada Then
            MsgBox("Duplikat data!")
        Else
            Dim cfrule As String

            Try

                cfrule = InputBox("Isi nilai CF Rule")
                If IsNumeric(cfrule) Then
                    FormAturan.ListView1.Items.Add(New ListViewItem(New String() {id, value, cfrule}))
                Else
                    MsgBox("Isikan data angka!")

                End If


            Catch

                MsgBox("Tolong isikan nilai CF Rule")

            End Try

        End If


        Me.Close()
    End Sub
End Class