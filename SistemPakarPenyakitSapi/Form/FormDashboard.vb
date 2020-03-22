Public Class FormDashboard
    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MulaiDiagnosisPenyakitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MulaiDiagnosisPenyakitToolStripMenuItem.Click
        FormDiagnosis.MdiParent = Me
        FormDiagnosis.Show()
    End Sub

    Private Sub DataGejalaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataGejalaToolStripMenuItem.Click
        FormGejala.MdiParent = Me
        FormGejala.Show()
    End Sub

    Private Sub DataPenyakitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPenyakitToolStripMenuItem.Click
        FormPenyakit.MdiParent = Me
        FormPenyakit.Show()
    End Sub

    Private Sub DataAturanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataAturanToolStripMenuItem.Click
        FormAturan.MdiParent = Me
        FormAturan.Show()
    End Sub
End Class
