Public Class ControlInformes
    Private _solicitudanalisis As dSolicitudAnalisis
    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Property SolicitudAnalisis() As dSolicitudAnalisis
        Get
            Return _solicitudanalisis
        End Get
        Set(ByVal value As dSolicitudAnalisis)
            _solicitudanalisis = value
        End Set
    End Property

    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarUsuarios()
        cargarComboInformes()
        cargarComboSubInformes()
    End Sub

    Private Sub cargarUsuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    If u.TIPOUSUARIO = 98 Then
                        cbxControladores.Items.Add(u)
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub cargarComboInformes()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    cbxTipoInfome.Items.Add(ti)
                Next
            End If
        End If
    End Sub

    Public Sub cargarComboSubInformes()
        Dim si As New dSubInforme
        Dim lista As New ArrayList
        lista = si.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each si In lista
                    cbxSubTipoInforme.Items.Add(si)
                Next
            End If
        End If
    End Sub

End Class