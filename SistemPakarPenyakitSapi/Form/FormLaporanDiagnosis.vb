Public Class FormLaporanDiagnosis
    Public namapenyakit As String
    Public Sub New(penyakit As String)
        namapenyakit = penyakit
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FormLaporanDiagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New LaporanDiagnosis
        report.Refresh()
        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.SelectionFormula = "{Command.nama_penyakit}='" & namapenyakit & "'"
    End Sub
End Class