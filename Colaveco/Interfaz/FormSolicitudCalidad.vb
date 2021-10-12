Public Class FormSolicitudCalidad
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
        If subinf = 9 Then
            desmarcarcheckbox()
            CheckRB.Checked = True
            CheckRC.Checked = True
            CheckComposicion.Checked = True
            CheckCrioscopia.Checked = True
            CheckInhibidores.Checked = True
            CheckEsporulados.Checked = True
            CheckUrea.Checked = True
            CheckTermofilos.Checked = True
            CheckPsicrotrofos.Checked = True
        ElseIf subinf = 18 Then
            desmarcarcheckbox()
            CheckRB.Checked = True
            CheckRC.Checked = True
            CheckComposicion.Checked = True
        ElseIf subinf = 19 Then
            desmarcarcheckbox()
            CheckRB.Checked = True
            CheckRC.Checked = True
            CheckComposicion.Checked = True
            CheckCrioscopia.Checked = True
            CheckInhibidores.Checked = True
        ElseIf subinf = 28 Then
            desmarcarcheckbox()
            CheckComposicion.Checked = True
            CheckUrea.Checked = True
        End If

    End Sub
    Private Sub desmarcarcheckbox()
        CheckRB.Checked = False
        CheckRC.Checked = False
        CheckComposicion.Checked = False
        CheckCrioscopia.Checked = False
        CheckInhibidores.Checked = False
        CheckEsporulados.Checked = False
        CheckUrea.Checked = False
        CheckTermofilos.Checked = False
        CheckPsicrotrofos.Checked = False
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        'Dim ficha As Long = Textficha.Text.Trim
        Dim rb As Integer
        Dim rc As Integer
        Dim composicion As Integer
        Dim crioscopia As Integer
        Dim crioscopia_crioscopo As Integer
        Dim inhibidores As Integer
        Dim esporulados As Integer
        Dim urea As Integer
        Dim termofilos As Integer
        Dim psicrotrofos As Integer
        If CheckRB.Checked = True Then
            rb = 1
        Else
            rb = 0
        End If
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
        If CheckCrioscopia.Checked = True Then
            crioscopia = 1
        Else
            crioscopia = 0
        End If
        If CheckCrioscopia_crioscopo.Checked = True Then
            crioscopia_crioscopo = 1
        Else
            crioscopia_crioscopo = 0
        End If
        If CheckInhibidores.Checked = True Then
            inhibidores = 1
        Else
            inhibidores = 0
        End If
        If CheckEsporulados.Checked = True Then
            esporulados = 1
        Else
            esporulados = 0
        End If
        If CheckUrea.Checked = True Then
            urea = 1
        Else
            urea = 0
        End If
        If CheckTermofilos.Checked = True Then
            termofilos = 1
        Else
            termofilos = 0
        End If
        If CheckPsicrotrofos.Checked = True Then
            psicrotrofos = 1
        Else
            psicrotrofos = 0
        End If

        Dim cs As New dCalidadSolicitud
        cs.ficha = idsol
        cs = cs.buscar
        If Not cs Is Nothing Then
            Dim c As New dCalidadSolicitud
            c.ficha = idsol
            c.RB = rb
            c.RC = rc
            c.COMPOSICION = composicion
            c.CRIOSCOPIA = crioscopia
            c.INHIBIDORES = inhibidores
            c.ESPORULADOS = esporulados
            c.UREA = urea
            c.TERMOFILOS = termofilos
            c.PSICROTROFOS = psicrotrofos
            c.CRIOSCOPIA_CRIOSCOPO = crioscopia_crioscopo
            If (c.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            Me.Close()
        Else
            Dim c As New dCalidadSolicitud
            c.ficha = idsol
            c.RB = rb
            c.RC = rc
            c.COMPOSICION = composicion
            c.CRIOSCOPIA = crioscopia
            c.INHIBIDORES = inhibidores
            c.ESPORULADOS = esporulados
            c.UREA = urea
            c.TERMOFILOS = termofilos
            c.PSICROTROFOS = psicrotrofos
            c.CRIOSCOPIA_CRIOSCOPO = crioscopia_crioscopo
            If (c.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            Me.Close()
        End If
        

        
    End Sub

    Private Sub FormSolicitudCalidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class