Public Class EntitasAturan
    Private idaturan, idpenyakit As String

    Public Property idaturan_ As String
        Get
            Return idaturan
        End Get
        Set(value As String)
            idaturan = value
        End Set
    End Property

    Public Property idpenyakit_ As String
        Get
            Return idpenyakit
        End Get
        Set(value As String)
            idpenyakit = value
        End Set
    End Property
End Class
