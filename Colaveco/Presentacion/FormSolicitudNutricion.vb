Public Class FormSolicitudNutricion
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
    Public Sub New(ByVal u As dUsuario, ByVal solicitud As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        'listarultimoid()
        idsol = solicitud
        buscarsolicitud()
        TextFicha.Text = idsol

    End Sub
#End Region
    Private Sub buscarsolicitud()
        Dim sn As New dSolicitudNutricion
        Dim lista As New ArrayList
        lista = sn.listarporsolicitud(idsol)
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sn In lista
                    ListMuestras().Items.Add(sn)
                Next
            End If
        End If
    End Sub

    Private Sub TextMuestra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
            listar_solicitud_nutricion()
            TextMuestra.Text = ""
            TextId.Text = ""
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub guardar()
        Dim idsolicitud As String = idsol
        Dim muestra As String = Trim(TextMuestra.Text)
        Dim mga As Integer
        Dim mgb As Integer
        Dim ensilados As Integer
        Dim pasturas As Integer
        Dim extetereo As Integer
        Dim nida As Integer
        Dim micotoxinas As Integer

        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim fecing As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")

        If RadioMGA.Checked = True Then
            mga = 1
        Else
            mga = 0
        End If
        If RadioMGB.Checked = True Then
            mgb = 1
        Else
            mgb = 0
        End If
        If RadioEnsilados.Checked = True Then
            ensilados = 1
        Else
            ensilados = 0
        End If
        If RadioPasturas.Checked = True Then
            pasturas = 1
        Else
            pasturas = 0
        End If
        If CheckExtEtereo.Checked = True Then
            extetereo = 1
        Else
            extetereo = 0
        End If
        If CheckNida.Checked = True Then
            nida = 1
        Else
            nida = 0
        End If
        If RadioMicotoxinas.Checked = True Then
            micotoxinas = 1
        Else
            micotoxinas = 0
        End If
        If TextMuestra.Text <> "" Then
            If TextId.Text <> "" Then
                Dim sn As New dSolicitudNutricion
                Dim n As New dNutricion
                Dim id As Long = TextId.Text
                sn.ID = id
                sn.FICHA = idsol
                sn.MUESTRA = muestra
                sn.MGA = mga
                sn.MGB = mgb
                sn.ENSILADOS = ensilados
                sn.PASTURAS = pasturas
                sn.EXTETEREO = extetereo
                sn.NIDA = nida
                sn.MICOTOXINAS = micotoxinas
                If (sn.modificar(Usuario)) Then
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim sn As New dSolicitudNutricion
                Dim n As New dNutricion
                sn.FICHA = idsol
                sn.MUESTRA = muestra
                sn.MGA = mga
                sn.MGB = mgb
                sn.ENSILADOS = ensilados
                sn.PASTURAS = pasturas
                sn.EXTETEREO = extetereo
                sn.NIDA = nida
                sn.MICOTOXINAS = micotoxinas

                n.FICHA = idsol
                n.FECHAINGRESO = fecing
                n.FECHAPROCESO = fecing
                n.MUESTRA = muestra
                n.DETALLEMUESTRA = ""
                n.CLASE = -1
                n.ALIMENTO = -1
                n.MSH = -1
                n.CENIZASH = -1
                n.CENIZASS = -1
                n.PBH = -1
                n.PBS = -1
                n.FNDH = -1
                n.FNDS = -1
                n.FADH = -1
                n.FADS = -1
                n.ENLS = -1
                n.EMS = -1
                n.FCH = -1
                n.FCS = -1
                n.PHH = -1
                n.EEH = -1
                n.EES = -1
                n.NIDAH = -1
                n.MARCA = 0

                If (sn.guardar(Usuario)) Then
                    n.guardar(Usuario)
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
    End Sub
    Public Sub listar_solicitud_nutricion()
        Dim sn As New dSolicitudNutricion
        Dim lista As New ArrayList
        lista = sn.listarporid(idsol)
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sn In lista
                    ListMuestras().Items.Add(sn)
                Next
            End If
        End If
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        TextMuestra.Text = ""
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim sn As dSolicitudNutricion = CType(ListMuestras.SelectedItem, dSolicitudNutricion)
            TextId.Text = sn.ID
            TextMuestra.Text = sn.MUESTRA
            If sn.MGA = 1 Then
                RadioMGA.Checked = True
            Else
                RadioMGA.Checked = False
            End If
            If sn.MGB = 1 Then
                RadioMGB.Checked = True
            Else
                RadioMGB.Checked = False
            End If
            If sn.ENSILADOS = 1 Then
                RadioEnsilados.Checked = True
            Else
                RadioEnsilados.Checked = False
            End If
            If sn.PASTURAS = 1 Then
                RadioPasturas.Checked = True
            Else
                RadioPasturas.Checked = False
            End If
            If sn.EXTETEREO = 1 Then
                CheckExtEtereo.Checked = True
            Else
                CheckExtEtereo.Checked = False
            End If
            If sn.NIDA = 1 Then
                CheckNida.Checked = True
            Else
                CheckNida.Checked = False
            End If
            If sn.MICOTOXINAS = 1 Then
                RadioMicotoxinas.Checked = True
            Else
                RadioMicotoxinas.Checked = False
            End If
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListMuestras.SelectedItem Is Nothing Then
            Dim sn As New dSolicitudNutricion
            Dim id As Long = CType(TextId.Text, Long)
            sn.ID = id
            If (sn.eliminar(Usuario)) Then
                MsgBox("Muestra eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        TextMuestra.Text = ""
        TextId.Text = ""
        listar_solicitud_nutricion()

    End Sub

    Private Sub ButtonCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCerrar.Click
        Me.Close()
    End Sub

    Private Sub RadioMGA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioMGA.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub RadioMGB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioMGB.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub RadioEnsilados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEnsilados.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub RadioPasturas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioPasturas.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckExtEtereo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckExtEtereo.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckNida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNida.CheckedChanged
        TextMuestra.Focus()
    End Sub
    Private Sub RadioMicotoxinas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioMicotoxinas.CheckedChanged
        TextMuestra.Focus()
    End Sub
End Class