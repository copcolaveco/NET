Public Class dSesion

#Region "Atributos"
    Private _id As Integer
    Private _usuario As dUsuario
    Private _inicio As Date
    Private _fin As Date
#End Region

#Region "Properties"
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Property Inicio() As Date
        Get
            Return _inicio
        End Get
        Set(ByVal value As Date)
            _inicio = value
        End Set
    End Property
    Public Property Fin() As Date
        Get
            Return _fin
        End Get
        Set(ByVal value As Date)
            _fin = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        ID = 0
    End Sub
#End Region

#Region "Métodos"
    Public Function buscarUltimaSesion() As dSesion
        Dim p As New pSesion
        Return p.buscarUltimaSesion(Me)
    End Function
    Public Function abrirSesion()
        Dim p As New pSesion
        Return p.abrirSesion(Me)
    End Function
    Public Function cerrarSesion()
        Dim p As New pSesion
        Return p.cerrarSesion(Me)
    End Function
#End Region

End Class
