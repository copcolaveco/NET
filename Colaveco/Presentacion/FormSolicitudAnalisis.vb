Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormSolicitudAnalisis
    Private productorweb_com As String
    Private productorweb_uy As String
    Private idproductorweb_com As Long
    Private idproductorweb_uy As Long
    Private idficha As String
    Private tipoinforme As String
    Private _usuario As dUsuario
    Private email As String
    Private celular As String
    Private nficha As String

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property


#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarComboInformes()
        cargarComboSubInformes()
        cargarComboTecnicos()
        cargarComboTipoFicha()
        cargarComboMuestras()
        cargarComboAgencia()
        limpiar()
        buscarultimaficha()
    End Sub
#End Region
    Private Sub buscarultimaficha()
        Dim ultimaf As New dUltimoNumero
        ultimaf = ultimaf.buscar
        TextId.Text = ultimaf.FICHAS + 1
    End Sub
    Public Sub cargarComboTecnicos()
        Dim t As New dTecnicos
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTecnico.Items.Add(t)
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
                    ComboTipoInforme.Items.Add(ti)
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
                    ComboSubInforme.Items.Add(si)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboMuestras()
        Dim m As New dMuestras
        Dim lista As New ArrayList
        lista = m.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ComboMuestra.Items.Add(m)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTipoFicha()
        Dim tf As New dTipoFicha
        Dim lista As New ArrayList
        lista = tf.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each tf In lista
                    ComboTipoFicha.Items.Add(tf)
                Next
            End If
        End If
        ComboTipoFicha.SelectedIndex = 0
    End Sub
    Private Sub ButtonBuscarProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        productorweb_com = ""
        'productorweb_uy = ""

        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            productorweb_com = pro.USUARIO_WEB
            'productorweb_uy = pro.USUARIO_WEB
            Dim pw_com As New dProductorWeb_com
            'Dim pw_uy As New dProductorWeb_uy
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            If Not pw_com Is Nothing Then
                idproductorweb_com = pw_com.ID
                email = RTrim(pw_com.ENVIAR_EMAIL)
                celular = Replace(pw_com.ENVIAR_SMS, " ", "")
                'celular = Trim(pw_com.ENVIAR_SMS)
            Else
                MsgBox("No coincide el usuario web (.com)")
                'comentado por error en la web
                'Exit Sub
            End If
            'pw_uy.USUARIO = productorweb_uy
            'pw_uy = pw_uy.buscar
            'If Not pw_uy Is Nothing Then
            'idproductorweb_uy = pw_uy.ID
            'Else
            'MsgBox("No coincide el usuario web del (.uy)")
            'Exit Sub
            'End If
            If pro.CONTRATO = 0 Then
                MsgBox("El cliente no tiene contrato firmado.")

            End If
            If pro.MOROSO = 1 Then
                MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
                TextIdProductor.Text = ""
                TextProductor.Text = ""
                TextDicose.Text = ""
                ComboTecnico.SelectedItem = Nothing
                Exit Sub
            End If
            TextIdProductor.Text = pro.ID
            TextProductor.Text = pro.NOMBRE
            TextDicose.Text = pro.DICOSE
            ComboTecnico.SelectedItem = Nothing
            Dim t As dTecnicos
            For Each t In ComboTecnico.Items
                If t.ID = pro.TECNICO Then
                    ComboTecnico.SelectedItem = t
                    Exit For
                End If
            Next
            ComboTipoInforme.Focus()
        End If
        guardar()
        'listarultimoid()
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click

        InsertarRegistro_com()

        'InsertarRegistro_uy()

        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        'If ListMuestras.Items.Count = 0 Then MsgBox("No se han ingresado identificaciones de muestras", MsgBoxStyle.Exclamation, "Atención") : TextMuestras.Focus() : Exit Sub
        Dim id As Long = TextId.Text.Trim
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim idtipoficha As dTipoFicha = CType(ComboTipoFicha.SelectedItem, dTipoFicha)
        Dim observaciones As String = TextObservaciones.Text.Trim
        If aguaclorada = 1 Then
            observaciones = observaciones & " - *** CLORADA ***"
            If observaciones <> "" Then
                TextObservaciones.Text = observaciones
            End If
            aguaclorada = 0
        End If
        Dim nmuestras As Integer
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        End If
        Dim idmuestra As dMuestras = CType(ComboMuestra.SelectedItem, dMuestras)
        Dim idtecnico As dTecnicos = CType(ComboTecnico.SelectedItem, dTecnicos)
        Dim sinsolicitud As Integer
        If CheckSinSolicitud.Checked = True Then
            sinsolicitud = 1
        Else
            sinsolicitud = 0
        End If
        Dim sinconservante As Integer
        If CheckSinConservante.Checked = True Then
            sinconservante = 1
        Else
            sinconservante = 0
        End If
        Dim temperatura As Double
        If TextTemperatura.Text <> "" Then
            temperatura = TextTemperatura.Text.Trim
        End If
        Dim derramadas As Integer
        If CheckDerramadas.Checked = True Then
            derramadas = 1
        Else
            derramadas = 0
        End If
        Dim desvioautorizado As Integer
        If CheckDesvio.Checked = True Then
            desvioautorizado = 1
        Else
            desvioautorizado = 0
        End If
        Dim idfactura As Long
        If TextIdFactura.Text <> "" Then
            idfactura = TextIdFactura.Text.Trim
        End If
        Dim web As Integer
        If CheckWeb.Checked = True Then
            web = 1
        Else
            web = 0
        End If
        Dim personal As Integer
        If CheckPersonal.Checked = True Then
            personal = 1
        Else
            personal = 0
        End If
        Dim mail As Integer
        If CheckEmail.Checked = True Then
            mail = 1
        Else
            mail = 0
        End If
        Dim fechaenvio As Date = DateFechaEnvio.Value.ToString("yyyy-MM-dd")
        Dim ultimaficha As Long = TextId.Text.Trim
        Dim sm As New dRelSolicitudMuestras
        sm.IDSOLICITUD = id
        sm = sm.buscar
        If tipoinforme = "Calidad de leche" Or tipoinforme = "Control Lechero" Or tipoinforme = "PAL" Or tipoinforme = "Serología" Or tipoinforme = "Agro Nutrición" Or tipoinforme = "Agro Suelos" Then
        Else

            If Not sm Is Nothing Then
            Else
                MsgBox("No se han ingresado muestras", MsgBoxStyle.Exclamation, "Atención") : TextMuestras.Focus() : Exit Sub
            End If
        End If

        If TextId.Text.Trim.Length > 0 Then
            Dim sol As New dSolicitudAnalisis()
            Dim un As New dUltimoNumero
            un = un.buscar
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fecing As String
            Dim fecenv As String
            fecing = Format(fechaingreso, "yyyy-MM-dd")
            fecenv = Format(fechaenvio, "yyyy-MM-dd")
            sol.ID = id
            sol.FECHAINGRESO = fecing
            sol.IDPRODUCTOR = idproductor
            If Not idtipoinforme Is Nothing Then
                sol.IDTIPOINFORME = idtipoinforme.ID
            End If
            If Not idsubinforme Is Nothing Then
                sol.IDSUBINFORME = idsubinforme.ID
            End If
            If Not idtipoficha Is Nothing Then
                sol.IDTIPOFICHA = idtipoficha.ID
            End If
            sol.OBSERVACIONES = observaciones
            sol.NMUESTRAS = nmuestras
            If Not idmuestra Is Nothing Then
                sol.IDMUESTRA = idmuestra.ID
            End If
            If Not idtecnico Is Nothing Then
                sol.IDTECNICO = idtecnico.ID
            End If
            sol.SINCOLICITUD = sinsolicitud
            sol.SINCONSERVANTE = sinconservante
            sol.TEMPERATURA = temperatura
            sol.DERRAMADAS = derramadas
            sol.DESVIOAUTORIZADO = desvioautorizado
            sol.IDFACTURA = idfactura
            sol.WEB = web
            sol.PERSONAL = personal
            sol.EMAIL = mail
            sol.FECHAENVIO = fecenv

            If (sol.modificar(Usuario)) Then
                If ultimaficha > un.FICHAS Then
                    un.FICHAS = ultimaficha
                    un.modificar()
                End If
                MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                enviomail()
                enviosms()
                imprimir_solicitud()
                Dim result2 = MessageBox.Show("Desea imprimir un ticket para el cliente?", "Atención!", MessageBoxButtons.YesNoCancel)
                If result2 = DialogResult.Cancel Then
                    imprimir_ticket()
                ElseIf result2 = DialogResult.No Then
                    imprimir_ticket()
                ElseIf result2 = DialogResult.Yes Then
                    imprimir_ticket_cliente()
                End If

                If idsubinforme.ID = 22 Then
                    Dim r As New dRosaBengalaDescarte
                    r.FICHA = id
                    r.FECHA = fecing
                    r.DESCARTADA = 0
                    r.FECHAD = fecing
                    r.MARCADA = 0
                    r.FECHAM = fecing
                    r.guardar(Usuario)
                End If

                If idproductor = 4870 Then
                    Dim result = MessageBox.Show("Enviar e-mail a PULSA S.A. con la solicitud de análisis? (Antes de enviar debe cerrar excel)", "Atención!", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Cancel Then

                    ElseIf result = DialogResult.No Then

                    ElseIf result = DialogResult.Yes Then
                        enviomailpulsa()
                    End If
                End If
                limpiar()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim sol As New dSolicitudAnalisis()
                Dim un As New dUltimoNumero
                un = un.buscar
                Dim fecing As String
                Dim fecenv As String
                fecing = Format(fechaingreso, "yyyy-MM-dd")
                fecenv = Format(fechaenvio, "yyyy-MM-dd")
                sol.ID = id
                sol.FECHAINGRESO = fecing
                sol.IDPRODUCTOR = idproductor
                If Not idtipoinforme Is Nothing Then
                    sol.IDTIPOINFORME = idtipoinforme.ID
                End If
                If Not idsubinforme Is Nothing Then
                    sol.IDSUBINFORME = idsubinforme.ID
                End If
                If Not idtipoficha Is Nothing Then
                    sol.IDTIPOFICHA = idtipoficha.ID
                End If
                sol.OBSERVACIONES = observaciones
                sol.NMUESTRAS = nmuestras
                If Not idtecnico Is Nothing Then
                    sol.IDTECNICO = idtecnico.ID
                End If
                sol.SINCOLICITUD = sinsolicitud
                sol.SINCONSERVANTE = sinconservante
                sol.TEMPERATURA = temperatura
                sol.DERRAMADAS = derramadas
                sol.DESVIOAUTORIZADO = desvioautorizado
                sol.IDFACTURA = idfactura
                sol.WEB = web
                sol.PERSONAL = personal
                sol.EMAIL = mail
                sol.FECHAENVIO = fecenv
                If (sol.guardar(Usuario)) Then
                    If ultimaficha > un.FICHAS Then
                        un.FICHAS = ultimaficha
                        un.modificar()
                    End If
                    MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    enviomail()
                    enviosms()
                    imprimir_solicitud()
                    Dim result3 = MessageBox.Show("Desea imprimir un ticket para el cliente?", "Atención!", MessageBoxButtons.YesNoCancel)
                    If result3 = DialogResult.Cancel Then
                        imprimir_ticket()
                    ElseIf result3 = DialogResult.No Then
                        imprimir_ticket()
                    ElseIf result3 = DialogResult.Yes Then
                        imprimir_ticket_cliente()
                    End If
                    If idsubinforme.ID = 22 Then
                        Dim r As New dRosaBengalaDescarte
                        r.FICHA = id
                        r.FECHA = fecing
                        r.DESCARTADA = 0
                        r.FECHAD = fecing
                        r.MARCADA = 0
                        r.FECHAM = fecing
                        r.guardar(Usuario)
                    End If
                    limpiar()
                    limpiar2()

                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        'cargarLista()


        'Dim result2 = MessageBox.Show("Desea imprimir un ticket para el cliente?", "Atención!", MessageBoxButtons.YesNoCancel)
        'If result2 = DialogResult.Cancel Then

        'ElseIf result2 = DialogResult.No Then

        'ElseIf result2 = DialogResult.Yes Then
        '    imprimir_ticket()
        'End If

        
        Me.Close()

    End Sub
    Private Sub imprimir_ticket()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As String
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = ""
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
       

        'Poner Titulos
        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)
        'Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 100, 40)

        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim

        Dim fila = 3
        Dim columna = 1
       
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        Dim pro As New dProductor
        Dim nombre_productor As String = ""
        pro.ID = TextIdProductor.Text.Trim
        pro = pro.buscar
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
      
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
    

        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Prodúctos Lácteos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()

            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDYPH = 1 Then
                texto = texto & " " & " - Conductividad y pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If

            If texto.Length > 0 Then

                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                    Next

                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next

                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next

                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)

            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                    Next

                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)

            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Agro Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Agro Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A9", "G10").Merge()
            x1hoja.Range("A9", "G10").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************
      


        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        '*** LISTADO DE MUESTRAS *********************************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************

        If tipoinforme = "Prodúctos Lácteos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5


            ' SI ES AGUA ********************************************************************************

        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES CALIDAD ********************************************************************************

        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA

                        If csm.RB = 1 Then

                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then

                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then

                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then

                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then

                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.ESPORULADOS = 1 Then

                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then

                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then

                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then

                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then

                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then

                            cuenta_caseina = cuenta_caseina + 1
                        End If

                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G16").Merge()
            x1hoja.Range("A13", "G16").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9

            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If

            fila = fila + 4

            'x1hoja.Range("A27", "G28").Merge()
            'x1hoja.Range("A27", "G28").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9

            fila = fila + 1



            ' SI ES CONTROL LECHERO ********************************************************************************

        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES ANTIBIOGRAMA ********************************************************************************

        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES AMBIENTAL ********************************************************************************

        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PARASITOLOGÍA ********************************************************************************

        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PAL ********************************************************************************

        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            Dim solpal As New dSolicitudPAL
            solpal.IDSOLICITUD = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If

            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************

        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Agro Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Agro Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
       
        x1hoja.Cells(fila, columna).formula = "En nuestro sitio web www.colaveco.com.uy, puede ver el estado de su solicitud."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Email: colaveco@gmail.com - web: www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo,"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True

        ' SEGUNDA COPIA *************************************************************************************************************************************
        fila = fila + 4
        columna = 1

        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1



        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Prodúctos Lácteos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()

            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDYPH = 1 Then
                texto = texto & " " & " - Conductividad y pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If

            If texto.Length > 0 Then

                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                    Next

                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next

                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next

                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)

            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                    Next

                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)

            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Agro Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Agro Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A36", "G37").Merge()
            x1hoja.Range("A36", "G37").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************



        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        '*** LISTADO DE MUESTRAS *********************************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************

        If tipoinforme = "Prodúctos Lácteos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5


            ' SI ES AGUA ********************************************************************************

        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES CALIDAD ********************************************************************************

        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA

                        If csm.RB = 1 Then

                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then

                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then

                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then

                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then

                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.ESPORULADOS = 1 Then

                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then

                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then

                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then

                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then

                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then

                            cuenta_caseina = cuenta_caseina + 1
                        End If

                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G43").Merge()
            x1hoja.Range("A40", "G43").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9

            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If

            fila = fila + 4

            'x1hoja.Range("A45", "G46").Merge()
            'x1hoja.Range("A45", "G46").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9

            fila = fila + 1



            ' SI ES CONTROL LECHERO ********************************************************************************

        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES ANTIBIOGRAMA ********************************************************************************

        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES AMBIENTAL ********************************************************************************

        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PARASITOLOGÍA ********************************************************************************

        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PAL ********************************************************************************

        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            Dim solpal As New dSolicitudPAL
            solpal.IDSOLICITUD = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If

            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************

        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Agro Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Agro Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2

        x1hoja.Cells(fila, columna).formula = "En nuestro sitio web www.colaveco.com.uy, puede ver el estado de su solicitud."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Email: colaveco@gmail.com - web: www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo,"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True

        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "FIRMA DEL CLIENTE: ________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
      

        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\TICKET_CLIENTES\TC" & ficha & ".xls")

        'x1app.Visible = True
        'x1libro.PrintPreview()

        'x1hoja.PrintOut()
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimir_solicitud()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As Integer
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = 0
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        If CheckSinSolicitud.Checked = True Then
            solicitud = "No"
        Else
            solicitud = "Si"
        End If
        Dim conservante As String = ""
        If CheckSinConservante.Checked = True Then
            conservante = "No"
        Else
            conservante = "Si"
        End If
        Dim temperatura As String = TextTemperatura.Text
        Dim derramadas As String = ""
        If CheckDerramadas.Checked = True Then
            derramadas = "Si"
        Else
            derramadas = "No"
        End If
        Dim desvio As String = ""
        If CheckDesvio.Checked = True Then
            desvio = "Si"
        Else
            desvio = "No"
        End If
        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim

        Dim fila = 1
        Dim columna = 1
        x1hoja.Cells(fila, columna).formula = Now
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = columna + 3
        x1hoja.Cells(fila, columna).formula = "RG.ADM.36"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Versión 02 del 30/12/14"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 2

        '************************************************************************
        x1hoja.Cells(fila, columna).formula = "*" & TextId.Text & "*"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Name = "Bar-Code 39"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 20
        columna = 1
        '************************************************************************

        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha de ingreso:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Control de Recepción de Muestras:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Solicitud:" & " " & solicitud
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 3
        Dim sc As New dRelSolicitudCajas
        Dim so As New dRelSolicitudOtros
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        lista2 = sc.listarporficha(ficha)
        lista3 = so.listarporficha(ficha)
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
        If Not lista2 Is Nothing Then
            For Each sc In lista2
                cajas = cajas + Format$(sc.IDCAJA) & " - "
                If sc.GRADILLA1 <> 0 Then
                    gradillas = gradillas + Format$(sc.GRADILLA1) & " - "
                End If
                If sc.GRADILLA2 <> 0 Then
                    gradillas = gradillas + Format$(sc.GRADILLA2) & " - "
                End If
                If sc.GRADILLA3 <> 0 Then
                    gradillas = gradillas + Format$(sc.GRADILLA3) & " - "
                End If
            Next
        End If
        If Not lista3 Is Nothing Then
            For Each so In lista3
                otros = otros + so.DESCRIPCION & " "
            Next
        End If
        x1hoja.Range("D9", "G10").Merge()
        x1hoja.Range("D9", "G10").WrapText = True
        x1hoja.Cells(fila, columna).formula = "Caja/s nº:" & " " & cajas
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Conservante:" & " " & conservante
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 3
        fila = fila + 1
        x1hoja.Range("D11", "G14").Merge()
        x1hoja.Range("D11", "G14").WrapText = True
        x1hoja.Cells(fila, columna).formula = "Gradillas nº:" & " " & gradillas
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        'fila = fila + 3
        x1hoja.Cells(fila, columna).formula = "Temperatura:" & " " & temperatura
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 3
        fila = fila + 4
        x1hoja.Cells(fila, columna).formula = "Otros:" & " " & otros
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1

        fila = fila - 3
        x1hoja.Cells(fila, columna).formula = "Derramadas en el envío:" & " " & derramadas
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Desvío autorizado por el cliente:" & " " & desvio
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 3
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Solicitud: Tipo de informe:" & " " & tipoinforme & " - " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Prodúctos Lácteos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + "Estaf. Coag. Positivo ____/____/____ "
                        End If
                        If sp.CF = 1 Then
                            texto = texto + "CF ____/____/____ "
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + "Mohos y levaduras ____/____/____ "
                        End If
                        If sp.CT = 1 Then
                            texto = texto + "CT ____/____/____ "
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + "E. Coli ____/____/____ "
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + "Salmonella ____/____/____ "
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + "Listeria SPP ____/____/____ "
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + "Humedad ____/____/____ "
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + "M. Grasa ____/____/____ "
                        End If
                        If sp.PH = 1 Then
                            texto = texto + "pH ____/____/____ "
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + "Cloruros ____/____/____ "
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + "Proteínas ____/____/____ "
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + "Enterobacterias ____/____/____ "
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + "Listeria Ambiental ____/____/____ "
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + "Espor. Anaer. Mesófilos ____/____/____ "
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + "Termodúricos ____/____/____ "
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + "Psicrótrofos ____/____/____ "
                        End If
                        If sp.RB = 1 Then
                            texto = texto + "RB ____/____/____ "
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + "Tabla nutricional ____/____/____ "
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + "Listeria monocitógenes ____/____/____ "
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + "Cenizas ____/____/____ "
                        End If
                    Next
                End If
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If

        ' SI ES AGUA ********************************************************************************
        If tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()

            texto = ComboSubInforme.Text & " "
            If a1.HET22 = 1 Then
                texto = texto & " " & "+ Heterotróficos 22 ____/____/____ "
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & "+ Heterotróficos 35 ____/____/____ "
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & "+ Heterotróficos 37 ____/____/____ "
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & "+ Cloro ____/____/____ "
            End If
            If a1.CONDYPH = 1 Then
                texto = texto & " " & "+ Conductividad y pH ____/____/____ "
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & "+ Ecoli ____/____/____ "
            End If

            If texto.Length > 0 Then

                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ES CALIDAD DE LECHE ********************************************************************************
        If tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            Dim caseina As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next

                End If
            End If
            If rb = 1 Then
                texto = texto + "RB ____/____/____ "
            End If
            If rc = 1 Then
                texto = texto + "RC ____/____/____ "
            End If
            If comp = 1 Then
                texto = texto + "Composición ____/____/____ "
            End If
            If criosc = 1 Then
                texto = texto + "Crioscopía ____/____/____ "
            End If
            If inh = 1 Then
                texto = texto + "Inhibidores ____/____/____ "
            End If
            If espor = 1 Then
                texto = texto + "Esporulados ____/____/____ "
            End If
            If urea = 1 Then
                texto = texto + "Urea ____/____/____ "
            End If
            If term = 1 Then
                texto = texto + "Termófilos ____/____/____ "
            End If
            If psicr = 1 Then
                texto = texto + "Psicrótrofos ____/____/____ "
            End If
            If crioscopo = 1 Then
                texto = texto + "Crioscopía (crióscopo) ____/____/____ "
            End If
            If caseina = 1 Then
                texto = texto + "Caseína ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
           
        End If
        ' SI ES CONTROL LECHERO ********************************************************************************
        If tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next

                End If
            End If
            If rc = 1 Then
                texto = texto + "RC ____/____/____ "
            End If
            If comp = 1 Then
                texto = texto + "Composición ____/____/____ "
            End If
            If urea = 1 Then
                texto = texto + "Urea ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ANTIBIOGRAMA ********************************************************************************
        If tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next

                End If
            End If
            If aislamiento = 1 Then
                texto = texto + "Aislamiento ____/____/____ "
            End If
            If antibiograma = 1 Then
                texto = texto + "Antibiograma ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ES AMBIENTAL ********************************************************************************
        If tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)

            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                    Next

                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + "Enterobacterias ____/____/____ "
            End If
            If listambiental = 1 Then
                texto = texto + "Listeria ambiental ____/____/____ "
            End If
            If listmono = 1 Then
                texto = texto + "Listeria monocitógenes ____/____/____ "
            End If
            If salmonella = 1 Then
                texto = texto + "Salmonella ____/____/____ "
            End If
            If ecoli = 1 Then
                texto = texto + "E. Coli ____/____/____ "
            End If
            If mohosylevaduras = 1 Then
                texto = texto + "Mohos y levaduras ____/____/____ "
            End If
            If rb = 1 Then
                texto = texto + "RB ____/____/____ "
            End If
            If ct = 1 Then
                texto = texto + "CT ____/____/____ "
            End If
            If cf = 1 Then
                texto = texto + "CF ____/____/____ "
            End If
            If pseudomonaspp = 1 Then
                texto = texto + "Pseudomona SPP ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ES PARASITOLOGÍA ********************************************************************************
        If tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)

            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + "Gastrointestinales ____/____/____ "
            End If
            If fasciola = 1 Then
                texto = texto + "Fasciola ____/____/____ "
            End If
            If coccidias = 1 Then
                texto = texto + "Coccidias ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ES NUTRICIÓN ********************************************************************************
        If tipoinforme = "Agro Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                    Next

                End If
            End If
            
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If

        End If
        ' SI ES SUELOS ********************************************************************************
        If tipoinforme = "Agro Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Análisis completo - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Cultivos de verano - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Cultivos de invierno - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Cationes - "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                        If ss.ACIDEZTITULABLE = 1 Then
                            texto = texto & "Acidez titulable - "
                        End If
                        If ss.CIC = 1 Then
                            texto = texto & "CIC - "
                        End If
                        If ss.SB = 1 Then
                            texto = texto & "% SB - "
                        End If

                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If

        End If
        '***********************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Enviado:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Web: ░░ - Personal: ░░ - Email: ░░ - Fecha de envío: "
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Otro: "
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        texto2 = ""
        If tipoinforme = "Prodúctos Lácteos" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If

        ' SI ES AGUA ********************************************************************************
        texto2 = ""
        If tipoinforme = "Agua" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If
        ' SI ES CALIDAD ********************************************************************************
        texto2 = ""
        Dim cuenta_rb As Integer = 0
        Dim cuenta_rc As Integer = 0
        Dim cuenta_comp As Integer = 0
        Dim cuenta_criosc As Integer = 0
        Dim cuenta_inhib As Integer = 0
        Dim cuenta_espor As Integer = 0
        Dim cuenta_urea As Integer = 0
        Dim cuenta_termo As Integer = 0
        Dim cuenta_psicro As Integer = 0
        Dim cuenta_criosc_criosc As Integer = 0
        Dim cuenta_caseina As Integer = 0
        If tipoinforme = "Calidad de leche" Then
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        'texto2 = texto2 + " ("
                        If csm.RB = 1 Then
                            'texto2 = texto2 + "RB "
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            'texto2 = texto2 + "RC "
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            'texto2 = texto2 + "Comp. "
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            'texto2 = texto2 + "Criosc. "
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            'texto2 = texto2 + "Inhib. "
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            'texto2 = texto2 + "Espor. "
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            'texto2 = texto2 + "Urea "
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            'texto2 = texto2 + "Termof. "
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            'texto2 = texto2 + "Psicrot. "
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            'texto2 = texto2 + "Criosc.(Crioscopo) "
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            'texto2 = texto2 + "Caseina."
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        'texto2 = texto2 + ")- "
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G37").Merge()
            x1hoja.Range("A27", "G37").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9

            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If

            fila = fila + 11

            x1hoja.Range("A38", "G39").Merge()
            x1hoja.Range("A38", "G39").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9

            fila = fila + 2

            ' Agrega en la planilla excel las muestras con Rc alto
            'If rc_alto <> "" Then
            '    x1hoja.Range("A41", "G43").Merge()
            '    x1hoja.Range("A41", "G43").WrapText = True
            '    x1hoja.Cells(fila, columna).Formula = "Muestras con RC > 500.000 --> " & rc_alto
            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            '    x1hoja.Cells(fila, columna).Font.Bold = True
            '    x1hoja.Cells(fila, columna).Font.Size = 9
            '    fila = fila + 3
            '    rc_alto = ""
            'End If
        End If


        ' SI ES CONTROL LECHERO ********************************************************************************
        texto2 = ""
        If tipoinforme = "Control Lechero" Then

            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If
        ' SI ES ANTIBIOGRAMA ********************************************************************************
        texto2 = ""
        If tipoinforme = "Bacteriología y Antibiograma" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If
        ' SI ES AMBIENTAL ********************************************************************************
        texto2 = ""
        If tipoinforme = "Ambiental" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If
        ' SI ES PARASITOLOGÍA ********************************************************************************
        texto2 = ""
        If tipoinforme = "Parasitología" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 6
        End If
        ' SI ES PAL ********************************************************************************
        texto2 = ""
        If tipoinforme = "PAL" Then
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 7

            Dim solpal As New dSolicitudPAL
            solpal.IDSOLICITUD = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If
        End If
        '********************************************************************************************************************
        ' SI ES BRUCELOSIS LECHE ********************************************************************************
        texto2 = ""
        If tipoinforme = "Brucelosis en leche" Then
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10

        '*** Controla que el productor realiza cambio de caravanas **********************
        If tipoinforme = "Control Lechero" Then
            Dim sa As New dSolicitudAnalisis
            Dim caravanas As Integer = 0
            sa.ID = ficha
            sa = sa.buscar
            If Not sa Is Nothing Then
                Dim p As New dProductor
                p.ID = sa.IDPRODUCTOR
                p = p.buscar
                If Not p Is Nothing Then
                    If p.CARAVANAS = 1 Then
                        caravanas = 1
                    End If
                End If
            End If
            If caravanas = 1 Then
                fila = fila + 4
                x1hoja.Cells(fila, columna).formula = "CAMBIAR CARAVANAS"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 18
            End If
        End If
        '*********************************************************************************************

        



        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls")
        'x1hoja.SaveAs("c:\NET\SOLICITUDES\" & ficha & ".xls")

        x1app.Visible = True
        x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Sub
    Public Sub guardar()
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim id As Long = TextId.Text.Trim
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim idtipoficha As dTipoFicha = CType(ComboTipoFicha.SelectedItem, dTipoFicha)
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim nmuestras As Integer
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        End If
        Dim idmuestra As dMuestras = CType(ComboMuestra.SelectedItem, dMuestras)
        Dim idtecnico As dTecnicos = CType(ComboTecnico.SelectedItem, dTecnicos)
        Dim sinsolicitud As Integer
        If CheckSinSolicitud.Checked = True Then
            sinsolicitud = 1
        Else
            sinsolicitud = 0
        End If
        Dim sinconservante As Integer
        If CheckSinConservante.Checked = True Then
            sinconservante = 1
        Else
            sinconservante = 0
        End If
        Dim temperatura As Double
        If TextTemperatura.Text <> "" Then
            temperatura = TextTemperatura.Text.Trim
        End If
        Dim derramadas As Integer
        If CheckDerramadas.Checked = True Then
            derramadas = 1
        Else
            derramadas = 0
        End If
        Dim desvioautorizado As Integer
        If CheckDesvio.Checked = True Then
            desvioautorizado = 1
        Else
            desvioautorizado = 0
        End If
        Dim idfactura As Long
        If TextIdFactura.Text <> "" Then
            idfactura = TextIdFactura.Text.Trim
        End If
        Dim web As Integer
        If CheckWeb.Checked = True Then
            web = 1
        Else
            web = 0
        End If
        Dim personal As Integer
        If CheckPersonal.Checked = True Then
            personal = 1
        Else
            personal = 0
        End If
        Dim mail As Integer
        If CheckEmail.Checked = True Then
            mail = 1
        Else
            mail = 0
        End If
        Dim fechaenvio As Date = DateFechaEnvio.Value.ToString("yyyy-MM-dd")
        'If TextId.Text.Trim.Length > 0 Then
        'Dim sol As New dSolicitudAnalisis()
        'Dim id As Long = CType(TextId.Text.Trim, Long)
        'Dim fecing As String
        'Dim fecenv As String
        'fecing = Format(fechaingreso, "yyyy-MM-dd")
        'fecenv = Format(fechaenvio, "yyyy-MM-dd")
        'sol.ID = id
        'sol.FECHAINGRESO = fecing
        'sol.IDPRODUCTOR = idproductor
        'If Not idtipoinforme Is Nothing Then
        ' sol.IDTIPOINFORME = idtipoinforme.ID
        'End If
        'If Not idsubinforme Is Nothing Then
        'sol.IDSUBINFORME = idsubinforme.ID
        'End If
        'If Not idtipoficha Is Nothing Then
        'sol.IDTIPOFICHA = idtipoficha.ID
        'End If
        'sol.OBSERVACIONES = observaciones
        'sol.NMUESTRAS = nmuestras
        'If Not idtecnico Is Nothing Then
        'sol.IDTECNICO = idtecnico.ID
        'End If
        'sol.SINCOLICITUD = sinsolicitud
        'sol.SINCONSERVANTE = sinconservante
        'sol.TEMPERATURA = temperatura
        'sol.DERRAMADAS = derramadas
        'sol.DESVIOAUTORIZADO = desvioautorizado
        'sol.IDFACTURA = idfactura
        'sol.WEB = web
        'sol.PERSONAL = personal
        'sol.EMAIL = email
        'sol.FECHAENVIO = fecenv
        'If (sol.modificar(Usuario)) Then
        'MsgBox("Solicitud modificada", MsgBoxStyle.Information, "Atención")
        'Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        'End If
        'Else
        'If TextIdProductor.Text.Trim.Length > 0 Then
        Dim sol As New dSolicitudAnalisis()
        Dim fecing As String
        Dim fecenv As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")
        fecenv = Format(fechaenvio, "yyyy-MM-dd")
        sol.ID = id
        sol.FECHAINGRESO = fecing
        sol.IDPRODUCTOR = idproductor
        If Not idtipoinforme Is Nothing Then
            sol.IDTIPOINFORME = idtipoinforme.ID
        End If
        If Not idsubinforme Is Nothing Then
            sol.IDSUBINFORME = idsubinforme.ID
        End If
        If Not idtipoficha Is Nothing Then
            sol.IDTIPOFICHA = idtipoficha.ID
        End If
        sol.OBSERVACIONES = observaciones
        sol.NMUESTRAS = nmuestras
        If Not idtecnico Is Nothing Then
            sol.IDTECNICO = idtecnico.ID
        End If
        sol.SINCOLICITUD = sinsolicitud
        sol.SINCONSERVANTE = sinconservante
        sol.TEMPERATURA = temperatura
        sol.DERRAMADAS = derramadas
        sol.DESVIOAUTORIZADO = desvioautorizado
        sol.IDFACTURA = idfactura
        sol.WEB = web
        sol.PERSONAL = personal
        sol.EMAIL = mail
        sol.FECHAENVIO = fecenv
        If (sol.guardar(Usuario)) Then
            'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        'End If
        'End If

    End Sub
    Public Sub cargarComboSubInformes2()
        Dim si As New dSubInforme
        Dim lista As New ArrayList
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim texto As Long = idtipoinforme.ID
        lista = si.listarportipoinforme(texto)
        ComboSubInforme.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each si In lista
                    ComboSubInforme.Items.Add(si)
                Next
            End If
        End If
    End Sub

    Public Sub listarultimoid()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarultimoid
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    TextId.Text = s.ID
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAgencia()
        Dim et As New dEmpresaT
        Dim lista As New ArrayList
        lista = et.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each et In lista
                    ComboAgencia.Items.Add(et)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        DateFechaIngreso.Value = Now()
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        ComboTipoInforme.Text = ""
        ComboSubInforme.Text = ""
        ComboTipoFicha.Text = ""
        TextObservaciones.Text = ""
        TextNMuestras.Text = ""
        ComboMuestra.Text = ""
        ComboTecnico.Text = ""
        CheckSinSolicitud.Checked = False
        CheckSinConservante.Checked = False
        TextTemperatura.Text = ""
        CheckDerramadas.Checked = False
        CheckDesvio.Checked = False
        TextIdFactura.Text = ""
        TextFactura.Text = ""
        CheckWeb.Checked = False
        CheckPersonal.Checked = False
        CheckEmail.Checked = False
        DateFechaEnvio.Value = Now()
        TextId.Focus()
        'cargarComboInformes()
        'cargarComboSubInformes()
        'cargarComboTecnicos()
        'cargarComboTipoFicha()
        'cargarComboMuestras()

    End Sub
    Private Sub actualizarTecnico()
        Dim p As New dProductor
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim tecnico As dTecnicos = CType(ComboTecnico.SelectedItem, dTecnicos)
        Dim tec As Integer = tecnico.ID
        p.ID = id
        p.actualizartecnico(p.ID, tec, Usuario)
    End Sub
    Private Sub ComboTecnico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTecnico.SelectedIndexChanged
        actualizarTecnico()
    End Sub

    Private Sub TextCaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCaja.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            buscarultimoenvio()
        End If

    End Sub


    Private Sub buscarultimoenvio()
        Dim e As New dEnvioCajas
        e.IDCAJA = TextCaja.Text.Trim
        e = e.buscarultimoenvio()
        If Not e Is Nothing Then
            TextIdEnvio.Text = e.ID
            TextGradilla1.Text = e.GRADILLA1
            TextGradilla2.Text = e.GRADILLA2
            TextGradilla3.Text = e.GRADILLA3
            TextFrascos.Text = e.FRASCOS
            TextRemito.Focus()
        Else
            TextGradilla1.Focus()
        End If
    End Sub
    Private Sub marcarrecibido()
        If TextIdEnvio.Text <> "" Then
            Dim id As Long = TextIdEnvio.Text.Trim
            Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
            Dim recibo As String = TextRemito.Text.Trim
            Dim fecharecibo As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim observaciones As String = TextObservaciones.Text.Trim
            'If Not ListCajas.SelectedItem Is Nothing Then
            Dim env As New dEnvioCajas()
            If TextCaja.Text.Trim.Length > 0 Then
                Dim fec As String
                fec = Format(fecharecibo, "yyyy-MM-dd")
                env.ID = id
                If Not agencia Is Nothing Then
                    env.IDAGENCIA = agencia.ID
                Else
                    env.IDAGENCIA = 8
                End If
                env.RECIBO = recibo
                env.FECHARECIBO = fec
                env.OBSRECIBO = observaciones
                env.RECIBIDO = 1
            End If
            If (env.marcarrecibido(Usuario)) Then
                'MsgBox("Caja recibida", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub desmarcarrecibido()
        Dim id As Long = TextIdEnvio.Text.Trim
        'Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        'Dim recibo As String = TextRemito.Text.Trim
        'Dim fecharecibo As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        'Dim observaciones As String = TextObservaciones.Text.Trim
        'If Not ListCajas.SelectedItem Is Nothing Then
        Dim env As New dEnvioCajas()
        If TextCaja.Text.Trim.Length > 0 Then
            'Dim fec As String
            'fec = Format(fecharecibo, "yyyy-MM-dd")
            env.ID = id
            env.IDAGENCIA = 0
            env.RECIBO = ""
            env.FECHARECIBO = "0000-00-00"
            env.OBSRECIBO = ""
            env.RECIBIDO = 0
        End If
        If (env.marcarrecibido(Usuario)) Then
            MsgBox("Registro actualizado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub
    Private Sub solicitud_caja()
        Dim idsolicitud As Long = TextId.Text.Trim
        Dim idenvio As Long
        If TextIdEnvio.Text <> "" Then
            idenvio = TextIdEnvio.Text.Trim
        End If
        Dim idcaja As Integer = TextCaja.Text.Trim
        Dim gradilla1 As Integer = TextGradilla1.Text.Trim
        Dim gradilla2 As Integer = TextGradilla2.Text.Trim
        Dim gradilla3 As Integer = TextGradilla3.Text.Trim
        Dim frascos As Integer = 0
        If TextFrascos.Text.Trim <> "" Then
            frascos = TextFrascos.Text.Trim
        End If
        Dim nocolaveco As Integer
        If CheckCajas.Checked = True Then
            nocolaveco = 1
        Else
            nocolaveco = 0
        End If
        Dim sc As New dRelSolicitudCajas()
        If TextCaja.Text.Trim.Length > 0 Then
            sc.IDSOLICITUD = idsolicitud
            sc.IDENVIO = idenvio
            sc.IDCAJA = idcaja
            sc.GRADILLA1 = gradilla1
            sc.GRADILLA2 = gradilla2
            sc.GRADILLA3 = gradilla3
            sc.FRASCOS = frascos
            sc.NOCOLAVECO = nocolaveco

        End If
        If (sc.guardar(Usuario)) Then
            'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub

    Private Sub TextRemito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRemito.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            marcarrecibido()
            solicitud_caja()
            listar_solicitud_cajas()
            TextCaja.Text = ""
            TextGradilla1.Text = ""
            TextGradilla2.Text = ""
            TextGradilla3.Text = ""
            TextFrascos.Text = ""
            TextRemito.Text = ""
            TextCaja.Focus()
        End If
    End Sub
    Public Sub listar_solicitud_cajas()
        Dim sc As New dRelSolicitudCajas
        Dim lista As New ArrayList
        Dim texto As Long = TextId.Text.Trim
        lista = sc.listarporid(texto)
        ListCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sc In lista
                    ListCajas().Items.Add(sc)
                Next
            End If
        End If
    End Sub
    Private Sub limpiar2()
        TextCaja.Text = ""
        TextGradilla1.Text = ""
        TextGradilla2.Text = ""
        TextFrascos.Text = ""
        TextRemito.Text = ""
        ComboAgencia.Text = ""
        CheckCajas.Checked = False
        CheckFrascos.Checked = False
        ListCajas.Items.Clear()
        ListMuestras.Items.Clear()

    End Sub

    Private Sub ButtonEliminarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarCaja.Click
        If Not ListCajas.SelectedItem Is Nothing Then
            Dim sc As New dRelSolicitudCajas
            Dim id As Long = CType(TextIdSC.Text, Long)
            sc.ID = id
            If (sc.eliminar(Usuario)) Then
                desmarcarrecibido()
                MsgBox("Caja eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar2()
        listar_solicitud_cajas()
    End Sub

    Private Sub ButtonEliminarMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarMuestra.Click
        If Not ListMuestras.SelectedItem Is Nothing Then
            Dim sm As New dRelSolicitudMuestras
            Dim id As Long = CType(TextIdSM.Text, Long)
            sm.ID = id
            If (sm.eliminar(Usuario)) Then
                MsgBox("Muestra eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        TextMuestras.Text = ""
        listar_solicitud_muestras()
    End Sub


    Private Sub ListCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListCajas.SelectedIndexChanged
        limpiar2()
        If ListCajas.SelectedItems.Count = 1 Then
            Dim sc As dRelSolicitudCajas = CType(ListCajas.SelectedItem, dRelSolicitudCajas)
            TextIdSC.Text = sc.ID
            TextIdEnvio.Text = sc.IDENVIO
            TextCaja.Text = sc.IDCAJA
            TextGradilla1.Text = sc.GRADILLA1
            TextGradilla2.Text = sc.GRADILLA2
            TextGradilla3.Text = sc.GRADILLA3
            TextFrascos.Text = sc.FRASCOS
            TextCaja.Focus()
        End If
    End Sub

    Private Sub solicitud_muestras()
        Dim idsolicitud As Long = TextId.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idmuestra As String = TextMuestras.Text.Trim
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim nocolaveco As Integer
        If CheckFrascos.Checked = True Then
            nocolaveco = 1
        Else
            nocolaveco = 0
        End If
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim fecing As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")
        Dim fechaingreso2 As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd hh:mm:ss")
        Dim fecing2 As String
        fecing2 = Format(fechaingreso2, "yyyy-MM-dd hh:mm:ss")
        Dim sm As New dRelSolicitudMuestras()
        Dim a As New dAntibiograma
        Dim ag As New dAgua2
        Dim sp As New dSubproducto2
        Dim am As New dAmbiental
        Dim b As New dBacteriologia
        If TextMuestras.Text.Trim.Length > 0 Then
            sm.IDSOLICITUD = idsolicitud
            sm.FECHA = fecing2
            sm.IDTIPOINFORME = idtipoinforme.ID
            sm.IDMUESTRA = idmuestra
            sm.NOCOLAVECO = nocolaveco
            a.IDSOLICITUD = idsolicitud
            a.FECHASOLICITUD = fecing
            a.IDANIMAL = idmuestra
            a.MARCA = 0
            ag.IDSOLICITUD = idsolicitud
            ag.FECHAENTRADA = fecing
            ag.IDMUESTRA = idmuestra
            ag.COLIFORMESTOTALES = -1
            ag.COLIFORMESFECALES = -1
            ag.IDASPECTO = -1
            ag.IDOLOR = -1
            ag.IDCOLOR = -1
            ag.PH = -1
            ag.IDMATERIAORGANICA = -1
            ag.CONDUCTIVIDAD = -1
            ag.IDDUREZA = -1
            ag.NITRATO = -1
            ag.NITRITO = -1
            ag.HETEROTROFICOS = -1
            ag.TURBIEDAD = -1
            ag.NITRATOTIRAS = -1
            ag.NITRITOTIRAS = -1
            ag.DUREZA = -1
            ag.VOLUMENDESIEMBRA = -1
            ag.VOLUMENDESIEMBRA2 = -1
            ag.HETEROTROFICOS37 = -1
            ag.HETEROTROFICOS35 = -1
            ag.CLOROLIBRE = -1
            ag.CLORORESIDUAL = -1
            ag.PSEUDOMONASAERUGINOSA = -1
            ag.PSEUDOMONASPP = -1
            ag.ECOLI = -1
            ag.SULFITOREDUCTORES = -1
            ag.LOTENITRATO = -1
            ag.LOTENITRITO = -1
            ag.LOTEDUREZA = -1
            ag.MEDIOS = 0
            ag.MARCA = 0
            sp.IDSOLICITUD = idsolicitud
            sp.FECHASOLICITUD = fecing
            sp.IDMUESTRA = idmuestra
            sp.ESTAFCOAGPOSITIVO = -1
            sp.ESTAFCOAGPOSITIVO_MET = -1
            sp.CF = -1
            sp.CF_MET = -1
            sp.MOHOS = -1
            sp.MOHOS_MET = -1
            sp.LEVADURAS = -1
            sp.LEVADURAS_MET = -1
            sp.CT = -1
            sp.CT_MET = -1
            sp.ECOLI = -1
            sp.ECOLI_MET = -1
            sp.SALMONELLA = -1
            sp.SALMONELLA_MET = -1
            sp.LISTERIASPP = -1
            sp.LISTERIASPP_MET = -1
            sp.HUMEDAD = -1
            sp.HUMEDAD_MET = -1
            sp.MGRASA = -1
            sp.MGRASA_MET = -1
            sp.PH = -1
            sp.PH_MET = -1
            sp.CLORUROS = -1
            sp.CLORUROS_MET = -1
            sp.PROTEINAS = -1
            sp.PROTEINAS_MET = -1
            sp.ENTEROBACTERIAS = -1
            sp.ENTEROBACTERIAS_MET = -1
            sp.LISTERIAAMBIENTAL = -1
            sp.LISTERIAAMBIENTAL2 = -1
            sp.LISTERIAAMBIENTAL_MET = -1
            sp.ESPORANAERMESOFILO = -1
            sp.ESPORANAERMESOFILO_MET = -1
            sp.TERMOFILOS = -1
            sp.TERMOFILOS_MET = -1
            sp.PSICROTROFOS = -1
            sp.PSICROTROFOS_MET = -1
            sp.RB = -1
            sp.RB_MET = -1
            sp.TABLANUTRICIONAL = -1
            sp.TNPROTEINA = -1
            sp.TNCARBOHIDRATOS = -1
            sp.TNGRASASTOTALES = -1
            sp.TNGRASASSATURADAS = -1
            sp.TNGRASASTRANS = -1
            sp.LISTERIAMONOCITOGENES = -1
            sp.LISTERIAMONOCITOGENES_MET = -1
            sp.CENIZAS = -1
            sp.CENIZAS_MET = -1
            sp.TNSODIO = -1
            sp.TNFIBRAALIMENTICIA = -1
            sp.MARCA = 0
            am.IDSOLICITUD = idsolicitud
            am.FECHASOLICITUD = fecing
            am.FECHAPROCESO = fecing
            am.IDMUESTRA = idmuestra
            am.DETALLEMUESTRA = ""
            am.OBSERVACIONES = ""
            am.ESTADOMUESTRA = -1
            am.LISTERIAAMBIENTAL = -1
            am.LISTERIAAMBIENTAL2 = -1
            am.LISTERIAMONOCITOGENES = -1
            am.SALMONELLA = -1
            am.ENTEROBACTERIAS = -1
            am.ENTEROBACTERIAS2 = -1
            am.ECOLI = -1
            am.ECOLI2 = -1
            am.RB = -1
            am.MOHOS = -1
            am.MOHOS2 = -1
            am.LEVADURAS = -1
            am.LEVADURAS2 = -1
            am.CT = -1
            am.CT2 = -1
            am.CF = -1
            am.CF2 = -1
            am.PSEUDOMONASPP = -1
            am.PSEUDOMONASPP2 = -1
            am.MARCA = 0
            b.FICHA = idsolicitud
            b.FECHASOLICITUD = fecing
            b.FECHAPROCESO = fecing
            b.IDMUESTRA = idmuestra
            b.RC = -1
            b.RB = -1
            b.COLIFORMES = -1
            b.TERMODURICOS = -1
            b.ESTREPTOCOCOAG = -1
            b.ESTREPTOCOCODYS = -1
            b.ESTREPTOCOCOUB = -1
            b.ESTREPTOCOCOSPP = -1
            b.ESTAFILOCOCOAU = -1
            b.ESTAPYLOCOCOCOAGNEG = -1
            b.PSICROTROFOS = -1
            b.CORYNEBACTERIUM = -1
            b.OTROS = -1
            b.OBSERVACIONES = -1
            b.MARCA = 0
        End If
        If (sm.guardar(Usuario)) Then
            'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            If idtipoinforme.ID = 4 Then
                If idsubinforme.ID <> 10 Then
                    a.guardar(Usuario)
                End If
                If idsubinforme.ID = 10 Then
                    b.guardar(Usuario)
                End If
            End If
            If idtipoinforme.ID = 3 Then
                ag.guardar(Usuario)
            End If
            If idtipoinforme.ID = 7 Then
                sp.guardar(Usuario)
            End If
            If idtipoinforme.ID = 11 Then
                am.guardar(Usuario)
            End If
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub
    Public Sub listar_solicitud_muestras()
        Dim sm As New dRelSolicitudMuestras
        Dim lista As New ArrayList
        Dim texto As Long = TextId.Text.Trim
        Dim cuenta_muestras As Integer = 0
        lista = sm.listarporid(texto)
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            cuenta_muestras = lista.Count
            If lista.Count > 0 Then
                For Each sm In lista
                    ListMuestras().Items.Add(sm)
                Next
            End If
        End If
        TextNMuestras.Text = ""
        TextNMuestras.Text = cuenta_muestras
    End Sub


    Private Sub TextMuestras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestras.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Dim sm As New dRelSolicitudMuestras
            Dim ficha As Long = TextId.Text
            Dim muestra As String = TextMuestras.Text.Trim
            sm.IDSOLICITUD = ficha
            sm.IDMUESTRA = muestra
            sm = sm.buscarrepetidas
            If Not sm Is Nothing Then
                My.Computer.Audio.Play("c:\debug\aviso.wav")
                Dim result = MessageBox.Show("La muestra ya existe, desea agregarla?", "Atención", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    solicitud_muestras()
                    listar_solicitud_muestras()
                    TextMuestras.Text = ""
                    TextMuestras.Focus()
                End If
            Else
                solicitud_muestras()
                listar_solicitud_muestras()
                TextMuestras.Text = ""
                TextMuestras.Focus()
            End If
        End If
    End Sub
    

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        TextMuestras.Text = ""
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim sm As dRelSolicitudMuestras = CType(ListMuestras.SelectedItem, dRelSolicitudMuestras)
            TextIdSM.Text = sm.ID
            TextMuestras.Text = sm.IDMUESTRA
            TextMuestras.Focus()
        End If
    End Sub

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        limpiar()
        Dim v As New FormBuscarSolicitud
        v.ShowDialog()
        If Not v.SolicitudAnalisis Is Nothing Then
            Dim sol As dSolicitudAnalisis = v.SolicitudAnalisis
            ComboTipoFicha.SelectedItem = Nothing
            Dim tf As dTipoFicha
            For Each tf In ComboTipoFicha.Items
                If tf.ID = sol.IDTIPOFICHA Then
                    ComboTipoFicha.SelectedItem = tf
                    Exit For
                End If
            Next
            TextId.Text = sol.ID
            DateFechaIngreso.Value = sol.FECHAINGRESO
            Dim p As New dProductor
            TextIdProductor.Text = sol.IDPRODUCTOR
            'Dim id As Long = CType(TextIdProductor.Text, Long)
            p.ID = Val(TextIdProductor.Text)
            p = p.buscar
            If Not p Is Nothing Then
                TextProductor.Text = p.NOMBRE
            End If
            ComboTipoInforme.SelectedItem = Nothing
            Dim ti As dTipoInforme
            For Each ti In ComboTipoInforme.Items
                If ti.ID = sol.IDTIPOINFORME Then
                    ComboTipoInforme.SelectedItem = ti
                    Exit For
                End If
            Next
            ComboSubInforme.SelectedItem = Nothing
            Dim si As dSubInforme
            For Each si In ComboSubInforme.Items
                If si.ID = sol.IDSUBINFORME Then
                    ComboSubInforme.SelectedItem = si
                    Exit For
                End If
            Next
            TextObservaciones.Text = sol.OBSERVACIONES
            TextNMuestras.Text = sol.NMUESTRAS
            ComboMuestra.SelectedItem = Nothing
            Dim m As dMuestras
            For Each m In ComboMuestra.Items
                If m.ID = sol.IDMUESTRA Then
                    ComboMuestra.SelectedItem = m
                    Exit For
                End If
            Next
            ComboTecnico.SelectedItem = Nothing
            Dim t As dTecnicos
            For Each t In ComboTecnico.Items
                If t.ID = sol.IDTECNICO Then
                    ComboTecnico.SelectedItem = t
                    Exit For
                End If
            Next
            If sol.SINCOLICITUD = 1 Then
                CheckSinSolicitud.Checked = True
            Else
                CheckSinSolicitud.Checked = False
            End If
            If sol.SINCONSERVANTE = 1 Then
                CheckSinConservante.Checked = True
            Else
                CheckSinConservante.Checked = False
            End If
            TextTemperatura.Text = sol.TEMPERATURA
            If sol.DERRAMADAS = 1 Then
                CheckDerramadas.Checked = True
            Else
                CheckDerramadas.Checked = False
            End If
            If sol.DESVIOAUTORIZADO = 1 Then
                CheckDesvio.Checked = True
            Else
                CheckDesvio.Checked = False
            End If
            Dim pr As New dProductor
            TextIdFactura.Text = sol.IDFACTURA
            'Dim idf As Long = CType(TextIdFactura.Text, Long)
            pr.ID = Val(TextIdFactura.Text)
            pr = p.buscar
            If Not p Is Nothing Then
                TextFactura.Text = pr.NOMBRE
            End If
            If sol.WEB = 1 Then
                CheckWeb.Checked = True
            Else
                CheckWeb.Checked = False
            End If
            If sol.PERSONAL = 1 Then
                CheckPersonal.Checked = True
            Else
                CheckPersonal.Checked = False
            End If
            If sol.EMAIL = 1 Then
                CheckEmail.Checked = True
            Else
                CheckEmail.Checked = False
            End If
            DateFechaEnvio.Value = sol.FECHAENVIO
        End If
        If TextId.Text <> "" Then
            If TextId.Text > 0 Then
                listar_solicitud_cajas()
                listar_solicitud_muestras()
            End If
        End If
    End Sub

    Private Sub ComboTipoInforme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipoInforme.SelectedIndexChanged
        cargarComboSubInformes2()
        GroupBox4.Enabled = True
    End Sub
    Private Sub guardarantibiograma()

    End Sub


    Private Sub TextRemito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRemito.TextChanged

    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        limpiar2()
    End Sub

    Private Sub TextMuestras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMuestras.TextChanged

    End Sub

    Private Sub ComboSubInforme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSubInforme.SelectedIndexChanged
        Dim si As New dSubInforme

        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim solicitud As Long = TextId.Text.Trim
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim idsubinf As Integer = idsubinforme.ID
        If idtipoinforme.ID = 1 Then
            Dim v As New FormSolicitudControlLechero(Usuario, solicitud, idsubinf)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 3 Then
            Dim v As New FormSolicitudAgua(Usuario, solicitud, fecha)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 4 Then
            If idsubinforme.ID = 3 Then
                Dim v As New FormAntibiograma2(Usuario, solicitud)
                v.ShowDialog()
            End If
        End If
        If idtipoinforme.ID = 5 Then
            GroupBox4.Enabled = False
            Dim v As New FormSolicitudPAL(Usuario, solicitud, idproductor)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 6 Then
            Dim v As New FormSolicitudParasitologia(Usuario, solicitud, idsubinf)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 7 Then
            Dim v As New FormSolicitudSubproductos(Usuario, solicitud, fecha, idsubinf)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 8 Then
            GroupBox4.Enabled = False
            Dim v As New FormSinaveleFicha(Usuario, solicitud)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 10 Then
            GroupBox4.Enabled = False
            idprod = TextIdProductor.Text.Trim
            Dim v As New FormSolicitudCalidadMuestras(Usuario, solicitud, idsubinf)
            v.ShowDialog()
            TextNMuestras.Text = cant_muestras
        End If
       
        If idtipoinforme.ID = 11 Then
            Dim v As New FormSolicitudAmbiental(Usuario, solicitud, idsubinf)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 13 Then
            GroupBox4.Enabled = False
            Dim v As New FormSolicitudNutricion(Usuario, solicitud)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 14 Then
            GroupBox4.Enabled = False
            Dim v As New FormSolicitudSuelos(Usuario, solicitud)
            v.ShowDialog()
        End If
       
       
    End Sub

    Private Sub ButtonGuardar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim id As Long = TextId.Text.Trim
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim idtipoficha As dTipoFicha = CType(ComboTipoFicha.SelectedItem, dTipoFicha)
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim nmuestras As Integer
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        End If
        Dim idmuestra As dMuestras = CType(ComboMuestra.SelectedItem, dMuestras)
        Dim idtecnico As dTecnicos = CType(ComboTecnico.SelectedItem, dTecnicos)
        Dim sinsolicitud As Integer
        If CheckSinSolicitud.Checked = True Then
            sinsolicitud = 1
        Else
            sinsolicitud = 0
        End If
        Dim sinconservante As Integer
        If CheckSinConservante.Checked = True Then
            sinconservante = 1
        Else
            sinconservante = 0
        End If
        Dim temperatura As Double
        If TextTemperatura.Text <> "" Then
            temperatura = TextTemperatura.Text.Trim
        End If
        Dim derramadas As Integer
        If CheckDerramadas.Checked = True Then
            derramadas = 1
        Else
            derramadas = 0
        End If
        Dim desvioautorizado As Integer
        If CheckDesvio.Checked = True Then
            desvioautorizado = 1
        Else
            desvioautorizado = 0
        End If
        Dim idfactura As Long
        If TextIdFactura.Text <> "" Then
            idfactura = TextIdFactura.Text.Trim
        End If
        Dim web As Integer
        If CheckWeb.Checked = True Then
            web = 1
        Else
            web = 0
        End If
        Dim personal As Integer
        If CheckPersonal.Checked = True Then
            personal = 1
        Else
            personal = 0
        End If
        Dim mail As Integer
        If CheckEmail.Checked = True Then
            mail = 1
        Else
            mail = 0
        End If
        Dim fechaenvio As Date = DateFechaEnvio.Value.ToString("yyyy-MM-dd")
        If TextId.Text.Trim.Length > 0 Then
            Dim sol As New dSolicitudAnalisis()
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fecing As String
            Dim fecenv As String
            fecing = Format(fechaingreso, "yyyy-MM-dd")
            fecenv = Format(fechaenvio, "yyyy-MM-dd")
            sol.ID = id
            sol.FECHAINGRESO = fecing
            sol.IDPRODUCTOR = idproductor
            If Not idtipoinforme Is Nothing Then
                sol.IDTIPOINFORME = idtipoinforme.ID
            End If
            If Not idsubinforme Is Nothing Then
                sol.IDSUBINFORME = idsubinforme.ID
            End If
            If Not idtipoficha Is Nothing Then
                sol.IDTIPOFICHA = idtipoficha.ID
            End If
            sol.OBSERVACIONES = observaciones
            sol.NMUESTRAS = nmuestras
            If Not idmuestra Is Nothing Then
                sol.IDMUESTRA = idmuestra.ID
            End If
            If Not idtecnico Is Nothing Then
                sol.IDTECNICO = idtecnico.ID
            End If
            sol.SINCOLICITUD = sinsolicitud
            sol.SINCONSERVANTE = sinconservante
            sol.TEMPERATURA = temperatura
            sol.DERRAMADAS = derramadas
            sol.DESVIOAUTORIZADO = desvioautorizado
            sol.IDFACTURA = idfactura
            sol.WEB = web
            sol.PERSONAL = personal
            sol.EMAIL = mail
            sol.FECHAENVIO = fecenv
            If (sol.modificar(Usuario)) Then
                MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                limpiar()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim sol As New dSolicitudAnalisis()
                Dim fecing As String
                Dim fecenv As String
                fecing = Format(fechaingreso, "yyyy-MM-dd")
                fecenv = Format(fechaenvio, "yyyy-MM-dd")
                sol.ID = id
                sol.FECHAINGRESO = fecing
                sol.IDPRODUCTOR = idproductor
                If Not idtipoinforme Is Nothing Then
                    sol.IDTIPOINFORME = idtipoinforme.ID
                End If
                If Not idsubinforme Is Nothing Then
                    sol.IDSUBINFORME = idsubinforme.ID
                End If
                If Not idtipoficha Is Nothing Then
                    sol.IDTIPOFICHA = idtipoficha.ID
                End If
                sol.OBSERVACIONES = observaciones
                sol.NMUESTRAS = nmuestras
                If Not idtecnico Is Nothing Then
                    sol.IDTECNICO = idtecnico.ID
                End If
                sol.SINCOLICITUD = sinsolicitud
                sol.SINCONSERVANTE = sinconservante
                sol.TEMPERATURA = temperatura
                sol.DERRAMADAS = derramadas
                sol.DESVIOAUTORIZADO = desvioautorizado
                sol.IDFACTURA = idfactura
                sol.WEB = web
                sol.PERSONAL = personal
                sol.EMAIL = mail
                sol.FECHAENVIO = fecenv
                If (sol.guardar(Usuario)) Then
                    MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    limpiar()
                    limpiar2()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        'cargarLista()
        Me.Close()

    End Sub


    Private Sub FormSolicitudAnalisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextId.Select()
    End Sub

    Private Sub TextCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCaja.TextChanged

    End Sub

    Private Sub TextTemperatura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextTemperatura.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(46) Or e.KeyChar = Microsoft.VisualBasic.ChrW(44) Then
            MsgBox("Ingresar solo números enteros", MsgBoxStyle.Information, "Atención")
            TextTemperatura.Text = ""
        End If
    End Sub

    Private Sub actualizardicose()
        Dim p As New dProductor
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim dicose As String = TextDicose.Text.Trim
        p.ID = id
        p.actualizardicose(p.ID, dicose, Usuario)
    End Sub

    Private Sub TextDicose_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextDicose.TextChanged
        actualizardicose()
    End Sub

    Private Sub TextId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextId.KeyPress
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextOtros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextOtros.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextMuestras.Focus()
        End If
    End Sub

    Private Sub TextOtros_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextOtros.LostFocus
        If TextOtros.Text <> "" Then
            Dim ficha As String = TextId.Text.Trim
            Dim descripcion As String = TextOtros.Text.Trim

            Dim so As New dRelSolicitudOtros()
            so.FICHA = ficha
            so.DESCRIPCION = descripcion
            If (so.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub



    Private Sub TextOtros_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextOtros.TextChanged

    End Sub

    Private Sub TextGradilla1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGradilla2.Focus()
        End If
    End Sub

    Private Sub TextGradilla1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextGradilla1.TextChanged

    End Sub

    Private Sub TextGradilla2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGradilla3.Focus()
        End If
    End Sub

    Private Sub TextGradilla2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextGradilla2.TextChanged

    End Sub

    Private Sub TextGradilla3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextFrascos.Focus()
        End If
    End Sub

    Private Sub TextGradilla3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextGradilla3.TextChanged

    End Sub

    Private Sub TextFrascos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFrascos.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRemito.Focus()
        End If
    End Sub

    Private Sub TextFrascos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFrascos.TextChanged

    End Sub
    Private Sub InsertarRegistro_com()
        tipoinforme = ComboTipoInforme.Text
        idficha = TextId.Text.Trim
        

        If tipoinforme = "Control Lechero" Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
            Dim cw_com As New dControlLecheroWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            cw_com.ID_USUARIO = idproductorweb_com
            cw_com.ABONADO = 0
            cw_com.FECHA_CREADO = fechaemi
            cw_com.FECHA_EMISION = fechaemi
            cw_com.FICHA = idficha
            cw_com.ID_ESTADO = 1
            cw_com.ID_LIBRO = idficha
            If (cw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Calidad de leche" Then 'SI EL TIPO DE INFORME ES DE CALIDAD DE LECHE
            Dim cw_com As New dCalidadWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            cw_com.ID_USUARIO = idproductorweb_com
            cw_com.ABONADO = 0
            cw_com.FECHA_CREADO = fechaemi
            cw_com.FECHA_EMISION = fechaemi
            cw_com.FICHA = idficha
            cw_com.ID_ESTADO = 1
            cw_com.ID_LIBRO = idficha
            If (cw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Agua" Then 'SI EL TIPO DE INFORME ES DE AGUA
            Dim aw_com As New dAguaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 0
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Parasitología" Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
            Dim parw_com As New dParasitologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            parw_com.ID_USUARIO = idproductorweb_com
            parw_com.ABONADO = 0
            parw_com.FECHA_CREADO = fechaemi
            parw_com.FECHA_EMISION = fechaemi
            parw_com.FICHA = idficha
            parw_com.ID_ESTADO = 1
            parw_com.ID_LIBRO = idficha
            If (parw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Prodúctos Lácteos" Then 'SI EL TIPO DE INFORME ES DE PRODÚCTOS LÁCTEOS
            Dim spw_com As New dSubproductosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            spw_com.ID_USUARIO = idproductorweb_com
            spw_com.ABONADO = 0
            spw_com.FECHA_CREADO = fechaemi
            spw_com.FECHA_EMISION = fechaemi
            spw_com.FICHA = idficha
            spw_com.ID_ESTADO = 1
            spw_com.ID_LIBRO = idficha
            If (spw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Serología" Then 'SI EL TIPO DE INFORME ES DE SEROLOGÍA
            Dim sw_com As New dSerologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            sw_com.ID_USUARIO = idproductorweb_com
            sw_com.ABONADO = 0
            sw_com.FECHA_CREADO = fechaemi
            sw_com.FECHA_EMISION = fechaemi
            sw_com.FICHA = idficha
            sw_com.ID_ESTADO = 1
            sw_com.ID_LIBRO = idficha
            If (sw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Patología - Toxicología" Then 'SI EL TIPO DE INFORME ES DE PATOLOGÍA - TOXICOLOGÍA
            Dim paw_com As New dPatologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            paw_com.ID_USUARIO = idproductorweb_com
            paw_com.ABONADO = 0
            paw_com.FECHA_CREADO = fechaemi
            paw_com.FECHA_EMISION = fechaemi
            paw_com.FICHA = idficha
            paw_com.ID_ESTADO = 1
            paw_com.ID_LIBRO = idficha
            If (paw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Calidad de leche" Then 'SI EL TIPO DE INFORME ES DE CALIDAD
            Dim cw_com As New dCalidadWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            cw_com.ID_USUARIO = idproductorweb_com
            cw_com.ABONADO = 0
            cw_com.FECHA_CREADO = fechaemi
            cw_com.FECHA_EMISION = fechaemi
            cw_com.FICHA = idficha
            cw_com.ID_ESTADO = 1
            cw_com.ID_LIBRO = idficha
            If (cw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Ambiental" Then 'SI EL TIPO DE INFORME ES AMBIENTAL
            Dim aw_com As New dAmbientalWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Lactómetros - Chequeos" Then 'SI EL TIPO DE INFORME ES DE LACTÓMETROS
            Dim lw_com As New dLactometrosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            lw_com.ID_USUARIO = idproductorweb_com
            lw_com.ABONADO = 0
            lw_com.FECHA_CREADO = fechaemi
            lw_com.FECHA_EMISION = fechaemi
            lw_com.FICHA = idficha
            lw_com.ID_ESTADO = 1
            lw_com.ID_LIBRO = idficha
            If (lw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Agro Nutrición" Then 'SI EL TIPO DE INFORME ES DE AGRO NUTRICIÓN
            Dim aw_com As New dAgroNutricionWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Otros Servicios" Then 'SI EL TIPO DE INFORME ES DE OTROS SERVICIOS
            Dim osw_com As New dOtrosServiciosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            osw_com.ID_USUARIO = idproductorweb_com
            osw_com.ABONADO = 0
            osw_com.FECHA_CREADO = fechaemi
            osw_com.FECHA_EMISION = fechaemi
            osw_com.FICHA = idficha
            osw_com.ID_ESTADO = 1
            osw_com.ID_LIBRO = idficha
            If (osw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Agro Suelos" Then 'SI EL TIPO DE INFORME ES DE AGRO SUELOS
            Dim aw_com As New dAgroSuelosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Brucelosis por ELISA" Then 'SI EL TIPO DE INFORME ES DE AGRO SUELOS
            Dim bw_com As New dBrucelosisLecheWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            bw_com.ID_USUARIO = idproductorweb_com
            bw_com.ABONADO = 0
            bw_com.FECHA_CREADO = fechaemi
            bw_com.FECHA_EMISION = fechaemi
            bw_com.FICHA = idficha
            bw_com.ID_ESTADO = 1
            bw_com.ID_LIBRO = idficha
            If (bw_com.guardar()) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub InsertarRegistro_uy()
        tipoinforme = ComboTipoInforme.Text
        idficha = TextId.Text.Trim

        If tipoinforme = "Control Lechero" Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
            Dim cw_uy As New dControlLecheroWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            cw_uy.ID_USUARIO = idproductorweb_uy
            cw_uy.ABONADO = 0
            cw_uy.FECHA_CREADO = fechaemi
            cw_uy.FECHA_EMISION = fechaemi
            cw_uy.FICHA = idficha
            cw_uy.ID_ESTADO = 1
            cw_uy.ID_LIBRO = idficha
            If (cw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Calidad de leche" Then 'SI EL TIPO DE INFORME ES DE CALIDAD DE LECHE
            Dim cw_uy As New dCalidadWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            cw_uy.ID_USUARIO = idproductorweb_uy
            cw_uy.ABONADO = 0
            cw_uy.FECHA_CREADO = fechaemi
            cw_uy.FECHA_EMISION = fechaemi
            cw_uy.FICHA = idficha
            cw_uy.ID_ESTADO = 1
            cw_uy.ID_LIBRO = idficha
            If (cw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Agua" Then 'SI EL TIPO DE INFORME ES DE AGUA
            Dim aw_uy As New dAguaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            aw_uy.ID_USUARIO = idproductorweb_uy
            aw_uy.ABONADO = 0
            aw_uy.FECHA_CREADO = fechaemi
            aw_uy.FECHA_EMISION = fechaemi
            aw_uy.FICHA = idficha
            aw_uy.ID_ESTADO = 1
            aw_uy.ID_LIBRO = idficha
            If (aw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Parasitología" Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
            Dim parw_uy As New dParasitologiaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            parw_uy.ID_USUARIO = idproductorweb_uy
            parw_uy.ABONADO = 0
            parw_uy.FECHA_CREADO = fechaemi
            parw_uy.FECHA_EMISION = fechaemi
            parw_uy.FICHA = idficha
            parw_uy.ID_ESTADO = 1
            parw_uy.ID_LIBRO = idficha
            If (parw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Prodúctos Lácteos" Then 'SI EL TIPO DE INFORME ES DE PRODÚCTOS LÁCTEOS
            Dim spw_uy As New dSubproductosWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            spw_uy.ID_USUARIO = idproductorweb_uy
            spw_uy.ABONADO = 0
            spw_uy.FECHA_CREADO = fechaemi
            spw_uy.FECHA_EMISION = fechaemi
            spw_uy.FICHA = idficha
            spw_uy.ID_ESTADO = 1
            spw_uy.ID_LIBRO = idficha
            If (spw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Serología" Then 'SI EL TIPO DE INFORME ES DE SEROLOGÍA
            Dim sw_uy As New dSerologiaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            sw_uy.ID_USUARIO = idproductorweb_uy
            sw_uy.ABONADO = 0
            sw_uy.FECHA_CREADO = fechaemi
            sw_uy.FECHA_EMISION = fechaemi
            sw_uy.FICHA = idficha
            sw_uy.ID_ESTADO = 1
            sw_uy.ID_LIBRO = idficha
            If (sw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Patología - Toxicología" Then 'SI EL TIPO DE INFORME ES DE PATOLOGÍA - TOXICOLOGÍA
            Dim paw_uy As New dPatologiaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            paw_uy.ID_USUARIO = idproductorweb_uy
            paw_uy.ABONADO = 0
            paw_uy.FECHA_CREADO = fechaemi
            paw_uy.FECHA_EMISION = fechaemi
            paw_uy.FICHA = idficha
            paw_uy.ID_ESTADO = 1
            paw_uy.ID_LIBRO = idficha
            If (paw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Calidad de leche" Then 'SI EL TIPO DE INFORME ES DE CALIDAD
            Dim cw_uy As New dCalidadWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            cw_uy.ID_USUARIO = idproductorweb_uy
            cw_uy.ABONADO = 0
            cw_uy.FECHA_CREADO = fechaemi
            cw_uy.FECHA_EMISION = fechaemi
            cw_uy.FICHA = idficha
            cw_uy.ID_ESTADO = 1
            cw_uy.ID_LIBRO = idficha
            If (cw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Ambiental" Then 'SI EL TIPO DE INFORME ES AMBIENTAL
            Dim aw_uy As New dAmbientalWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            aw_uy.ID_USUARIO = idproductorweb_uy
            aw_uy.ABONADO = 0
            aw_uy.FECHA_CREADO = fechaemi
            aw_uy.FECHA_EMISION = fechaemi
            aw_uy.FICHA = idficha
            aw_uy.ID_ESTADO = 1
            aw_uy.ID_LIBRO = idficha
            If (aw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Lactómetros - Chequeos" Then 'SI EL TIPO DE INFORME ES DE LACTÓMETROS
            Dim lw_uy As New dLactometrosWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            lw_uy.ID_USUARIO = idproductorweb_uy
            lw_uy.ABONADO = 0
            lw_uy.FECHA_CREADO = fechaemi
            lw_uy.FECHA_EMISION = fechaemi
            lw_uy.FICHA = idficha
            lw_uy.ID_ESTADO = 1
            lw_uy.ID_LIBRO = idficha
            If (lw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Agro Nutrición" Then 'SI EL TIPO DE INFORME ES DE AGRO NUTRICIÓN
            Dim aw_uy As New dAgroNutricionWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            aw_uy.ID_USUARIO = idproductorweb_uy
            aw_uy.ABONADO = 0
            aw_uy.FECHA_CREADO = fechaemi
            aw_uy.FECHA_EMISION = fechaemi
            aw_uy.FICHA = idficha
            aw_uy.ID_ESTADO = 1
            aw_uy.ID_LIBRO = idficha
            If (aw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        ElseIf tipoinforme = "Otros Servicios" Then 'SI EL TIPO DE INFORME ES DE OTROS SERVICIOS
            Dim osw_uy As New dOtrosServiciosWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")

            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")

            osw_uy.ID_USUARIO = idproductorweb_uy
            osw_uy.ABONADO = 0
            osw_uy.FECHA_CREADO = fechaemi
            osw_uy.FECHA_EMISION = fechaemi
            osw_uy.FICHA = idficha
            osw_uy.ID_ESTADO = 1
            osw_uy.ID_LIBRO = idficha
            If (osw_uy.guardar(Usuario)) Then
                'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub enviomail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        '******************************************************************************************************************************************
        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As String
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = ""
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim

        Dim titulo As String = ""
        Dim enc_ficha As String = ""
        Dim enc_fecha As String = ""
        Dim enc_cliente As String = ""
        Dim enc_muestras As String = ""
        Dim enc_muestrade As String = ""
        Dim cuerpo_analisis As String = ""
        Dim cuerpo_muestras As String = ""
        Dim pie_observaciones As String = ""
        Dim pie_estadosolicitud As String = "En nuestro sitio web www.colaveco.com.uy, puede ver el estado de su solicitud."
        
        Dim pro As New dProductor
        Dim nombre_productor As String = ""
        pro.ID = TextIdProductor.Text.Trim
        pro = pro.buscar
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
      
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
     
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
       
        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Prodúctos Lácteos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
              
            End If


            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()

            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDYPH = 1 Then
                texto = texto & " " & " - Conductividad y pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If


            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                    Next

                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
           


            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next

                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
           

            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next

                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
           

            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)

            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                    Next

                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
           

            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)

            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
           

            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Agro Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                    Next

                End If
            End If



            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Agro Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                    Next

                End If
            End If

        
        End If


        '*** LISTADO DE MUESTRAS *********************************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Prodúctos Lácteos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If


            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES CALIDAD ********************************************************************************

        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        If csm.RB = 1 Then
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
        
            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If

            ' SI ES CONTROL LECHERO ********************************************************************************

        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""

            ' SI ES ANTIBIOGRAMA ********************************************************************************

        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If

            ' SI ES AMBIENTAL ********************************************************************************

        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If

            ' SI ES PARASITOLOGÍA ********************************************************************************

        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If

            ' SI ES PAL ********************************************************************************

        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If

            Dim solpal As New dSolicitudPAL
            solpal.IDSOLICITUD = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                ' x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                
            End If

            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************

        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
          
       
        End If
        '********************************************************************************************************************
    
        If tipoinforme = "Agro Nutrición" Or tipoinforme = "Agro Suelos" Then
            If email <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
                _SMTP.Host = "smtp.gmail.com"
                _SMTP.Port = 587 '465
                _SMTP.EnableSsl = True
                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(LTrim(email))
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Solicitud de análisis"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                _Message.Body = "A ingresado una solicitud con el número" & " " & ficha & vbCrLf _
                & "Fecha de recepción: " & fecha & "." & vbCrLf _
                & "A nombre de: " & nombre_productor & "." & vbCrLf _
                & "Muestras ingresadas: " & nmuestras & "." & vbCrLf _
                & "Tipo de muestra: " & muestra & "." & vbCrLf _
                & "Análisis requerido: " & tipoinforme & "." & vbCrLf _
                & "Subtipo: " & subtipoinforme & "." & vbCrLf _
                & vbCrLf _
                & texto & vbCrLf _
                & vbCrLf _
                & "Observaciones:" & vbCrLf _
                & observaciones & vbCrLf _
                & vbCrLf _
                & "En nuestro sitio web, www.colaveco.com.uy, puede ver el estado de su solicitud." & vbCrLf _
                & "Gracias." & vbCrLf _
                & "COLAVECO"
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                Try
                    _SMTP.Send(_Message)
                Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                End Try
            End If
            email = ""
            nficha = ""
        Else
            If email <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
                _SMTP.Host = "smtp.gmail.com"
                _SMTP.Port = 587 '465
                _SMTP.EnableSsl = True
                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(LTrim(email))
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Solicitud de análisis"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                _Message.Body = "A ingresado una solicitud con el número" & " " & ficha & vbCrLf _
                & "Fecha/Hora de recepción: " & fecha & "." & vbCrLf _
                & "A nombre de: " & nombre_productor & "." & vbCrLf _
                & "Muestras ingresadas: " & nmuestras & "." & vbCrLf _
                & "Tipo de muestra: " & muestra & "." & vbCrLf _
                & "Análisis requerido: " & tipoinforme & "." & vbCrLf _
                & "Subtipo: " & subtipoinforme & "." & vbCrLf _
                & vbCrLf _
                & texto & vbCrLf _
                & vbCrLf _
                & "Identificación de las muestras:" & vbCrLf _
                & texto2 & vbCrLf _
                & vbCrLf _
                & "Observaciones:" & vbCrLf _
                & observaciones & vbCrLf _
                & vbCrLf _
                & "En nuestro sitio web, www.colaveco.com.uy, puede ver el estado de su solicitud." & vbCrLf _
                & "Gracias." & vbCrLf & vbCrLf _
                & "COLAVECO" & vbCrLf _
                & "Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838" & vbCrLf _
                & "Email: colaveco@gmail.com - web: www.colaveco.com.uy" & vbCrLf & vbCrLf _
                & "-------------------------------------------------------------------------------------" & vbCrLf _
                & "Cuando el cliente solicite suspender el servicio ya presupuestado y en jecución, o una parte del mismo," & vbCrLf _
                & "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                Try
                    _SMTP.Send(_Message)
                Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                End Try
            End If
            email = ""
            nficha = ""
        End If
    End Sub
    Private Sub enviomail_no_se_usa_mas()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim sa As New dSolicitudAnalisis
        Dim p As New dProductor
        Dim ti As New dTipoInforme
        Dim si As New dSubInforme
        Dim tm As New dMuestras
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        Dim subtipo As String = ""
        Dim cantmuestras As String = ""
        Dim tipo_muestra As String = ""
        nficha = TextId.Text.Trim
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
            si.ID = sa.IDSUBINFORME
            si = si.buscar
            If Not si Is Nothing Then
                subtipo = si.NOMBRE
            End If
            If sa.NMUESTRAS = 0 Then
                cantmuestras = "-"
            Else
                cantmuestras = sa.NMUESTRAS
            End If
            tm.ID = sa.IDMUESTRA
            tm = tm.buscar
            If Not tm Is Nothing Then
                tipo_muestra = tm.NOMBRE
            End If
        End If
        If email <> "" Then

            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(LTrim(email))
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Solicitud de análisis"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "A ingresado una solicitud con el número" & " " & nficha & vbCrLf _
            & "A nombre de: " & nombre_productor & "." & vbCrLf _
            & "Tipo de análisis: " & tipo_analisis & "." & vbCrLf _
            & "Subtipo: " & subtipo & "." & vbCrLf _
            & "Tipo de muestra: " & tipo_muestra & "." & vbCrLf _
            & "Muestras ingresadas: " & cantmuestras & "." & vbCrLf & vbCrLf _
            & "En nuestro sitio web, www.colaveco.com.uy, puede ver el estado de su solicitud." & vbCrLf _
            & "Gracias." & vbCrLf _
            & "COLAVECO"
            '_Message.Body = "Su solicitud de análisis Nº " & " " & nficha & ", " & "ha ingresado correctamente al sistema. Gracias."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        nficha = ""

    End Sub
    Private Sub enviosms()
        Dim num1 As String = ""
        Dim num2 As String = ""
        Dim email1 As String = ""
        Dim email2 As String = ""
        Dim sms As String = ""
        Dim sms1 As String = ""
        Dim sms2 As String = ""
        Dim cel1 As String = ""
        Dim cel2 As String = ""
        Dim largotexto As Integer = 0
        Dim celular1 As String = ""
        Dim celular2 As String = ""
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim texto As String = celular
        Dim cantcaracteres As Integer = Len(texto)
        If celular <> "" Then
            largotexto = celular.Length
        End If
        nficha = TextId.Text.Trim

        Dim posicion As Integer
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        posicion = InStr(celular, ",")
        If posicion > 0 Then
            posicion1 = posicion - 1
            posicion2 = posicion + 1
            cel1 = Mid(celular, 1, posicion1)
            cel2 = Mid(celular, posicion2, largotexto)

            'If Mid(cel1, 1, 2) = "09" Then
            '    celular1 = cel1.Remove(0, 2)
            'Else
            celular1 = cel1
            'End If

            email = celular1
            num1 = Mid(celular1, 3, 1)

            If num1 = "9" Or num1 = "8" Or num1 = "1" Or num1 = "2" Then
                'ancel es numero  + pin
                sms1 = email & "@antelinfo.com.uy"
            ElseIf num1 = "3" Or num1 = "4" Or num1 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular1 = celular.Remove(0, 1)
                End If
                email = celular1
                sms1 = email & "@sms.movistar.com.uy"
            ElseIf num1 = "6" Or num1 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular1
                sms1 = email & "@sms.ctimovil.com.uy"
            End If
            '*****************************************
            'If Mid(cel2, 1, 2) = "09" Then
            '    celular2 = cel2.Remove(0, 2)
            'Else
            celular2 = cel2
            'End If

            email2 = celular2
            num2 = Mid(celular2, 1, 1)

            If num2 = "9" Or num2 = "8" Or num2 = "1" Or num2 = "2" Then
                'ancel es numero (sin 09 inicial + pin)
                sms2 = email2 & "@antelinfo.com.uy"
            ElseIf num2 = "3" Or num2 = "4" Or num2 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular2, 1, 1) = "0" Then
                    celular2 = celular2.Remove(0, 1)
                End If
                email2 = celular2
                sms2 = email2 & "@sms.movistar.com.uy"
            ElseIf num2 = "6" Or num2 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular2, 1, 1) = "0" Then
                    celular2 = celular2.Remove(0, 1)
                End If
                email2 = celular2
                sms2 = email2 & "@sms.ctimovil.com.uy"
            End If
            sms = sms1 & "," & sms2
        Else

            'Dim celular As String = ""

            'celular = TextCelular1.Text.Trim
            nficha = TextId.Text.Trim
            'If Mid(celular, 1, 2) = "09" Then
            '    celular2 = celular.Remove(0, 2)
            'Else
            celular2 = celular
            'End If

            email = celular2
            num1 = Mid(celular2, 1, 1)

            If num1 = "9" Or num1 = "8" Or num1 = "1" Or num1 = "2" Then
                'ancel es numero (sin 09 inicial + pin)
                sms = email & "@antelinfo.com.uy"
            ElseIf num1 = "3" Or num1 = "4" Or num1 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular2
                sms = email & "@sms.movistar.com.uy"
            ElseIf num1 = "6" Or num1 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular2
                sms = email & "@sms.ctimovil.com.uy"
            End If

        End If

        Dim sa As New dSolicitudAnalisis
        Dim p As New dProductor
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        nficha = TextId.Text.Trim
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
        End If


        If sms <> "" Then

            'CONFIGURACIÓN DEL STMP 
            '_SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(sms)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Su solicitud de análisis Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "ha ingresado correctamente al sistema. Gracias. COLAVECO"
            '_Message.Subject = "Su solicitud de análisis número " & " " & nficha & ", " & "ha ingresado correctamente al sistema. Gracias."
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy"
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy"
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Mensaje enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        texto = ""

    End Sub
    Private Sub enviomailpulsa()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        nficha = TextId.Text.Trim
        Dim fichero As String = ""
        fichero = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & nficha & ".xls"
        If email <> "" Then

            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(email)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Solicitud de análisis"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""

            _Message.Body = "Su solicitud de análisis Nº " & " " & nficha & ", " & "ha ingresado correctamente al sistema. Gracias."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        nficha = ""

    End Sub
    Private Sub TextObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextObservaciones.TextChanged

    End Sub

  
    Private Sub CheckSinSolicitud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSinSolicitud.CheckedChanged
        If CheckSinSolicitud.Checked = True Then
            Dim ficha As Long = TextId.Text.Trim
            Dim v As New FormSinSolicitud(Usuario, ficha)
            v.ShowDialog()
        End If
    End Sub

    Private Sub imprimir_ticket_cliente()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As String
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = ""
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""


        'Poner Titulos
        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)
        'Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 100, 40)

        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim

        Dim fila = 3
        Dim columna = 1

        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        Dim pro As New dProductor
        Dim nombre_productor As String = ""
        pro.ID = TextIdProductor.Text.Trim
        pro = pro.buscar
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""

        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)


        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Prodúctos Lácteos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()

            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDYPH = 1 Then
                texto = texto & " " & " - Conductividad y pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If

            If texto.Length > 0 Then

                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                    Next

                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next

                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next

                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)

            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                    Next

                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)

            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Agro Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Agro Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A9", "G10").Merge()
            x1hoja.Range("A9", "G10").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************



        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        '*** LISTADO DE MUESTRAS *********************************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************

        If tipoinforme = "Prodúctos Lácteos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5


            ' SI ES AGUA ********************************************************************************

        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES CALIDAD ********************************************************************************

        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA

                        If csm.RB = 1 Then

                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then

                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then

                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then

                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then

                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.ESPORULADOS = 1 Then

                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then

                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then

                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then

                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then

                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then

                            cuenta_caseina = cuenta_caseina + 1
                        End If

                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G16").Merge()
            x1hoja.Range("A13", "G16").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9

            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If

            fila = fila + 4

            'x1hoja.Range("A27", "G28").Merge()
            'x1hoja.Range("A27", "G28").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9

            fila = fila + 1



            ' SI ES CONTROL LECHERO ********************************************************************************

        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES ANTIBIOGRAMA ********************************************************************************

        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES AMBIENTAL ********************************************************************************

        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PARASITOLOGÍA ********************************************************************************

        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PAL ********************************************************************************

        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            Dim solpal As New dSolicitudPAL
            solpal.IDSOLICITUD = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If

            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************

        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Agro Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Agro Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2

        x1hoja.Cells(fila, columna).formula = "En nuestro sitio web www.colaveco.com.uy, puede ver el estado de su solicitud."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Email: colaveco@gmail.com - web: www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo,"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True

        ' SEGUNDA COPIA *************************************************************************************************************************************
        fila = fila + 4
        columna = 1

        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1



        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Prodúctos Lácteos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()

            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDYPH = 1 Then
                texto = texto & " " & " - Conductividad y pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If

            If texto.Length > 0 Then

                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                    Next

                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next

                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next

                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)

            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                    Next

                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)

            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Agro Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Agro Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A36", "G37").Merge()
            x1hoja.Range("A36", "G37").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************



        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        '*** LISTADO DE MUESTRAS *********************************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************

        If tipoinforme = "Prodúctos Lácteos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5


            ' SI ES AGUA ********************************************************************************

        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES CALIDAD ********************************************************************************

        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA

                        If csm.RB = 1 Then

                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then

                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then

                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then

                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then

                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.ESPORULADOS = 1 Then

                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then

                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then

                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then

                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then

                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then

                            cuenta_caseina = cuenta_caseina + 1
                        End If

                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G43").Merge()
            x1hoja.Range("A40", "G43").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9

            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If

            fila = fila + 4

            'x1hoja.Range("A45", "G46").Merge()
            'x1hoja.Range("A45", "G46").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9

            fila = fila + 1



            ' SI ES CONTROL LECHERO ********************************************************************************

        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES ANTIBIOGRAMA ********************************************************************************

        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES AMBIENTAL ********************************************************************************

        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PARASITOLOGÍA ********************************************************************************

        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PAL ********************************************************************************

        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            Dim solpal As New dSolicitudPAL
            solpal.IDSOLICITUD = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If

            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************

        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Agro Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Agro Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2

        x1hoja.Cells(fila, columna).formula = "En nuestro sitio web www.colaveco.com.uy, puede ver el estado de su solicitud."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Email: colaveco@gmail.com - web: www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo,"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True

        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "FIRMA DEL CLIENTE: ________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10


        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\TICKET_CLIENTES\TC" & ficha & ".xls")




        x1app.Visible = True
        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    

End Class