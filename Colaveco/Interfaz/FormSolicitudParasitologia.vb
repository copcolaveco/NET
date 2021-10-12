Public Class FormSolicitudParasitologia
    Private _usuario As dUsuario
    Dim idsol As String
    Dim subinf As Integer
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal solicitud As String, ByVal idsubinf As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        'listarultimoid()
        idsol = solicitud
        subinf = idsubinf

    End Sub
#End Region

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        'Dim ficha As Long = Textficha.Text.Trim
        Dim gastrointestinales As Integer
        Dim fasciola As Integer
        Dim coccidias As Integer
        Dim coproparasitario_can As Integer

        If CheckGastrointesinales.Checked = True Then
            gastrointestinales = 1
        Else
            gastrointestinales = 0
        End If
        If CheckFasciola.Checked = True Then
            fasciola = 1
        Else
            fasciola = 0
        End If
        If CheckCoccidias.Checked = True Then
            coccidias = 1
        Else
            coccidias = 0
        End If
        If CheckCoproparasitario_can.Checked = True Then
            coproparasitario_can = 1
        Else
            coproparasitario_can = 0
        End If

        Dim ps As New dParasitologiaSolicitud
        ps.ficha = idsol
        ps = ps.buscar
        If Not ps Is Nothing Then
            Dim p As New dParasitologiaSolicitud
            p.ficha = idsol
            p.GASTROINTESTINALES = gastrointestinales
            p.FASCIOLA = fasciola
            p.COCCIDIAS = coccidias
            p.COPROPARASITARIO_CAN = coproparasitario_can
            If (p.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            Me.Close()
        Else
            Dim p As New dParasitologiaSolicitud
            p.ficha = idsol
            p.GASTROINTESTINALES = gastrointestinales
            p.FASCIOLA = fasciola
            p.COCCIDIAS = coccidias
            p.COPROPARASITARIO_CAN = coproparasitario_can
            If (p.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            Me.Close()
        End If
    End Sub
End Class