Public Class FormDetailDiagnosis


    Public Sub tambahGejala(idgejala As String, namagejala As String)

        ListView1.Items.Add(New ListViewItem(New String() {idgejala, namagejala}))

    End Sub

    Public Sub tambahPresentase(namapenyakit As String, presentase As String)
        ListView2.Items.Add(New ListViewItem(New String() {namapenyakit, presentase}))
    End Sub


    Private Sub FormDetailDiagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details


        ListView1.Columns.Add("ID Gejala", 200, HorizontalAlignment.Left) 'Add column 2
        ListView1.Columns.Add("Gejala Penyakit", 170, HorizontalAlignment.Left) 'Add column 3

        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        ListView2.View = View.Details



        ListView2.Columns.Add("Nama Penyakit", 250) 'Add column 2
        ListView2.Columns.Add("Presentase Diagnosis", 150) 'Add column 3

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim namapenyakit As String = ListView2.Items(ListView2.FocusedItem.Index).SubItems(0).Text
            'MsgBox(mobil_)
            Dim formLembar As New FormLaporanDiagnosis(namapenyakit)

            formLembar.Show()

        Catch ex As Exception

        End Try

    End Sub
End Class