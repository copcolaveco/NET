Public Class FormSolicitudControlLechero
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
        cargarcheckbox()
    End Sub
#End Region

    Private Sub cargarcheckbox()
        If subinf = 1 Then
            desmarcarcheckbox()
            CheckRC.Checked = True
            CheckComposicion.Checked = True

        ElseIf subinf = 32 Then
            desmarcarcheckbox()
            CheckRC.Checked = True
            CheckComposicion.Checked = True
            CheckUrea.Checked = True
        ElseIf subinf = 33 Then
            desmarcarcheckbox()
            CheckUrea.Checked = True
        ElseIf subinf = 53 Then
            desmarcarcheckbox()
            CheckRC.Checked = True
            CheckComposicion.Checked = True
            CheckCaseina.Checked = True
        ElseIf subinf = 54 Then
            desmarcarcheckbox()
            CheckRC.Checked = True
            CheckComposicion.Checked = True
            CheckUrea.Checked = True
            CheckCaseina.Checked = True
        End If

    End Sub
    Private Sub desmarcarcheckbox()
        CheckRC.Checked = False
        CheckComposicion.Checked = False
        CheckUrea.Checked = False
        CheckCaseina.Checked = False
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim rc As Integer
        Dim composicion As Integer
        Dim urea As Integer
        Dim caseina As Integer
        If CheckRC.Checked = True Then
            rc = 1
        Else
            rc = 0
        End If
        If CheckComposicion.Checked = True Then
            composicion = 1
        Else
            composicion = 0
        End If
        If CheckUrea.Checked = True Then
            urea = 1
        Else
            urea = 0
        End If
        If CheckCaseina.Checked = True Then
            caseina = 1
        Else
            caseina = 0
        End If

        Dim cs As New dControlSolicitud
        cs.FICHA = idsol
        cs = cs.buscar
        If Not cs Is Nothing Then
            Dim c As New dControlSolicitud
            c.FICHA = idsol
            c.RC = rc
            c.COMPOSICION = composicion
            c.UREA = urea
            c.CASEINA = caseina
            If (c.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            Me.Close()
        Else
            Dim c As New dControlSolicitud
            c.FICHA = idsol
            c.RC = rc
            c.COMPOSICION = composicion
            c.UREA = urea
            c.CASEINA = caseina
            If (c.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            Me.Close()
        End If


        modificar_tambo()

    End Sub
    Private Sub modificar_tambo()
        Dim sa As New dSolicitudAnalisis
        Dim tambo As Integer = 0
        tambo = NumericTambo.Value
        sa.ID = idsol
        sa.TAMBO = tambo
        sa.modificartambo(Usuario)

    End Sub
    
End Class