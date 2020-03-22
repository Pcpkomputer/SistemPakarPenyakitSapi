Imports SistemPakarPenyakitSapi

Public Class ControllerAturan : Implements InterfaceAturan

    Public Sub CreateData(objek As Object) Implements InterfaceAturan.CreateData
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand(String.Format("INSERT INTO aturan VALUES ('{0}','{1}')", objek.idaturan_, objek.idpenyakit_), Koneksi.bukaKoneksi)
        query.ExecuteNonQuery()
    End Sub

    Public Sub UpdateData(objek As Object) Implements InterfaceAturan.UpdateData
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand(String.Format("UPDATE aturan SET id_penyakit='{0}' WHERE id_aturan='{1}'", objek.idpenyakit_, objek.idgaturan_), Koneksi.bukaKoneksi())
        query.ExecuteNonQuery()
    End Sub

    Public Sub DeleteData(id As String) Implements InterfaceAturan.DeleteData
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand(String.Format("DELETE FROM aturan WHERE id_aturan='{0}'", id), Koneksi.bukaKoneksi())
        query.ExecuteNonQuery()
    End Sub

    Public Function ReadData() As DataSet Implements InterfaceAturan.ReadData
        Koneksi.tutupKoneksi()
        Dim adapter As New OleDb.OleDbDataAdapter(String.Format("SELECT aturan.*, penyakit.nama_penyakit FROM aturan INNER JOIN penyakit ON penyakit.id_penyakit=aturan.id_penyakit"), Koneksi.bukaKoneksi())
        Dim ds As New DataSet
        adapter.Fill(ds, "tabelaturan")
        Return ds
    End Function
End Class
