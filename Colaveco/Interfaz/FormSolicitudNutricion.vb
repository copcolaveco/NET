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
        cant_muestras = 0

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
            cant_muestras = cant_muestras + 1
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub guardar()
        Dim ficha As String = idsol
        Dim muestra As String = Trim(TextMuestra.Text)
        Dim mga As Integer
        Dim mgb As Integer
        Dim ensilados As Integer
        Dim pasturas As Integer
        Dim extetereo As Integer
        Dim nida As Integer
        Dim micotoxinas As Integer
        Dim don As Integer
        Dim afla As Integer
        Dim zeara As Integer
        Dim proteinas As Integer
        Dim materiaseca As Integer
        Dim ph As Integer
        Dim fibraefectiva As Integer
        Dim clostridios As Integer
        Dim timac As Integer
        Dim timacproteina As Integer
        Dim fibraneutra As Integer
        Dim fibraacida As Integer

        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim fecing As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")

        If CheckMGA.Checked = True Then
            mga = 1
        Else
            mga = 0
        End If
        If CheckMGB.Checked = True Then
            mgb = 1
        Else
            mgb = 0
        End If
        If CheckEnsilados.Checked = True Then
            ensilados = 1
        Else
            ensilados = 0
        End If
        If CheckPasturas.Checked = True Then
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
        If CheckMicotoxinas.Checked = True Then
            micotoxinas = 1
        Else
            micotoxinas = 0
        End If
        If CheckDon.Checked = True Then
            don = 1
        Else
            don = 0
        End If
        If CheckAfla.Checked = True Then
            afla = 1
        Else
            afla = 0
        End If
        If CheckZeara.Checked = True Then
            zeara = 1
        Else
            zeara = 0
        End If
        If CheckProteina.Checked = True Then
            proteinas = 1
        Else
            proteinas = 0
        End If
        If CheckMSeca.Checked = True Then
            materiaseca = 1
        Else
            materiaseca = 0
        End If
        If CheckPH.Checked = True Then
            ph = 1
        Else
            ph = 0
        End If
        If CheckFibraEfectiva.Checked = True Then
            fibraefectiva = 1
        Else
            fibraefectiva = 0
        End If
        If CheckClostridios.Checked = True Then
            clostridios = 1
        Else
            clostridios = 0
        End If
        If CheckTimac.Checked = True Then
            timac = 1
        Else
            timac = 0
        End If
        If CheckTimacProteina.Checked = True Then
            timacproteina = 1
        Else
            timacproteina = 0
        End If
        If CheckFibraNeutra.Checked = True Then
            fibraneutra = 1
        Else
            fibraneutra = 0
        End If
        If CheckFibraAcida.Checked = True Then
            fibraacida = 1
        Else
            fibraacida = 0
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
                sn.DON = don
                sn.AFLA = afla
                sn.ZEARA = zeara
                sn.PROTEINAS = proteinas
                sn.MATERIASECA = materiaseca
                sn.PH = ph
                sn.FIBRAEFECTIVA = fibraefectiva
                sn.CLOSTRIDIOS = clostridios
                sn.TIMAC = timac
                sn.TIMACPROTEINA = timacproteina
                sn.FIBRANEUTRA = fibraneutra
                sn.FIBRAACIDA = fibraacida
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
                sn.DON = don
                sn.AFLA = afla
                sn.ZEARA = zeara
                sn.PROTEINAS = proteinas
                sn.MATERIASECA = materiaseca
                sn.PH = ph
                sn.FIBRAEFECTIVA = fibraefectiva
                sn.CLOSTRIDIOS = clostridios
                sn.TIMAC = timac
                sn.TIMACPROTEINA = timacproteina
                sn.FIBRANEUTRA = fibraneutra
                sn.FIBRAACIDA = fibraacida

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
                n.DON = "-1"
                n.AFLA = "-1"
                n.ZEARA = "-1"
                n.FIBRAEFECTIVA = "-1"
                n.CLOSTRIDIOS = "-1"
                n.ZINC = -1
                n.CALCIO = -1
                n.FOSFORO = -1
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
                CheckMGA.Checked = True
            Else
                CheckMGA.Checked = False
            End If
            If sn.MGB = 1 Then
                CheckMGB.Checked = True
            Else
                CheckMGB.Checked = False
            End If
            If sn.ENSILADOS = 1 Then
                CheckEnsilados.Checked = True
            Else
                CheckEnsilados.Checked = False
            End If
            If sn.PASTURAS = 1 Then
                CheckPasturas.Checked = True
            Else
                CheckPasturas.Checked = False
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
                CheckMicotoxinas.Checked = True
            Else
                CheckMicotoxinas.Checked = False
            End If
            If sn.DON = 1 Then
                CheckDon.Checked = True
            Else
                CheckDon.Checked = False
            End If
            If sn.AFLA = 1 Then
                CheckAfla.Checked = True
            Else
                CheckAfla.Checked = False
            End If
            If sn.ZEARA = 1 Then
                CheckZeara.Checked = True
            Else
                CheckZeara.Checked = False
            End If
            If sn.PROTEINAS = 1 Then
                CheckProteina.Checked = True
            Else
                CheckProteina.Checked = False
            End If
            If sn.FIBRAEFECTIVA = 1 Then
                CheckFibraEfectiva.Checked = True
            Else
                CheckFibraEfectiva.Checked = False
            End If
            If sn.CLOSTRIDIOS = 1 Then
                CheckClostridios.Checked = True
            Else
                CheckClostridios.Checked = False
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

    Private Sub RadioMGA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextMuestra.Focus()
    End Sub

    Private Sub RadioMGB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextMuestra.Focus()
    End Sub

    Private Sub RadioEnsilados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextMuestra.Focus()
    End Sub

    Private Sub RadioPasturas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextMuestra.Focus()
    End Sub

    Private Sub CheckExtEtereo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckExtEtereo.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckNida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNida.CheckedChanged
        TextMuestra.Focus()
    End Sub
    Private Sub RadioMicotoxinas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextMuestra.Focus()
    End Sub

    Private Sub TextMuestra_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextMuestra.RightToLeftChanged

    End Sub

    Private Sub TextMuestra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMuestra.TextChanged

    End Sub

    Private Sub CheckMicotoxinas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMicotoxinas.CheckedChanged
        cargarmicotoxinas()
        TextMuestra.Focus()
    End Sub
    Private Sub cargarmicotoxinas()
        If CheckMicotoxinas.Checked = True Then
            CheckDon.Checked = True
            CheckAfla.Checked = True
            CheckZeara.Checked = True
        Else
            CheckDon.Checked = False
            CheckAfla.Checked = False
            CheckZeara.Checked = False
        End If
    End Sub

    Private Sub CheckMGA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMGA.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckMGB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMGB.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckEnsilados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEnsilados.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckPasturas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPasturas.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckDon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDon.CheckedChanged
        If CheckDon.Checked = True Then
            CheckMicotoxinas.Checked = True
        End If
        TextMuestra.Focus()
    End Sub

    Private Sub CheckAfla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAfla.CheckedChanged
        If CheckAfla.Checked = True Then
            CheckMicotoxinas.Checked = True
        End If
        TextMuestra.Focus()
    End Sub

    Private Sub CheckZeara_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckZeara.CheckedChanged
        If CheckZeara.Checked = True Then
            CheckMicotoxinas.Checked = True
        End If
        TextMuestra.Focus()
    End Sub

    Private Sub CheckProteina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckProteina.CheckedChanged
        TextMuestra.Focus()
    End Sub
End Class