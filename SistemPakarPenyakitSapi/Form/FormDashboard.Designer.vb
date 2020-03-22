<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MulaiDiagnosisPenyakitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGejalaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPenyakitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataAturanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.SlateGray
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MulaiDiagnosisPenyakitToolStripMenuItem, Me.DataToolStripMenuItem, Me.LaporanToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1095, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MulaiDiagnosisPenyakitToolStripMenuItem
        '
        Me.MulaiDiagnosisPenyakitToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MulaiDiagnosisPenyakitToolStripMenuItem.Name = "MulaiDiagnosisPenyakitToolStripMenuItem"
        Me.MulaiDiagnosisPenyakitToolStripMenuItem.Size = New System.Drawing.Size(151, 20)
        Me.MulaiDiagnosisPenyakitToolStripMenuItem.Text = "Mulai Diagnosis Penyakit"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataGejalaToolStripMenuItem, Me.DataPenyakitToolStripMenuItem, Me.DataAturanToolStripMenuItem})
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.DataToolStripMenuItem.Text = "Data"
        '
        'DataGejalaToolStripMenuItem
        '
        Me.DataGejalaToolStripMenuItem.Name = "DataGejalaToolStripMenuItem"
        Me.DataGejalaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DataGejalaToolStripMenuItem.Text = "Data Gejala"
        '
        'DataPenyakitToolStripMenuItem
        '
        Me.DataPenyakitToolStripMenuItem.Name = "DataPenyakitToolStripMenuItem"
        Me.DataPenyakitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DataPenyakitToolStripMenuItem.Text = "Data Penyakit"
        '
        'DataAturanToolStripMenuItem
        '
        Me.DataAturanToolStripMenuItem.Name = "DataAturanToolStripMenuItem"
        Me.DataAturanToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DataAturanToolStripMenuItem.Text = "Data Aturan"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'FormDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SistemPakarPenyakitSapi.My.Resources.Resources.bg1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1095, 644)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormDashboard"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MulaiDiagnosisPenyakitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGejalaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPenyakitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataAturanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As ToolStripMenuItem
End Class
