Public Class EntitasPenyakit
    Private idpenyakit, namapenyakit, penanganan As String

    Public Property idpenyakit_ As String
        Get
            Return idpenyakit
        End Get
        Set(value As String)
            idpenyakit = value
        End Set
    End Property

    Public Property namapenyakit_ As String
        Get
            Return namapenyakit
        End Get
        Set(value As String)
            namapenyakit = value
        End Set
    End Property

    Public Property penanganan_ As String
        Get
            Return penanganan
        End Get
        Set(value As String)
            penanganan = value
        End Set
    End Property
End Class
