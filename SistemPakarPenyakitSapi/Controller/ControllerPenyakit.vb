Imports SistemPakarPenyakitSapi

Public Class ControllerPenyakit : Implements InterfacePenyakit

    Public Sub CreateData(objek As Object) Implements InterfacePenyakit.CreateData
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand(String.Format("INSERT INTO penyakit VALUES ('{0}','{1}','{2}')", objek.idpenyakit_, objek.namapenyakit_, objek.penanganan_), Koneksi.bukaKoneksi)
        query.ExecuteNonQuery()
    End Sub

    Public Sub UpdateData(objek As Object) Implements InterfacePenyakit.UpdateData
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand(String.Format("UPDATE penyakit SET nama_penyakit='{0}',penanganan='{1}' WHERE id_penyakit='{2}'", objek.namapenyakit_, objek.penanganan_, objek.idpenyakit_), Koneksi.bukaKoneksi())
        query.ExecuteNonQuery()
    End Sub

    Public Sub DeleteData(id As String) Implements InterfacePenyakit.DeleteData
        Koneksi.tutupKoneksi()
        Dim query As New OleDb.OleDbCommand(String.Format("DELETE FROM penyakit WHERE id_penyakit='{0}'", id), Koneksi.bukaKoneksi())
        query.ExecuteNonQuery()
    End Sub

    Public Function ReadData() As DataSet Implements InterfacePenyakit.ReadData
        Koneksi.tutupKoneksi()
        Dim adapter As New OleDb.OleDbDataAdapter(String.Format("SELECT * FROM penyakit"), Koneksi.bukaKoneksi())
        Dim ds As New DataSet
        adapter.Fill(ds, "tabelpenyakit")
        Return ds
    End Function
End Class
