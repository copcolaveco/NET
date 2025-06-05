
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class FormInformesPendientesUsuario

    Private _sesion As New dSesion
    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Property Sesion() As dSesion
        Get
            Return _sesion
        End Get
        Set(ByVal value As dSesion)
            _sesion = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

    End Sub
#End Region

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

    End Sub

End Class