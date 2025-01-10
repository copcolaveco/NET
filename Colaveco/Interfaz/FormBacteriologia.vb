Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormBacteriologia
    Private _usuario As dUsuario
    Dim idsol As Long
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
        listarfichas()
        cargarCombos()
        limpiar()
    End Sub
#End Region

    Public Sub listarfichas()
        Dim b As New dBacteriologia
        Dim lista As New ArrayList
        lista = b.listarfichas
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each b In lista
                    ListFichas().Items.Add(b)
                Next
            End If
        End If
    End Sub

    Public Sub listarbacteriologia()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim b As dBacteriologia = CType(ListFichas.SelectedItem, dBacteriologia)
            Dim id As Long = b.FICHA
            idsol = id
            Dim lista As New ArrayList
            lista = b.listarporsolicitud(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each b In lista
                        ListMuestras().Items.Add(b)
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        DateFechaSolicitud.Value = Now()
        TextMuestra.Text = ""
        DateFechaProceso.Value = Now()
        TextRC.Text = ""
        TextRB.Text = ""
        TextColiformes.Text = ""
        TextTermoduricos.Text = ""
        ComboEstreptococoAg.Text = ""
        TextEstreptococoDys.Text = ""
        TextEstreptococoUb.Text = ""
        TextEstreptococoSpp.Text = ""
        TextEstafilococoau.Text = ""
        TextestapylococoCoagNeg.Text = ""
        TextPsicrotrofos.Text = ""
        ComboCorynebacterium.Text = ""
        ComboOtros.Text = ""
        TextObservaciones.Text = ""
        
    End Sub

    Public Sub cargarCombos()
        
        ComboEstreptococoAg.Items.Add("Detectado")
        ComboEstreptococoAg.Items.Add("No detectado")
        ComboCorynebacterium.Items.Add("Detectado")
        ComboCorynebacterium.Items.Add("No detectado")
        ComboOtros.Items.Add("Detectado")
        ComboOtros.Items.Add("No detectado")
            
    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim b As dBacteriologia = CType(ListFichas.SelectedItem, dBacteriologia)
            Dim id As Long = b.FICHA
            Dim lista As New ArrayList
            lista = b.listarporid(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each b In lista
                        ListMuestras().Items.Add(b)
                    Next
                End If
            End If

        End If
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim b As dBacteriologia = CType(ListMuestras.SelectedItem, dBacteriologia)
            
            TextId.Text = b.ID
            TextFicha.Text = b.FICHA
            DateFechaSolicitud.Value = b.FECHASOLICITUD
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = b.IDMUESTRA
            If b.FECHAPROCESO <> "00:00:00" Then
                DateFechaProceso.Value = b.FECHAPROCESO
            Else
                DateFechaProceso.Value = Now()
            End If
            If b.RC <> "-1" Then
                TextRC.Text = b.RC
            End If
            If b.RB <> "-1" Then
                TextRB.Text = b.RB
            End If
            If b.COLIFORMES <> "-1" Then
                TextColiformes.Text = b.COLIFORMES
            End If
            If b.TERMODURICOS <> "-1" Then
                TextTermoduricos.Text = b.TERMODURICOS
            End If
            If b.ESTREPTOCOCOAG <> "-1" Then
                ComboEstreptococoAg.Text = b.ESTREPTOCOCOAG
            End If
            If b.ESTREPTOCOCODYS <> "-1" Then
                TextEstreptococoDys.Text = b.ESTREPTOCOCODYS
            End If
            If b.ESTREPTOCOCOUB <> "-1" Then
                TextEstreptococoUb.Text = b.ESTREPTOCOCOUB
            End If
            If b.ESTREPTOCOCOSPP <> "-1" Then
                TextEstreptococoSpp.Text = b.ESTREPTOCOCOSPP
            End If
            If b.ESTAFILOCOCOAU <> "-1" Then
                TextEstafilococoau.Text = b.ESTAFILOCOCOAU
            End If
            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                TextestapylococoCoagNeg.Text = b.ESTAPYLOCOCOCOAGNEG
            End If
            If b.PSICROTROFOS <> "-1" Then
                TextPsicrotrofos.Text = b.PSICROTROFOS
            End If
            If b.CORYNEBACTERIUM <> "-1" Then
                ComboCorynebacterium.Text = b.CORYNEBACTERIUM
            End If
            If b.OTROS <> "-1" Then
                ComboOtros.Text = b.OTROS
            End If
            If b.OBSERVACIONES <> "-1" Then
                TextObservaciones.Text = b.OBSERVACIONES
            End If
        End If
    End Sub
    Private Sub guardar()
        Dim ficha As Long = TextFicha.Text.Trim
        Dim fechasolicitud As Date = DateFechaSolicitud.Value.ToString("yyyy-MM-dd")
        Dim fechasol As String
        fechasol = Format(fechasolicitud, "yyyy-MM-dd")
        Dim fechaproceso As Date = Now()
        Dim fechapro As String
        fechapro = Format(fechaproceso, "yyyy-MM-dd")
        If TextMuestra.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestra.Focus() : Exit Sub
        Dim idmuestra As String = TextMuestra.Text.Trim
        Dim rc As String
        If TextRC.Text <> "" Then
            rc = TextRC.Text.Trim
        Else
            rc = -1
        End If
        Dim rb As String
        If TextRB.Text <> "" Then
            rb = TextRB.Text.Trim
        Else
            rb = -1
        End If
        Dim coliformes As String
        If TextColiformes.Text <> "" Then
            coliformes = TextColiformes.Text.Trim
        Else
            coliformes = -1
        End If
        Dim termoduricos As String
        If TextTermoduricos.Text <> "" Then
            termoduricos = TextTermoduricos.Text.Trim
        Else
            termoduricos = -1
        End If
        Dim estreptococoag As String
        If ComboEstreptococoAg.Text <> "" Then
            estreptococoag = ComboEstreptococoAg.Text
        Else
            estreptococoag = -1
        End If
        'Dim estreptococodys As String
        'If TextEstreptococoDys.Text <> "" Then
        '    estreptococodys = TextEstreptococoDys.Text
        'Else
        '    estreptococodys = -1
        'End If
        Dim estreptococoub As String
        If TextEstreptococoUb.Text <> "" Then
            estreptococoub = TextEstreptococoUb.Text
        Else
            estreptococoub = -1
        End If
        Dim estreptococospp As String
        If TextEstreptococoSpp.Text <> "" Then
            estreptococospp = TextEstreptococoSpp.Text
        Else
            estreptococospp = -1
        End If
        Dim estafilococoau As String
        If TextEstafilococoau.Text <> "" Then
            estafilococoau = TextEstafilococoau.Text
        Else
            estafilococoau = -1
        End If
        Dim estapylocococoagneg As String
        If TextestapylococoCoagNeg.Text <> "" Then
            estapylocococoagneg = TextestapylococoCoagNeg.Text
        Else
            estapylocococoagneg = -1
        End If
        Dim psicrotrofos As String
        If TextPsicrotrofos.Text <> "" Then
            psicrotrofos = TextPsicrotrofos.Text.Trim
        Else
            psicrotrofos = -1
        End If
        'Dim corynebacterium As String
        'If ComboCorynebacterium.Text <> "" Then
        '    corynebacterium = ComboCorynebacterium.Text
        'Else
        '    corynebacterium = -1
        'End If
        'Dim otros As String
        'If ComboOtros.Text <> "" Then
        '    otros = ComboOtros.Text
        'Else
        '    otros = -1
        'End If
        Dim observaciones As String
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        Else
            observaciones = -1
        End If
        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim b As New dBacteriologia()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            b.ID = id
            b.FICHA = ficha
            b.FECHASOLICITUD = fechasol
            b.FECHAPROCESO = fechapro
            b.IDMUESTRA = idmuestra
            b.RC = rc
            b.RB = rb
            b.COLIFORMES = coliformes
            b.TERMODURICOS = termoduricos
            b.ESTREPTOCOCOAG = estreptococoag
            'b.ESTREPTOCOCODYS = estreptococodys
            b.ESTREPTOCOCOUB = estreptococoub
            b.ESTREPTOCOCOSPP = estreptococospp
            b.ESTAFILOCOCOAU = estafilococoau
            b.ESTAPYLOCOCOCOAGNEG = estapylocococoagneg
            b.PSICROTROFOS = psicrotrofos
            'b.CORYNEBACTERIUM = corynebacterium
            'b.OTROS = otros
            b.OBSERVACIONES = observaciones
            b.OPERADOR = operador
            b.MARCA = 0
            If (b.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim b As New dBacteriologia()
            b.FICHA = ficha
            b.FECHASOLICITUD = fechasol
            b.FECHAPROCESO = fechapro
            b.IDMUESTRA = idmuestra
            b.RC = rc
            b.RB = rb
            b.COLIFORMES = coliformes
            b.TERMODURICOS = termoduricos
            b.ESTREPTOCOCOAG = estreptococoag
            'b.ESTREPTOCOCODYS = estreptococodys
            b.ESTREPTOCOCOUB = estreptococoub
            b.ESTREPTOCOCOSPP = estreptococospp
            b.ESTAFILOCOCOAU = estafilococoau
            b.ESTAPYLOCOCOCOAGNEG = estapylocococoagneg
            b.PSICROTROFOS = psicrotrofos
            'b.CORYNEBACTERIUM = corynebacterium
            'b.OTROS = otros
            b.OBSERVACIONES = observaciones
            b.OPERADOR = operador
            b.MARCA = 0
            If (b.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonGenerarInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerarInforme.Click
        guardar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim b As dBacteriologia = CType(ListFichas.SelectedItem, dBacteriologia)
            Dim id As Long = b.FICHA
            Dim lista As New ArrayList
            lista = b.listarporid(id)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each b In lista
                        Dim fechaproceso As Date = Now()
                        Dim fechapro As String
                        fechapro = Format(fechaproceso, "yyyy-MM-dd")
                        b.MARCA = 1
                        b.FECHAPROCESO = fechapro
                        If (b.modificar2(Usuario)) Then
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    Next
                End If
            End If
            listarbacteriologia()
            If ListMuestras.Items.Count = 0 Then
                creainformeexcel()
                listarfichas()
            End If
        End If
    End Sub
    Private Sub creainformeexcel()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)
        Dim b As New dBacteriologia
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim lista As New ArrayList
        '*****************************
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        x1hoja.Cells(6, 2).formula = sa.ID
        x1hoja.Cells(6, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(7, 2).formula = pro.NOMBRE
        x1hoja.Cells(7, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(7, 2).Font.Size = 9
        x1hoja.Cells(8, 2).formula = pro.DIRECCION
        x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 2).Font.Size = 9
        lista = b.listarporsolicitud2(idsol)
        'x1hoja.Range("H8", "J8").Merge()
        x1hoja.Cells(6, 6).formula = sa.FECHAINGRESO
        x1hoja.Cells(6, 6).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 6).Font.Size = 9
        'x1hoja.Range("H9", "L9").Merge()
        'x1hoja.Range("H10", "L10").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(8, 6).formula = fecha2
        x1hoja.Cells(8, 6).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 6).Font.Size = 9
        Dim fila As Integer
        Dim columna As Integer
        'fila = 17
        'columna = 1
        'ListAntibiogramas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 2
                'Poner Titulos
                x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
                Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)
                x1hoja.Cells(3, 1).columnwidth = 15 '15
                x1hoja.Cells(3, 2).columnwidth = 16 '27
                x1hoja.Cells(3, 3).columnwidth = 11 '17
                x1hoja.Cells(3, 4).columnwidth = 11 '24
                x1hoja.Cells(3, 5).columnwidth = 10
                x1hoja.Cells(3, 6).columnwidth = 16 '24
                x1hoja.Range("A1", "D1").Merge()
                columna = 2
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Formula = "Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Range("B4", "C4").Merge()
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Range("A5", "F5").Merge()
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "BACTERIOLOGÍA DE TANQUE"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Cliente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Fecha informe:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Dirección:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "RESULTADO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                Dim linea As Integer = 0
                Dim i As Integer = 1
                Dim contadormuestras As Integer = 0
                contadormuestras = lista.Count
                For Each b In lista
                    x1hoja.Cells(7, 6).formula = b.FECHAPROCESO
                    x1hoja.Cells(7, 6).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(7, 6).Font.Size = 9
                    x1app.Visible = True
                    'PRODUCTO 1 ****************************************************************
                    If i = 1 Then
                        x1hoja.Range("A12", "B12").Merge()
                        x1hoja.Range("A12", "B12").Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = "Meta"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Fuente"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 5
                        linea = linea + 1
                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A13", "B13").Merge()
                            x1hoja.Range("A13", "B13").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A13", "B13").Merge()
                            x1hoja.Range("A13", "B13").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A14", "B14").Merge()
                            x1hoja.Range("A14", "B14").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A14", "B14").Merge()
                            x1hoja.Range("A14", "B14").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A15", "B15").Merge()
                            x1hoja.Range("A15", "B15").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A15", "B15").Merge()
                            x1hoja.Range("A15", "B15").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A16", "B16").Merge()
                            x1hoja.Range("A16", "B16").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A16", "B16").Merge()
                            x1hoja.Range("A16", "B16").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A19", "B19").Merge()
                            x1hoja.Range("A19", "B19").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A19", "B19").Merge()
                            x1hoja.Range("A19", "B19").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A18", "B18").Merge()
                            x1hoja.Range("A18", "B18").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A18", "B18").Merge()
                            x1hoja.Range("A18", "B18").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A17", "B17").Merge()
                            x1hoja.Range("A17", "B17").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A17", "B17").Merge()
                            x1hoja.Range("A17", "B17").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A18", "B18").Merge()
                        '    x1hoja.Range("A18", "B18").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                        '    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A18", "B18").Merge()
                        '    x1hoja.Range("A18", "B18").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A19", "B19").Merge()
                            x1hoja.Range("A19", "B19").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A19", "B19").Merge()
                            x1hoja.Range("A19", "B19").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A20", "B20").Merge()
                            x1hoja.Range("A20", "B20").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A20", "B20").Merge()
                            x1hoja.Range("A20", "B20").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A21", "B21").Merge()
                            x1hoja.Range("A21", "B21").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A21", "B21").Merge()
                            x1hoja.Range("A21", "B21").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                            'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A24", "B24").Merge()
                        '    x1hoja.Range("A24", "B24").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A24", "B24").Merge()
                        '    x1hoja.Range("A24", "B24").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A25", "B25").Merge()
                        '    x1hoja.Range("A25", "B25").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A25", "B25").Merge()
                        '    x1hoja.Range("A25", "B25").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene solo una muestra
                        If contadormuestras = 1 Then
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 4
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                          
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 2 ****************************************************************
                    If i = 2 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 3
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene dos muestras
                        If contadormuestras > 1 Then
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 1
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 3 ****************************************************************
                    If i = 3 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Range("A27", "B27").Merge()
                        x1hoja.Range("A27", "B27").Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = "Meta"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Fuente"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 5
                        linea = linea + 1
                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A28", "B28").Merge()
                            x1hoja.Range("A28", "B28").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A28", "B28").Merge()
                            x1hoja.Range("A28", "B28").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A29", "B29").Merge()
                            x1hoja.Range("A29", "B29").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A29", "B29").Merge()
                            x1hoja.Range("A29", "B29").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A30", "B30").Merge()
                            x1hoja.Range("A30", "B30").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A30", "B30").Merge()
                            x1hoja.Range("A30", "B30").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A31", "B31").Merge()
                            x1hoja.Range("A31", "B31").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A31", "B31").Merge()
                            x1hoja.Range("A31", "B31").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A34", "B34").Merge()
                            x1hoja.Range("A34", "B34").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A34", "B34").Merge()
                            x1hoja.Range("A34", "B34").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A33", "B33").Merge()
                            x1hoja.Range("A33", "B33").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A33", "B33").Merge()
                            x1hoja.Range("A33", "B33").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A32", "B32").Merge()
                            x1hoja.Range("A32", "B32").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A32", "B32").Merge()
                            x1hoja.Range("A32", "B32").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A35", "B35").Merge()
                        '    x1hoja.Range("A35", "B35").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A35", "B35").Merge()
                        '    x1hoja.Range("A35", "B35").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A36", "B36").Merge()
                            x1hoja.Range("A36", "B36").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A36", "B36").Merge()
                            x1hoja.Range("A36", "B36").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A37", "B37").Merge()
                            x1hoja.Range("A37", "B37").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A37", "B37").Merge()
                            x1hoja.Range("A37", "B37").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A38", "B38").Merge()
                            x1hoja.Range("A38", "B38").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A38", "B38").Merge()
                            x1hoja.Range("A38", "B38").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A39", "B39").Merge()
                        '    x1hoja.Range("A39", "B39").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A39", "B39").Merge()
                        '    x1hoja.Range("A39", "B39").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A40", "B40").Merge()
                        '    x1hoja.Range("A40", "B40").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A40", "B40").Merge()
                        '    x1hoja.Range("A40", "B40").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene 3 muestras
                        If contadormuestras = 3 Then
                            columna = 1
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 4
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 4 ****************************************************************
                    If i = 4 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 3
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene mas de 3 muestras
                        If contadormuestras > 3 Then
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 1
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 5 ****************************************************************
                    If i = 5 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Range("A42", "B42").Merge()
                        x1hoja.Range("A42", "B42").Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = "Meta"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Fuente"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 5
                        linea = linea + 1
                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A43", "B43").Merge()
                            x1hoja.Range("A43", "B43").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A43", "B43").Merge()
                            x1hoja.Range("A43", "B43").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A44", "B44").Merge()
                            x1hoja.Range("A44", "B44").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A44", "B44").Merge()
                            x1hoja.Range("A44", "B44").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A45", "B45").Merge()
                            x1hoja.Range("A45", "B45").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A45", "B45").Merge()
                            x1hoja.Range("A45", "B45").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A46", "B46").Merge()
                            x1hoja.Range("A46", "B46").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A46", "B46").Merge()
                            x1hoja.Range("A46", "B46").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A49", "B49").Merge()
                            x1hoja.Range("A49", "B49").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A49", "B49").Merge()
                            x1hoja.Range("A49", "B49").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A48", "B48").Merge()
                            x1hoja.Range("A48", "B48").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A48", "B48").Merge()
                            x1hoja.Range("A48", "B48").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A47", "B47").Merge()
                            x1hoja.Range("A47", "B47").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A47", "B47").Merge()
                            x1hoja.Range("A47", "B47").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A50", "B50").Merge()
                        '    x1hoja.Range("A50", "B50").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A50", "B50").Merge()
                        '    x1hoja.Range("A50", "B50").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A51", "B51").Merge()
                            x1hoja.Range("A51", "B51").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A51", "B51").Merge()
                            x1hoja.Range("A51", "B51").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A52", "B52").Merge()
                            x1hoja.Range("A52", "B52").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A52", "B52").Merge()
                            x1hoja.Range("A52", "B52").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A53", "B53").Merge()
                            x1hoja.Range("A53", "B53").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A53", "B53").Merge()
                            x1hoja.Range("A53", "B53").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A54", "B54").Merge()
                        '    x1hoja.Range("A54", "B54").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A54", "B54").Merge()
                        '    x1hoja.Range("A54", "B54").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A55", "B55").Merge()
                        '    x1hoja.Range("A55", "B55").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A55", "B55").Merge()
                        '    x1hoja.Range("A55", "B55").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene 5 muestras
                        If contadormuestras = 5 Then
                            columna = 1
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 4
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 6 ****************************************************************
                    If i = 6 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 3
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1
                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene mas de 5 muestras
                        If contadormuestras > 5 Then
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 1
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 7 ****************************************************************
                    If i = 7 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Range("A57", "B57").Merge()
                        x1hoja.Range("A57", "B57").Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = "Meta"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Fuente"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 5
                        linea = linea + 1
                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A58", "B58").Merge()
                            x1hoja.Range("A58", "B58").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A58", "B58").Merge()
                            x1hoja.Range("A58", "B58").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A59", "B59").Merge()
                            x1hoja.Range("A59", "B59").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A59", "B59").Merge()
                            x1hoja.Range("A59", "B59").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A60", "B60").Merge()
                            x1hoja.Range("A60", "B60").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A60", "B60").Merge()
                            x1hoja.Range("A60", "B60").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A61", "B61").Merge()
                            x1hoja.Range("A61", "B61").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A61", "B61").Merge()
                            x1hoja.Range("A61", "B61").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A64", "B64").Merge()
                            x1hoja.Range("A64", "B64").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A64", "B64").Merge()
                            x1hoja.Range("A64", "B64").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A63", "B63").Merge()
                            x1hoja.Range("A63", "B63").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A63", "B63").Merge()
                            x1hoja.Range("A63", "B63").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A62", "B62").Merge()
                            x1hoja.Range("A62", "B62").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A62", "B62").Merge()
                            x1hoja.Range("A62", "B62").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A65", "B65").Merge()
                        '    x1hoja.Range("A65", "B65").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A65", "B65").Merge()
                        '    x1hoja.Range("A65", "B65").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A66", "B66").Merge()
                            x1hoja.Range("A66", "B66").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A66", "B66").Merge()
                            x1hoja.Range("A66", "B66").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A67", "B67").Merge()
                            x1hoja.Range("A67", "B67").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A67", "B67").Merge()
                            x1hoja.Range("A67", "B67").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A68", "B68").Merge()
                            x1hoja.Range("A68", "B68").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A68", "B68").Merge()
                            x1hoja.Range("A68", "B68").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A69", "B69").Merge()
                        '    x1hoja.Range("A69", "B69").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A69", "B69").Merge()
                        '    x1hoja.Range("A69", "B69").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A70", "B70").Merge()
                        '    x1hoja.Range("A70", "B70").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A70", "B70").Merge()
                        '    x1hoja.Range("A70", "B70").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene 7 muestras
                        If contadormuestras = 7 Then
                            columna = 1
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 4
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 8 ****************************************************************
                    If i = 8 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 3
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene mas de 7 muestras
                        If contadormuestras > 7 Then
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 1
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 9 ****************************************************************
                    If i = 9 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Range("A72", "B72").Merge()
                        x1hoja.Range("A72", "B72").Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = "Meta"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Fuente"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 5
                        linea = linea + 1
                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A73", "B73").Merge()
                            x1hoja.Range("A73", "B73").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A73", "B73").Merge()
                            x1hoja.Range("A73", "B73").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A74", "B74").Merge()
                            x1hoja.Range("A74", "B74").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A74", "B74").Merge()
                            x1hoja.Range("A74", "B74").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A75", "B75").Merge()
                            x1hoja.Range("A75", "B75").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A75", "B75").Merge()
                            x1hoja.Range("A75", "B75").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A76", "B76").Merge()
                            x1hoja.Range("A76", "B76").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A76", "B76").Merge()
                            x1hoja.Range("A76", "B76").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A79", "B79").Merge()
                            x1hoja.Range("A79", "B79").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A79", "B79").Merge()
                            x1hoja.Range("A79", "B79").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A78", "B78").Merge()
                            x1hoja.Range("A78", "B78").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A78", "B78").Merge()
                            x1hoja.Range("A78", "B78").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A77", "B77").Merge()
                            x1hoja.Range("A77", "B77").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A77", "B77").Merge()
                            x1hoja.Range("A77", "B77").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A80", "B80").Merge()
                        '    x1hoja.Range("A80", "B80").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A80", "B80").Merge()
                        '    x1hoja.Range("A80", "B80").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A81", "B81").Merge()
                            x1hoja.Range("A81", "B81").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A81", "B81").Merge()
                            x1hoja.Range("A81", "B81").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A82", "B82").Merge()
                            x1hoja.Range("A82", "B82").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A82", "B82").Merge()
                            x1hoja.Range("A82", "B82").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A83", "B83").Merge()
                            x1hoja.Range("A83", "B83").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A83", "B83").Merge()
                            x1hoja.Range("A83", "B83").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A84", "B84").Merge()
                        '    x1hoja.Range("A84", "B84").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A84", "B84").Merge()
                        '    x1hoja.Range("A84", "B84").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A85", "B85").Merge()
                        '    x1hoja.Range("A85", "B85").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A85", "B85").Merge()
                        '    x1hoja.Range("A85", "B85").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene 9 muestras
                        If contadormuestras = 9 Then
                            columna = 1
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 4
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 10 ****************************************************************
                    If i = 10 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 3
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene mas de 9 muestras
                        If contadormuestras > 9 Then
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 1
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 11 ****************************************************************
                    If i = 11 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Range("A87", "B87").Merge()
                        x1hoja.Range("A87", "B87").Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = "Meta"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Fuente"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 5
                        linea = linea + 1
                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A88", "B88").Merge()
                            x1hoja.Range("A88", "B88").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A88", "B88").Merge()
                            x1hoja.Range("A88", "B88").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento celular (x 1000 cels/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A89", "B89").Merge()
                            x1hoja.Range("A89", "B89").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A89", "B89").Merge()
                            x1hoja.Range("A89", "B89").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A90", "B90").Merge()
                            x1hoja.Range("A90", "B90").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A90", "B90").Merge()
                            x1hoja.Range("A90", "B90").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Coliformes (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A91", "B91").Merge()
                            x1hoja.Range("A91", "B91").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A91", "B91").Merge()
                            x1hoja.Range("A91", "B91").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Termodúricos (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A94", "B94").Merge()
                            x1hoja.Range("A94", "B94").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A94", "B94").Merge()
                            x1hoja.Range("A94", "B94").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo uberis (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A93", "B93").Merge()
                            x1hoja.Range("A93", "B93").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A93", "B93").Merge()
                            x1hoja.Range("A93", "B93").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo dysgalactiae (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A92", "B92").Merge()
                            x1hoja.Range("A92", "B92").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A92", "B92").Merge()
                            x1hoja.Range("A92", "B92").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estreptococo agalactiae:"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A95", "B95").Merge()
                        '    x1hoja.Range("A95", "B95").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A95", "B95").Merge()
                        '    x1hoja.Range("A95", "B95").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Estreptococo spp (UFC/ml):"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A96", "B96").Merge()
                            x1hoja.Range("A96", "B96").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A96", "B96").Merge()
                            x1hoja.Range("A96", "B96").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo aureus (UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A97", "B97").Merge()
                            x1hoja.Range("A97", "B97").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A97", "B97").Merge()
                            x1hoja.Range("A97", "B97").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Estafilococo coag. negativos(UFC/ml):"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Range("A98", "B98").Merge()
                            x1hoja.Range("A98", "B98").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Range("A98", "B98").Merge()
                            x1hoja.Range("A98", "B98").Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Formula = "Psicrotrofos (x 1000 UFC/ml)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 2
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A99", "B99").Merge()
                        '    x1hoja.Range("A99", "B99").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A99", "B99").Merge()
                        '    x1hoja.Range("A99", "B99").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Corynebacterium bovis:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Range("A100", "B100").Merge()
                        '    x1hoja.Range("A100", "B100").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'Else
                        '    fila = fila + 1
                        '    x1hoja.Range("A100", "B100").Merge()
                        '    x1hoja.Range("A100", "B100").Borders.Color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Formula = "Otros micro-organismos:"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = True
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna + 2
                        '    x1hoja.Cells(fila, columna).Formula = "---"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    columna = columna - 2
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene 11 muestras
                        If contadormuestras = 11 Then
                            columna = 1
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 4
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'PRODUCTO 12 ****************************************************************
                    If i = 12 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 3
                        x1hoja.Cells(fila, columna).Formula = b.IDMUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If b.RC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.COLIFORMES <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.COLIFORMES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.TERMODURICOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.TERMODURICOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOUB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOUB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCODYS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCODYS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTREPTOCOCOAG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOAG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.ESTREPTOCOCOSPP <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.ESTREPTOCOCOSPP
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        If b.ESTAFILOCOCOAU <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAFILOCOCOAU
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.ESTAPYLOCOCOCOAGNEG
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        If b.PSICROTROFOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = b.PSICROTROFOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            linea = linea + 1
                        End If
                        'If b.CORYNEBACTERIUM <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.CORYNEBACTERIUM
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'If b.OTROS <> "-1" Then
                        '    fila = fila + 1
                        '    x1hoja.Cells(fila, columna).Formula = b.OTROS
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        '    x1hoja.Cells(fila, columna).Font.Bold = False
                        '    x1hoja.Cells(fila, columna).Font.Size = 10
                        '    linea = linea + 1
                        'End If
                        'Si la lista tiene mas de 11 muestras
                        If contadormuestras > 11 Then
                            fila = fila - linea
                            fila = fila + 2
                            linea = 0
                            columna = columna + 1
                            If b.RC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<200.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.RB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<10.000"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, tanque, pezón, falta frío"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.COLIFORMES <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.TERMODURICOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "máquina"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOUB <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCODYS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<150"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTREPTOCOCOAG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "ausente"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.ESTREPTOCOCOSPP <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "<150"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "ubre, pezón, ambiente"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            If b.ESTAFILOCOCOAU <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<100"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.ESTAPYLOCOCOCOAGNEG <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<1200"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "ubre, pezón"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).WrapText = True
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            If b.PSICROTROFOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "<5000 ufc/ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "agua, tanque, máquina, ubres sucias"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna - 1
                                fila = fila + 1
                                linea = linea + 1
                            End If
                            'If b.CORYNEBACTERIUM <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    fila = fila + 1
                            '    linea = linea + 1
                            'End If
                            'If b.OTROS <> "-1" Then
                            '    x1hoja.Cells(fila, columna).Formula = "??????"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = "!?!?!?"
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    x1hoja.Cells(fila, columna).WrapText = True
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'Else
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna + 1
                            '    x1hoja.Cells(fila, columna).Formula = ""
                            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            '    x1hoja.Cells(fila, columna).Font.Bold = False
                            '    x1hoja.Cells(fila, columna).Font.Size = 10
                            '    columna = columna - 1
                            '    linea = linea + 1
                            'End If
                        End If
                    End If
                    'Next i
                    i = i + 1
                Next
                '***************************************
                fila = fila + 1
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Nota:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 10
                If sa.OBSERVACIONES <> "" Then
                    columna = columna + 1
                    'x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    columna = 1
                End If
                fila = fila + 1
                '******* CALCULO PRECIO ************************************************************************
                Dim bact As New dBacteriologia
                Dim listamuestras As New ArrayList
                listamuestras = bact.listarporid(idsol)

                Dim ana As New dAnalisis
                Dim idbacteriologia As Integer = 7
                Dim idtimbre As Integer = 86
                Dim preciobacteriologia As Double = 0
                Dim preciotimbre As Double = 0

                ana.ID = idbacteriologia
                ana = ana.buscar
                preciobacteriologia = ana.COSTO
                ana.ID = idtimbre
                ana = ana.buscar
                preciotimbre = ana.COSTO
                Dim total As Double
                Dim muestras As Integer
                muestras = listamuestras.Count
                total = muestras * preciobacteriologia
                total = total + preciotimbre
                '***********************************************************************************************
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 9
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Técnico responsable:" & " " & ComboOperador.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 9
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 9
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                Dim rangeFirma As String = "A" + fila.ToString
                x1libro.ActiveSheet.Range(rangeFirma).select()
                InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 5
                x1hoja.Cells(fila, columna).formula = "Este informe no podra ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Los resultados consignados se refieren exclusivamente a la muestra recibida."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "asi como el plan, procedimientos de muestreo e información brindada por el cliente. Dra. Cecilia Abelenda (DT)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
            End If
        End If
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\ANTIBIOGRAMA\Bacteriologia\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & idsol & ".xls")
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub


    Sub InsertImageToDeclaredVariable(ByVal x1libro As Microsoft.Office.Interop.Excel.Workbook, ByVal rangeFirma As String, ByVal imagePath As String)

        Dim myImage As Shape
        Dim ws As Microsoft.Office.Interop.Excel.Worksheet

        ws = x1libro.ActiveSheet
        myImage = ws.Shapes.AddPicture( _
            Filename:=imagePath, _
            LinkToFile:=Microsoft.Office.Core.MsoTriState.msoFalse, _
            SaveWithDocument:=Microsoft.Office.Core.MsoTriState.msoCTrue, _
            Left:=0, _
            Top:=0, _
            Width:=-1, _
            Height:=-1)
        myImage.Left = x1libro.ActiveSheet.Range(rangeFirma).Left
        myImage.Top = x1libro.ActiveSheet.Range(rangeFirma).Top
    End Sub
End Class