Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormInformes
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarusuarios()
        DateDesde.Value = Now
        DateHasta.Value = Now
        limpiar()
    End Sub
#End Region
    Public Sub cargarusuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboUsuarios.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        RadioTodos.Checked = True
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listar()
    End Sub
    Private Sub listar()
       
    End Sub

    Private Sub ButtonListarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListarTodos.Click
        If RadioTodos.Checked = True Then
            listartodos2()
        Else
            listarindividual()
        End If

        'listarautorizaciones()
    End Sub
    Private Sub listartodos()
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

        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        'fecdesde = Format(fechadesde, "yyyy-MM-dd 00:00:00")
        'fechasta = Format(fechahasta, "yyyy-MM-dd 23:59:59")
        fecdesde = Format(fechadesde, "yyyy-MM-dd")
        fechasta = Format(fechahasta, "yyyy-MM-dd")

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        'Dim idusuario As dUsuarioReloj = CType(ComboUsuarios.SelectedItem, dUsuarioReloj)
        Dim usuario As Integer = 0
        Dim nombreusuario As String = ""
        'If Not idusuario Is Nothing Then
        '    usuario = idusuario.ID
        'End If
        Dim lista As New ArrayList
        Dim m As New dMarcas
        Dim listafechas As New ArrayList

        Dim usu As New dUsuario
        Dim listausuarios As New ArrayList
        listausuarios = usu.listar
        If Not listausuarios Is Nothing Then
            If listausuarios.Count > 0 Then
                For Each usu In listausuarios
                    usuario = usu.ID
                    nombreusuario = usu.NOMBRE

                    lista = m.listarxusuario(usuario, fecdesde, fechasta)

                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then

                            Dim marca1 As Date
                            Dim marca2 As Date
                            Dim marca3 As Date
                            Dim marca4 As Date
                            Dim horas1 As TimeSpan
                            Dim horas2 As TimeSpan
                            'Dim horasdia As TimeSpan
                            Dim horasacumuladas As Integer
                            Dim minutosacumulados As Long
                            Dim hora1 As Integer = 0
                            Dim hora2 As Integer = 0
                            Dim minuto1 As Integer = 0
                            Dim minuto2 As Integer = 0
                            Dim sumahoras As Integer = 0
                            Dim sumaminutos As Integer = 0

                            x1hoja.Cells(1, 1).columnwidth = 20
                            x1hoja.Cells(1, 2).columnwidth = 20
                            x1hoja.Cells(1, 3).columnwidth = 20


                            If nombreusuario <> "" Then
                                x1hoja.Cells(fila, columna).formula = nombreusuario
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 12
                                fila = fila + 2
                            End If

                            Dim dia As Date
                            Dim _dia As String
                            Dim _dia2 As String
                            Dim contador As Integer = 0

                            For Each m In lista

                                Dim m2 As New dMarcas
                                Dim listadia As New ArrayList
                                dia = m.MARCA
                                _dia = Format(dia, "yyyy-MM-dd 00:00:00")
                                _dia2 = Format(dia, "yyyy-MM-dd 23:59:59")
                                Dim cuentamarcas As Integer = 0
                                Dim dia_texto As String = ""
                                Dim diatexto As String = ""
                                Dim fechadia As Date
                                fechadia = dia
                                dia_texto = fechadia.DayOfWeek
                                If dia_texto = "0" Then
                                    diatexto = "Domingo"
                                ElseIf dia_texto = "1" Then
                                    diatexto = "Lunes"
                                ElseIf dia_texto = "2" Then
                                    diatexto = "Martes"
                                ElseIf dia_texto = "3" Then
                                    diatexto = "Miércoles"
                                ElseIf dia_texto = "4" Then
                                    diatexto = "Jueves"
                                ElseIf dia_texto = "5" Then
                                    diatexto = "Viernes"
                                ElseIf dia_texto = "6" Then
                                    diatexto = "Sábado"
                                End If
                                Dim marcas As String = ""
                                listadia = m2.listarxusuario2(usuario, _dia, _dia2)
                                cuentamarcas = listadia.Count

                                If Not listadia Is Nothing Then
                                    If listadia.Count > 0 Then

                                        contador = 1
                                        hora1 = 0
                                        hora2 = 0
                                        minuto1 = 0
                                        minuto2 = 0
                                        For Each m2 In listadia
                                            If cuentamarcas = 2 Or 4 Then
                                                If cuentamarcas = 2 Then
                                                    If m2.TIPOMARCA = 1 Then
                                                        marca1 = m2.MARCA
                                                        marcas = marcas & Mid(marca1, 12, 8)
                                                    Else
                                                        marca2 = m2.MARCA
                                                        marcas = marcas & " - " & Mid(marca2, 12, 8)
                                                    End If
                                                    If contador = 2 Then
                                                        horas1 = marca2 - marca1

                                                        hora1 = horas1.Hours
                                                        minuto1 = horas1.Minutes
                                                        sumahoras = sumahoras + hora1
                                                        sumaminutos = sumaminutos + minuto1
                                                        horasacumuladas = horasacumuladas + hora1 + hora2
                                                        minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                    End If

                                                Else
                                                    If contador = 1 Then
                                                        marca1 = m2.MARCA
                                                        marcas = marcas & Mid(marca1, 12, 8)
                                                    ElseIf contador = 2 Then
                                                        marca2 = m2.MARCA
                                                        marcas = marcas & " - " & Mid(marca2, 12, 8)
                                                    ElseIf contador = 3 Then
                                                        marca3 = m2.MARCA
                                                        marcas = marcas & " / " & Mid(marca3, 12, 8)
                                                    ElseIf contador = 4 Then
                                                        marca4 = m2.MARCA
                                                        marcas = marcas & " - " & Mid(marca4, 12, 8)
                                                    End If
                                                    If contador = 2 Then
                                                        horas1 = marca2 - marca1
                                                    End If
                                                    If contador = 4 Then
                                                        horas2 = marca4 - marca3
                                                    End If

                                                    If contador = 2 Then
                                                        If cuentamarcas = 2 Then
                                                            hora1 = horas1.Hours
                                                            minuto1 = horas1.Minutes
                                                            sumahoras = sumahoras + hora1
                                                            sumaminutos = sumaminutos + minuto1
                                                            horasacumuladas = horasacumuladas + hora1 + hora2
                                                            minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                        Else
                                                            hora1 = horas1.Hours
                                                            minuto1 = horas1.Minutes
                                                            sumahoras = sumahoras + hora1
                                                            sumaminutos = sumaminutos + minuto1
                                                        End If
                                                    ElseIf contador = 4 Then
                                                        hora2 = horas2.Hours
                                                        minuto2 = horas2.Minutes
                                                        sumahoras = sumahoras + hora2
                                                        sumaminutos = sumaminutos + minuto2
                                                        horasacumuladas = horasacumuladas + hora1 + hora2
                                                        minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                    End If
                                                End If
                                            Else

                                            End If

                                            If contador = 2 Then
                                                If cuentamarcas = 2 Then
                                                    Dim calculahoras As Integer = 0
                                                    Dim calculaminutos As Integer = 0
                                                    Dim muestrohoras As Integer
                                                    Dim muestrominutos As Integer
                                                    If sumaminutos > 59 Then
                                                        calculahoras = sumaminutos \ 60
                                                        calculaminutos = sumaminutos Mod 60
                                                        muestrohoras = sumahoras + calculahoras
                                                        muestrominutos = calculaminutos
                                                    Else
                                                        muestrohoras = sumahoras
                                                        muestrominutos = sumaminutos
                                                    End If
                                                    x1hoja.Cells(fila, columna).formula = diatexto
                                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                    columna = columna + 1
                                                    x1hoja.Cells(fila, columna).formula = m.MARCA
                                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                    columna = columna + 1
                                                    x1hoja.Cells(fila, columna).formula = muestrohoras & ":" & muestrominutos
                                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                    columna = columna + 1
                                                    x1hoja.Cells(fila, columna).formula = marcas
                                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                    fila = fila + 1
                                                    columna = 1
                                                    sumahoras = 0
                                                    sumaminutos = 0
                                                End If
                                            ElseIf contador = 4 Then
                                                If cuentamarcas = 4 Then
                                                    Dim calculahoras As Integer = 0
                                                    Dim calculaminutos As Integer = 0
                                                    Dim muestrohoras As Integer
                                                    Dim muestrominutos As Integer
                                                    If sumaminutos > 59 Then
                                                        calculahoras = sumaminutos \ 60
                                                        calculaminutos = sumaminutos Mod 60
                                                        muestrohoras = sumahoras + calculahoras
                                                        muestrominutos = calculaminutos
                                                    Else
                                                        muestrohoras = sumahoras
                                                        muestrominutos = sumaminutos
                                                    End If
                                                    x1hoja.Cells(fila, columna).formula = diatexto
                                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                    columna = columna + 1
                                                    x1hoja.Cells(fila, columna).formula = m.MARCA
                                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                    columna = columna + 1
                                                    x1hoja.Cells(fila, columna).formula = muestrohoras & ":" & muestrominutos
                                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                    columna = columna + 1
                                                    x1hoja.Cells(fila, columna).formula = marcas
                                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                    fila = fila + 1
                                                    columna = 1
                                                    sumahoras = 0
                                                    sumaminutos = 0
                                                End If
                                            End If
                                            contador = contador + 1
                                            If contador = 5 Then
                                                contador = 0
                                            End If
                                        Next
                                    End If
                                End If


                            Next
                            Dim calculahorastotal As Integer = 0
                            Dim calculaminutostotal As Integer = 0
                            Dim muestrohorastotal As Integer
                            Dim muestrominutostotal As Integer
                            If minutosacumulados > 59 Then
                                calculahorastotal = minutosacumulados \ 60
                                calculaminutostotal = minutosacumulados Mod 60
                                muestrohorastotal = horasacumuladas + calculahorastotal
                                muestrominutostotal = calculaminutostotal
                            Else
                                muestrohorastotal = horasacumuladas
                                muestrominutostotal = minutosacumulados
                            End If
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).formula = muestrohorastotal & ":" & muestrominutostotal
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)

                            horasacumuladas = 0
                            minutosacumulados = 0
                            fila = fila + 2

                        End If
                    End If

                    '**** AUTORIZACIONES ****************************************************************
                    fila = fila + 1
                    Dim a As New dAutorizaciones
                    Dim listaaut As New ArrayList
                    listaaut = a.listarxusuarioxfecha(usuario, fecdesde, fechasta)
                    If Not listaaut Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Pedidos de autorizaciones:"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        fila = fila + 1
                        For Each a In listaaut
                            Dim ta As New dTipoAutorizacion
                            Dim tipo As String = ""
                            ta.ID = a.TIPO
                            ta = ta.buscar
                            If Not ta Is Nothing Then
                                tipo = ta.NOMBRE
                            End If
                            x1hoja.Range("A" & fila, "E" & fila).Merge()
                            x1hoja.Cells(fila, columna).formula = a.FECHAEVENTO & " - " & tipo & " - " & a.DETALLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            fila = fila + 1
                            ta = Nothing
                            tipo = Nothing
                        Next
                    End If
                    a = Nothing
                    '**** NOTIFICACIONES ****************************************************************

                    Dim c As New dComunicaciones
                    Dim listanot As New ArrayList
                    listanot = c.listarxusuarioxfecha(usuario, fecdesde, fechasta)
                    If Not listanot Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Notificaciones:"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        fila = fila + 1
                        For Each c In listanot
                            x1hoja.Range("A" & fila, "E" & fila).Merge()
                            x1hoja.Cells(fila, columna).formula = c.FECHAEVENTO & " - " & c.DETALLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            fila = fila + 1
                        Next
                    End If
                    c = Nothing

                    '************************************************************************************

                    '*** LISTAR HORARIO ASIGNADO *****************************************************************
                    Dim tipomarca As String = ""
                    If usu.TIPOMARCA = 1 Then
                        tipomarca = "Corrido"
                    ElseIf usu.TIPOMARCA = 2 Then
                        tipomarca = "Cortado"
                    Else
                        tipomarca = "Rotativo"
                    End If
                    x1hoja.Cells(fila, columna).formula = "Horario establecido: " & tipomarca
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    fila = fila + 1
                    If usu.TIPOMARCA = 1 Then
                        x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                    ElseIf usu.TIPOMARCA = 2 Then
                        x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE & " / " & usu.ENTRAC & " - " & usu.SALEC
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2 & " / " & usu.ENTRAC2 & " - " & usu.SALEC2
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3 & " / " & usu.ENTRAC3 & " - " & usu.SALEC3
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4 & " / " & usu.ENTRAC4 & " - " & usu.SALEC4
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5 & " / " & usu.ENTRAC5 & " - " & usu.SALEC5
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6 & " / " & usu.ENTRAC6 & " - " & usu.SALEC6
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                    Else
                        x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE & " / " & usu.ENTRAR & " - " & usu.SALER
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2 & " / " & usu.ENTRAR2 & " - " & usu.SALER2
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3 & " / " & usu.ENTRAR3 & " - " & usu.SALER3
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4 & " / " & usu.ENTRAR4 & " - " & usu.SALER4
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5 & " / " & usu.ENTRAR5 & " - " & usu.SALER5
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6 & " / " & usu.ENTRAR6 & " - " & usu.SALER6
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                    End If
                    fila = fila + 2
                    x1hoja.Cells(fila, columna).formula = "A partir del lunes 22/6 se comienza a trabajar 8 hs"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    '********************************************************************************************
                Next
            End If
        End If




        x1app.Visible = True
        'x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub listartodos2()
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

        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")

        Dim fecdesde As String
        Dim fechasta As String
        Dim fecactual As String

        fecdesde = Format(fechadesde, "yyyy-MM-dd")
        fechasta = Format(fechahasta, "yyyy-MM-dd")


        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim usuario As Integer = 0
        Dim nombreusuario As String = ""
        Dim lista As New ArrayList
        Dim m As New dMarcas
        Dim listafechas As New ArrayList

        Dim usu As New dUsuario
        Dim listausuarios As New ArrayList
        listausuarios = usu.listar
        If Not listausuarios Is Nothing Then
            If listausuarios.Count > 0 Then
                For Each usu In listausuarios
                    usuario = usu.ID
                    nombreusuario = usu.NOMBRE
                    Dim fechaactual As Date = DateDesde.Value.ToString("yyyy-MM-dd")
                    lista = m.listarxusuario(usuario, fecdesde, fechasta)

                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then

                            Dim marca1 As Date
                            Dim marca2 As Date
                            Dim marca3 As Date
                            Dim marca4 As Date
                            Dim marca5 As Date
                            Dim marca6 As Date
                            Dim horas1 As TimeSpan
                            Dim horas2 As TimeSpan
                            Dim horas3 As TimeSpan
                            'Dim horasdia As TimeSpan
                            Dim horasacumuladas As Integer
                            Dim minutosacumulados As Long
                            Dim hora1 As Integer = 0
                            Dim hora2 As Integer = 0
                            Dim hora3 As Integer = 0
                            Dim minuto1 As Integer = 0
                            Dim minuto2 As Integer = 0
                            Dim minuto3 As Integer = 0
                            Dim sumahoras As Integer = 0
                            Dim sumaminutos As Integer = 0

                            x1hoja.Cells(1, 1).columnwidth = 20
                            x1hoja.Cells(1, 2).columnwidth = 20
                            x1hoja.Cells(1, 3).columnwidth = 20


                            If nombreusuario <> "" Then
                                x1hoja.Cells(fila, columna).formula = nombreusuario
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 12
                                fila = fila + 2
                            End If

                            Dim dia As Date
                            Dim _dia As String
                            Dim _dia2 As String
                            Dim contador As Integer = 0

                            For Each m In lista
                                Do While fechaactual <= fechahasta
                                    fecactual = Format(fechaactual, "yyyy-MM-dd")
                                    Dim m2 As New dMarcas
                                    Dim listadia As New ArrayList
                                    _dia = Format(fechaactual, "yyyy-MM-dd 00:00:00")
                                    _dia2 = Format(fechaactual, "yyyy-MM-dd 23:59:59")
                                    Dim cuentamarcas As Integer = 0
                                    Dim dia_texto As String = ""
                                    Dim diatexto As String = ""
                                    Dim fechadia As Date
                                    fechadia = dia
                                    dia_texto = fechaactual.DayOfWeek
                                    If dia_texto = "0" Then
                                        diatexto = "Domingo"
                                    ElseIf dia_texto = "1" Then
                                        diatexto = "Lunes"
                                    ElseIf dia_texto = "2" Then
                                        diatexto = "Martes"
                                    ElseIf dia_texto = "3" Then
                                        diatexto = "Miércoles"
                                    ElseIf dia_texto = "4" Then
                                        diatexto = "Jueves"
                                    ElseIf dia_texto = "5" Then
                                        diatexto = "Viernes"
                                    ElseIf dia_texto = "6" Then
                                        diatexto = "Sábado"
                                    End If
                                    Dim marcas As String = ""

                                    listadia = m2.listarxusuario2(usuario, _dia, _dia2)


                                    If Not listadia Is Nothing Then
                                        cuentamarcas = listadia.Count
                                        If listadia.Count > 0 Then

                                            contador = 1
                                            hora1 = 0
                                            hora2 = 0
                                            hora3 = 0
                                            minuto1 = 0
                                            minuto2 = 0
                                            minuto3 = 0
                                            For Each m2 In listadia
                                                If cuentamarcas = 2 Or cuentamarcas = 4 Or cuentamarcas = 6 Then
                                                    If cuentamarcas = 2 Then
                                                        If m2.TIPOMARCA = 1 Then
                                                            marca1 = m2.MARCA
                                                            marcas = marcas & Mid(marca1, 12, 8)
                                                        Else
                                                            marca2 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca2, 12, 8)
                                                        End If
                                                        If contador = 2 Then
                                                            horas1 = marca2 - marca1

                                                            hora1 = horas1.Hours
                                                            minuto1 = horas1.Minutes
                                                            sumahoras = sumahoras + hora1
                                                            sumaminutos = sumaminutos + minuto1
                                                            horasacumuladas = horasacumuladas + hora1 + hora2
                                                            minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                        End If

                                                    ElseIf cuentamarcas = 4 Then
                                                        If contador = 1 Then
                                                            marca1 = m2.MARCA
                                                            marcas = marcas & Mid(marca1, 12, 8)
                                                        ElseIf contador = 2 Then
                                                            marca2 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca2, 12, 8)
                                                        ElseIf contador = 3 Then
                                                            marca3 = m2.MARCA
                                                            marcas = marcas & " / " & Mid(marca3, 12, 8)
                                                        ElseIf contador = 4 Then
                                                            marca4 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca4, 12, 8)
                                                        End If
                                                        If contador = 2 Then
                                                            horas1 = marca2 - marca1
                                                        End If
                                                        If contador = 4 Then
                                                            horas2 = marca4 - marca3
                                                        End If

                                                        If contador = 2 Then
                                                            If cuentamarcas = 2 Then
                                                                hora1 = horas1.Hours
                                                                minuto1 = horas1.Minutes
                                                                sumahoras = sumahoras + hora1
                                                                sumaminutos = sumaminutos + minuto1
                                                                horasacumuladas = horasacumuladas + hora1 + hora2
                                                                minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                            Else
                                                                hora1 = horas1.Hours
                                                                minuto1 = horas1.Minutes
                                                                sumahoras = sumahoras + hora1
                                                                sumaminutos = sumaminutos + minuto1
                                                            End If
                                                        ElseIf contador = 4 Then
                                                            hora2 = horas2.Hours
                                                            minuto2 = horas2.Minutes
                                                            sumahoras = sumahoras + hora2
                                                            sumaminutos = sumaminutos + minuto2
                                                            horasacumuladas = horasacumuladas + hora1 + hora2
                                                            minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                        End If
                                                        '**************************************************************************
                                                        'si hay mas de 4 marcas
                                                    Else
                                                        If contador = 1 Then
                                                            marca1 = m2.MARCA
                                                            marcas = marcas & Mid(marca1, 12, 8)
                                                        ElseIf contador = 2 Then
                                                            marca2 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca2, 12, 8)
                                                        ElseIf contador = 3 Then
                                                            marca3 = m2.MARCA
                                                            marcas = marcas & " / " & Mid(marca3, 12, 8)
                                                        ElseIf contador = 4 Then
                                                            marca4 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca4, 12, 8)
                                                        ElseIf contador = 5 Then
                                                            marca5 = m2.MARCA
                                                            marcas = marcas & " / " & Mid(marca5, 12, 8)
                                                        ElseIf contador = 6 Then
                                                            marca6 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca6, 12, 8)
                                                        End If
                                                        If contador = 2 Then
                                                            horas1 = marca2 - marca1
                                                        End If
                                                        If contador = 4 Then
                                                            horas2 = marca4 - marca3
                                                        End If
                                                        If contador = 6 Then
                                                            horas3 = marca6 - marca5
                                                        End If

                                                        If contador = 2 Then
                                                            If cuentamarcas = 2 Then
                                                                hora1 = horas1.Hours
                                                                minuto1 = horas1.Minutes
                                                                sumahoras = sumahoras + hora1
                                                                sumaminutos = sumaminutos + minuto1
                                                                horasacumuladas = horasacumuladas + hora1 'hora1 + hora2
                                                                minutosacumulados = minutosacumulados + minuto1 'minuto1 + minuto2
                                                            Else
                                                                hora1 = horas1.Hours
                                                                minuto1 = horas1.Minutes
                                                                sumahoras = sumahoras + hora1
                                                                sumaminutos = sumaminutos + minuto1
                                                            End If
                                                        ElseIf contador = 4 Then
                                                            hora2 = horas2.Hours
                                                            minuto2 = horas2.Minutes
                                                            sumahoras = sumahoras + hora2
                                                            sumaminutos = sumaminutos + minuto2
                                                            horasacumuladas = horasacumuladas + hora1 + hora2
                                                            minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                        ElseIf contador = 6 Then
                                                            hora3 = horas3.Hours
                                                            minuto3 = horas3.Minutes
                                                            sumahoras = sumahoras + hora3
                                                            sumaminutos = sumaminutos + minuto3
                                                            horasacumuladas = horasacumuladas + hora3 'hora1 + hora2 + hora3
                                                            minutosacumulados = minutosacumulados + minuto3 'minuto1 + minuto2 + minuto3
                                                        End If

                                                        '**************************************************************************
                                                    End If
                                                Else
                                                    If contador = cuentamarcas Then
                                                        x1hoja.Cells(fila, columna).formula = diatexto
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = "FALTAN MARCAS"
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = 1
                                                        fila = fila + 1
                                                    End If
                                                End If

                                                If contador = 2 Then
                                                    If cuentamarcas = 2 Then
                                                        Dim calculahoras As Integer = 0
                                                        Dim calculaminutos As Integer = 0
                                                        Dim muestrohoras As Integer
                                                        Dim muestrominutos As Integer
                                                        If sumaminutos > 59 Then
                                                            calculahoras = sumaminutos \ 60
                                                            calculaminutos = sumaminutos Mod 60
                                                            muestrohoras = sumahoras + calculahoras
                                                            muestrominutos = calculaminutos
                                                        Else
                                                            muestrohoras = sumahoras
                                                            muestrominutos = sumaminutos
                                                        End If
                                                        x1hoja.Cells(fila, columna).formula = diatexto
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = muestrohoras & ":" & muestrominutos
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = marcas
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        fila = fila + 1
                                                        columna = 1
                                                        sumahoras = 0
                                                        sumaminutos = 0
                                                    End If
                                                ElseIf contador = 4 Then
                                                    If cuentamarcas = 4 Then
                                                        Dim calculahoras As Integer = 0
                                                        Dim calculaminutos As Integer = 0
                                                        Dim muestrohoras As Integer
                                                        Dim muestrominutos As Integer
                                                        If sumaminutos > 59 Then
                                                            calculahoras = sumaminutos \ 60
                                                            calculaminutos = sumaminutos Mod 60
                                                            muestrohoras = sumahoras + calculahoras
                                                            muestrominutos = calculaminutos
                                                        Else
                                                            muestrohoras = sumahoras
                                                            muestrominutos = sumaminutos
                                                        End If
                                                        x1hoja.Cells(fila, columna).formula = diatexto
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = muestrohoras & ":" & muestrominutos
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = marcas
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        fila = fila + 1
                                                        columna = 1
                                                        sumahoras = 0
                                                        sumaminutos = 0
                                                    End If
                                                    '***************************************************************************************
                                                ElseIf contador = 6 Then
                                                    If cuentamarcas = 6 Then
                                                        Dim calculahoras As Integer = 0
                                                        Dim calculaminutos As Integer = 0
                                                        Dim muestrohoras As Integer
                                                        Dim muestrominutos As Integer
                                                        If sumaminutos > 59 Then
                                                            calculahoras = sumaminutos \ 60
                                                            calculaminutos = sumaminutos Mod 60
                                                            muestrohoras = sumahoras + calculahoras
                                                            muestrominutos = calculaminutos
                                                        Else
                                                            muestrohoras = sumahoras
                                                            muestrominutos = sumaminutos
                                                        End If
                                                        x1hoja.Cells(fila, columna).formula = diatexto
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = muestrohoras & ":" & muestrominutos
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = marcas
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        fila = fila + 1
                                                        columna = 1
                                                        sumahoras = 0
                                                        sumaminutos = 0
                                                    End If
                                                    '***************************************************************************************
                                                End If
                                                contador = contador + 1
                                                If contador = 7 Then
                                                    contador = 0
                                                End If
                                            Next
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = diatexto
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                        columna = columna + 1
                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                        columna = columna + 1
                                        x1hoja.Cells(fila, columna).formula = "FALTA"
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                        columna = 1
                                        fila = fila + 1
                                    End If
                                    fechaactual = fechaactual.AddDays(+1)
                                Loop
                            Next
                            Dim calculahorastotal As Integer = 0
                            Dim calculaminutostotal As Integer = 0
                            Dim muestrohorastotal As Integer
                            Dim muestrominutostotal As Integer
                            If minutosacumulados > 59 Then
                                calculahorastotal = minutosacumulados \ 60
                                calculaminutostotal = minutosacumulados Mod 60
                                muestrohorastotal = horasacumuladas + calculahorastotal
                                muestrominutostotal = calculaminutostotal
                            Else
                                muestrohorastotal = horasacumuladas
                                muestrominutostotal = minutosacumulados
                            End If
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).formula = muestrohorastotal & ":" & muestrominutostotal
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)

                            '**** AUTORIZACIONES ****************************************************************

                            'Dim a As New dAutorizaciones
                            'Dim listaaut As New ArrayList
                            'listaaut = a.listarxusuarioxfecha(usuario, fecdesde, fechasta)
                            'If Not listaaut Is Nothing Then
                            '    fila = fila + 1
                            '    For Each a In listaaut
                            '        Dim ta As New dTipoAutorizacion
                            '        Dim tipo As String = ""
                            '        ta.ID = a.TIPO
                            '        ta = ta.buscar
                            '        If Not ta Is Nothing Then
                            '            tipo = ta.NOMBRE
                            '        End If
                            '        x1hoja.Cells(fila, columna).formula = a.FECHAEVENTO & " - " & tipo & " - " & a.DETALLE
                            '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '        x1hoja.Cells(fila, columna).Font.Bold = True
                            '        x1hoja.Cells(fila, columna).Font.Size = 10
                            '        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            '        fila = fila + 1
                            '        ta = Nothing
                            '        tipo = Nothing
                            '    Next
                            'End If
                            'a = Nothing
                            '**** NOTIFICACIONES ****************************************************************

                            'Dim c As New dComunicaciones
                            'Dim listanot As New ArrayList
                            'listanot = c.listarxusuarioxfecha(usuario, fecdesde, fechasta)
                            'If Not listanot Is Nothing Then
                            '    fila = fila + 1
                            '    For Each c In listanot
                            '        x1hoja.Cells(fila, columna).formula = c.FECHAEVENTO & " - " & c.DETALLE
                            '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            '        x1hoja.Cells(fila, columna).Font.Bold = True
                            '        x1hoja.Cells(fila, columna).Font.Size = 10
                            '        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            '        fila = fila + 1
                            '    Next
                            'End If
                            'c = Nothing

                            '************************************************************************************
                            horasacumuladas = 0
                            minutosacumulados = 0
                            fila = fila + 2
                            '**** AUTORIZACIONES ****************************************************************
                            'fila = fila + 1
                            Dim a As New dAutorizaciones
                            Dim listaaut As New ArrayList
                            listaaut = a.listarxusuarioxfecha(usuario, fecdesde, fechasta)
                            If Not listaaut Is Nothing Then
                                'fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Pedidos de autorizaciones:"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                fila = fila + 1
                                For Each a In listaaut
                                    Dim ta As New dTipoAutorizacion
                                    Dim tipo As String = ""
                                    ta.ID = a.TIPO
                                    ta = ta.buscar
                                    If Not ta Is Nothing Then
                                        tipo = ta.NOMBRE
                                    End If
                                    x1hoja.Range("A" & fila, "E" & fila).Merge()
                                    x1hoja.Cells(fila, columna).formula = a.FECHAEVENTO & " - " & tipo & " - " & a.DETALLE
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    fila = fila + 1
                                    ta = Nothing
                                    tipo = Nothing
                                Next
                            End If
                            a = Nothing
                            '**** NOTIFICACIONES ****************************************************************

                            Dim c As New dComunicaciones
                            Dim listanot As New ArrayList
                            listanot = c.listarxusuarioxfecha(usuario, fecdesde, fechasta)
                            If Not listanot Is Nothing Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Notificaciones:"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                fila = fila + 1
                                For Each c In listanot
                                    x1hoja.Range("A" & fila, "E" & fila).Merge()
                                    x1hoja.Cells(fila, columna).formula = c.FECHAEVENTO & " - " & c.DETALLE
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    fila = fila + 1
                                Next
                            End If
                            c = Nothing

                            '************************************************************************************
                            '*** LISTAR HORARIO ASIGNADO ****************************************************************
                            Dim tipomarca As String = ""
                            If usu.TIPOMARCA = 1 Then
                                tipomarca = "Corrido"
                            ElseIf usu.TIPOMARCA = 2 Then
                                tipomarca = "Cortado"
                            Else
                                tipomarca = "Rotativo"
                            End If
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).formula = "Horario establecido: " & tipomarca
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            fila = fila + 1
                            If usu.TIPOMARCA = 1 Then
                                x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                            ElseIf usu.TIPOMARCA = 2 Then
                                x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE & " / " & usu.ENTRAC & " - " & usu.SALEC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2 & " / " & usu.ENTRAC2 & " - " & usu.SALEC2
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3 & " / " & usu.ENTRAC3 & " - " & usu.SALEC3
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4 & " / " & usu.ENTRAC4 & " - " & usu.SALEC4
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5 & " / " & usu.ENTRAC5 & " - " & usu.SALEC5
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6 & " / " & usu.ENTRAC6 & " - " & usu.SALEC6
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                            Else
                                x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE & " / " & usu.ENTRAR & " - " & usu.SALER
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2 & " / " & usu.ENTRAR2 & " - " & usu.SALER2
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3 & " / " & usu.ENTRAR3 & " - " & usu.SALER3
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4 & " / " & usu.ENTRAR4 & " - " & usu.SALER4
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5 & " / " & usu.ENTRAR5 & " - " & usu.SALER5
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6 & " / " & usu.ENTRAR6 & " - " & usu.SALER6
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                            End If
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).formula = "A partir del lunes 22/6 se comienza a trabajar 8 hs"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            '********************************************************************************************
                            fila = fila + 2
                        End If
                    End If
                Next
            End If
        End If


        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub listartodos_BD()
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
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(fechadesde, "yyyy-MM-dd")
        fechasta = Format(fechahasta, "yyyy-MM-dd")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim usuario As Integer = 0
        Dim nombreusuario As String = ""
        Dim lista As New ArrayList
        Dim m As New dMarcas
        Dim listafechas As New ArrayList
        Dim usu As New dUsuario
        Dim listausuarios As New ArrayList
        listausuarios = usu.listar
        If Not listausuarios Is Nothing Then
            If listausuarios.Count > 0 Then
                For Each usu In listausuarios
                    usuario = usu.ID
                    nombreusuario = usu.NOMBRE
                    Dim fechaactual As Date = DateDesde.Value.ToString("yyyy-MM-dd")
                    lista = m.listarxusuario_bd(usuario, fecdesde, fechasta)
                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            x1hoja.Cells(1, 1).columnwidth = 20
                            x1hoja.Cells(1, 2).columnwidth = 20
                            x1hoja.Cells(1, 3).columnwidth = 20
                            If nombreusuario <> "" Then
                                x1hoja.Cells(fila, columna).formula = nombreusuario
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 12
                                fila = fila + 2
                            End If
                            For Each m In lista
                                x1hoja.Cells(fila, columna).formula = m.MARCA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                If m.TIPOMARCA = 0 Then
                                    x1hoja.Cells(fila, columna).formula = "salida"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = 1
                                    fila = fila + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "entrada"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = 1
                                    fila = fila + 1
                                End If
                                'x1hoja.Cells(fila, columna).formula = m.TIPOMARCA
                                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                'x1hoja.Cells(fila, columna).Font.Bold = False
                                'x1hoja.Cells(fila, columna).Font.Size = 10
                                'x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                'columna = 1
                                'fila = fila + 1
                            Next
                        End If
                    End If
                    fila = fila + 2
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub listarindividual_BD()
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
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(fechadesde, "yyyy-MM-dd")
        fechasta = Format(fechahasta, "yyyy-MM-dd")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim usuario As Integer = 0
        Dim nombreusuario As String = ""
        Dim lista As New ArrayList
        Dim m As New dMarcas
        Dim listafechas As New ArrayList
        Dim usu As New dUsuario
        Dim dusu As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
        Dim idusuario As Integer = dusu.ID
        nombreusuario = dusu.NOMBRE
        Dim fechaactual As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        lista = m.listarxusuario_bd(idusuario, fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                x1hoja.Cells(1, 1).columnwidth = 20
                x1hoja.Cells(1, 2).columnwidth = 20
                x1hoja.Cells(1, 3).columnwidth = 20
                If nombreusuario <> "" Then
                    x1hoja.Cells(fila, columna).formula = nombreusuario
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 12
                    fila = fila + 2
                End If
                For Each m In lista
                    x1hoja.Cells(fila, columna).formula = m.MARCA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    If m.TIPOMARCA = 0 Then
                        x1hoja.Cells(fila, columna).formula = "salida"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "entrada"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If
                    'x1hoja.Cells(fila, columna).formula = m.TIPOMARCA
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 10
                    'x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    'columna = 1
                    'fila = fila + 1
                Next
            End If
        End If

        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub listarindividual()
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

        Dim dusu As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
        Dim idusuario As Integer = dusu.ID

        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")

        Dim fecdesde As String
        Dim fechasta As String
        Dim fecactual As String

        fecdesde = Format(fechadesde, "yyyy-MM-dd")
        fechasta = Format(fechahasta, "yyyy-MM-dd")


        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim usuario As Integer = 0
        Dim nombreusuario As String = ""
        Dim lista As New ArrayList
        Dim m As New dMarcas
        Dim listafechas As New ArrayList

        Dim usu As New dUsuario
        Dim listausuarios As New ArrayList
        listausuarios = usu.listar2(idusuario)
        If Not listausuarios Is Nothing Then
            If listausuarios.Count > 0 Then
                For Each usu In listausuarios
                    usuario = usu.ID
                    nombreusuario = usu.NOMBRE
                    Dim fechaactual As Date = DateDesde.Value.ToString("yyyy-MM-dd")
                    lista = m.listarxusuario(usuario, fecdesde, fechasta)

                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then

                            Dim marca1 As Date
                            Dim marca2 As Date
                            Dim marca3 As Date
                            Dim marca4 As Date
                            Dim marca5 As Date
                            Dim marca6 As Date
                            Dim horas1 As TimeSpan
                            Dim horas2 As TimeSpan
                            Dim horas3 As TimeSpan
                            'Dim horasdia As TimeSpan
                            Dim horasacumuladas As Integer
                            Dim minutosacumulados As Long
                            Dim hora1 As Integer = 0
                            Dim hora2 As Integer = 0
                            Dim hora3 As Integer = 0
                            Dim minuto1 As Integer = 0
                            Dim minuto2 As Integer = 0
                            Dim minuto3 As Integer = 0
                            Dim sumahoras As Integer = 0
                            Dim sumaminutos As Integer = 0

                            x1hoja.Cells(1, 1).columnwidth = 20
                            x1hoja.Cells(1, 2).columnwidth = 20
                            x1hoja.Cells(1, 3).columnwidth = 20


                            If nombreusuario <> "" Then
                                x1hoja.Cells(fila, columna).formula = nombreusuario
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 12
                                fila = fila + 2
                            End If

                            Dim dia As Date
                            Dim _dia As String
                            Dim _dia2 As String
                            Dim contador As Integer = 0

                            For Each m In lista
                                Do While fechaactual <= fechahasta
                                    fecactual = Format(fechaactual, "yyyy-MM-dd")
                                    Dim m2 As New dMarcas
                                    Dim listadia As New ArrayList
                                    _dia = Format(fechaactual, "yyyy-MM-dd 00:00:00")
                                    _dia2 = Format(fechaactual, "yyyy-MM-dd 23:59:59")
                                    Dim cuentamarcas As Integer = 0
                                    Dim dia_texto As String = ""
                                    Dim diatexto As String = ""
                                    Dim fechadia As Date
                                    fechadia = dia
                                    dia_texto = fechaactual.DayOfWeek
                                    If dia_texto = "0" Then
                                        diatexto = "Domingo"
                                    ElseIf dia_texto = "1" Then
                                        diatexto = "Lunes"
                                    ElseIf dia_texto = "2" Then
                                        diatexto = "Martes"
                                    ElseIf dia_texto = "3" Then
                                        diatexto = "Miércoles"
                                    ElseIf dia_texto = "4" Then
                                        diatexto = "Jueves"
                                    ElseIf dia_texto = "5" Then
                                        diatexto = "Viernes"
                                    ElseIf dia_texto = "6" Then
                                        diatexto = "Sábado"
                                    End If
                                    Dim marcas As String = ""

                                    listadia = m2.listarxusuario2(usuario, _dia, _dia2)


                                    If Not listadia Is Nothing Then
                                        cuentamarcas = listadia.Count
                                        If listadia.Count > 0 Then

                                            contador = 1
                                            hora1 = 0
                                            hora2 = 0
                                            hora3 = 0
                                            minuto1 = 0
                                            minuto2 = 0
                                            minuto3 = 0
                                            For Each m2 In listadia
                                                If cuentamarcas = 2 Or cuentamarcas = 4 Or cuentamarcas = 6 Then
                                                    If cuentamarcas = 2 Then
                                                        If m2.TIPOMARCA = 1 Then
                                                            marca1 = m2.MARCA
                                                            marcas = marcas & Mid(marca1, 12, 8)
                                                        Else
                                                            marca2 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca2, 12, 8)
                                                        End If
                                                        If contador = 2 Then
                                                            horas1 = marca2 - marca1

                                                            hora1 = horas1.Hours
                                                            minuto1 = horas1.Minutes
                                                            sumahoras = sumahoras + hora1
                                                            sumaminutos = sumaminutos + minuto1
                                                            horasacumuladas = horasacumuladas + hora1 + hora2
                                                            minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                        End If

                                                    ElseIf cuentamarcas = 4 Then
                                                        If contador = 1 Then
                                                            marca1 = m2.MARCA
                                                            marcas = marcas & Mid(marca1, 12, 8)
                                                        ElseIf contador = 2 Then
                                                            marca2 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca2, 12, 8)
                                                        ElseIf contador = 3 Then
                                                            marca3 = m2.MARCA
                                                            marcas = marcas & " / " & Mid(marca3, 12, 8)
                                                        ElseIf contador = 4 Then
                                                            marca4 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca4, 12, 8)
                                                        End If
                                                        If contador = 2 Then
                                                            horas1 = marca2 - marca1
                                                        End If
                                                        If contador = 4 Then
                                                            horas2 = marca4 - marca3
                                                        End If

                                                        If contador = 2 Then
                                                            If cuentamarcas = 2 Then
                                                                hora1 = horas1.Hours
                                                                minuto1 = horas1.Minutes
                                                                sumahoras = sumahoras + hora1
                                                                sumaminutos = sumaminutos + minuto1
                                                                horasacumuladas = horasacumuladas + hora1 + hora2
                                                                minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                            Else
                                                                hora1 = horas1.Hours
                                                                minuto1 = horas1.Minutes
                                                                sumahoras = sumahoras + hora1
                                                                sumaminutos = sumaminutos + minuto1
                                                            End If
                                                        ElseIf contador = 4 Then
                                                            hora2 = horas2.Hours
                                                            minuto2 = horas2.Minutes
                                                            sumahoras = sumahoras + hora2
                                                            sumaminutos = sumaminutos + minuto2
                                                            horasacumuladas = horasacumuladas + hora1 + hora2
                                                            minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                        End If
                                                        '**************************************************************************
                                                        'si hay mas de 4 marcas
                                                    Else
                                                        If contador = 1 Then
                                                            marca1 = m2.MARCA
                                                            marcas = marcas & Mid(marca1, 12, 8)
                                                        ElseIf contador = 2 Then
                                                            marca2 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca2, 12, 8)
                                                        ElseIf contador = 3 Then
                                                            marca3 = m2.MARCA
                                                            marcas = marcas & " / " & Mid(marca3, 12, 8)
                                                        ElseIf contador = 4 Then
                                                            marca4 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca4, 12, 8)
                                                        ElseIf contador = 5 Then
                                                            marca5 = m2.MARCA
                                                            marcas = marcas & " / " & Mid(marca5, 12, 8)
                                                        ElseIf contador = 6 Then
                                                            marca6 = m2.MARCA
                                                            marcas = marcas & " - " & Mid(marca6, 12, 8)
                                                        End If
                                                        If contador = 2 Then
                                                            horas1 = marca2 - marca1
                                                        End If
                                                        If contador = 4 Then
                                                            horas2 = marca4 - marca3
                                                        End If
                                                        If contador = 6 Then
                                                            horas3 = marca6 - marca5
                                                        End If

                                                        If contador = 2 Then
                                                            If cuentamarcas = 2 Then
                                                                hora1 = horas1.Hours
                                                                minuto1 = horas1.Minutes
                                                                sumahoras = sumahoras + hora1
                                                                sumaminutos = sumaminutos + minuto1
                                                                horasacumuladas = horasacumuladas + hora1 'hora1 + hora2
                                                                minutosacumulados = minutosacumulados + minuto1 'minuto1 + minuto2
                                                            Else
                                                                hora1 = horas1.Hours
                                                                minuto1 = horas1.Minutes
                                                                sumahoras = sumahoras + hora1
                                                                sumaminutos = sumaminutos + minuto1
                                                            End If
                                                        ElseIf contador = 4 Then
                                                            hora2 = horas2.Hours
                                                            minuto2 = horas2.Minutes
                                                            sumahoras = sumahoras + hora2
                                                            sumaminutos = sumaminutos + minuto2
                                                            horasacumuladas = horasacumuladas + hora1 + hora2
                                                            minutosacumulados = minutosacumulados + minuto1 + minuto2
                                                        ElseIf contador = 6 Then
                                                            hora3 = horas3.Hours
                                                            minuto3 = horas3.Minutes
                                                            sumahoras = sumahoras + hora3
                                                            sumaminutos = sumaminutos + minuto3
                                                            horasacumuladas = horasacumuladas + hora3 'hora1 + hora2 + hora3
                                                            minutosacumulados = minutosacumulados + minuto3 'minuto1 + minuto2 + minuto3
                                                        End If

                                                        '**************************************************************************
                                                    End If
                                                Else
                                                    If contador = cuentamarcas Then
                                                        x1hoja.Cells(fila, columna).formula = diatexto
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = "FALTAN MARCAS"
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = 1
                                                        fila = fila + 1
                                                    End If
                                                End If

                                                If contador = 2 Then
                                                    If cuentamarcas = 2 Then
                                                        Dim calculahoras As Integer = 0
                                                        Dim calculaminutos As Integer = 0
                                                        Dim muestrohoras As Integer
                                                        Dim muestrominutos As Integer
                                                        If sumaminutos > 59 Then
                                                            calculahoras = sumaminutos \ 60
                                                            calculaminutos = sumaminutos Mod 60
                                                            muestrohoras = sumahoras + calculahoras
                                                            muestrominutos = calculaminutos
                                                        Else
                                                            muestrohoras = sumahoras
                                                            muestrominutos = sumaminutos
                                                        End If
                                                        x1hoja.Cells(fila, columna).formula = diatexto
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = muestrohoras & ":" & muestrominutos
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = marcas
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        fila = fila + 1
                                                        columna = 1
                                                        sumahoras = 0
                                                        sumaminutos = 0
                                                    End If
                                                ElseIf contador = 4 Then
                                                    If cuentamarcas = 4 Then
                                                        Dim calculahoras As Integer = 0
                                                        Dim calculaminutos As Integer = 0
                                                        Dim muestrohoras As Integer
                                                        Dim muestrominutos As Integer
                                                        Dim diferenciaMinDia As Integer = 0
                                                        Dim horarioEntrada As String
                                                        Dim horarioSalida As String
                                                        horarioEntrada = horarioEntrada & Mid(usu.ENTRA, 12, 8)

                                                        If sumaminutos > 59 Then
                                                            calculahoras = sumaminutos \ 60
                                                            calculaminutos = sumaminutos Mod 60
                                                            muestrohoras = sumahoras + calculahoras
                                                            muestrominutos = calculaminutos
                                                        Else
                                                            muestrohoras = sumahoras
                                                            muestrominutos = sumaminutos
                                                        End If



                                                        x1hoja.Cells(fila, columna).formula = diatexto
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = muestrohoras & ":" & muestrominutos
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = marcas
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        fila = fila + 1
                                                        columna = 1
                                                        sumahoras = 0
                                                        sumaminutos = 0
                                                    End If
                                                    '***************************************************************************************
                                                ElseIf contador = 6 Then
                                                    If cuentamarcas = 6 Then
                                                        Dim calculahoras As Integer = 0
                                                        Dim calculaminutos As Integer = 0
                                                        Dim muestrohoras As Integer
                                                        Dim muestrominutos As Integer
                                                        If sumaminutos > 59 Then
                                                            calculahoras = sumaminutos \ 60
                                                            calculaminutos = sumaminutos Mod 60
                                                            muestrohoras = sumahoras + calculahoras
                                                            muestrominutos = calculaminutos
                                                        Else
                                                            muestrohoras = sumahoras
                                                            muestrominutos = sumaminutos
                                                        End If
                                                        x1hoja.Cells(fila, columna).formula = diatexto
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = muestrohoras & ":" & muestrominutos
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        columna = columna + 1
                                                        x1hoja.Cells(fila, columna).formula = marcas
                                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                                        fila = fila + 1
                                                        columna = 1
                                                        sumahoras = 0
                                                        sumaminutos = 0
                                                    End If
                                                    '***************************************************************************************
                                                End If
                                                contador = contador + 1
                                                If contador = 7 Then
                                                    contador = 0
                                                End If
                                            Next
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = diatexto
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                        columna = columna + 1
                                        x1hoja.Cells(fila, columna).formula = fechaactual
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                        columna = columna + 1
                                        x1hoja.Cells(fila, columna).formula = "FALTA"
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                        columna = 1
                                        fila = fila + 1
                                    End If
                                    fechaactual = fechaactual.AddDays(+1)
                                Loop
                            Next
                            Dim calculahorastotal As Integer = 0
                            Dim calculaminutostotal As Integer = 0
                            Dim muestrohorastotal As Integer
                            Dim muestrominutostotal As Integer
                            If minutosacumulados > 59 Then
                                calculahorastotal = minutosacumulados \ 60
                                calculaminutostotal = minutosacumulados Mod 60
                                muestrohorastotal = horasacumuladas + calculahorastotal
                                muestrominutostotal = calculaminutostotal
                            Else
                                muestrohorastotal = horasacumuladas
                                muestrominutostotal = minutosacumulados
                            End If
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).formula = muestrohorastotal & ":" & muestrominutostotal
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)

                            '**** AUTORIZACIONES ****************************************************************
                            fila = fila + 1
                            Dim a As New dAutorizaciones
                            Dim listaaut As New ArrayList
                            listaaut = a.listarxusuarioxfecha(usuario, fecdesde, fechasta)
                            If Not listaaut Is Nothing Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Pedidos de autorizaciones:"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                fila = fila + 1
                                For Each a In listaaut
                                    Dim ta As New dTipoAutorizacion
                                    Dim tipo As String = ""
                                    ta.ID = a.TIPO
                                    ta = ta.buscar
                                    If Not ta Is Nothing Then
                                        tipo = ta.NOMBRE
                                    End If
                                    x1hoja.Range("A" & fila, "E" & fila).Merge()
                                    x1hoja.Cells(fila, columna).formula = a.FECHAEVENTO & " - " & tipo & " - " & a.DETALLE
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    fila = fila + 1
                                    ta = Nothing
                                    tipo = Nothing
                                Next
                            End If
                            a = Nothing
                            '**** NOTIFICACIONES ****************************************************************

                            Dim c As New dComunicaciones
                            Dim listanot As New ArrayList
                            listanot = c.listarxusuarioxfecha(usuario, fecdesde, fechasta)
                            If Not listanot Is Nothing Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).formula = "Notificaciones:"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                fila = fila + 1
                                For Each c In listanot
                                    x1hoja.Range("A" & fila, "E" & fila).Merge()
                                    x1hoja.Cells(fila, columna).formula = c.FECHAEVENTO & " - " & c.DETALLE
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    fila = fila + 1
                                Next
                            End If
                            c = Nothing

                            '************************************************************************************
                            horasacumuladas = 0
                            minutosacumulados = 0
                            fila = fila + 2
                        End If
                    End If
                Next
                fila = fila - 1
                Dim tipomarca As String = ""
                If usu.TIPOMARCA = 1 Then
                    tipomarca = "Corrido"
                ElseIf usu.TIPOMARCA = 2 Then
                    tipomarca = "Cortado"
                Else
                    tipomarca = "Rotativo"
                End If
                x1hoja.Cells(fila, columna).formula = "Horario establecido: " & tipomarca
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                fila = fila + 1
                If usu.TIPOMARCA = 1 Then
                    x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                ElseIf usu.TIPOMARCA = 2 Then
                    x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE & " / " & usu.ENTRAC & " - " & usu.SALEC
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2 & " / " & usu.ENTRAC2 & " - " & usu.SALEC2
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3 & " / " & usu.ENTRAC3 & " - " & usu.SALEC3
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4 & " / " & usu.ENTRAC4 & " - " & usu.SALEC4
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5 & " / " & usu.ENTRAC5 & " - " & usu.SALEC5
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6 & " / " & usu.ENTRAC6 & " - " & usu.SALEC6
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                Else
                    x1hoja.Cells(fila, columna).formula = "Lunes - " & usu.ENTRA & " - " & usu.SALE & " / " & usu.ENTRAR & " - " & usu.SALER
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Martes - " & usu.ENTRA2 & " - " & usu.SALE2 & " / " & usu.ENTRAR2 & " - " & usu.SALER2
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Miércoles - " & usu.ENTRA3 & " - " & usu.SALE3 & " / " & usu.ENTRAR3 & " - " & usu.SALER3
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Jueves - " & usu.ENTRA4 & " - " & usu.SALE4 & " / " & usu.ENTRAR4 & " - " & usu.SALER4
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Viernes - " & usu.ENTRA5 & " - " & usu.SALE5 & " / " & usu.ENTRAR5 & " - " & usu.SALER5
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "Sábado - " & usu.ENTRA6 & " - " & usu.SALE6 & " / " & usu.ENTRAR6 & " - " & usu.SALER6
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                End If
                fila = fila + 2
                x1hoja.Cells(fila, columna).formula = "A partir del lunes 22/6 se comienza a trabajar 8 hs"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
            End If
        End If


        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub listarautorizaciones()
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

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 20
        x1hoja.Cells(1, 4).columnwidth = 70
        x1hoja.Cells(1, 5).columnwidth = 10
        x1hoja.Cells(1, 6).columnwidth = 20
        x1hoja.Cells(1, 7).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1
        '*** LISTA DE PEDIDOS DE AUTORIZACIONES ********************************************************
        Dim a As New dAutorizaciones
        Dim listaau As New ArrayList
        listaau = a.listar
        For Each a In listaau
            x1hoja.Cells(fila, columna).formula = a.FECHA
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            columna = columna + 1
            Dim u As New dUsuario
            u.ID = a.IDUSUARIO
            u = u.buscar
            x1hoja.Cells(fila, columna).formula = u.NOMBRE
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            columna = columna + 1
            Dim t As New dTipoAutorizacion
            t.ID = a.TIPO
            t = t.buscar
            x1hoja.Cells(fila, columna).formula = t.NOMBRE
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).formula = a.DETALLE
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            columna = columna + 1
            If a.AUTORIZADA = 0 Then
                x1hoja.Cells(fila, columna).formula = "No autorizada"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                columna = columna + 1
            Else
                x1hoja.Cells(fila, columna).formula = "Autorizada"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                columna = columna + 1
            End If
            Dim us As New dUsuario
            us.ID = a.AUTORIZA
            us = us.buscar
            If Not us Is Nothing Then
                x1hoja.Cells(fila, columna).formula = us.NOMBRE
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                columna = columna + 1
            Else
                x1hoja.Cells(fila, columna).formula = ""
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                columna = columna + 1
            End If
            x1hoja.Cells(fila, columna).formula = a.OBSERVACIONES
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            columna = 1
            fila = fila + 1
        Next
        '***********************************************************************************************
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listartodos2()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listarautorizaciones()
    End Sub

    Private Sub RadioTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTodos.CheckedChanged
        validar()
    End Sub
    Private Sub validar()
        If RadioTodos.Checked = True Then
            ComboUsuarios.Enabled = False
        Else
            ComboUsuarios.Enabled = True
        End If
    End Sub

    Private Sub RadioIndividual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioIndividual.CheckedChanged
        validar()
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioTodos.Checked = True Then
            listartodos_BD()
        Else
            listarindividual_BD()
        End If
    End Sub
End Class