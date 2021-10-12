Public Class FormSolicitudCalidadMuestras
    Private _usuario As dUsuario
    Dim idsol As String


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

        cant_muestras = 0
        buscarsolicitud()

        LabelMuestras.Text = cant_muestras

    End Sub
#End Region
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub buscarsolicitud()
        Dim scm As New dCalidadSolicitudMuestra
        Dim lista As New ArrayList
        lista = scm.listarporsolicitud(idsol)
        'scm.IDSOLICITUD = idsol
        'scm = scm.buscar
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            cant_muestras = lista.Count

            If lista.Count > 0 Then
                For Each csm In lista
                    ListMuestras().Items.Add(csm)
                Next
            End If
        End If
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestra.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Dim idsolicitud As String = idsol
            Dim muestra As String = Trim(TextMuestra.Text)
            Dim csm As New dCalidadSolicitudMuestra
            Dim lista As ArrayList
            If TextMuestra.Text.Length > 0 Then
                lista = csm.controlarmuestras(idsolicitud, muestra)
                If Not lista Is Nothing Then
                    My.Computer.Audio.Play("c:\debug\aviso.wav")
                    Dim result = MessageBox.Show("La muestra ya existe, desea agregarla?", "Atención", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        Exit Sub
                    ElseIf result = DialogResult.Yes Then

                    End If
                Else

                End If
            End If

            solicitud_calidad_muestras()
            listar_solicitud_calidad_muestras()
            TextMuestra.Text = ""
            TextMuestra.Focus()
            cant_muestras = cant_muestras + 1
            LabelMuestras.Text = cant_muestras


            ' Busco en la tabla calidad los registros que tengan rc alto
            Dim sa As New dSolicitudAnalisis
            Dim lista_fichas As New ArrayList
            lista_fichas = sa.listarporproductor3(idprod)
            If lista_fichas IsNot Nothing Then
                If lista_fichas.Count > 0 Then
                    For Each sa In lista_fichas
                        Dim c As New dCalidad
                        Dim ficha As Long = sa.ID
                        c.FICHA = ficha
                        c.MUESTRA = muestra
                        c = c.buscarxfichaxmuestra
                        If c IsNot Nothing Then
                            If c.RC > 500 Then
                                rc_alto = rc_alto & muestra & " - " & sa.FECHAINGRESO & " / "
                            End If
                        End If
                        c = Nothing
                    Next
                End If
            End If
            'If rc_alto <> "" Then
            '    MsgBox("Muestras con RC > 500.000 --> " & rc_alto)
            'End If
            sa = Nothing

        End If
    End Sub
    
    Private Sub solicitud_calidad_muestras()
        Dim idsolicitud As String = idsol
        Dim muestra As String = Trim(TextMuestra.Text)
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
        Dim caseina As Integer
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
        If CheckCaseina.Checked = True Then
            caseina = 1
        Else
            caseina = 0
        End If
        Dim csm As New dCalidadSolicitudMuestra
        'csm.IDSOLICITUD = idsol
        'csm = csm.buscar
        If TextMuestra.Text <> "" Then
            Dim c As New dCalidadSolicitudMuestra
            c.IDSOLICITUD = idsol
            c.MUESTRA = muestra
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
            c.CASEINA = caseina
            If (c.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            'Me.Close()
        End If
    End Sub
    Public Sub listar_solicitud_calidad_muestras()
        Dim csm As New dCalidadSolicitudMuestra
        Dim lista As New ArrayList
        lista = csm.listarporid(idsol)
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each csm In lista
                    ListMuestras().Items.Add(csm)
                Next
            End If
        End If
    End Sub
    
    
    Private Sub TextMuestra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMuestra.TextChanged

    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        TextMuestra.Text = ""
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim csm As dCalidadSolicitudMuestra = CType(ListMuestras.SelectedItem, dCalidadSolicitudMuestra)
            TextIdCSM.Text = csm.ID

            TextMuestra.Text = csm.MUESTRA
            If csm.RB = 1 Then
                CheckRB.Checked = True
            Else
                CheckRB.Checked = False
            End If
            If csm.RC = 1 Then
                CheckRC.Checked = True
            Else
                CheckRC.Checked = False
            End If
            If csm.COMPOSICION = 1 Then
                CheckComposicion.Checked = True
            Else
                CheckComposicion.Checked = False
            End If
            If csm.CRIOSCOPIA = 1 Then
                CheckCrioscopia.Checked = True
            Else
                CheckCrioscopia.Checked = False
            End If
            If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                CheckCrioscopia_crioscopo.Checked = True
            Else
                CheckCrioscopia_crioscopo.Checked = False
            End If
            If csm.INHIBIDORES = 1 Then
                CheckInhibidores.Checked = True
            Else
                CheckInhibidores.Checked = False
            End If
            If csm.ESPORULADOS = 1 Then
                CheckEsporulados.Checked = True
            Else
                CheckEsporulados.Checked = False
            End If
            If csm.UREA = 1 Then
                CheckUrea.Checked = True
            Else
                CheckUrea.Checked = False
            End If
            If csm.TERMOFILOS = 1 Then
                CheckTermofilos.Checked = True
            Else
                CheckTermofilos.Checked = False
            End If
            If csm.PSICROTROFOS = 1 Then
                CheckPsicrotrofos.Checked = True
            Else
                CheckPsicrotrofos.Checked = False
            End If
            If csm.CASEINA = 1 Then
                CheckCaseina.Checked = True
            Else
                CheckCaseina.Checked = False
            End If
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not ListMuestras.SelectedItem Is Nothing Then
            Dim csm As New dCalidadSolicitudMuestra
            Dim id As Long = CType(TextIdCSM.Text, Long)
            csm.ID = id
            If (csm.eliminar(Usuario)) Then
                MsgBox("Muestra eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        TextMuestra.Text = ""
        TextIdCSM.Text = ""
        listar_solicitud_calidad_muestras()
        cant_muestras = cant_muestras - 1
        LabelMuestras.Text = cant_muestras
    End Sub

    Private Sub CheckRB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckRB.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckRC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckRC.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckComposicion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckComposicion.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckCrioscopia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCrioscopia.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckCrioscopia_crioscopo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCrioscopia_crioscopo.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckInhibidores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInhibidores.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckEsporulados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEsporulados.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckUrea_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckUrea.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckTermofilos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTermofilos.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckPsicrotrofos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPsicrotrofos.CheckedChanged
        TextMuestra.Focus()
    End Sub
    Private Sub CheckCaseina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCaseina.CheckedChanged
        TextMuestra.Focus()
    End Sub
    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Close()
    End Sub
End Class