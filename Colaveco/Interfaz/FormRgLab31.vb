Public Class FormRgLab31
    Private _usuario As dUsuario
    Dim _hora As String
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        Timer1.Enabled = True
        cargarlista()
        cargarCombos()
        cargarComboAnalisis()
        limpiar()
        CargarTemHum()

    End Sub

    Private Sub cargarlista()
        Dim r As New dRgLab31
        Dim lista As New ArrayList
        lista = r.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each r In lista
                    DataGridView1(columna, fila).Value = r.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FICHA
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub cargarCombos()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboOperador.Items.Add(u)
                    ComboEliminado.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAnalisis()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboAnalisis.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        _hora = Now.ToString("HH:mm")
        TextId.Text = ""
        DateFecha.Value = Now
        TextHora.Text = _hora
        ComboEquipo.Text = "Bentley"
        TextFicha.Text = ""
        TextCantidad.Text = ""
        ComboAnalisis.Text = ""
        CheckRC.Checked = False
        CheckComposicion.Checked = False
        CheckUrea.Checked = False
        CheckRB.Checked = False
        CheckRC2.Checked = False
        CheckComposicion2.Checked = False
        CheckCrioscopia.Checked = False
        CheckCrioscopo.Checked = False
        CheckInhibidores.Checked = False
        CheckEsporulados.Checked = False
        CheckUrea2.Checked = False
        CheckTermofilos.Checked = False
        CheckPsicrotrofos.Checked = False
        CheckCaseina.Checked = False
        ComboOperador.SelectedItem = Usuario.ID
        ComboOperador.Text = Usuario.NOMBRE
        TextTemperatura.Text = ""
        TextHumedad.Text = ""
        ComboOperador.SelectedItem = Usuario.ID
        ComboEliminado.Text = Usuario.NOMBRE
        TextObservaciones.Text = ""
        ComboEquipo.Select()
    End Sub
    Public Sub limpiar2()
        CheckRC.Checked = False
        CheckComposicion.Checked = False
        CheckUrea.Checked = False
        CheckRB.Checked = False
        CheckRC2.Checked = False
        CheckComposicion2.Checked = False
        CheckCrioscopia.Checked = False
        CheckCrioscopo.Checked = False
        CheckInhibidores.Checked = False
        CheckEsporulados.Checked = False
        CheckUrea2.Checked = False
        CheckTermofilos.Checked = False
        CheckPsicrotrofos.Checked = False
        CheckCaseina.Checked = False
        
    End Sub
    Private Sub buscarregistros()
        _hora = Now.ToString("HH:mm")
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        Dim hora As Integer = 0
        fec = Format(fecha, "yyyy-MM-dd")
        Dim ra As New dRegistrosAmbientales
        ra = ra.buscarultimofq
        If Not ra Is Nothing Then
            If ra.FECHA = fecha Then
                hora = Mid(ra.HORA, 1, 2)
                If hora > 12 Then
                    TextTemperatura.Text = ""
                    TextHumedad.Text = ""
                Else
                    TextTemperatura.Text = ra.TEMPERATURA
                    TextHumedad.Text = ra.HUMEDAD
                End If
            Else
                TextTemperatura.Text = ""
                TextHumedad.Text = ""
            End If
        Else
            TextTemperatura.Text = ""
            TextHumedad.Text = ""
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim r As New dRgLab31
                Dim id As Long = CType(TextId.Text, Long)
                r.ID = id
                If (r.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim modifica As Integer = 0
        If TextFicha.Text <> "" Then
            Dim f As Long = TextFicha.Text
            Dim r31 As New dRgLab31
            r31.FICHA = f
            r31 = r31.buscarxficha
            If Not r31 Is Nothing Then
                modifica = 1
                TextId.Text = r31.ID
            End If
        End If
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim hora As String = TextHora.Text.Trim
        Dim equipo As String = ComboEquipo.Text
        Dim ficha As Long = TextFicha.Text.Trim
        Dim cantidad As Double = TextCantidad.Text
        Dim idtipoinforme As dTipoInforme = CType(ComboAnalisis.SelectedItem, dTipoInforme)
        Dim operador As dUsuario = CType(ComboOperador.SelectedItem, dUsuario)
        Dim temperatura As Double = TextTemperatura.Text.Trim
        Dim humedad As Double = TextHumedad.Text.Trim
        Dim eliminado As dUsuario = CType(ComboEliminado.SelectedItem, dUsuario)
        Dim observaciones As String = TextObservaciones.Text
       
        If modifica = 1 Then
            Dim r As New dRgLab31()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            r.FECHA = fec
            r.HORA = hora
            r.EQUIPO = equipo
            r.FICHA = ficha
            r.CANTIDAD = cantidad
            If Not idtipoinforme Is Nothing Then
                r.IDTIPOINFORME = idtipoinforme.ID
            Else
                MsgBox("Falta ingresar el tipo de análisis")
                ComboOperador.Focus()
                Exit Sub
            End If
            If Not operador Is Nothing Then
                r.OPERADOR = operador.ID
            Else
                MsgBox("Falta ingresar el operador")
                ComboOperador.Focus()
                Exit Sub
            End If
            r.TEMPERATURA = temperatura
            r.HUMEDAD = humedad
            If Not eliminado Is Nothing Then
                r.ELIMINADO = eliminado.ID
            Else
                MsgBox("Falta ingresar la persona que elimina las muestras")
                ComboEliminado.Focus()
                Exit Sub
            End If
            r.OBSERVACIONES = observaciones
            If (r.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim r As New dRgLab31()
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            r.FECHA = fec
            r.HORA = hora
            r.EQUIPO = equipo
            r.FICHA = ficha
            r.CANTIDAD = cantidad
            If Not idtipoinforme Is Nothing Then
                r.IDTIPOINFORME = idtipoinforme.ID
            Else
                MsgBox("Falta ingresar el tipo de análisis")
                ComboOperador.Focus()
                Exit Sub
            End If
            If Not operador Is Nothing Then
                r.OPERADOR = operador.ID
            Else
                MsgBox("Falta ingresar el operador")
                ComboOperador.Focus()
                Exit Sub
            End If
            r.TEMPERATURA = temperatura
            r.HUMEDAD = humedad
            If Not eliminado Is Nothing Then
                r.ELIMINADO = eliminado.ID
            Else
                MsgBox("Falta ingresar la persona que elimina las muestras")
                ComboEliminado.Focus()
                Exit Sub
            End If
            r.OBSERVACIONES = observaciones
            If (r.guardar(Usuario)) Then
                Dim ra As New dRegistrosAmbientales
                ra.SECTOR = "fq"
                ra.FECHA = fec
                ra.HORA = hora
                ra.TEMPERATURA = temperatura
                ra.HUMEDAD = humedad
                ra.guardar(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
        limpiar()
    End Sub

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            limpiar2()
            Dim sa As New dSolicitudAnalisis
            Dim csm As New dCalidadSolicitudMuestra
            Dim cs As New dControlSolicitud
            Dim listacsm As New ArrayList
            Dim listacs As New ArrayList
            Dim rc As Integer = 0
            Dim compos As Integer = 0
            Dim urea As Integer = 0
            Dim rb As Integer = 0
            Dim rc2 As Integer = 0
            Dim compos2 As Integer = 0
            Dim crioscopia As Integer = 0
            Dim crioscopo As Integer = 0
            Dim inhibidores As Integer = 0
            Dim esporulados As Integer = 0
            Dim urea2 As Integer = 0
            Dim termofilos As Integer = 0
            Dim psicrotrofos As Integer = 0
            Dim caseina As Integer = 0

            Dim ficha As Long = 0
            Dim tinf As Integer = 0
            Dim cantidad As Integer = 0
            Dim obs As String = ""
            ficha = TextFicha.Text
            sa.ID = ficha
            sa = sa.buscar
            If Not sa Is Nothing Then
                tinf = sa.IDTIPOINFORME
                cantidad = sa.NMUESTRAS
                obs = sa.OBSERVACIONES
            End If
            csm.ficha = ficha
            csm = csm.buscarxsolicitud
            cs.FICHA = ficha
            cs = cs.buscar

            ComboAnalisis.SelectedItem = Nothing
            Dim ti As New dTipoInforme
            For Each ti In ComboAnalisis.Items
                If ti.ID = tinf Then
                    ComboAnalisis.SelectedItem = ti
                    Exit For
                End If
            Next

            If Not csm Is Nothing Then
                listacsm = csm.listarporsolicitud(ficha)
                If Not listacsm Is Nothing Then
                    If listacsm.Count > 0 Then
                        For Each csm In listacsm
                            If csm.RB = 1 Then
                                rb = 1
                            End If
                            If csm.RC = 1 Then
                                rc2 = 1
                            End If
                            If csm.COMPOSICION = 1 Then
                                compos2 = 1
                            End If
                            If csm.CRIOSCOPIA = 1 Then
                                crioscopia = 1
                            End If
                            If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                                crioscopo = 1
                            End If
                            If csm.INHIBIDORES = 1 Then
                                inhibidores = 1
                            End If
                            If csm.ESPORULADOS = 1 Then
                                esporulados = 1
                            End If
                            If csm.UREA = 1 Then
                                urea2 = 1
                            End If
                            If csm.TERMOFILOS = 1 Then
                                termofilos = 1
                            End If
                            If csm.PSICROTROFOS = 1 Then
                                psicrotrofos = 1
                            End If
                            If csm.CASEINA = 1 Then
                                caseina = 1
                            End If
                        Next
                    End If
                End If
            End If

            If Not cs Is Nothing Then
                listacs = cs.listarporsolicitud(ficha)
                If Not listacs Is Nothing Then
                    If listacs.Count > 0 Then
                        For Each cs In listacs
                            If cs.RC = 1 Then
                                rc = 1
                            End If
                            If cs.COMPOSICION = 1 Then
                                compos = 1
                            End If
                            If cs.UREA = 1 Then
                                urea = 1
                            End If
                        Next
                    End If
                End If
            End If

            If rc = 1 Then
                CheckRC.Checked = True
            End If
            If compos = 1 Then
                CheckComposicion.Checked = True
            End If
            If urea = 1 Then
                CheckUrea.Checked = True
            End If
            If rb = 1 Then
                CheckRB.Checked = True
            End If
            If rc2 = 1 Then
                CheckRC2.Checked = True
            End If
            If compos2 = 1 Then
                CheckComposicion2.Checked = True
            End If
            If crioscopia = 1 Then
                CheckCrioscopia.Checked = True
            End If
            If crioscopo = 1 Then
                CheckCrioscopo.Checked = True
            End If
            If inhibidores = 1 Then
                CheckInhibidores.Checked = True
            End If
            If esporulados = 1 Then
                CheckEsporulados.Checked = True
            End If
            If urea2 = 1 Then
                CheckUrea2.Checked = True
            End If
            If termofilos = 1 Then
                CheckTermofilos.Checked = True
            End If
            If psicrotrofos = 1 Then
                CheckPsicrotrofos.Checked = True
            End If
            If caseina = 1 Then
                CheckCaseina.Checked = True
            End If

            ComboOperador.SelectedItem = Nothing
            ComboEliminado.SelectedItem = Nothing
            Dim usu As New dUsuario
            For Each usu In ComboOperador.Items
                If usu.ID = Usuario.ID Then
                    ComboOperador.SelectedItem = usu
                    ComboEliminado.SelectedItem = usu
                    ComboOperador.Text = usu.NOMBRE
                    ComboEliminado.Text = usu.NOMBRE
                    Exit For
                End If
            Next

            TextCantidad.Text = cantidad
            TextObservaciones.Text = obs
            buscarregistros()
            TextTemperatura.Focus()
        End If
    End Sub

   
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab31
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                ComboEquipo.Text = r.EQUIPO
                TextFicha.Text = r.FICHA
                TextCantidad.Text = r.CANTIDAD
                ComboAnalisis.SelectedItem = Nothing
                Dim ti As New dTipoInforme
                For Each ti In ComboAnalisis.Items
                    If ti.ID = r.IDTIPOINFORME Then
                        ComboAnalisis.SelectedItem = ti
                        Exit For
                    End If
                Next

                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        ComboOperador.Text = op.NOMBRE
                        Exit For
                    End If
                Next

                TextTemperatura.Text = r.TEMPERATURA
                TextHumedad.Text = r.HUMEDAD

                Dim us As New dUsuario
                For Each us In ComboEliminado.Items
                    If us.ID = r.ELIMINADO Then
                        ComboEliminado.SelectedItem = us
                        ComboEliminado.Text = us.NOMBRE
                        Exit For
                    End If
                Next

                TextObservaciones.Text = r.OBSERVACIONES
                cargarchecks()
            End If
        End If

        If DataGridView1.Columns(e.ColumnIndex).Name = "Ficha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab31
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                ComboEquipo.Text = r.EQUIPO
                TextFicha.Text = r.FICHA
                TextCantidad.Text = r.CANTIDAD
                ComboAnalisis.SelectedItem = Nothing
                Dim ti As New dTipoInforme
                For Each ti In ComboAnalisis.Items
                    If ti.ID = r.IDTIPOINFORME Then
                        ComboAnalisis.SelectedItem = ti
                        Exit For
                    End If
                Next

                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        Exit For
                    End If
                Next

                TextTemperatura.Text = r.TEMPERATURA
                TextHumedad.Text = r.HUMEDAD

                Dim us As New dUsuario
                For Each us In ComboEliminado.Items
                    If us.ID = r.ELIMINADO Then
                        ComboEliminado.SelectedItem = us
                        Exit For
                    End If
                Next

                TextObservaciones.Text = r.OBSERVACIONES
                cargarchecks()
            End If
        End If
    End Sub

    Private Sub TextFicha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFicha.TextChanged

    End Sub
    Private Sub cargarchecks()
        limpiar2()

        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim listacsm As New ArrayList
        Dim listacs As New ArrayList
        Dim rc As Integer = 0
        Dim compos As Integer = 0
        Dim urea As Integer = 0
        Dim rb As Integer = 0
        Dim rc2 As Integer = 0
        Dim compos2 As Integer = 0
        Dim crioscopia As Integer = 0
        Dim crioscopo As Integer = 0
        Dim inhibidores As Integer = 0
        Dim esporulados As Integer = 0
        Dim urea2 As Integer = 0
        Dim termofilos As Integer = 0
        Dim psicrotrofos As Integer = 0
        Dim caseina As Integer = 0

        Dim ficha As Long = 0
        ficha = TextFicha.Text
        
        csm.ficha = ficha
        csm = csm.buscarxsolicitud
        cs.FICHA = ficha
        cs = cs.buscar

        If Not csm Is Nothing Then
            listacsm = csm.listarporsolicitud(ficha)
            If Not listacsm Is Nothing Then
                If listacsm.Count > 0 Then
                    For Each csm In listacsm
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc2 = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            compos2 = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            crioscopia = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inhibidores = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            esporulados = 1
                        End If
                        If csm.UREA = 1 Then
                            urea2 = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            termofilos = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicrotrofos = 1
                        End If
                        If csm.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next
                End If
            End If
        End If

        If Not cs Is Nothing Then
            listacs = cs.listarporsolicitud(ficha)
            If Not listacs Is Nothing Then
                If listacs.Count > 0 Then
                    For Each cs In listacs
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            compos = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next
                End If
            End If
        End If

        If rc = 1 Then
            CheckRC.Checked = True
        End If
        If compos = 1 Then
            CheckComposicion.Checked = True
        End If
        If urea = 1 Then
            CheckUrea.Checked = True
        End If
        If rb = 1 Then
            CheckRB.Checked = True
        End If
        If rc2 = 1 Then
            CheckRC2.Checked = True
        End If
        If compos2 = 1 Then
            CheckComposicion2.Checked = True
        End If
        If crioscopia = 1 Then
            CheckCrioscopia.Checked = True
        End If
        If crioscopo = 1 Then
            CheckCrioscopo.Checked = True
        End If
        If inhibidores = 1 Then
            CheckInhibidores.Checked = True
        End If
        If esporulados = 1 Then
            CheckEsporulados.Checked = True
        End If
        If urea2 = 1 Then
            CheckUrea2.Checked = True
        End If
        If termofilos = 1 Then
            CheckTermofilos.Checked = True
        End If
        If psicrotrofos = 1 Then
            CheckPsicrotrofos.Checked = True
        End If
        If caseina = 1 Then
            CheckCaseina.Checked = True
        End If
    End Sub
    Private Sub actualizarhora()
        _hora = Now.ToString("HH:mm")
        TextHora.Text = _hora
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        actualizarhora()
    End Sub

    Private Sub CargarTemHum()
        Dim fecha As DateTime = Now.ToString("dd/MM/yyyy")
        Dim r31 As New dRgLab31
        r31 = r31.buscarFichaDeHoy
        If Not r31 Is Nothing Then
            If r31.FECHA = fecha Then
                If IsNumeric(r31.HUMEDAD) Then
                    TextTemperatura.Text = r31.TEMPERATURA
                    TextHumedad.Text = r31.HUMEDAD
                End If
            End If
        End If
    End Sub

End Class