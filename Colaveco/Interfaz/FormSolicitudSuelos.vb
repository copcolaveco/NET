Public Class FormSolicitudSuelos
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
        Dim ss As New dSolicitudSuelos
        Dim lista As New ArrayList
        lista = ss.listarporsolicitud(idsol)
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ss In lista
                    ListMuestras().Items.Add(ss)
                Next
            End If
        End If
    End Sub

    Private Sub TextMuestra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
            listar_solicitud_suelos()
            TextMuestra.Text = ""
            TextId.Text = ""
            cant_muestras = cant_muestras + 1
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub guardar()
        Dim ficha As String = idsol
        Dim muestra As String = Trim(TextMuestra.Text)
        Dim paquete As Integer
        Dim nitratos As Integer
        Dim mineralizacion As Integer
        Dim fosforobray As Integer
        Dim fosforocitrico As Integer
        Dim phagua As Integer
        Dim phkci As Integer
        Dim materiaorg As Integer
        Dim potasioint As Integer
        Dim sulfatos As Integer
        Dim nitrogenovegetal As Integer
        Dim calcio As Integer
        Dim magnesio As Integer
        Dim sodio As Integer
        Dim acideztitulable As Integer
        Dim cic As Integer
        Dim sb As Integer
        Dim muestreo As Integer
        Dim zinc As Integer
        Dim isusaestandar As Integer
        Dim isusazinc As Integer

        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim fecing As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")
        If CheckAnalisisCompleto.Checked = True Then
            paquete = 1
        ElseIf CheckCultivosVerano.Checked = True Then
            paquete = 2
        ElseIf CheckCultivosInvierno.Checked = True Then
            paquete = 3
        ElseIf CheckCationes.Checked = True Then
            paquete = 4
        ElseIf CheckPastura.Checked = True Then
            paquete = 5
        ElseIf CheckIsusaEstandar.Checked = True Then
            paquete = 6
        ElseIf CheckIsusaZinc.Checked = True Then
            paquete = 6
        ElseIf CheckFoliar.Checked = True Then
            paquete = 7
        Else
            paquete = 0
        End If
        If CheckNitratos.Checked = True Then
            nitratos = 1
        Else
            nitratos = 0
        End If
        If CheckMineralizacion.Checked = True Then
            mineralizacion = 1
        Else
            mineralizacion = 0
        End If
        If CheckFosforoBray.Checked = True Then
            fosforobray = 1
        Else
            fosforobray = 0
        End If
        If CheckFosforoCitrico.Checked = True Then
            fosforocitrico = 1
        Else
            fosforocitrico = 0
        End If
        If CheckPHAgua.Checked = True Then
            phagua = 1
        Else
            phagua = 0
        End If
        If CheckPHKCI.Checked = True Then
            phkci = 1
        Else
            phkci = 0
        End If
        If CheckMateriaOrg.Checked = True Then
            materiaorg = 1
        Else
            materiaorg = 0
        End If
        If CheckPotasioInt.Checked = True Then
            potasioint = 1
        Else
            potasioint = 0
        End If
        If CheckSulfatos.Checked = True Then
            sulfatos = 1
        Else
            sulfatos = 0
        End If
        If CheckNitrogenoVegetal.Checked = True Then
            nitrogenovegetal = 1
        Else
            nitrogenovegetal = 0
        End If
        If CheckCalcio.Checked = True Then
            calcio = 1
        Else
            calcio = 0
        End If
        If CheckMagnesio.Checked = True Then
            magnesio = 1
        Else
            magnesio = 0
        End If
        If CheckSodio.Checked = True Then
            sodio = 1
        Else
            sodio = 0
        End If
        If CheckAcidezT.Checked = True Then
            acideztitulable = 1
        Else
            acideztitulable = 0
        End If
        If CheckCIC.Checked = True Then
            cic = 1
        Else
            cic = 0
        End If
        If CheckSB.Checked = True Then
            sb = 1
        Else
            sb = 0
        End If
        If CheckMuestreo.Checked = True Then
            muestreo = 1
        Else
            muestreo = 0
        End If
        If CheckZinc.Checked = True Then
            zinc = 1
        Else
            zinc = 0
        End If
        If CheckIsusaEstandar.Checked = True Then
            isusaestandar = 1
        Else
            isusaestandar = 0
        End If
        If CheckIsusaZinc.Checked = True Then
            isusazinc = 1
        Else
            isusazinc = 0
        End If

        If TextMuestra.Text <> "" Then
            If TextId.Text <> "" Then
                Dim ss As New dSolicitudSuelos
                Dim id As Long = TextId.Text
                ss.ID = id
                ss.FICHA = idsol
                ss.MUESTRA = muestra
                ss.PAQUETE = paquete
                ss.NITRATOS = nitratos
                ss.MINERALIZACION = mineralizacion
                ss.FOSFOROBRAY = fosforobray
                ss.FOSFOROCITRICO = fosforocitrico
                ss.PHAGUA = phagua
                ss.PHKCI = phkci
                ss.MATERIAORG = materiaorg
                ss.POTASIOINT = potasioint
                ss.SULFATOS = sulfatos
                ss.NITROGENOVEGETAL = nitrogenovegetal
                ss.CALCIO = calcio
                ss.MAGNESIO = magnesio
                ss.SODIO = sodio
                ss.ACIDEZTITULABLE = acideztitulable
                ss.CIC = cic
                ss.SB = sb
                ss.MUESTREO = muestreo
                ss.ZINC = zinc
                ss.ISUSAESTANDAR = isusaestandar
                ss.ISUSAZINC = isusazinc
                If (ss.modificar(Usuario)) Then
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim s As New dSuelos
                Dim ss As New dSolicitudSuelos
                ss.FICHA = idsol
                ss.MUESTRA = muestra
                ss.PAQUETE = paquete
                ss.NITRATOS = nitratos
                ss.MINERALIZACION = mineralizacion
                ss.FOSFOROBRAY = fosforobray
                ss.FOSFOROCITRICO = fosforocitrico
                ss.PHAGUA = phagua
                ss.PHKCI = phkci
                ss.MATERIAORG = materiaorg
                ss.POTASIOINT = potasioint
                ss.SULFATOS = sulfatos
                ss.NITROGENOVEGETAL = nitrogenovegetal
                ss.CALCIO = calcio
                ss.MAGNESIO = magnesio
                ss.SODIO = sodio
                ss.SODIO = sodio
                ss.ACIDEZTITULABLE = acideztitulable
                ss.CIC = cic
                ss.SB = sb
                ss.MUESTREO = muestreo
                ss.ZINC = zinc
                ss.ISUSAESTANDAR = isusaestandar
                ss.ISUSAZINC = isusazinc

                s.FICHA = idsol
                s.FECHAINGRESO = fecing
                s.FECHAPROCESO = fecing
                s.MUESTRA = muestra
                s.DETALLEMUESTRA = ""
                s.FOSFOROBRAY = -1
                s.FOSFOROCITRICO = -1
                s.NITRATOS = -1
                s.PHAGUA = -1
                s.PHKCI = -1
                s.POTASIOINT = -1
                s.SULFATOS = -1
                s.NITROGENOVEGETAL = -1
                s.CARBONOORGANICO = -1
                s.MATERIAORGANICA = -1
                s.PMN = -1
                s.CALCIO = -1
                s.MAGNESIO = -1
                s.SODIO = -1
                s.ACIDEZTITULABLE = -1
                s.CIC = -1
                s.SB = -1
                s.ZINC = -1
                s.MARCA = 0

                If (ss.guardar(Usuario)) Then
                    s.guardar(Usuario)
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
    End Sub
    Public Sub listar_solicitud_suelos()
        Dim ss As New dSolicitudSuelos
        Dim lista As New ArrayList
        lista = ss.listarporid(idsol)
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ss In lista
                    ListMuestras().Items.Add(ss)
                Next
            End If
        End If
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        TextMuestra.Text = ""
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim ss As dSolicitudSuelos = CType(ListMuestras.SelectedItem, dSolicitudSuelos)
            TextId.Text = ss.ID
            TextMuestra.Text = ss.MUESTRA
            If ss.PAQUETE = 1 Then
                CheckAnalisisCompleto.Checked = True
            ElseIf ss.PAQUETE = 2 Then
                CheckCultivosVerano.Checked = True
            ElseIf ss.PAQUETE = 3 Then
                CheckCultivosInvierno.Checked = True
            ElseIf ss.PAQUETE = 4 Then
                CheckCationes.Checked = True
            ElseIf ss.PAQUETE = 5 Then
                CheckPastura.Checked = True
            End If
            If ss.NITRATOS = 1 Then
                CheckNitratos.Checked = True
            Else
                CheckNitratos.Checked = False
            End If
            If ss.MINERALIZACION = 1 Then
                CheckMineralizacion.Checked = True
            Else
                CheckMineralizacion.Checked = False
            End If
            If ss.FOSFOROBRAY = 1 Then
                CheckFosforoBray.Checked = True
            Else
                CheckFosforoBray.Checked = False
            End If
            If ss.FOSFOROCITRICO = 1 Then
                CheckFosforoCitrico.Checked = True
            Else
                CheckFosforoCitrico.Checked = False
            End If
            If ss.PHAGUA = 1 Then
                CheckPHAgua.Checked = True
            Else
                CheckPHAgua.Checked = False
            End If
            If ss.PHKCI = 1 Then
                CheckPHKCI.Checked = True
            Else
                CheckPHKCI.Checked = False
            End If
            If ss.MATERIAORG = 1 Then
                CheckMateriaOrg.Checked = True
            Else
                CheckMateriaOrg.Checked = False
            End If
            If ss.POTASIOINT = 1 Then
                CheckPotasioInt.Checked = True
            Else
                CheckPotasioInt.Checked = False
            End If
            If ss.SULFATOS = 1 Then
                CheckSulfatos.Checked = True
            Else
                CheckSulfatos.Checked = False
            End If
            If ss.NITROGENOVEGETAL = 1 Then
                CheckNitrogenoVegetal.Checked = True
            Else
                CheckNitrogenoVegetal.Checked = False
            End If
            If ss.CALCIO = 1 Then
                CheckCalcio.Checked = True
            Else
                CheckCalcio.Checked = False
            End If
            If ss.MAGNESIO = 1 Then
                CheckMagnesio.Checked = True
            Else
                CheckMagnesio.Checked = False
            End If
            If ss.SODIO = 1 Then
                CheckSodio.Checked = True
            Else
                CheckSodio.Checked = False
            End If
            If ss.ACIDEZTITULABLE = 1 Then
                CheckAcidezT.Checked = True
            Else
                CheckAcidezT.Checked = False
            End If
            If ss.CIC = 1 Then
                CheckCIC.Checked = True
            Else
                CheckCIC.Checked = False
            End If
            If ss.SB = 1 Then
                CheckSB.Checked = True
            Else
                CheckSB.Checked = False
            End If
            If ss.MUESTREO = 1 Then
                CheckMuestreo.Checked = True
            Else
                CheckMuestreo.Checked = False
            End If
            If ss.ZINC = 1 Then
                CheckZinc.Checked = True
            Else
                CheckZinc.Checked = False
            End If
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListMuestras.SelectedItem Is Nothing Then
            Dim ss As New dSolicitudSuelos
            Dim id As Long = CType(TextId.Text, Long)
            ss.ID = id
            If (ss.eliminar(Usuario)) Then
                MsgBox("Muestra eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        TextMuestra.Text = ""
        TextId.Text = ""
        listar_solicitud_suelos()

    End Sub

    Private Sub ButtonCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCerrar.Click
        Me.Close()
    End Sub

    Private Sub CheckNitrogeno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNitratos.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckMineralizacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMineralizacion.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckFosforoBray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFosforoBray.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckFosforoCitrico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFosforoCitrico.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckPH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPHAgua.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckMateriaOrg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMateriaOrg.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckPotasioInt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPotasioInt.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub TextMuestra_ReadOnlyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextMuestra.ReadOnlyChanged

    End Sub

    Private Sub TextMuestra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMuestra.TextChanged

    End Sub

    Private Sub CheckAnalisisCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAnalisisCompleto.CheckedChanged
        cargarchecks()
    End Sub
    Private Sub cargarchecks()
        'desmarcarchecks()
        If CheckAnalisisCompleto.Checked = True Then
            CheckNitratos.Checked = True
            CheckFosforoBray.Checked = True
            CheckPotasioInt.Checked = True
            CheckPHAgua.Checked = True
            CheckMateriaOrg.Checked = True
        ElseIf CheckCultivosVerano.Checked = True Then
            CheckPHAgua.Checked = True
            CheckFosforoBray.Checked = True
            CheckPotasioInt.Checked = True
            CheckSulfatos.Checked = True
        ElseIf CheckCultivosInvierno.Checked = True Then
            CheckNitratos.Checked = True
            CheckFosforoBray.Checked = True
            CheckPotasioInt.Checked = True
            CheckPHAgua.Checked = True
        ElseIf CheckCationes.Checked = True Then
            CheckCalcio.Checked = True
            CheckMagnesio.Checked = True
            CheckSodio.Checked = True
            CheckPotasioInt.Checked = True
            CheckCIC.Checked = True
            CheckSB.Checked = True
            CheckAcidezT.Checked = True
        ElseIf CheckPastura.Checked = True Then
            CheckFosforoBray.Checked = True
            CheckPotasioInt.Checked = True
            CheckPHAgua.Checked = True
            CheckMateriaOrg.Checked = True
        ElseIf CheckIsusaEstandar.Checked = True Then
            CheckPHAgua.Checked = True
            CheckFosforoBray.Checked = True
            CheckPotasioInt.Checked = True
            CheckMateriaOrg.Checked = True
            CheckCalcio.Checked = True
            CheckMagnesio.Checked = True
        ElseIf CheckIsusaZinc.Checked = True Then
            CheckPHAgua.Checked = True
            CheckFosforoBray.Checked = True
            CheckPotasioInt.Checked = True
            CheckMateriaOrg.Checked = True
            CheckCalcio.Checked = True
            CheckMagnesio.Checked = True
            CheckZinc.Checked = True
        ElseIf CheckFoliar.Checked = True Then
            CheckPotasio.Checked = True
            CheckFosforo.Checked = True
            CheckNitrogenoVegetal.Checked = True
        End If
    End Sub
    Private Sub desmarcarchecks()
        CheckNitratos.Checked = False
        CheckMineralizacion.Checked = False
        CheckFosforoBray.Checked = False
        CheckFosforoCitrico.Checked = False
        CheckPHAgua.Checked = False
        CheckPHKCI.Checked = False
        CheckMateriaOrg.Checked = False
        CheckPotasioInt.Checked = False
        CheckSulfatos.Checked = False
        CheckNitrogenoVegetal.Checked = False
        CheckCalcio.Checked = False
        CheckMagnesio.Checked = False
        CheckSodio.Checked = False
        CheckAcidezT.Checked = False
        CheckCIC.Checked = False
        CheckSB.Checked = False
        CheckZinc.Checked = False
        CheckPotasio.Checked = False
        CheckFosforo.Checked = False

    End Sub

    Private Sub CheckCultivosVerano_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCultivosVerano.CheckedChanged
        cargarchecks()
    End Sub

    Private Sub CheckCultivosInvierno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCultivosInvierno.CheckedChanged
        cargarchecks()
    End Sub

    Private Sub CheckCationes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCationes.CheckedChanged
        cargarchecks()
    End Sub

    Private Sub CheckZinc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckZinc.CheckedChanged
        TextMuestra.Focus()
    End Sub

    Private Sub CheckPastura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPastura.CheckedChanged
        cargarchecks()
    End Sub

    Private Sub CheckIsusaEstandar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckIsusaEstandar.CheckedChanged
        cargarchecks()
    End Sub

    Private Sub CheckIsusaZinc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckIsusaZinc.CheckedChanged
        cargarchecks()
    End Sub

    Private Sub CheckFoliar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFoliar.CheckedChanged
        cargarchecks()
    End Sub
End Class