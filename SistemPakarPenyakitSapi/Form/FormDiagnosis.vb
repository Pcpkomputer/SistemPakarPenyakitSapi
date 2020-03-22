Public Class FormDiagnosis


    Private Sub FormDiagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListView1.View = View.Details
        ListView1.CheckBoxes = True

        ListView1.Columns.Add("", 30, HorizontalAlignment.Left)          'Add column 1
        ListView1.Columns.Add("ID Gejala", 200, HorizontalAlignment.Left) 'Add column 2
        ListView1.Columns.Add("Gejala Penyakit", 170, HorizontalAlignment.Left) 'Add column 3

        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        Koneksi.tutupKoneksi()
        Dim adapter As New OleDb.OleDbCommand(String.Format("SELECT * FROM gejala"), Koneksi.bukaKoneksi())
        Dim reader As OleDb.OleDbDataReader = adapter.ExecuteReader

        While reader.Read
            ListView1.Items.Add(New ListViewItem({"", reader.Item(0).ToString, reader.Item(1).ToString}))

        End While


        'Use this to set the first column to be displayed as the last column
        ListView1.Columns(0).DisplayIndex = ListView1.Columns.Count - 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim idgejala As New List(Of String)()
        Dim namagejala As New List(Of String)()
        Dim cfpengguna As New List(Of String)()


        Dim listq As New List(Of String)()

        For i = 0 To ListView1.Items.Count - 1

            If ListView1.Items(i).Checked = True Then
                Dim newitem As String = ListView1.Items(i).SubItems(1).Text
                Dim newitem1 As String = ListView1.Items(i).SubItems(2).Text

                FormDetailDiagnosis.tambahGejala(newitem, newitem1)

                idgejala.Add(newitem)
                namagejala.Add(newitem1)

                listq.Add("'" + newitem + "'")

            End If

        Next

        Dim stringJoin As String = String.Join(",", listq)

        '1 Tidak 0
        '  2 Tidak tahu 0,2
        '  3 Sedikit yakin 0,4
        '  4 Cukup yakin 0,6
        '  5 Yakin 0,8
        '  6 Sangat yakin 1


        For i = 0 To namagejala.Count - 1
            Dim s As String
            s = InputBox("Berapa tingkat keyakinan sapi Anda mengalami " + namagejala.Item(i) &
         vbCrLf & vbTab & "1 - Tidak" &
         vbCrLf & vbTab & "2 - Tidak Tahu" &
         vbCrLf & vbTab & "3 - Sedikit Yakin" &
         vbCrLf & vbTab & "4 - Cukup Yakin" &
         vbCrLf & vbTab & "5 - Yakin" &
           vbCrLf & vbTab & "6 - Sangat Yakin" &
         vbCrLf & vbTab & "", "Tingkat Keyakinan")
            Select Case s
                Case "1"
                    cfpengguna.Add("0")
                Case "2"
                    cfpengguna.Add("0.2")
                Case "3"
                    cfpengguna.Add("0.4")
                Case "4"
                    cfpengguna.Add("0.6")
                Case "5"
                    cfpengguna.Add("0.8")
                Case "6"
                    cfpengguna.Add("1")
                Case Else
                    Me.Close()
            End Select
        Next


        Dim penyakitditemukan As New List(Of String)()
        Dim namapenyakitditemukan As New List(Of String)()
        Koneksi.tutupKoneksi()
        Dim q As New OleDb.OleDbCommand(String.Format("SELECT data_aturan.id_aturan, aturan.id_penyakit, penyakit.nama_penyakit FROM data_aturan INNER JOIN aturan ON aturan.id_aturan=data_aturan.id_aturan 
INNER JOIN penyakit ON penyakit.id_penyakit=aturan.id_penyakit WHERE id_gejala IN ({0}) GROUP BY data_aturan.id_aturan,aturan.id_penyakit, penyakit.nama_penyakit", stringJoin), Koneksi.bukaKoneksi())
        Dim reader As OleDb.OleDbDataReader
        reader = q.ExecuteReader()

        If reader.HasRows Then
            While reader.Read
                penyakitditemukan.Add(reader.Item(1))
                namapenyakitditemukan.Add(reader.Item(2))
            End While

        Else
            MsgBox("Tidak ada penyakit yang terdeteksi!")
            Me.Close()
        End If



        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim presentasepenyakit As New List(Of String)()

        For i = 0 To penyakitditemukan.Count - 1
            Koneksi.tutupKoneksi()
            Dim q1 As New OleDb.OleDbCommand(String.Format("SELECT data_aturan.*, aturan.id_penyakit FROM data_aturan INNER JOIN aturan ON aturan.id_aturan=data_aturan.id_aturan 
WHERE id_gejala IN ({0}) AND id_penyakit='{1}'", stringJoin, penyakitditemukan.Item(i)), Koneksi.bukaKoneksi())
            Dim reader1 As OleDb.OleDbDataReader
            reader1 = q1.ExecuteReader()

            Dim counter1 As Integer = -1
            Dim cfsudahdikali As New List(Of String)()


            While reader1.Read
                counter1 = counter1 + 1
                Dim parsed As Double

                ''''''''mencari cfpengguna'''''
                Dim indexcfpengguna As String
                For i_cf = 0 To namagejala.Count - 1
                    If idgejala.Item(i_cf) = reader1.Item(1) Then
                        indexcfpengguna = i_cf
                    End If
                Next

                Double.TryParse(reader1.Item(2), parsed)
                '''
                Dim t = parsed * cfpengguna.Item(indexcfpengguna)
                cfsudahdikali.Add(t.ToString())

            End While

            'CFCOMBINE(CF1, CF2) = CF1 + CF2 * (1 - CF1)
            Dim payload As String = cfsudahdikali.Item(0)
            For i2 = 0 To cfsudahdikali.Count - 1
                Try
                    Dim cf1, cf2 As Double
                    Double.TryParse(payload, cf1)
                    Double.TryParse(cfsudahdikali.Item(i2 + 1), cf2)

                    Dim hasil As Double = cf1 + cf2 * (1 - cf1)
                    payload = hasil.ToString()
                Catch ex As Exception

                End Try

            Next

            presentasepenyakit.Add(payload * 100)

        Next

        For x = 0 To namapenyakitditemukan.Count - 1
            FormDetailDiagnosis.tambahPresentase(namapenyakitditemukan.Item(x), presentasepenyakit.Item(x))
        Next

        FormDetailDiagnosis.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_DoubleClick(sender As Object, e As EventArgs) Handles Button1.DoubleClick

    End Sub
End Class